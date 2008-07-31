<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Manutencao.aspx.cs" Inherits="Telas_Manutencao_Residuos_Manutencao" Title="Untitled Page" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Common" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:Label ID="lblTitulo" runat="server">Resíduos</cc1:Label><br />
    <br />
    <cc1:Panel ID="Panel2" runat="server" Width="100%">
        <cc1:Label ID="Label2" runat="server">Nome: </cc1:Label>
        <cc1:TextBox ID="TextBox1" runat="server" Width="475px"></cc1:TextBox></cc1:Panel>
    <cc1:Panel ID="Panel5" runat="server" Width="100%">
        <cc1:Label ID="Label4" runat="server">Unidade de medida:</cc1:Label>&nbsp;<cc1:DropDownList
            ID="DropDownList2" runat="server">
        </cc1:DropDownList>
        <cc1:Label ID="Label6" runat="server">Classe: </cc1:Label>
        <cc1:DropDownList ID="DropDownList3" runat="server">
        </cc1:DropDownList>
        <cc1:CheckBox ID="CheckBox1" runat="server" Text="Auditoria" /></cc1:Panel>
    <cc1:Panel ID="Panel1" runat="server" Width="100%">
        <cc1:Label id="Label1" runat="server">Tipo de Resíduo:</cc1:label>
        <cc1:DropDownList id="DropDownList1" runat="server"></cc1:dropdownlist>
        <cc1:Label id="Label3" runat="server">Estado físico:</cc1:label>
        <cc1:RadioButton id="RadioButton2" runat="server" checked="True" groupname="grpEstadoFisico"
            text="Líquido"></cc1:radiobutton>
        <cc1:RadioButton id="RadioButton1" runat="server" groupname="grpEstadoFisico" text="Sólido"></cc1:radiobutton>
        <cc1:RadioButton id="RadioButton3" runat="server" groupname="grpEstadoFisico" text="Gasoso"></cc1:radiobutton></cc1:Panel>
    <br />
    <cc1:Button ID="btnGravar" runat="server" Text="Gravar" />
    <cc1:Button ID="btnCancelar" runat="server" Text="Cancelar" />
</asp:Content>

