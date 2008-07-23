<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Telas_Manutencao_Residuos_Consulta" Title="Untitled Page" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax" TagPrefix="cc3" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Common" TagPrefix="cc2" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax.Sistema"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server" />
    <center>
        <cc1:Filtro ID="Filtro1" runat="server" CollapsedImage="~/images/Padrao/mais.gif" ExpandedImage="~/images/Padrao/menos.gif">
            <MainControls>
                <cc2:TextBox ID="TextBox1" runat="server"></cc2:TextBox>
            </MainControls>
            <AdvancedControls>
                <cc2:Label ID="Label1" runat="server">Teste</cc2:Label>
                <cc2:TextBox ID="TextBox2" runat="server"></cc2:TextBox>
            </AdvancedControls>
        </cc1:Filtro>
        &nbsp;
        <cc2:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Text" />
        <cc2:Label ID="Label2" runat="server"></cc2:Label>
        <cc2:Panel ID="Panel1" runat="server" BorderWidth="1px">
        </cc2:Panel>
    </center>
    <cc3:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" Corners="All" TargetControlID="Panel1">
    </cc3:RoundedCornersExtender>

</asp:Content>

