<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuTopo.ascx.cs" Inherits="Master_Controls_MenuTopo" %>
<sgr:Panel ID="pnlMenuTopo" runat="server" Width="100%" style="height: 20px;background-color: gainsboro; margin-bottom: 1px; border-bottom: gray 1px solid; border-top: white 1px solid; vertical-align:middle;">
    <sgr:Repeater ID="rptMenuTopo" runat="server" OnItemDataBound="rptMenuTopo_ItemDataBound">
    <ItemTemplate><sgr:LinkButton ID="lnkMenu" runat="Server" Text="Link" OnClick="item_Click"></sgr:LinkButton></ItemTemplate>
    <SeparatorTemplate>|</SeparatorTemplate>
    </sgr:Repeater>
</sgr:Panel>
