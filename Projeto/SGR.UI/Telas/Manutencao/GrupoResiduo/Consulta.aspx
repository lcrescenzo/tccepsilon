<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Telas_Manutencao_GrupoResiduos_Consulta" Title="Untitled Page" %>
<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax.Sistema"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajax:ScriptManager id="ScriptManager1" runat="server" />
        <sgr:Label id="lblTitulo" runat="server" Text="Grupo de Resíduos"></sgr:Label>
        <br />
        <br />
        <cc1:Filtro ID="Filtro1" runat="server" CollapsedImage="~/images/Padrao/mais.gif" ExpandedImage="~/images/Padrao/menos.gif">
            <MainControls>
                        <sgr:Label ID="Label2" runat="server" Text="Nome: "></sgr:Label>
                        <sgr:TextBox ID="txtNome" runat="server" Width="100%"></sgr:TextBox>
            </MainControls>
        </cc1:Filtro>
    <br />
    <sgr:Panel ID="Panel3" runat="server" HorizontalAlign="Right" Width="100%">
    
    
        <sgr:Button ID="btnNovo" runat="server" OnClick="btnNovo_Click" Text="Novo" />
        <sgr:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" /></sgr:Panel>
        <br />
    <ajax:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
            <sgr:GridView id="gdvLista" runat="server" Width="100%" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:TemplateField ShowHeader="False">
                    <itemtemplate>
                        <asp:ImageButton id="imgEditar" runat="server" Text="Editar" CausesValidation="false" ImageUrl="~/Images/Padrao/editar.gif" CommandName="0" __designer:wfdid="w4" OnCommand="imgEditar_Command"></asp:ImageButton> 
                    </itemtemplate>
                    <itemstyle width="20px"  />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <itemtemplate>
                        <asp:ImageButton id="imgExcluir" runat="server" Text="Excluir" CausesValidation="false" ImageUrl="~/Images/Padrao/excluir.gif" CommandName="1" OnCommand="imgExcluir_Command" __designer:wfdid="w2"></asp:ImageButton> 
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
    
</asp:Content>

