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
using System.Collections.Generic;

public partial class Telas_Manutencao_Perfil_Manutencao : PageBaseManutencao<Perfil>
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

    #region Metodos
    private List<int> CapturaRecursos(List<Recurso> recursos)
    {
        List<int> returnList = new List<int>();
        foreach (Recurso recurso in recursos)
        {
            returnList.Add(recurso.ID);
        }
        return returnList;
    }
    #endregion

    #region Metodos Sobrescritos

    protected override void LimparCampos()
    {
        txtNome.Text = string.Empty;
        TreeViewPerfil1.Checked(false);
    }

    protected override Perfil PreparaObjeto()
    {
        Perfil perfil = new Perfil();
        perfil.Nome = txtNome.Text;

        perfil.Recursos.Clear();

        foreach (int idRecursoSelecionado in TreeViewPerfil1.SelectedValues)
        {
            Recurso recurso = new Recurso(idRecursoSelecionado, false);
            perfil.Recursos.Add(recurso);
        }
    
        return perfil;
    }

    protected override void PreencherObjeto()
    {
        Objeto.Nome = txtNome.Text;

        Objeto.Recursos.Clear();

        foreach (int idRecursoSelecionado in TreeViewPerfil1.SelectedValues)
        {
            Recurso recurso = new Recurso(idRecursoSelecionado, false);
            Objeto.Recursos.Add(recurso);
        }
    }

    protected override void PreencherCampos()
    {
        txtNome.Text = Objeto.Nome;

        TreeViewPerfil1.SelectedValues = CapturaRecursos(Objeto.Recursos);
    }

    protected override Perfil CarregarObjeto(int id)
    {
        return new Perfil(id);
    }

    protected override void CarregarCampos() { }

   
    #endregion
}

