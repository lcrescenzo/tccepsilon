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

public partial class Telas_Manutencao_GrupoResiduos_Manutencao : PageBaseManutencao<GrupoResiduo>
{
    #region Eventos
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
        txtNome.Text = string.Empty;
    }

    protected override GrupoResiduo PreparaObjeto()
    {
        GrupoResiduo grupoResiduo = new GrupoResiduo();
        grupoResiduo.Nome = txtNome.Text;
        return grupoResiduo;
    }

    protected override void PreencherObjeto()
    {
        Objeto.Nome = txtNome.Text;
    }

    protected override void PreencherCampos()
    {
        txtNome.Text = Objeto.Nome;
    }

    protected override GrupoResiduo CarregarObjeto(int id)
    {
        return new GrupoResiduo(id);
    }

    protected override void CarregarCampos(){}

   
    #endregion
}

