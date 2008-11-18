<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Manutencao.aspx.cs" Inherits="Telas_Manutencao_GrupoResiduos_Manutencao" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <ajax:ScriptManager id="ScriptManager1" runat="server">
    </ajax:ScriptManager>
      <sgr:Label id="lblTitulo" SkinID="lblTitulo" runat="server" Text="Grupo de Resíduos"></sgr:Label>
        <br />
        <br />
    <sgr:Panel ID="Panel2" runat="server" Width="100%">
        <sgr:Label ID="Label2" runat="server" Font-Bold="True">Nome: </sgr:Label>
        <sgr:TextBox ID="txtNome" runat="server" Width="475px"></sgr:TextBox>
        <sgr:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome"
            Display="None" ErrorMessage="O campo Nome é obrigatório."></sgr:RequiredFieldValidator></sgr:Panel>
    <sgr:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br />
    <sgr:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
    <sgr:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />
</asp:Content>

