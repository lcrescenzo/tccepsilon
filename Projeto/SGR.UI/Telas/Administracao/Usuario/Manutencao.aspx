<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Manutencao.aspx.cs" Inherits="Telas_Manutencao_Usuario_Manutencao" Title="Untitled Page" %>

<%@ Register Src="../../../Controles/MenssagemOK.ascx" TagName="MenssagemOK" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <ajax:ScriptManager id="ScriptManager1" runat="server">
    </ajax:ScriptManager>
    <uc1:MenssagemOK ID="MenssagemOK1"  runat="server" />
        <sgr:Label id="lblTitulo" SkinID="lblTitulo" runat="server" Text="Usuário"></sgr:Label>
        <br />
        <br />
        <table border="0" cellpadding="3" cellspacing="0" width="100%">
        <tr>
            <td width="80">
                <sgr:Label ID="Label1" runat="server" Font-Bold="True">Nome: </sgr:Label></td>
            <td colspan="5" rowspan="2">
                <sgr:TextBox ID="txtNome" runat="server" Width="99%"></sgr:TextBox>
                <sgr:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNome"
                    Display="None" ErrorMessage="O campo Nome é obrigatório."></sgr:RequiredFieldValidator><sgr:TextBox ID="txtEmail" runat="server" Width="99%"></sgr:TextBox><sgr:RequiredFieldValidator
                            ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" Display="None"
                            ErrorMessage="O campo E-mail é obrigatório."></sgr:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td width="80">
                <sgr:Label ID="Label2" runat="server" Font-Bold="True">E-mail: </sgr:Label></td>
        </tr>
        <tr>
            <td width="80">
                <sgr:Label ID="Label4" runat="server" Font-Bold="True">Usuário: </sgr:Label></td>
            <td width="110">
                <sgr:TextBox ID="txtUsuario" runat="server" Width="140px"></sgr:TextBox><sgr:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario" Display="None"
                    ErrorMessage="O campo Usuário é obrigatório."></sgr:RequiredFieldValidator>&nbsp;</td>
            <td>
                <sgr:Label ID="Label3" runat="server" Font-Bold="True">Perfil: </sgr:Label></td>
            <td>
                <sgr:DropDownList ID="ddlPerfil" runat="server" Width="306px">
                </sgr:DropDownList></td>
            <td width="80">
                <sgr:Label ID="Label7" runat="server" Font-Bold="True">Telefone: </sgr:Label></td>
            <td width="110">
                <sgr:TextBox ID="txtTelefone" runat="server" Width="110px"></sgr:TextBox></td>
        </tr>
        <tr>
            <td width="80">
                <sgr:Label ID="Label6" runat="server" Font-Bold="True">Endereço: </sgr:Label></td>
            <td colspan="5">
                <sgr:TextBox ID="txtEndereco" runat="server" Height="48px" TextMode="MultiLine" Width="99%"></sgr:TextBox></td>
        </tr>
    </table>
    <sgr:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br />
    <sgr:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
    <sgr:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />
</asp:Content>

