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

public partial class Telas_Manutencao_Residuos_Manutencao : PageBaseManutencao<Residuo>
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
        rdbLiquido.Checked = true;
        ddlClasse.SelectedIndex = 0;
        ddlTipoResiduo.SelectedIndex = 0;
        ddlUnidadeMedida.SelectedIndex = 0;
        chkAuditoria.Checked = true;
    }
    
    protected override Residuo PreparaObjeto()
    {
        Residuo residuo = new Residuo();
        residuo.Auditoria = chkAuditoria.Checked;
        residuo.Classe = new Classe(int.Parse(ddlClasse.SelectedValue));
        residuo.Grupo = new GrupoResiduo(int.Parse(ddlGrupoResiduo.SelectedValue), false);
        residuo.Nome = txtNome.Text;
        residuo.TipoResiduo = new TipoResiduo(int.Parse(ddlTipoResiduo.SelectedValue));
        residuo.UnidadeMedida = ddlUnidadeMedida.SelectedValue;
        return residuo;
    }

    protected override void PreencherObjeto()
    {
        Objeto.Auditoria = chkAuditoria.Checked;
        Objeto.Classe = new Classe(int.Parse(ddlClasse.SelectedValue));
        Objeto.Nome = txtNome.Text;
        Objeto.TipoResiduo = new TipoResiduo(int.Parse(ddlTipoResiduo.SelectedValue));
        Objeto.UnidadeMedida = ddlUnidadeMedida.SelectedValue;
        Objeto.Grupo = new GrupoResiduo(int.Parse(ddlGrupoResiduo.SelectedValue));
    }

    protected override void PreencherCampos()
    {
        chkAuditoria.Checked = Objeto.Auditoria;
        ddlClasse.SelectedValue = Objeto.Classe.ID.ToString();
        txtNome.Text = Objeto.Nome;
        ddlTipoResiduo.SelectedValue = Objeto.TipoResiduo.ID.ToString();
        ddlUnidadeMedida.SelectedValue = Objeto.UnidadeMedida;
        ddlGrupoResiduo.SelectedValue = Objeto.Grupo.ID.ToString();
    }

    protected override Residuo CarregarObjeto(int id)
    {
        return new Residuo(id);
    }

    protected override void CarregarCampos()
    {
        CarregarClasse();
        CarregarTipoResiduo();
        CarregarGrupoResiduo();
    }

    #endregion

    #region Metodos
    private void CarregarGrupoResiduo()
    {
        ddlGrupoResiduo.DataSource = GrupoResiduo.Lista(new FiltroGrupoResiduo());
        ddlGrupoResiduo.DataValueField = "ID";
        ddlGrupoResiduo.DataTextField = "Nome";
        ddlGrupoResiduo.DataBind();
    }

    private void CarregarClasse()
    {
        ddlClasse.DataSource = Classe.Lista(new FiltroClasse());
        ddlClasse.DataValueField = "ID";
        ddlClasse.DataTextField = "Descricao";
        ddlClasse.DataBind();
    }

    private void CarregarTipoResiduo()
    {
        ddlTipoResiduo.DataSource = TipoResiduo.Lista(new FiltroTipoResiduo());
        ddlTipoResiduo.DataValueField = "ID";
        ddlTipoResiduo.DataTextField = "Descricao";
        ddlTipoResiduo.DataBind();
    }
    #endregion
}

