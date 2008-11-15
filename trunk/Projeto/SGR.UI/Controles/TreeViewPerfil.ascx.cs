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
using System.Collections.Generic;

public partial class Controles_TreeViewPerfil : System.Web.UI.UserControl
{

    protected override void OnInit(EventArgs e)
    {
        CarregaTreeView();
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e) { }

    private void CarregaTreeView()
    {
        List<Recurso> recursos = Recurso.ListaPrincipaisRecursos();

        foreach (Recurso recurso in recursos)
        {

            TreeNode node = new TreeNode();
            node.ImageUrl = CaminhoImagem(recurso.TipoRecurso);
            node.Text = recurso.Nome;
            node.Value = recurso.ID.ToString();
            node.NavigateUrl = "#";
            if(recurso.Filhos.Count > 0)
                CarregaFilhos(recurso.Filhos, node);
            trvPerfil.Nodes.Add(node);
        }
    }

    private void CarregaFilhos(List<Recurso> recursos, TreeNode nodePai)
    {
        foreach (Recurso recurso in recursos)
        {

            TreeNode node = new TreeNode();
            node.ImageUrl = CaminhoImagem(recurso.TipoRecurso);
            node.Text = recurso.Nome;
            node.Value = recurso.ID.ToString();
            node.NavigateUrl = "#";
            if(recurso.Filhos.Count > 0)
                CarregaFilhos(recurso.Filhos, node);

            nodePai.ChildNodes.Add(node);
        }
    }

    private string CaminhoImagem(ETipoRecurso eTipoRecurso)
    {
        switch (eTipoRecurso)
        {
            case ETipoRecurso.Acao: return "~/Images/TreeView/Acao.gif";
            case ETipoRecurso.Botao: return "~/Images/TreeView/Botao.gif";
            case ETipoRecurso.ItemMenu: return "~/Images/TreeView/menu.gif";
            case ETipoRecurso.None: return "~/Images/TreeView/None.gif";
            case ETipoRecurso.Outros: return "~/Images/TreeView/None.gif";
            case ETipoRecurso.Pagina: return "~/Images/TreeView/Pagina.gif";
        }
        return string.Empty;
    }

    public void Checked(bool ativo)
    {
        CheckedNode(trvPerfil.Nodes, ativo);
    }

    private void CheckedNode(TreeNodeCollection nodes, bool ativo)
    {
        foreach (TreeNode node in nodes)
        {
            if (node.ChildNodes.Count > 0)
                CheckedNode(node.ChildNodes, ativo);

            node.Checked = ativo;
        }
    }

    private void SetCheckedNode(TreeNodeCollection nodes, List<int> lista)
    {
        foreach (TreeNode node in nodes)
        {
            if (node.ChildNodes.Count > 0)
                SetCheckedNode(node.ChildNodes, lista);

            if(lista.Contains(int.Parse(node.Value)))
            {
                node.Checked = true;
            }
        }
    }

    public List<int> SelectedValues
    {
        get
        {
            return CapturaChecked();
        }
        set
        {
            SetCheckedNode(trvPerfil.Nodes, value);
        }
    }

    private List<int> CapturaChecked()
    {
        List<int> returnList = new List<int>();

        GetCheckedNode(trvPerfil.Nodes, returnList);

        return returnList;
    }

    private void GetCheckedNode(TreeNodeCollection nodes, List<int> lista)
    {
        foreach (TreeNode node in nodes)
        {
            if (node.ChildNodes.Count > 0)
                GetCheckedNode(node.ChildNodes, lista);

            if(node.Checked)
                lista.Add(int.Parse(node.Value));
        }
    }
}
