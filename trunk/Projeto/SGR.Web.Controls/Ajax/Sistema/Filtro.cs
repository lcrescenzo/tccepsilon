using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Web.UI.Design;
using System.Drawing;

namespace SGR.Web.Controls.Ajax.Sistema
{
    [DefaultProperty("MainControlID")]
    [ToolboxData("<{0}:Filtro runat=server></{0}:Filtro>")]
    [Designer(typeof(FiltroDesigner))]
    public class Filtro : CompositeControl, INamingContainer
    {
        Panel panelMain = null;
        Panel panelMainControls = null;
        Panel panelAvancado = null;
            

        protected override void  CreateChildControls()
        {
            panelMain = new Panel();
            panelMain.ID = "PanelMain";
            panelMain.Width = new Unit(100, UnitType.Percentage);
            panelMain.BorderColor = Color.Black;
            panelMain.BorderWidth = new Unit(1);

            Panel panelTitulo = new Panel();
            panelTitulo.ID = "panelTitulo";
            panelTitulo.Width = new Unit(100, UnitType.Percentage);

            Label label = new Label();
            label.ID = "label";
            label.Text = "Filtro";

            ImageButton image = new ImageButton();
            image.ImageUrl = (Collapsed) ? CollapsedImage : ExpandedImage;

            HtmlTable table = new HtmlTable();
            table.Width = "100%";

            HtmlTableRow row = new HtmlTableRow();
            
            HtmlTableCell cellTitle = new HtmlTableCell();
            cellTitle.Align = "left";
            cellTitle.Controls.Add(label);

            HtmlTableCell cellImage = new HtmlTableCell();
            cellImage.Align = "right";
            cellImage.Controls.Add(image);

            row.Cells.Add(cellTitle);
            row.Cells.Add(cellImage);

            table.Rows.Add(row);

            panelTitulo.Controls.Add(table);

            panelMainControls = new Panel();
            panelMainControls.ID = "panelMainControls";
            panelMainControls.Width = new Unit(100, UnitType.Percentage);
            if (MainControls != null)
            {

                Control mainControl = new Control();
                MainControls.InstantiateIn(mainControl);
                panelMainControls.Controls.Add(mainControl);
            }

            panelMain.Controls.Add(panelTitulo);
            panelMain.Controls.Add(panelMainControls);


            panelAvancado = new Panel();
            panelAvancado.ID = "PanelAvancado";
            panelAvancado.Width = new Unit(100, UnitType.Percentage);
            if (AdvancedControls != null)
            {

                Control advControl = new Control();
                AdvancedControls.InstantiateIn(advControl);
                panelAvancado.Controls.Add(advControl);
            }
            panelMain.Controls.Add(panelAvancado);

            Ajax.RoundedCornersExtender rounded = new RoundedCornersExtender();
            rounded.TargetControlID = panelMain.ID;
            rounded.Radius = 5;
            rounded.Corners = AjaxControlToolkit.BoxCorners.All;

            Ajax.CollapsiblePanel collapsi = new CollapsiblePanel();
            collapsi.TargetControlID = panelAvancado.ID;
            collapsi.CollapseControlID = panelTitulo.ID;
            collapsi.ExpandControlID = panelTitulo.ID;
            collapsi.TextLabelID = label.ID;
            collapsi.ImageControlID = image.ID;
            collapsi.ExpandedImage = ExpandedImage;
            collapsi.CollapsedImage = CollapsedImage;
            collapsi.SuppressPostBack = true;
            collapsi.Collapsed = Collapsed;
            
            this.Controls.Add(panelMain);
            this.Controls.Add(rounded);
            this.Controls.Add(collapsi);

            base.CreateChildControls();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            EnsureChildControls();
            base.Render(writer);
        }


        private string _expandedImage = string.Empty;
        private string _collapsedImage = string.Empty;
        private bool _collapsed = true;
        private ITemplate _advancedControls;
        private ITemplate _mainControls;

        public string ExpandedImage
        {
            get
            {
                return _expandedImage;
            }
            set
            {
                _expandedImage = value;
            }
        }

        public string CollapsedImage
        {
            get
            {
                return _collapsedImage;
            }
            set
            {
                _collapsedImage = value;
            }
        }

        public bool Collapsed
        {
            get
            {
                return _collapsed;
            }
            set
            {
                _collapsed = value;
            }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate MainControls
        {
            get
            {
                EnsureChildControls();
                return this. _mainControls;
            }
            set
            {
                this._mainControls = value;
                
            }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate AdvancedControls
        {
            get
            {
                EnsureChildControls();
                return this._advancedControls;
            }
            set
            {
                this._advancedControls = value;
            }
        }
            
    }


    class FiltroDesigner : ControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            SetViewFlags(ViewFlags.TemplateEditing, true);
        }
        private TemplateGroupCollection _templateGroups;
        public override TemplateGroupCollection TemplateGroups
        {
            get
            {
                if (_templateGroups == null)
                {
                    _templateGroups = new TemplateGroupCollection();
                    TemplateGroup group;
                    TemplateDefinition mainControls, advancedControls;
                    Filtro ctl;
                    ctl = (Filtro)this.Component;
                    group = new TemplateGroup("Filtro");

                    mainControls = new TemplateDefinition(this, "MainControls", ctl, "MainControls", true);
                    advancedControls = new TemplateDefinition(this, "AdvancedControls", ctl, "AdvancedControls", true);
                    group.AddTemplateDefinition(mainControls);
                    group.AddTemplateDefinition(advancedControls);
                    _templateGroups.Add(group);
                }
                return _templateGroups;
            }
        }
    }

    [ToolboxItem(false)]
    public class FiltroTemplate : TemplateControl, INamingContainer
    {
       
    }
}
