<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Manutencao.aspx.cs" Inherits="Telas_Manutencao_GrupoResiduos_Manutencao" Title="Untitled Page" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax" TagPrefix="cc2" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Common" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:Label ID="lblTitulo" runat="server">Resíduos</cc1:Label><br />
    <br />
    <cc1:Panel ID="Panel2" runat="server" Width="100%">
        <cc1:Label ID="Label2" runat="server" Font-Bold="True">Nome: </cc1:Label>
        <cc1:TextBox ID="txtNome" runat="server" Width="475px"></cc1:TextBox></cc1:Panel>
    <br />
    <cc1:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
    <cc1:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Content>

