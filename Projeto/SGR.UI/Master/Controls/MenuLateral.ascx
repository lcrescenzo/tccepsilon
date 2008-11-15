<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuLateral.ascx.cs" Inherits="Master_Controls_MenuLateral" %>
<sgr:Panel ID="pnlMenuLateral" runat="server" Width="150px">
    <sgr:Repeater ID="rptMenuLateral" runat="server" OnItemDataBound="rptMenuLateral_ItemDataBound">
    <HeaderTemplate>
        <table>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <sgr:LinkButton ID="lnkMenu" runat="Server" Text="Link" OnClick="item_Click"></sgr:LinkButton>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
    </sgr:Repeater>
</sgr:Panel>
