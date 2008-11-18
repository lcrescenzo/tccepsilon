<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NovaSenha.aspx.cs" Inherits="Login_EsqueciMinhaSenha" %>
<%@ Register Src="../Controles/Mensagem.ascx" TagName="Mensagem" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" src="../Script/cripto.js"></script>
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
                        <sgr:TextBox ID="txtSenha" runat="server" TextMode="Password"></sgr:TextBox><br />
                        <sgr:Label ID="Label3" runat="server">Confirmação da senha</sgr:Label><br />
                        <sgr:TextBox ID="txtConfirmacaoSenha" runat="server" TextMode="Password"></sgr:TextBox><sgr:CompareValidator
                            ID="CompareValidator1" runat="server" ControlToCompare="txtSenha" ControlToValidate="txtConfirmacaoSenha"
                            Display="None" ErrorMessage="Senha e Confirmação devem ser idênticas"></sgr:CompareValidator><br />
                        <sgr:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSenha"
                            Display="None" ErrorMessage="Nova senha é obrigatória."></sgr:RequiredFieldValidator></sgr:Panel>
                    <sgr:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirmacaoSenha"
                        Display="None" ErrorMessage="Confirmação da senha é obrigatório. "></sgr:RequiredFieldValidator>
                </ContentTemplate>
            </ajax:UpdatePanel>
            <sgr:Label ID="lblMensagem" runat="server"></sgr:Label><sgr:ValidationSummary ID="ValidationSummary1"
                runat="server" />
        </sgr:Panel>
        <uc1:Mensagem ID="msg" runat="server" />
        <sgr:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />
        <sgr:Button ID="btnConfirmar" runat="server" Text="Confirmação" OnClick="btnConfirmar_Click" />
    </form>
</body>
</html>
