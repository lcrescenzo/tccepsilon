using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SGR.BP.Bases;

public abstract class PageBaseManutencao<T> : PageLogedBase where T : ObjectBase
{
    #region Contrutor
    public PageBaseManutencao()
    {

    }
    #endregion

    #region Atributos
    private ObjectBase _objeto;
    #endregion

    #region Propriedades Gerais
    public T Objeto
    {
        get
        {
            if (_objeto == null)
            {
                _objeto = (ObjectBase)CarregarObjeto((int)ViewState["idObject"]);
            }
            return (T)_objeto;
        }
        set
        {
            ViewState["idObject"] = value.ID;
            _objeto = value;
        }
    }

    public ETipoManutencao TipoManutencao
    {
        get
        {
            return (ETipoManutencao)((int)ViewState["TipoManutencao"]);
        }
        set
        {
            ViewState["TipoManutencao"] = (int)value;
        }
    }
    #endregion
       
    #region Eventos
    protected override void OnLoad(EventArgs e)
    {
        if (!IsPostBack)
        {
            Inicializar();
        }

        base.OnLoad(e);
    }
    #endregion

    #region Metodos Gerais
    private void Inicializar()
    {
        if ((Session["TipoManutencao"] == null) && Context.Items["TipoManutencao"] == null)
            Server.Transfer("Consulta.aspx");

        TipoManutencao = (Session["TipoManutencao"] == null) ? (ETipoManutencao)((int)Context.Items["TipoManutencao"]) : (ETipoManutencao)((int)Session["TipoManutencao"]);
        CarregarCampos();
        GuardarFiltro();
        if (TipoManutencao == ETipoManutencao.Alteracao)
        {

            ViewState["idObject"] = (int)Session["idObject"];
            PreencherCampos();
            RemoverSession();
        }
        else
        {
            LimparCampos();
        }
    }

    private void RemoverSession()
    {
        Session.Remove("TipoManutencao");
        Session.Remove("idObject");
        Session.Remove("filtro");
    }

    private void GuardarFiltro()
    {
        ViewState["filtro"] = (Session["filtro"] != null) ? Session["filtro"] : Context.Items["filtro"];
    }

    protected void Cancelar()
    {
        Context.Items["filtro"] = ViewState["filtro"];
        Server.Transfer("Consulta.aspx");
    }
    
    protected void Gravar()
    {
        switch (TipoManutencao)
        {
            case ETipoManutencao.Inclusao: Incluir(); break;
            case ETipoManutencao.Alteracao: Alterar(); break;
        }
        Context.Items["filtro"] = ViewState["filtro"];
        Server.Transfer("Consulta.aspx");
    }

    private void Incluir()
    {
        T obj = PreparaObjeto();
        obj.Inserir();
        Objeto = obj;
    }

    private void Alterar()
    {
        PreencherObjeto();
        ((ObjectBase)Objeto).Alterar();
    }
    #endregion

    #region Metodos Abstratos
    protected abstract void LimparCampos();

    protected abstract T PreparaObjeto();

    protected abstract void PreencherObjeto();

    protected abstract void PreencherCampos();

    protected abstract void CarregarCampos();

    protected abstract T CarregarObjeto(int id);
    
    #endregion

}
