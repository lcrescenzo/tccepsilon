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

public partial class Controles_ListaResiduos : System.Web.UI.UserControl
{
    [Serializable]
    class ItemResiduo
    {
        public ItemResiduo(int id, string texto)
        {
            _id = id;
            _texto = texto;
        }

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _texto;

        public string Texto
        {
            get { return _texto; }
            set { _texto = value; }
        }

    }

    public List<Residuo> SelectedItems
    {
        set
        {
            foreach (Residuo item in value)
            {
                lstResiduos.Adicionar(item.Nome, item.ID);
            }
        }
        get
        {
            List<Residuo> returnList = new List<Residuo>();
            foreach (int id in lstResiduos.IDs)
            {
                returnList.Add(new Residuo(id, false));
            }
            return returnList;
        }
    }

    public void AtualizarResiduos()
    {
        RemoveSelecionados();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregaResiduos(Residuo.Lista(new SGR.BP.Objeto.Filtro.FiltroResiduo()));
        }
        lstResiduos.OnDelete += new Controles_List.Delete(lstResiduos_OnDelete);
    }

    void lstResiduos_OnDelete(string texto, int id)
    {
        ddlResiduo.Items.Add(new ListItem(texto, id.ToString()));
    }

    private void CarregaResiduos(System.Collections.Generic.List<Residuo> residuos)
    {
        ddlResiduo.DataSource = residuos;
        ddlResiduo.DataTextField = "Nome";
        ddlResiduo.DataValueField = "ID";
        ddlResiduo.DataBind();
        AdicionaItemBranco();
        RemoveSelecionados();
    }

    private void AdicionaItemBranco()
    {
        ddlResiduo.Items.Insert(0, new ListItem("Selecione um Resíduo...", string.Empty));
    }

    private void RemoveSelecionados()
    {
        foreach(int id in lstResiduos.IDs)
        {
            ListItem item = ddlResiduo.Items.FindByValue(id.ToString());
            if(item != null)
                ddlResiduo.Items.Remove(item);
        }
    }

    protected void btnAdicionarResiduo_Click(object sender, EventArgs e)
    {
        if (ddlResiduo.SelectedValue != string.Empty)
        {
            int id = int.Parse(ddlResiduo.SelectedValue);
            this.Adicionar(ddlResiduo.SelectedItem.Text, id);
            ddlResiduo.Items.Remove(ddlResiduo.SelectedItem);
            ddlResiduo.SelectedIndex = -1;
        }
    }

    private void Adicionar(string texto, int id)
    {
        lstResiduos.Adicionar(texto, id);
    }

    protected void btnAdicionarGrupo_Click(object sender, EventArgs e)
    {
        //GrupoResiduo grupoResiduo = new GrupoResiduo(int.Parse(ddlGrupoResiduo.SelectedValue));
        //grupoResiduo.
    }
    
}
