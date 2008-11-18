using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SGR.BP.Bases;
using SGR.BP.Objeto;
using SGR.BP.Objeto.Filtro;
using System.Collections.Generic;

public partial class Telas_Manutencao_CADRI_Manutencao : PageBaseManutencao<CADRI>
{
    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        ManterData();
    }

    private void ManterData()
    {
        if(txtValidade.Text != string.Empty)
            cldValidade.SelectedDate = DateTime.Parse(txtValidade.Text, Util.Formatacao.Data);
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {
        Gravar();
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Cancelar();
    }
    #endregion

    #region Metodos Sobrescritos

    protected override void LimparCampos()
    {
        txtNumero.Text = string.Empty;
        txtOI.Text = string.Empty;
        txtQuantidade.Text = string.Empty;
        txtDestino.Text = string.Empty;
        txtValidade.Text = string.Empty;
        lstResiduo.SelectedItems = new List<Residuo>();
        lstResiduo.AtualizarResiduos();
    }

    protected override CADRI PreparaObjeto()
    {
        CADRI cadri = new CADRI();
        cadri.Destino = txtDestino.Text;
        cadri.Numero = txtNumero.Text;
        cadri.OI = int.Parse(txtOI.Text);
        cadri.Quantidade = double.Parse(txtQuantidade.Text, Util.Formatacao.Numero);
        cadri.Validade = DateTime.Parse(txtValidade.Text, Util.Formatacao.Data);
        cadri.LoginUltimaAlteracao = base.UsuarioLogado;
        cadri.Residuos.Clear();
        foreach (Residuo item in lstResiduo.SelectedItems)
        {
            cadri.Residuos.Add(item);
        }
        return cadri;
    }

    protected override void PreencherObjeto()
    {
        Objeto.Destino = txtDestino.Text;
        Objeto.Numero = txtNumero.Text;
        Objeto.OI = int.Parse(txtOI.Text);
        Objeto.Quantidade = double.Parse(txtQuantidade.Text);
        Objeto.LoginUltimaAlteracao = base.UsuarioLogado;
        Objeto.Validade = DateTime.Parse(txtValidade.Text, Util.Formatacao.Data); 
        Objeto.Residuos.Clear();
        foreach (Residuo item in lstResiduo.SelectedItems)
        {
            Objeto.Residuos.Add(item);
        }
    }

    protected override void PreencherCampos()
    {
        txtDestino.Text = Objeto.Destino;
        txtNumero.Text = Objeto.Numero;
        txtOI.Text = Objeto.OI.ToString();
        txtQuantidade.Text = Objeto.Quantidade.ToString("0#.##", Util.Formatacao.Numero);
        txtValidade.Text = Objeto.Validade.ToString(Util.Formatacao.Data.ShortDatePattern);
        lstResiduo.SelectedItems = Objeto.Residuos;
        lstResiduo.AtualizarResiduos();
    }

    protected override CADRI CarregarObjeto(int id)
    {
        return new CADRI(id);
    }

    protected override void CarregarCampos()
    {
        if(!IsPostBack)
        {
            cldValidade.Format = Util.Formatacao.Data.ShortDatePattern;
            if(base.TipoManutencao != ETipoManutencao.Alteracao)
                cldValidade.SelectedDate = DateTime.Now.AddYears(1);
            CriaCamposNumerico();
        }
    }

    private void CriaCamposNumerico()
    {
        txtNumero.Attributes.Add("onkeypress", "return ValidarKeyPressInteger(this, 30);");
        txtOI.Attributes.Add("onkeypress", "return ValidarKeyPressInteger(this, 8)");
        txtQuantidade.Attributes.Add("onkeypress", "return ValidarKeyPressNumeric(this, '" + Util.Formatacao.Numero.CurrencyDecimalSeparator + "', 2);");
    }
   
    #endregion
}

