<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<%@ Register Src="../Controles/Mensagem.ascx" TagName="Mensagem" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SGR - Login</title>
    <script type="text/javascript" src="../Script/cripto.js"></script>
</head>
<body style="vertical-align: middle; text-align: center">
    <form id="form1" runat="server">
        <ajax:ScriptManager ID="ScriptManager1" runat="server">
        </ajax:ScriptManager>
        <sgr:Panel ID="Panel2" runat="server" HorizontalAlign="Center" BorderStyle="Solid" BorderWidth="1px" style="padding:10px 10px 10px 10px; " Wrap="False">
            <table>
                <tr>
                    <td align="left" >
                        <sgr:Panel ID="Panel1" runat="server" Width="188px" HorizontalAlign="Left">
                            <ajax:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <sgr:Label ID="lblUsuario" runat="server">Usuário</sgr:Label>
                                    <sgr:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario"
                                        Display="None" ErrorMessage="Usuário obrigatório."></sgr:RequiredFieldValidator><br />
                                    <sgr:TextBox ID="txtUsuario" runat="server" Width="170px"></sgr:TextBox>
                                    <sgr:Label ID="Label2" runat="server">Senha</sgr:Label>
                                    <sgr:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSenha"
                                        Display="None" ErrorMessage="Senha obrigatória."></sgr:RequiredFieldValidator><br />
                                    <sgr:TextBox ID="txtSenha" runat="server" Width="170px" TextMode="Password"></sgr:TextBox>
                                </ContentTemplate>
                                <Triggers>
                                    <ajax:AsyncPostBackTrigger ControlID="btnEntrar" EventName="Click" />
                                
                                </Triggers>
                            </ajax:UpdatePanel>
                            <sgr:LinkButton ID="lkbEsqueciMinhaSenha" runat="server" PostBackUrl="EsqueciMinhaSenha.aspx">Esqueci minha senha</sgr:LinkButton>
                            <sgr:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
                        </sgr:Panel>
                    </td>
                    <td >
                        <sgr:Panel ID="Panel3" runat="server" Width="130px">
                            <sgr:Image ID="imgLogo" runat="server" />
                        </sgr:Panel>
                    </td>
                </tr>
            </table>
        </sgr:Panel>
        <uc1:Mensagem ID="msg" runat="server" />
        <sgr:ValidationSummary ID="ValidationSummary1" runat="server" />
        
    </form>
</body>
</html>
