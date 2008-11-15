<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Mensagem.ascx.cs" Inherits="Mensagem" %>
<ajax:UpdatePanel ID="updMessages" runat="server">
<ContentTemplate>
    <asp:Panel ID="pnlMensagem" runat="server" BackColor="WhiteSmoke" Visible="false" BorderStyle="Double"
        BorderWidth="4px" Height="150px" Width="350px">
        <table height="100%" width="100%">
            <tr>
                <td align="center" style="width: 81px; height: 96px">
                    &nbsp;<sgr:image id="imgTipo" runat="server" imageurl="~/Images/Menssagens/informacao.gif"></sgr:image></td>
                <td style="height: 96px">
                    <sgr:label id="lblMensagem" runat="server" width="100%"></sgr:label>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <sgrAjax:ModalPopup ID="mdpModal" runat="server" CancelControlID="pnlMensagem" TargetControlID="imgTipo" PopupControlID="pnlMensagem" BackgroundCssClass="mensagem">
    </sgrAjax:ModalPopup>
</ContentTemplate>
</ajax:UpdatePanel>


