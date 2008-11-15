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
using System.Collections.Specialized;
namespace Telas.Administracao.Confuguracao.UserControl
{
    public partial class TabelaDominio : System.Web.UI.UserControl
    {
        private enum ECommandoGrid
        {
            Remover = 1,
            Editar = 0
        }

        public event OnAdicionar Adicionar;
        public delegate void OnAdicionar(string texto, EventArgs e);
        public event OnRemover Remover;
        public delegate void OnRemover(int Key, EventArgs e);
        public event OnEditar Editar;
        public delegate void OnEditar(string Descricao, int Key, EventArgs e);


        public object DataSource
        {
            get
            {
                return gdvTabela.DataSource;
            }
            set
            {
                gdvTabela.DataSource = value;
            }
        }

        public string DescricaoField
        {
            get
            {
                return ((BoundField)gdvTabela.Columns[0]).DataField;
            }
            set
            {
                ((BoundField)gdvTabela.Columns[0]).DataField = value;
            }
        }

        public string[] DataKeyNames
        {
            get
            {
                return gdvTabela.DataKeyNames;
            }
            set
            {
                gdvTabela.DataKeyNames = value;
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (Adicionar != null)
                Adicionar(txtDescricao.Text, new EventArgs());
        }

        public override void DataBind()
        {
            gdvTabela.DataBind();
            base.DataBind();
        }

        private void CommandRemover(int index)
        {
            gdvTabela.SelectedIndex = index;
            if (Remover != null)
                Remover((int)gdvTabela.DataKeys[index].Value, null);
        }

        private void CommandEditar(int index)
        {
            if (gdvTabela.SelectedIndex != -1)
                HabilitaLinha(true);

            gdvTabela.SelectedIndex = index;
            txtDescricao.Text = gdvTabela.SelectedRow.Cells[0].Text;
            HabilitaLinha(false);
            AcaoEditar(true);
        }

        protected void gdvTabela_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch ((ECommandoGrid)(int.Parse(e.CommandName)))
            {
                case ECommandoGrid.Remover: CommandRemover(int.Parse(e.CommandArgument.ToString())); break;
                case ECommandoGrid.Editar: CommandEditar(int.Parse(e.CommandArgument.ToString())); break;
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if (Editar != null)
                Editar(txtDescricao.Text, (int)gdvTabela.DataKeys[gdvTabela.SelectedIndex].Value, null);
            HabilitaLinha(true);
            gdvTabela.SelectedIndex = -1;
            AcaoEditar(false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitaLinha(true);
            gdvTabela.SelectedIndex = -1;
            AcaoEditar(false);
        }

        private void AcaoEditar(bool editar)
        {
            pnlAdicionar.Visible = !editar;
            pnlEditar.Visible = editar;
        }

        private void HabilitaLinha(bool value)
        {
            ImageButton imgEditar = (ImageButton)gdvTabela.SelectedRow.FindControl("imgEditar");
            ImageButton imgApagar = (ImageButton)gdvTabela.SelectedRow.FindControl("imgApagar");
            imgApagar.Enabled = value;
            imgEditar.Enabled = value;
            if (value)
                txtDescricao.Text = string.Empty;
        }

        protected void gdvTabela_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imgEditar = (ImageButton)e.Row.FindControl("imgEditar");
                ImageButton imgApagar = (ImageButton)e.Row.FindControl("imgApagar");

                imgApagar.CommandArgument = imgEditar.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
    }
}
