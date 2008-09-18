using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace SGR.Web.Controls.Common.Sistema
{
    public class Titulo : WebControl
    {
        public Titulo()
            : base(System.Web.UI.HtmlTextWriterTag.H1)
        { }
        protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
        {
            writer.WriteLine(this.Text);
            base.RenderContents(writer);
        }

        
        public string Text
        {
            get 
            { 
                return ViewState["_text"].ToString(); 
            }
            set 
            {
                ViewState["_text"] = value; 
            }
        }

    }
}
