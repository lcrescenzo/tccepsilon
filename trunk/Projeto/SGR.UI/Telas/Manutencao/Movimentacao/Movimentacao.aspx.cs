using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using SGR.BP.Objeto;
using System.Collections.Generic;
using SGR.BP.Objeto.Filtro;
using SGR.Web.Controls.Common;
using System.Globalization;

public partial class Telas_Manutencao_Movimentacao_Movimentacao : PageLogedBase
{
    #region Atributos
    private const int _quantidadeTransportes = 60;
    
    private Movimentacao _movimentacao;
    private Transporte _tranporte;
    #endregion

    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        AtacharEventos();
        Inicializar();
    }

    void Confirm_Acao(RetornoConfirm retorno)
    {
        if (retorno == RetornoConfirm.Sim)
        {
            if (ViewState["idExcluir"] == null)
            {
                GravarMovimentacao();
            }
            else
            {
                ApagarTransporte((int)ViewState["idExcluir"]);
                
            } 
            CarregarMovimentacao(MovimentacaoSelecionada);
        }
       
    }

    
    protected void ddlResiduo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlResiduo.SelectedValue != string.Empty)
        {
            CarregarCadri(CADRI.Lista(new Residuo(int.Parse(ddlResiduo.SelectedValue), false)));
        }
        else 
        {
            CarregarCadri();
        }
        ValidarMovimentacao();
    }

    protected void ddlCadri_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCadri.SelectedValue != string.Empty)
        {
            CarregarResiduo(Residuo.Lista(new CADRI(int.Parse(ddlCadri.SelectedValue), false)));
        }
        else
        {
            CarregarResiduo();
        }
        ValidarMovimentacao();
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {
        GravarTransporte();
    }

    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            ImageButton imgEditar = (ImageButton)e.Row.FindControl("imgEditar");
            ImageButton imgExcluir = (ImageButton)e.Row.FindControl("imgExcluir");
            imgEditar.CommandArgument =
            imgExcluir.CommandArgument = ((Transporte)e.Row.DataItem).ID.ToString();
        }
    }

    protected void imgExcluir_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
    {
        ConfirmaExcluirTransporte(int.Parse(e.CommandArgument.ToString()));
    }

    protected void imgEditar_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
    {
        EditarTransporte(int.Parse(e.CommandArgument.ToString()));
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        if (Manutencao == ETipoManutencao.Alteracao)
        {
            TransporteSelecionado = null;
            Manutencao = ETipoManutencao.Inclusao;
            LimparTransporte();
            txtData.Enabled = true;
            txtData.Text = DateTime.Now.ToString(Util.Formatacao.Data.ShortDatePattern);
        }
    }
    #endregion

    #region Propriedades

    public Movimentacao MovimentacaoSelecionada
    {
        get 
        {
            if (_movimentacao == null)
            {
                if(ViewState["idMovimentacao"] != null)
                    _movimentacao = new Movimentacao((int)ViewState["idMovimentacao"]);
            }
            return _movimentacao; 
        }
        set 
        {
             _movimentacao = value;
             if (value == null)
                 ViewState["idMovimentacao"] = null;

             ViewState["idMovimentacao"] = value.ID;
        }
    }

    public ETipoManutencao Manutencao
    {
        get 
        {
            if (ViewState["Manutencao"] == null)
                return ETipoManutencao.Inclusao;

            return (ETipoManutencao)ViewState["Manutencao"]; 
        }
        set { ViewState["Manutencao"] = (int)value; }
    }

    public Transporte TransporteSelecionado
    {
        get
        {
            if (ViewState["idTransporte"] == null)
                return null;

            _tranporte = new Transporte((int)ViewState["idTransporte"]);

            return _tranporte;
        }
        set
        {
            if (value == null)
                ViewState["idTransporte"] = null;
            else
                ViewState["idTransporte"] = value.ID;
            
            _tranporte = value;
        }
    }

    #endregion

    #region Metodos
    private void AtacharEventos()
    {
        Confirm.Acao += new Confirm.OnAcao(Confirm_Acao);
    }

    private void GravarMovimentacao()
    {
        Movimentacao novaMovimentacao = new Movimentacao();
        novaMovimentacao.CADRI = new CADRI(int.Parse(ddlCadri.SelectedValue), false);
        novaMovimentacao.Login = base.UsuarioLogado;
        novaMovimentacao.Residuo = new Residuo(int.Parse(ddlResiduo.SelectedValue), false);
        novaMovimentacao.Inserir();
        _movimentacao = novaMovimentacao;
    }

    private void ValidarMovimentacao()
    {
        if (ddlCadri.SelectedValue != string.Empty && ddlResiduo.SelectedValue != string.Empty)
        {
            Movimentacao movimentacao = Movimentacao.Carregar(new CADRI(int.Parse(ddlCadri.SelectedValue), false), new Residuo(int.Parse(ddlResiduo.SelectedValue),false ));
            if (movimentacao == null)
            {
                pnlNovoTransporte.Visible = false;
                Confirm.Mostrar("Não existe nenhuma movimentação com o resíduo \"" + ddlResiduo.SelectedItem.Text + "\" com o CADRI de número \"" + ddlCadri.SelectedItem.Text + "\", deseja criar esta relação?");
            }
            else
            {
                MovimentacaoSelecionada = movimentacao;
                CarregarMovimentacao(movimentacao);
            }
        }
    }

    private void CarregarMovimentacao(Movimentacao movimentacao)
    {
        gdvUtimosTransportes.DataSource = movimentacao.CarregarUltimosTransportes(_quantidadeTransportes);
        gdvUtimosTransportes.DataBind();
        pnlNovoTransporte.Visible = true;
        CarregarTelaTransporte();
    }

    private void CarregarTelaTransporte()
    {
        Residuo residuo = null;
        CADRI cadri = null;

        if (ddlResiduo.SelectedValue != string.Empty)
        {
            residuo = new Residuo(int.Parse(ddlResiduo.SelectedValue));
            lblUnidadeMedida.Text = residuo.UnidadeMedida;
        }

        if (ddlCadri.SelectedValue != string.Empty)
        {
            cadri = new CADRI(int.Parse(ddlCadri.SelectedValue));
            lblPermitido.Text = cadri.Quantidade.ToString("#0,00", Util.Formatacao.Numero) + " " + lblUnidadeMedida.Text;
        }

        MovimentacaoSelecionada = Movimentacao.Carregar(cadri, residuo);
        
        double transportados = 0.0;
        foreach(Transporte item in MovimentacaoSelecionada.Transportes)
        {
            transportados += item.Quantidade;
        }
        txtData.Text = DateTime.Now.ToString(Util.Formatacao.Data.ShortDatePattern);
        lblTransportados.Text = transportados.ToString("#0.00", Util.Formatacao.Numero) + " " + lblUnidadeMedida.Text;
        CriaCampoNumerico(transportados, cadri.Quantidade);
    }

    private void Inicializar()
    {
        if (!IsPostBack)
        {
            Configurar();
            CarregarDropDown();
            
        }
    }

    private void Configurar()
    {
        Calendar1.Format = Util.Formatacao.Data.ShortDatePattern;
    }

    private void CriaCampoNumerico(double transportados, double permitidos)
    {
        double percentualCritico = double.Parse(base.ConfiguracaoUsuario["Home.Movimentacao"], Util.Formatacao.Numero);
        NumberFormatInfo format = new CultureInfo("en-us").NumberFormat;
        txtQuantidade.Attributes.Add("onkeypress", "return ValidarKeyPressNumeric(this, '" + Util.Formatacao.Numero.CurrencyDecimalSeparator + "', 2);");
        txtQuantidade.Attributes.Add("onkeyup", "ValidarQuantidade(this, " + transportados.ToString("#0.00", format) + " , " + permitidos.ToString("#0.00", format) + ",  " + percentualCritico.ToString("#0.00", format) + ")");
    }

    private void CarregarCadri()
    {
        ddlCadri.DataSource = CADRI.Lista(new FiltroCADRI());
        ddlCadri.DataBind();
        Util.Telas.AdicionaItemBranco(ddlCadri);
    }

    private void CarregarResiduo()
    {
        ddlResiduo.DataSource = Residuo.Lista(new FiltroResiduo());
        ddlResiduo.DataBind();
        Util.Telas.AdicionaItemBranco(ddlResiduo);
    }

    private void CarregarResiduo(List<Residuo> lista)
    {
        string value = ddlResiduo.SelectedValue;
        ddlResiduo.DataSource = lista;
        ddlResiduo.DataBind();
        Util.Telas.AdicionaItemBranco(ddlResiduo);
        MantemItemSelecionado(ddlResiduo, value);
    }

    private void CarregarCadri(List<CADRI> lista)
    {
        string value = ddlCadri.SelectedValue;
        ddlCadri.DataSource = lista;
        ddlCadri.DataBind();
        Util.Telas.AdicionaItemBranco(ddlCadri);
        MantemItemSelecionado(ddlCadri, value);
    }

    private void MantemItemSelecionado(DropDownList ddl, string value)
    {
        System.Web.UI.WebControls.ListItem item = ddl.Items.FindByValue(value);
        if (item != null)
            item.Selected = true;
        else
            ddl.SelectedIndex = 0;
    }

    private void CarregarDropDown()
    {
        CarregarCadri();
        CarregarResiduo();
    }

    private void EditarTransporte(int _id)
    {
        Manutencao = ETipoManutencao.Alteracao;
        Transporte transporte = new Transporte(_id);
        txtData.Enabled = false;
        TransporteSelecionado = transporte;
        CarregaDadosTransporte(transporte);
    }

    private void CarregaDadosTransporte(Transporte transporte)
    {
        txtData.Text = transporte.Data.ToString(Util.Formatacao.Data.ShortDatePattern);
        txtQuantidade.Text =  transporte.Quantidade.ToString(",#0.00", Util.Formatacao.Numero);
        txtTransportadora.Text = transporte.Transportadora;
    }

    private void GravarTransporte()
    {
        switch (Manutencao)
        {
            case ETipoManutencao.Inclusao: InserirTransporte(); break;
            case ETipoManutencao.Alteracao: AlterarTransporte(); break;
        }
        Manutencao = ETipoManutencao.Inclusao;
        LimparTransporte();
        CarregarMovimentacao(MovimentacaoSelecionada);
    }

    private void InserirTransporte()
    {
        Transporte novoTransporte = new Transporte();
        novoTransporte.Data = DateTime.Parse(txtData.Text, Util.Formatacao.Data);
        novoTransporte.LoginUltimaAlteracao = base.UsuarioLogado;
        novoTransporte.Movimentacao = MovimentacaoSelecionada;
        novoTransporte.Quantidade = double.Parse(txtQuantidade.Text, Util.Formatacao.Numero); 
        novoTransporte.Transportadora = txtTransportadora.Text;
        novoTransporte.Inserir();
    }

    private void AlterarTransporte()
    {
        Transporte transporte = TransporteSelecionado;
        transporte.Data = DateTime.Parse(txtData.Text, Util.Formatacao.Data);
        transporte.LoginUltimaAlteracao = base.UsuarioLogado;
        transporte.Movimentacao = MovimentacaoSelecionada;
        transporte.Quantidade = double.Parse(txtQuantidade.Text, Util.Formatacao.Numero);
        transporte.Transportadora = txtTransportadora.Text;
        transporte.Alterar();
    }

    private void ApagarTransporte(int _id)
    {
        Transporte transporte = new Transporte(_id, false);
        transporte.LoginUltimaAlteracao = base.UsuarioLogado;
        transporte.Excluir();
    }


    private void ConfirmaExcluirTransporte(int _id)
    {
        Confirm.Mostrar("Deseja realmente excluir este transporte?");
        ViewState["idExcluir"] = _id;
    }

    private void LimparTransporte()
    {
        txtData.Enabled = true;
        txtData.Text = string.Empty;
        txtQuantidade.Text = string.Empty;
        txtTransportadora.Text = string.Empty;
    }
    #endregion
}
