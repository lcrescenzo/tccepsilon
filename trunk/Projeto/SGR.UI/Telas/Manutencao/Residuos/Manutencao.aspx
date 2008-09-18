<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Manutencao.aspx.cs" Inherits="Telas_Manutencao_Residuos_Manutencao" Title="Untitled Page" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax" TagPrefix="cc2" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Common" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:Label ID="lblTitulo" runat="server">Resíduos</cc1:Label><br />
    <br />
    <cc1:Panel ID="Panel2" runat="server" Width="100%">
        <cc1:Label ID="Label2" runat="server" Font-Bold="True">Nome: </cc1:Label>
        <cc1:TextBox ID="txtNome" runat="server" Width="475px"></cc1:TextBox></cc1:Panel>
    <cc1:Panel ID="Panel5" runat="server" Width="100%">
        <cc1:Label ID="Label4" runat="server" Font-Bold="True">Unidade de medida:</cc1:Label>&nbsp;<cc1:DropDownList
            ID="ddlUnidadeMedida" runat="server">
            <asp:ListItem Value="-1">Selecione...</asp:ListItem>
            <asp:ListItem Value="lts">
            </asp:ListItem>
            <asp:ListItem Value="kg">
            </asp:ListItem>
            <asp:ListItem Value="t">
            </asp:ListItem>
            <asp:ListItem Value="mc">m&#179;</asp:ListItem>
        </cc1:DropDownList>
        <cc1:Label ID="Label6" runat="server" Font-Bold="True">Classe: </cc1:Label>&nbsp;
        <cc1:DropDownList ID="ddlClasse" runat="server">
        </cc1:DropDownList>
        <cc1:CheckBox ID="chkAuditoria" runat="server" Text="Auditoria" Checked="True" />&nbsp;
    </cc1:Panel>
    <cc1:Panel ID="Panel1" runat="server" Width="100%">
        <cc1:Label id="Label3" runat="server" Font-Bold="True">Estado físico:</cc1:label>
        <cc1:RadioButton id="rdbLiquido" runat="server" checked="True" groupname="grpEstadoFisico"
            text="Líquido"></cc1:radiobutton>
        <cc1:RadioButton id="rdbSolido" runat="server" groupname="grpEstadoFisico" text="Sólido"></cc1:radiobutton>
        <cc1:RadioButton id="rdbGasoso" runat="server" groupname="grpEstadoFisico" text="Gasoso"></cc1:radiobutton>
        <cc1:Label id="Label1" runat="server" Font-Bold="True">Tipo de Resíduo:</cc1:label>&nbsp;<cc1:DropDownList id="ddlTipoResiduo" runat="server"></cc1:dropdownlist></cc1:Panel>
    <asp:Panel ID="Panel3" runat="server" Width="100%">
        <cc1:Label ID="Label5" runat="server" Font-Bold="True">Grupo de Resíduo:</cc1:Label>&nbsp;<cc1:DropDownList id="ddlGrupoResiduo" runat="server">
        </cc1:DropDownList></asp:Panel>
    <br />
    <cc1:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
    <cc1:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Content>

