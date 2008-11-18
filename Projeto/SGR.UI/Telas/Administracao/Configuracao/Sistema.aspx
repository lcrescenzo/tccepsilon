<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="Sistema.aspx.cs" Inherits="Telas_Administracao_Configuracao_Sistema"
    Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit, Version=1.0.20229.20821, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="UserControl/TabelaDominio.ascx" TagName="TabelaDominio" TagPrefix="uc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../../Script/Telas.js" type="text/javascript"></script>
    
    <ajax:ScriptManager ID="ScriptManager1" runat="server">
    </ajax:ScriptManager>
    <sgr:Label id="lblTitulo" SkinID="lblTitulo" runat="server" Text="Configuração do Sistema"></sgr:Label>
    <br />
    <br />
    <sgrAjax:TabContainer ID="tbcSistemas" runat="server" ActiveTabIndex="2">
        <sgrAjax:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Gerais
            </HeaderTemplate>
            <ContentTemplate>
                <fieldset ><legend>
                    <sgr:Label ID="Label3" runat="server">Avisos</sgr:Label></legend>
                    <table width="100%">
                        <tr>
                            <td colspan="2">
                                <sgr:Label ID="Label4" runat="server">Mostrar as movimentações onde seu total transportado esteja acima de</sgr:Label>
                                <sgr:TextBox ID="txtMovimentacoes" runat="server" Width="30px">80</sgr:TextBox><sgr:Label ID="Label5"
                                    runat="server">% do permitido.</sgr:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <sgr:Label ID="Label6" runat="server">Mostrar os CADRIs que estejam a </sgr:Label>
                                <sgr:TextBox ID="txtCADRI" runat="server" Width="30px">30</sgr:TextBox><sgr:Label ID="Label7"
                                    runat="server">dias de acabar o prazo de validade.</sgr:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <fieldset><legend><sgr:Label ID="Label8" runat="server">Gráfico</sgr:Label></legend>
                                    <sgr:Label ID="Label9" runat="server">Meses:</sgr:Label> <sgr:DropDownList ID="ddlMesesGrafico" runat="server">
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
                                    </sgr:DropDownList>
                                    <sgr:Label ID="Label10" runat="server">Quantidade de residuos: </sgr:Label>
                                    <sgr:DropDownList ID="ddlQtdResiduos" runat="server">
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem Value="9">
                                        </asp:ListItem>
                                        <asp:ListItem Value="8">
                                        </asp:ListItem>
                                        <asp:ListItem Value="7">
                                        </asp:ListItem>
                                        <asp:ListItem Value="6">
                                        </asp:ListItem>
                                        <asp:ListItem Value="5">
                                        </asp:ListItem>
                                        <asp:ListItem Value="4">
                                        </asp:ListItem>
                                        <asp:ListItem Value="3">
                                        </asp:ListItem>
                                        <asp:ListItem Value="2">
                                        </asp:ListItem>
                                        <asp:ListItem Value="1">
                                        </asp:ListItem>
                                    </sgr:DropDownList></fieldset>
                                </td>
                        </tr>
                    </table>
                    
                </fieldset>
            </ContentTemplate>
        </sgrAjax:TabPanel>
        <sgrAjax:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>
                Tabelas
            </HeaderTemplate>
            <ContentTemplate>
                <table width="100%">
                    <tbody>
                        <tr>
                            <td>
                                <sgr:Label ID="Label1" runat="server">Tipo de Resíduo</sgr:Label>
                            </td>
                            <td style="width: 100px">
                                <sgr:Label ID="Label2" runat="server" Width="138px">Classe</sgr:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <ajax:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <uc1:TabelaDominio ID="tbdTipoResiduo" runat="server" OnRemover="tbdTipoResiduo_Remover"
                                            OnEditar="tbdTipoResiduo_Editar" OnAdicionar="tbdTipoResiduo_Adicionar"></uc1:TabelaDominio>
                                    </ContentTemplate>
                                </ajax:UpdatePanel>
                            </td>
                            <td style="width: 50%">
                                <ajax:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <uc1:TabelaDominio ID="tbdClasse" runat="server" OnRemover="tbdClasse_Remover" OnEditar="tbdClasse_Editar"
                                            OnAdicionar="tbdClasse_Adicionar"></uc1:TabelaDominio>
                                    </ContentTemplate>
                                </ajax:UpdatePanel>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </sgrAjax:TabPanel>
        <sgrAjax:TabPanel ID="TabPanel1" runat="server" HeaderText="Apar&#234;ncia">
            <contenttemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <sgr:Label id="Label11" runat="server">Logotipo</sgr:Label></td>
                        <td>
                            <sgr:Label ID="Label12" runat="server">Cor do Topo:</sgr:Label>
                            <select style="font-size: 10px; width: 120px; height: 18px" id="ddlCor" runat="server">
                                <option style="background-color:green;" value="green" selected="selected"></option>
                                <option style="background-color:lime;" value="lime"></option>
                                <option style="background-color:teal;" value="teal"></option>
                                <option style="background-color:aqua;" value="aqua"></option>
                                <option style="background-color:navy;" value="navy"></option>
                                <option style="background-color:blue;" value="blue"></option>
                                <option style="background-color:purple;" value="purple"></option>
                                <option style="background-color:fuchsia;" value="fuchsia"></option>
                                <option style="background-color:maroon;" value="maroon"></option>
                                <option style="background-color:red;" value="red"></option>
                                <option style="background-color:olive;" value="olive"></option>
                                <option style="background-color:yellow;" value="yellow"></option>
                                <option style="background-color:white;" value="white"></option>
                                <option style="background-color:silver;" value="silver"></option>
                                <option style="background-color:gray;" value="gray"></option>
                                <option style="background-color:black;" value=""></option>
                                <option style="background-color:#336699;" value="#336699"></option>
                                <option style="background-color:#ff9933;" value="#ff9933" ></option>
                                <option style="background-color:#66ff66;" value="#66ff66"></option>
                                <option style="background-color:lightskyblue" value="lightskyblue"></option>
                                <option style="background-color:#ffffcc;" value="#ffffcc"></option>
                                <option style="background-color:#cc66ff;" value="#cc66ff"></option>
                                <option style="background-color:#66ffcc;" value="#66ffcc"></option>
                                <option style="background-color:orange;" value="orange"></option>
                                <option style="background-color:tan;" value="tan"></option>
                             </select>

                      </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <sgr:FileUpload ID="fluLogo" runat="server" Width="100%" /></td>
                        <td rowspan="5" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="4" width="50%" style="height: 82px" valign="top">
                            <table style="width: 178px">
                                <tr>
                                    <td style="width: 20px">
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td rowspan="2">
                                    </td>
                                    <td rowspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20px">
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20px">
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td style="width: 20px">
                                    </td>
                                    <td colspan="2">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                        <td colspan="2" >
                                
                                <sgr:Panel ID="pnlTopo" runat="server" Height="100px" Width="100%">
                                    <img id="imgView" src="" style="position: relative" runat="server" /></sgr:Panel>
                        </td>
                    </tr>
                </table>
                <div style="text-align: right">
                    </div>
            </contenttemplate>
            <headertemplate>
                Aparência
            </headertemplate>
        </sgrAjax:TabPanel>
    </sgrAjax:TabContainer><br />
                    <table style="width: 100%">
                        <tr>
                            <td align="right">
                                <sgr:Button ID="btnGravar" runat="server" OnClick="btnGravar_Click" Text="Gravar Alterações" CausesValidation="False" /></td>
                        </tr>
                    </table>
</asp:Content>
