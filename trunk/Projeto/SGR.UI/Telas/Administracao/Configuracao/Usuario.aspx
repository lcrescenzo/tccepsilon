<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true"
    CodeFile="Usuario.aspx.cs" Inherits="Telas_Administracao_Configuracao_Usuario"
    Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit, Version=1.0.20229.20821, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajax:ScriptManager ID="ScriptManager1" runat="server">
    </ajax:ScriptManager>
        <sgr:Label id="lblTitulo" runat="server" Text="Configuração do Usuário"></sgr:Label>
        <br />
        <br />

    <sgrAjax:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <sgrAjax:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Avisos
            </HeaderTemplate>
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td colspan="2">
                            <sgr:Label ID="Label4" runat="server">Mostrar as movimentações onde seu total transportado esteja acima de</sgr:Label>
                            <sgr:TextBox ID="txtMovimentacoes" runat="server" Width="30px">80</sgr:TextBox>
                            <sgr:Label ID="Label5" runat="server" >% do permitido.</sgr:Label>
                        </td>
                    </tr>
                    <tr >
                        <td colspan="2" >
                        </td>
                    </tr>
                    <tr >
                        <td colspan="2">
                            <sgr:Label ID="Label6" runat="server">Mostrar os CADRIs que estejam a </sgr:Label>
                            <sgr:TextBox ID="txtCADRI" runat="server" Width="30px">30</sgr:TextBox>
                            <sgr:Label ID="Label7" runat="server" >dias de acabar o prazo de validade.</sgr:Label>
                        </td>
                    </tr>
                    <tr >
                        <td colspan="2" >
                        </td>
                    </tr>
                    <tr >
                        <td colspan="2" >
                            <fieldset>
                                <legend >
                                    <sgr:Label ID="Label8" runat="server"  >Gráfico</sgr:Label>
                                </legend>
                                <sgr:Label ID="Label9" runat="server" >Meses:</sgr:Label>
                                <sgr:DropDownList ID="ddlMesesGrafico" runat="server" >
                                    <asp:ListItem >1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem Selected="True">3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </sgr:DropDownList>
                                <sgr:Label ID="Label10" runat="server">Quantidade de residuos: </sgr:Label>
                                <sgr:DropDownList ID="ddlQtdResiduos" runat="server">
                                    <asp:ListItem >10</asp:ListItem>
                                    <asp:ListItem >9</asp:ListItem>
                                    <asp:ListItem >8</asp:ListItem>
                                    <asp:ListItem >7</asp:ListItem>
                                    <asp:ListItem >6</asp:ListItem>
                                    <asp:ListItem >5</asp:ListItem>
                                    <asp:ListItem >4</asp:ListItem>
                                    <asp:ListItem >3</asp:ListItem>
                                    <asp:ListItem >2</asp:ListItem>
                                    <asp:ListItem >1</asp:ListItem>
                                </sgr:DropDownList></fieldset>
                        </td>
                    </tr>
                    </TBODY></table>
            </ContentTemplate>
        </sgrAjax:TabPanel>
    </sgrAjax:TabContainer>
    <table style="width: 100%">
        <tr>
            <td align="right" style="height: 26px">
                <sgr:Button ID="btnGravar" runat="server" Text="Gravar configurações" OnClick="btnGravar_Click" /></td>
        </tr>
    </table>
</asp:Content>
