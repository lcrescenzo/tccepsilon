<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Manutencao.aspx.cs" Inherits="Telas_Manutencao_Perfil_Manutencao" Title="Untitled Page" %>
<%@ Register Src="../../../Controles/TreeViewPerfil.ascx" TagName="TreeViewPerfil"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajax:ScriptManager id="ScriptManager1" runat="server">
    </ajax:ScriptManager>
        <sgr:Label id="Label1" runat="server" Text="Perfil"></sgr:Label>
        <br />
        <br />

    <sgr:Label ID="lblTitulo" runat="server">Resíduos</sgr:Label><br />
    <br />
    <sgr:Panel ID="Panel2" runat="server" Width="100%">
        <sgr:Label ID="Label2" runat="server" Font-Bold="True">Nome: </sgr:Label>
        <sgr:TextBox ID="txtNome" runat="server" Width="475px"></sgr:TextBox></sgr:Panel>
    <uc1:TreeViewPerfil ID="TreeViewPerfil1" runat="server" />
    <br />
    <sgr:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
    <sgr:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Content>

