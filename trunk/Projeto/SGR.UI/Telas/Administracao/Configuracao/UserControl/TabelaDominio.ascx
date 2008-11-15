<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TabelaDominio.ascx.cs" Inherits="Telas.Administracao.Confuguracao.UserControl.TabelaDominio" %>
<table width="100%">
    <tr>
        <td style="width: 100%">
            <sgr:TextBox ID="txtDescricao" runat="server" Width="100%"></sgr:TextBox></td>
        <td width="100">
            <sgr:Panel ID="pnlAdicionar" runat="server">
            <sgr:Button ID="btnAdicionar" runat="server" Text="Adicionar" Width="100px" OnClick="btnAdicionar_Click" /></sgr:Panel>
            <sgr:Panel ID="pnlEditar" Wrap="false" Visible="false" runat="server">
            <sgr:Button ID="btnAlterar" runat="server" Text="Alterar" Width="100px" OnClick="btnAlterar_Click" />&nbsp;
            <sgr:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="100px" OnClick="btnCancelar_Click" />
            </sgr:Panel>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <sgr:GridView ID="gdvTabela" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                Width="100%" CellPadding="4" ForeColor="#333333" GridLines="Horizontal" AllowSorting="True" EmptyDataText="-" OnRowCommand="gdvTabela_RowCommand" OnRowDataBound="gdvTabela_RowDataBound" >
                <Columns>
                    <asp:BoundField HeaderText="Descri&#231;&#227;o" />
                    <asp:TemplateField ShowHeader="False">
                        <itemtemplate>
                            <asp:ImageButton id="imgEditar" runat="server" Text="Editar" __designer:wfdid="w3" CommandName="0" CausesValidation="false" ImageAlign="AbsMiddle" ImageUrl="~/Images/Padrao/editar.gif"></asp:ImageButton> 
                        </itemtemplate>
                        <itemstyle width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <itemtemplate>
                            <asp:ImageButton id="imgApagar" runat="server" Text="Apagar" __designer:wfdid="w4" CommandName="1" CausesValidation="false" ImageUrl="~/Images/Padrao/excluir.gif"></asp:ImageButton> 
                        </itemtemplate>
                        <itemstyle width="20px" />
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
            </sgr:GridView>
        </td>
    </tr>
</table>
