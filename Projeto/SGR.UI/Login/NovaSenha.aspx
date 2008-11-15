<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NovaSenha.aspx.cs" Inherits="Login_EsqueciMinhaSenha" %>
<%@ Register Src="../Controles/Mensagem.ascx" TagName="Mensagem" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="vertical-align: middle; text-align: center">
    <form id="form1" runat="server">
    <div>
        <ajax:ScriptManager ID="ScriptManager1" runat="server">
        </ajax:ScriptManager>
    
    </div>
        <sgr:Panel ID="pnlPrincipal" runat="server" Width="223px" HorizontalAlign="Center">
            <ajax:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <sgr:Panel ID="Panel1" runat="server" Width="160px" HorizontalAlign="Left">
                        <sgr:Label ID="Label1" runat="server">Usuario</sgr:Label>
                        <br />
                        <sgr:TextBox ID="txtUsuario" runat="server" Enabled="False"></sgr:TextBox><br />
                        <sgr:Label ID="Label2" runat="server">Nova Senha</sgr:Label><br />
                        <sgr:TextBox ID="txtSenha" runat="server"></sgr:TextBox><br />
                        <sgr:Label ID="Label3" runat="server">Confirma��o da senha</sgr:Label><br />
                        <sgr:TextBox ID="txtConfirmacaoSenha" runat="server"></sgr:TextBox><br />
                    </sgr:Panel>
                </ContentTemplate>
            </ajax:UpdatePanel>
        </sgr:Panel>
        <uc1:Mensagem ID="msg" runat="server" />
        <sgr:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        <sgr:Button ID="btnConfirmar" runat="server" Text="Confirma��o" OnClick="btnConfirmar_Click" />
    </form>
</body>
</html>
