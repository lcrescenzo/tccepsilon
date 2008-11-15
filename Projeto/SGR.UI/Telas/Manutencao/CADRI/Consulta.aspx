<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Telas_Manutencao_CADRI_Consulta" Title="Untitled Page" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax.Sistema"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajax:ScriptManager id="ScriptManager1" runat="server" />
        <sgr:Label id="lblTitulo" runat="server" Text="CADRI"></sgr:Label>
        <br />
        <br />
        <cc1:Filtro ID="Filtro1" runat="server" CollapsedImage="~/images/Padrao/mais.gif" ExpandedImage="~/images/Padrao/menos.gif">
            <MainControls>
                        <sgr:Label ID="Label2" runat="server" Text="N&#250;mero: "></sgr:Label>
                        <sgr:TextBox ID="txtNumero" runat="server" Width="100%"></sgr:TextBox>
            </MainControls>
            <AdvancedControls>
                        <sgr:Label ID="lblValidade" runat="server" Font-Bold="True">Validade:</sgr:Label>
                <sgr:TextBox ID="txtValidade" runat="server"></sgr:TextBox>
                        <sgrAjax:Calendar ID="cldValidade" runat="server" Enabled="True" TargetControlID="txtValidade">
                        </sgrAjax:Calendar>
                        <sgr:Label ID="Label3" runat="server" Font-Bold="True">Destino:</sgr:Label>
                        <sgr:TextBox ID="txtDestino" runat="server"></sgr:TextBox>
            </AdvancedControls>
        </cc1:Filtro>
        <br />
        <sgr:Panel ID="Panel3" runat="server" HorizontalAlign="Right" Width="100%">
    
        <sgr:Button ID="btnNovo" runat="server" OnClick="btnNovo_Click" Text="Novo" />
        <sgr:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" /></sgr:Panel>
        <br />
        <ajax:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <contenttemplate>
<sgr:GridView id="gdvLista" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" OnRowCreated="gdvLista_RowCreated"><Columns>
        <asp:BoundField DataField="Numero" HeaderText="Número"></asp:BoundField>
        <asp:BoundField DataField="Validade" HeaderText="Validade"></asp:BoundField>
        <asp:BoundField DataField="Quantidade" HeaderText="Qtde"></asp:BoundField>
        <asp:BoundField DataField="Destino" HeaderText="Destino"></asp:BoundField>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:ImageButton id="imgEditar" runat="server" Text="Editar" CausesValidation="false" ImageUrl="~/Images/Padrao/editar.gif" CommandName="0" __designer:wfdid="w4" OnCommand="imgEditar_Command"></asp:ImageButton> 
            </ItemTemplate>
            <ItemStyle Width="20px"></ItemStyle>
        </asp:TemplateField>
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:ImageButton id="imgExcluir" runat="server" Text="Excluir" CausesValidation="false" ImageUrl="~/Images/Padrao/excluir.gif" CommandName="1" OnCommand="imgExcluir_Command" __designer:wfdid="w2"></asp:ImageButton> 
            </ItemTemplate>
            <ItemStyle Width="20px"></ItemStyle>
        </asp:TemplateField>
</Columns>
</sgr:GridView> 
</contenttemplate>
        <triggers>
<ajax:AsyncPostBackTrigger ControlID="btnPesquisar" EventName="Click"></ajax:AsyncPostBackTrigger>
</triggers>
    </ajax:UpdatePanel>
    
</asp:Content>

