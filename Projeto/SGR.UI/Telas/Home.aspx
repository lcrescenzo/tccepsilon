<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Telas_Home" Title="Untitled Page" %>

<%@ Register Src="../Controles/GraficoPizza.ascx" TagName="GraficoPizza" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajax:ScriptManager ID="ScriptManager1" runat="server">
    </ajax:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="10" style="width: 100%; height: 100%">
        <tr>
            <td rowspan="3" valign="top">
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="tituloInfo">
                            <sgr:label id="Label1" runat="server">Movimentação</sgr:label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" cellpadding="2">
                                    <sgr:Repeater ID="rptMovimentacao" runat="server" OnItemDataBound="rptMovimentacao_ItemDataBound">
                                    <HeaderTemplate>
                                        <tr>
                                            <td>
                                                <sgr:Label ID="Label4" runat="server">CADRI</sgr:Label>
                                            </td>
                                            <td>
                                                <sgr:Label ID="Label5" runat="server">Resíduo</sgr:Label>
                                            </td>
                                            <td>
                                                <sgr:Label ID="Label6" runat="server">Transportado</sgr:Label>
                                            </td>
                                            <td>
                                                <sgr:Label ID="Label7" runat="server">Permitido</sgr:Label>
                                            </td>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <sgr:Panel ID="pnlMovimentacao" runat="server" Width="100%">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <sgr:Label ID="lblCadri" runat="server"></sgr:Label>
                                                            </td>
                                                            <td>
                                                                <sgr:Label ID="lblResiduo" runat="server"></sgr:Label>
                                                            </td>
                                                            <td>
                                                                <sgr:Label ID="lblUtilizados" runat="server"></sgr:Label>
                                                            </td>
                                                            <td>
                                                                <sgr:Label ID="lblPermitido" runat="server"></sgr:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </sgr:Panel>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    </sgr:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
    </TD>
    <td rowspan="3" valign="top">
                
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="tituloInfo">
                            <sgr:label id="Label2" runat="server">CADRI</sgr:label></td>
                    </tr>
                    <tr>
                        <td>
                        <table width="100%" cellpadding="2">
                                <tr>
                                    <sgr:Repeater ID="rptCadri" runat="server" OnItemDataBound="rptCadri_ItemDataBound">
                                    <ItemTemplate>
                                        
                                            <td>
                                                <sgr:Panel ID="pnlCadri" runat="server" Width="100%">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <sgr:Label ID="lblCadri" runat="server"></sgr:Label>
                                                            </td>
                                                            <td>
                                                                <sgr:Label ID="lblData" runat="server"></sgr:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </sgr:Panel>
                                            </td>
                                        
                                    </ItemTemplate>
                                    </sgr:Repeater>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                </table>
        </td>
        <td rowspan="3" valign="top" style="width: 225px">
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="tituloInfo">
                            <sgr:label id="Label3" runat="server">Resíduos</sgr:label></td>
                    </tr>
                    <tr>
                        <td class="tituloInfo">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <sgr:Label ID="Label8" runat="server">Meses:</sgr:Label><sgr:DropDownList ID="ddlMeses"
                                            runat="server">
                                            <asp:ListItem>1</asp:ListItem>
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
                                        </sgr:DropDownList></td>
                                    <td style="width: 10px">
                                    </td>
                                    <td style="width: 130px">
                                        <sgr:Label ID="Label9" runat="server">Qtd Resíduos::</sgr:Label><sgr:DropDownList
                                            ID="ddlQuantidade" runat="server">
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                        </sgr:DropDownList></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <sgr:Button ID="btnGerarGrafico" runat="server" OnClick="btnGerarGrafico_Click" Text="Gerar gráfico" /></td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />
                            <ajax:UpdatePanel id="UpdatePanel1" runat="server">
                                <contenttemplate>
                            <sgr:Image ID="imgGrafico" runat="server" Height="400px" Width="200px" />
                                </contenttemplate>
                                <triggers>
                                <ajax:AsyncPostBackTrigger ControlID="btnGerarGrafico" EventName="Click"></ajax:AsyncPostBackTrigger>
                                </triggers>
                            </ajax:UpdatePanel></td>
                    </tr>
                </table>
    </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
</asp:Content>

