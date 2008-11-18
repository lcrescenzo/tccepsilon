<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true"
    CodeFile="Consulta.aspx.cs" Inherits="Telas_Manutencao_Residuos_Consulta" Title="Untitled Page" %>

<%@ Register Src="../../../Controles/Mensagem.ascx" TagName="Mensagem" TagPrefix="uc1" %>
<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax.Sistema"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <sgr:Label id="lblTitulo" SkinID="lblTitulo" runat="server" Text="Resíduos"></sgr:Label>
        <br />
        <br />
    <ajax:ScriptManager id="ScriptManager1" runat="server" />
    <cc1:Filtro ID="Filtro1" runat="server" CollapsedImage="~/images/Padrao/mais.gif"
        ExpandedImage="~/images/Padrao/menos.gif">
        <MainControls>
            <sgr:Label ID="Label2" runat="server" Text="Nome: "></sgr:Label>
            <sgr:TextBox ID="txtNome" runat="server" Width="100%"></sgr:TextBox>
        </MainControls>
        <AdvancedControls>
            <sgr:Panel ID="Panel1" runat="server" Width="100%">
                <sgr:Label ID="Label1" runat="server">Tipo de Resíduo:</sgr:Label>
                <sgr:DropDownList ID="ddlTipoResiduo" runat="server">
                </sgr:DropDownList>
            </sgr:Panel>
            <sgr:Panel ID="Panel2" runat="server" Width="100%">
            </sgr:Panel>
        </AdvancedControls>
    </cc1:Filtro>
    <br />
    <sgr:Panel ID="Panel3" runat="server" HorizontalAlign="Right" Width="100%">
        <sgr:Button ID="btnNovo" runat="server" OnClick="btnNovo_Click" Text="Novo" />
        <sgr:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" /></sgr:Panel>
    &nbsp;<br />
    <ajax:UpdatePanel id="UpdatePanel1" runat="server">
        <Contenttemplate>
<sgr:GridView id="gdvLista" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gdvLista_RowDataBound">
        <Columns>
        <asp:BoundField DataField="Nome" HeaderText="Nome"></asp:BoundField>
        <asp:TemplateField HeaderText="Tipo de Res&#237;duo">
        <ItemTemplate>
            <asp:Label id="lblTipoResiduo" runat="server" Text='<%# Eval("TipoResiduo.Descricao") %>' __designer:wfdid="w1"></asp:Label> 
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Classe">
        <ItemTemplate>
            <asp:Label id="lblClasse" runat="server" Text='<%# Eval("Classe.Descricao") %>' __designer:wfdid="w3"></asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False">
        <itemtemplate>
            <asp:ImageButton id="imgEditar" runat="server" Text="Editar" CausesValidation="false" ImageUrl="~/Images/Padrao/editar.gif" CommandName="0" OnCommand="imgEditar_Command"></asp:ImageButton> 
        </itemtemplate>
        <itemstyle width="20px"  />
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False">
        <itemtemplate>
            <asp:ImageButton id="imgExcluir" runat="server" Text="Excluir" CausesValidation="false" ImageUrl="~/Images/Padrao/excluir.gif" CommandName="1" OnCommand="imgExcluir_Command"></asp:ImageButton> 
        </itemtemplate>
        <itemstyle width="20px" />
        </asp:TemplateField>
     </Columns>
    </sgr:GridView> 
</contenttemplate>
    <triggers>
        <ajax:AsyncPostBackTrigger ControlID="btnPesquisar" EventName="Click"></ajax:AsyncPostBackTrigger>
    </triggers>
    </ajax:UpdatePanel>
    <uc1:Mensagem ID="Mensagem1" runat="server" />
</asp:Content>
