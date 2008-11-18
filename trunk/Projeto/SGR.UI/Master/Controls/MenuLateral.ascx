<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuLateral.ascx.cs" Inherits="Master_Controls_MenuLateral" %>
<sgr:Panel ID="pnlMenuLateral" runat="server" Width="150px" Height="100%">
    <sgr:Repeater ID="rptMenuLateral" runat="server" OnItemDataBound="rptMenuLateral_ItemDataBound">
    <HeaderTemplate>
        <table>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <span class="submenu"><sgr:LinkButton ID="lnkMenu" CausesValidation="false" runat="Server" Text="Link" OnClick="item_Click"></sgr:LinkButton></span>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
    </sgr:Repeater>
</sgr:Panel>
