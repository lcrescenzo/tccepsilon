<%@ Control Language="C#" AutoEventWireup="true" CodeFile="List.ascx.cs" Inherits="Controles_List" %>
<sgr:DataList ID="dtlItems" runat="server" OnItemDataBound="dtlItems_ItemDataBound" Width="100%">
<ItemTemplate>
    <table>
        <tr>
            <td width="100%">
                <sgr:Label ID="lblTexto" runat="server"></sgr:Label>
            </td>
            <td width=16>
                <sgr:ImageButton ID="imbExcluir" runat="server" ImageUrl="~/Images/Padrao/excluir.gif" ImageAlign="Middle" OnCommand="imbExcluir_Command" />
            </td>
        </tr>
    </table>
    
</ItemTemplate>
    <SeparatorTemplate>
        <hr />
    </SeparatorTemplate>
    <HeaderTemplate>
        <hr color="silver" size="3" />
    </HeaderTemplate>
    <FooterTemplate>
        <hr color="#c0c0c0" size="3" />
    </FooterTemplate>
</sgr:DataList>

