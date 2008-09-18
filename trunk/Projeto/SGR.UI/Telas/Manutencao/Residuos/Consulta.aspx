<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Telas_Manutencao_Residuos_Consulta" Title="Untitled Page" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax" TagPrefix="cc3" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Common" TagPrefix="cc2" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax.Sistema"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server" />
    
        <cc1:Filtro ID="Filtro1" runat="server" CollapsedImage="~/images/Padrao/mais.gif" ExpandedImage="~/images/Padrao/menos.gif">
            <MainControls>
                        <cc2:Label ID="Label2" runat="server" Text="Nome: "></cc2:Label>
                        <cc2:TextBox ID="txtNome" runat="server" Width="100%"></cc2:TextBox>
            </MainControls>
            <AdvancedControls>
                <cc2:Panel ID="Panel1" runat="server" Width="100%">
                    <cc2:Label ID="Label1" runat="server">Tipo de Resíduo:</cc2:Label>
                    <cc2:DropDownList ID="ddlTipoResiduo" runat="server">
                    </cc2:DropDownList>
                </cc2:Panel>
                <cc2:Panel ID="Panel2" runat="server" Width="100%">
                </cc2:Panel>
            </AdvancedControls>
        </cc1:Filtro>
    <br />
    <cc2:Panel ID="Panel3" runat="server" HorizontalAlign="Right" Width="100%">
    
    
        <cc2:Button ID="btnNovo" runat="server" OnClick="btnNovo_Click" Text="Novo" />
        <cc2:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" /></cc2:Panel>
        <br />
        <cc2:GridView ID="gdvLista" runat="server" Width="100%" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="TipoResiduo.Nome" HeaderText="Tipo de Res&#237;duo" />
                <asp:BoundField />
                <asp:BoundField />
                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Padrao/editar.gif" Text="Editar">
                    <itemstyle width="20px" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Padrao/excluir.gif" Text="Apagar">
                    <itemstyle width="20px" />
                </asp:ButtonField>
            </Columns>
        </cc2:GridView>
    
</asp:Content>

