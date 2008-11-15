<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListaResiduos.ascx.cs" Inherits="Controles_ListaResiduos" %>
<%@ Register Src="List.ascx" TagName="List" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit, Version=1.0.20229.20821, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc3" %>
<table width="100%">
    <tr>
        <td colspan="2">
            <sgrAjax:TabContainer id="TabContainer1" runat="server" ActiveTabIndex="0">
                <cc3:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td>
                                    <sgr:DropDownList id="ddlResiduo" runat="server" Width="100%"></sgr:DropDownList>
                                </td>
                                <td width="70">
                                    <sgr:Button id="btnAdicionarResiduo" onclick="btnAdicionarResiduo_Click" runat="server" Text="Adicionar"></sgr:Button>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <HeaderTemplate>
                        Resíduo
                    </HeaderTemplate>
                </cc3:TabPanel>
                <cc3:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2" Visible="False">
                    <HeaderTemplate>
                        Grupo de Resíduos
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td style="width: 80px">
                                    <sgr:DropDownList id="ddlGrupoResiduo" runat="server">
                                    </sgr:DropDownList>
                                </td>
                                <TD width=70>
                                    <sgr:Button ID="btnAdicionarGrupo" runat="server" Text="Adicionar" OnClick="btnAdicionarGrupo_Click" /></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc3:TabPanel>
            </sgrAjax:TabContainer>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <uc1:List ID="lstResiduos" runat="server" />
        </td>
    </tr>
</table>
