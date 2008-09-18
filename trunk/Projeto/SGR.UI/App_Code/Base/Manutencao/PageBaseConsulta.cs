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
            CarregaControles();
            AplicarFiltro();
        }

        base.OnLoad(e);
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

}
