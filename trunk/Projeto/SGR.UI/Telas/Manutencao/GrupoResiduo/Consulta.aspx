<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Telas_Manutencao_GrupoResiduos_Consulta" Title="Untitled Page" %>

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
        </cc1:Filtro>
    <br />
    <cc2:Panel ID="Panel3" runat="server" HorizontalAlign="Right" Width="100%">
    
    
        <cc2:Button ID="btnNovo" runat="server" OnClick="btnNovo_Click" Text="Novo" />
        <cc2:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" /></cc2:Panel>
        <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
            <cc2:GridView id="gdvLista" runat="server" Width="100%" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False" >
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
        </cc2:GridView>
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="btnPesquisar" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>
    
</asp:Content>

