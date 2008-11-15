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

public abstract class PageBaseConsulta : PageLogedBase
{

	public PageBaseConsulta()
	{

	}
    
    protected override void OnLoad(EventArgs e)
    {
        
        CapturaControles();
        if (!IsPostBack)
        {
            CarregaRecurso();
            CarregaControles();
            AplicarFiltro();
        }

        base.OnLoad(e);
    }

    private void CarregaRecurso()
    {
        int id = -1;
        if (Session["id"] != null)
        {
            id = (int)Session["id"];
            Session.Remove("id");
        }

        if(Session["admin"] == null)
            ValidaRecurso(id);
    }

    private void ValidaRecurso(int id)
    {
        SGR.BP.Objeto.Recurso filhoConsultar, filhoManutencao;
        SGR.BP.Objeto.Recurso recurso = new SGR.BP.Objeto.Recurso(id);
        if (recurso.Filhos.Count > 0)
        {
            filhoConsultar = recurso.Filhos.Find(delegate(SGR.BP.Objeto.Recurso recursoFilho)
                {
                    return ((recursoFilho.TipoRecurso == SGR.BP.Objeto.ETipoRecurso.Acao) &&
                        (recursoFilho.Nome == "Consultar"));
                }
            );

            filhoManutencao = recurso.Filhos.Find(delegate(SGR.BP.Objeto.Recurso recursoFilho)
                {
                    return ((recursoFilho.TipoRecurso == SGR.BP.Objeto.ETipoRecurso.Acao) &&
                        (recursoFilho.Nome == "Manter"));
                }
            );

            if (filhoConsultar == null)
                Response.Redirect("~/Erro/SemPermissao.aspx");

            BotaoNovo.Enabled = (filhoManutencao != null);
        }
    }
    
    protected void Novo()
    {
        Context.Items["TipoManutencao"] = (int)ETipoManutencao.Inclusao;
        Context.Items["filtro"] = MontaFiltro();
        Server.Transfer("Manutencao.aspx");
    }
    
    protected void Editar(int id)
    {
        Session["TipoManutencao"] = (int)ETipoManutencao.Alteracao;
        Session["idObject"] = id;
        Session["filtro"] = MontaFiltro();
        Response.Redirect("Manutencao.aspx");
    }

    protected void Remover(ObjectBase objeto)
    {
        objeto.Excluir();
        CarregaLista(MontaFiltro());
    }

    private void AplicarFiltro()
    {
        if (Context.Items["filtro"] != null)
        {
            IFiltro filtro = (IFiltro)Context.Items["filtro"];
            CarregaFiltro(filtro);
            CarregaLista(filtro);
        }
    }

    protected abstract void CarregaLista(IFiltro filtro);

    protected abstract void CarregaControles();

    protected abstract void CapturaControles();

    protected abstract IFiltro MontaFiltro();

    protected abstract void CarregaFiltro(IFiltro filtro);

    protected abstract WebControl BotaoNovo { get; }

}
