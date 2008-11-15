<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EsqueciMinhaSenha.aspx.cs" Inherits="Login_EsqueciMinhaSenha" %>

<%@ Register Src="../Controles/Mensagem.ascx" TagName="Mensagem" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="vertical-align: middle; text-align: center">
    <form id="form1" runat="server">
        <ajax:ScriptManager ID="ScriptManager1" runat="server">
        </ajax:ScriptManager>
        <br />
        <table border="0" cellpadding="0" cellspacing="0" style="width: 329px">
            <tr>
                <td>
                    <sgr:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/Images/Menssagens/informacao.gif" /></td>
                <td align="left">
                    <sgr:Label ID="lblAviso" runat="server">Este procedimento irá enviar um e-mail para permitir que você altere a sua senha.</sgr:Label></td>
            </tr>
        </table>
        &nbsp;&nbsp;<br />
        <sgr:Panel ID="Panel1" runat="server" HorizontalAlign="Left" Width="150px">
            <ajax:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <sgr:Label ID="Label1" runat="server">Usuário</sgr:Label><br />
                    <sgr:TextBox ID="txtUsuario" runat="server"></sgr:TextBox><br />
                    <sgr:Label ID="Label2" runat="server">E-mail</sgr:Label><br />
                    <sgr:TextBox ID="txtEmail" runat="server"></sgr:TextBox><br />
                </ContentTemplate>
                <Triggers>
                    <ajax:AsyncPostBackTrigger ControlID="btnEnviarEmail" EventName="Click" />
                </Triggers>
            </ajax:UpdatePanel>
        </sgr:Panel>
        <sgr:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        <sgr:Button ID="btnEnviarEmail" runat="server" Text="Enviar Email" OnClick="btnEnviarEmail_Click" />
        <uc1:Mensagem ID="msg" runat="server" />
    </form>
</body>
</html>
