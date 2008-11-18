<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Telas_Manutencao_Historico_Consulta" Title="Histórico" %>

<%@ Register Src="../../../Controles/Mensagem.ascx" TagName="Mensagem" TagPrefix="uc1" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax.Sistema"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <ajax:ScriptManager id="ScriptManager1" runat="server" />
        <sgr:Label id="lblTitulo" SkinID="lblTitulo" runat="server" Text="Histórico" ></sgr:Label><br />
        <br />
        <cc1:Filtro ID="Filtro1" runat="server" CollapsedImage="~/images/Padrao/mais.gif" ExpandedImage="~/images/Padrao/menos.gif">
            <MainControls>
                        <sgr:Label ID="Label2" runat="server" Text="Entidade: "></sgr:Label>
                <sgr:DropDownList ID="ddlEntidade" runat="server">
                    <asp:ListItem Value="1">Perfil</asp:ListItem>
                    <asp:ListItem Value="3">Tipo de Res&#237;duo</asp:ListItem>
                    <asp:ListItem Value="4">Grupo de Res&#237;duo</asp:ListItem>
                    <asp:ListItem Value="7">Cadri</asp:ListItem>
                    <asp:ListItem Value="8">Usuario</asp:ListItem>
                    <asp:ListItem Value="10">Res&#237;duo</asp:ListItem>
                    <asp:ListItem Value="11">Movimentacao</asp:ListItem>
                    <asp:ListItem Value="12">Transporte</asp:ListItem>
                </sgr:DropDownList>
                <sgr:Label ID="Label1" runat="server">Manutencao</sgr:Label>
                <sgr:DropDownList ID="ddlManutencao" runat="server">
                    <asp:ListItem Value="1">Incluir</asp:ListItem>
                    <asp:ListItem Value="2">Alterar</asp:ListItem>
                    <asp:ListItem Value="3">Excluir</asp:ListItem>
                </sgr:DropDownList>
            </MainControls>
            <AdvancedControls>
                        <sgr:Label ID="lblValidade" runat="server" Font-Bold="True">De:</sgr:Label>
                <sgr:TextBox ID="txtDe" runat="server"></sgr:TextBox>
                        <sgrAjax:Calendar ID="cldDe" runat="server" Enabled="True" TargetControlID="txtDe">
                        </sgrAjax:Calendar>
                <sgr:Label ID="Label4" runat="server" Font-Bold="True">Até:</sgr:Label>
                <sgr:TextBox ID="txtAte" runat="server"></sgr:TextBox>
                <sgrAjax:Calendar ID="cldAte" runat="server" Enabled="True" TargetControlID="txtAte">
                </sgrAjax:Calendar>
                        <sgr:Label ID="Label3" runat="server" Font-Bold="True">Usuário:</sgr:Label>
                <sgr:DropDownList ID="ddlUsuario" runat="server">
                </sgr:DropDownList>
            </AdvancedControls>
        </cc1:Filtro>
        <br />
        <sgr:Panel ID="Panel3" runat="server" HorizontalAlign="Right" Width="100%">
        <sgr:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" /></sgr:Panel>
        <br />
        <ajax:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <contenttemplate>
<sgr:GridView id="gdvLista" runat="server" Width="100%" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" ><Columns>
        <asp:BoundField DataField="Login" HeaderText="Login"></asp:BoundField>
        <asp:BoundField DataField="Data" HeaderText="Data da A&#231;&#227;o"></asp:BoundField>
        <asp:BoundField DataField="Manutencao" HeaderText="Manuten&#231;&#227;o"></asp:BoundField>
        <asp:BoundField DataField="Entidade" HeaderText="Entidade"></asp:BoundField>
    <asp:BoundField DataField="IdMantido" HeaderText="ID interno" />
</Columns>
</sgr:GridView> 
</contenttemplate>
        <triggers>
<ajax:AsyncPostBackTrigger ControlID="btnPesquisar" EventName="Click"></ajax:AsyncPostBackTrigger>
</triggers>
    </ajax:UpdatePanel>
    <uc1:Mensagem ID="Mensagem1" runat="server" />
</asp:Content>

