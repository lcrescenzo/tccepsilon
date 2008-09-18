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
using SGR.BP.Objeto;
using Telas.Administracao.Confuguracao.UserControl;

public partial class Telas_Administracao_Confuguracao_Sistema : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarTipoResiduo();
            CarregarClasse();
        }
    }

    #region Metodos de Carga
    private void CarregarTipoResiduo()
    {
        tbdTipoResiduo.DataSource = TipoResiduo.Lista(new SGR.BP.Objeto.Filtro.FiltroTipoResiduo());
        tbdTipoResiduo.DataKeyNames = new string[] { "ID" };
        tbdTipoResiduo.DescricaoField = "Descricao";
        tbdTipoResiduo.DataBind();
    }

    private void CarregarClasse()
    {
        tbdClasse.DataSource = Classe.Lista(new SGR.BP.Objeto.Filtro.FiltroClasse());
        tbdClasse.DataKeyNames = new string[] { "ID" };
        tbdClasse.DescricaoField = "Descricao";
        tbdClasse.DataBind();
    }
    #endregion

    #region Eventos de Ação
    protected void tbdTipoResiduo_Adicionar(string texto, EventArgs e)
    {
        TipoResiduo tipoResiduo = new TipoResiduo();
        tipoResiduo.Descricao = texto;
        tipoResiduo.Inserir();
        CarregarTipoResiduo();
    }
    protected void tbdTipoResiduo_Remover(int Key, EventArgs e)
    {
        TipoResiduo tipoResiduo = new TipoResiduo(Key);
        tipoResiduo.Excluir();
        CarregarTipoResiduo();
    }
    protected void tbdTipoResiduo_Editar(string Descricao, int Key, EventArgs e)
    {
        TipoResiduo tipoResiduo = new TipoResiduo(Key);
        tipoResiduo.Descricao = Descricao;
        tipoResiduo.Alterar();
        CarregarTipoResiduo();

    }

    protected void tbdClasse_Adicionar(string texto, EventArgs e)
    {
        Classe classe = new Classe();
        classe.Descricao = texto;
        classe.Inserir();
        CarregarClasse();
    }
    protected void tbdClasse_Remover(int Key, EventArgs e)
    {
        Classe classe = new Classe(Key);
        classe.Excluir();
        CarregarClasse();
    }
    protected void tbdClasse_Editar(string Descricao, int Key, EventArgs e)
    {
        Classe classe = new Classe(Key);
        classe.Descricao = Descricao;
        classe.Alterar();
        CarregarClasse();
    }
    #endregion

}
