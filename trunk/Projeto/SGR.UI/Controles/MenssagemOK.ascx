<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenssagemOK.ascx.cs" Inherits="MenssagemOK" %>
<ajax:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <asp:Panel ID="pnlConfirm" runat="server" Visible="false" BackColor="WhiteSmoke" BorderStyle="Double"
            BorderWidth="4px" Height="150px" Width="350px">
            <table height="100%" width="350">
                <tr>
                    <td align="center" style="width: 81px; height: 76px">
                        &nbsp;<sgr:image id="img" runat="server" imageurl="~/Images/Menssagens/informacao.gif"></sgr:image></td>
                    <td style="height: 76px">
                        <sgr:label id="lblPergunta" runat="server" width="100%"></sgr:label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" height="15" rowspan="">
                        <sgr:Button ID="btnSim" runat="server" Text="Ok" OnClick="btnOk_Click" CausesValidation="False" /></td>
                </tr>
            </table>
        </asp:Panel>
    <sgrAjax:ModalPopup ID="mdpConfirm" runat="server" TargetControlID="img" PopupControlID="pnlConfirm" BackgroundCssClass="mensagem" >
    </sgrAjax:ModalPopup>
    </ContentTemplate>
</ajax:UpdatePanel>