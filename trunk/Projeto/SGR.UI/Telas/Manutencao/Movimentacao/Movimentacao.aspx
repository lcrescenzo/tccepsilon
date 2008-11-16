<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master/MasterGeral.master"
    CodeFile="Movimentacao.aspx.cs" Inherits="Telas_Manutencao_Movimentacao_Movimentacao" %>
<%@ Register Src="../../../Controles/Confirm.ascx" TagName="Confirm" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <sgr:Label id="lblTitulo" runat="server" Text="Movimentação"></sgr:Label>
        <br />
        <br />
    <script src="../../../Script/Telas.js" type="text/javascript"></script>

    <ajax:ScriptManager ID="ScriptManager1" runat="server">
    </ajax:ScriptManager>
    <table style="width: 100%">
        <tr>
            <td>
                <ajax:UpdatePanel ID="updResiduo" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%">
                            <tbody>
                                <tr>
                                    <td width="50">
                                        <sgr:Label ID="lblResiduo" runat="server">Resíduo:</sgr:Label>
                                    </td>
                                    <td>
                                        <sgr:DropDownList DataTextField="Nome" DataValueField="ID" ID="ddlResiduo" runat="server"
                                            Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlResiduo_SelectedIndexChanged">
                                        </sgr:DropDownList>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <ajax:AsyncPostBackTrigger ControlID="ddlCadri" EventName="SelectedIndexChanged"></ajax:AsyncPostBackTrigger>
                    </Triggers>
                </ajax:UpdatePanel>
            </td>
            <td>
                <ajax:UpdatePanel ID="updCadri" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td width="50">
                                    <sgr:Label ID="Label1" runat="server">CADRI:</sgr:Label></td>
                                <td>
                                    <sgr:DropDownList DataTextField="Numero" DataValueField="ID" ID="ddlCadri" runat="server"
                                        Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlCadri_SelectedIndexChanged">
                                    </sgr:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <ajax:AsyncPostBackTrigger ControlID="ddlResiduo" EventName="SelectedIndexChanged"></ajax:AsyncPostBackTrigger>
                    </Triggers>
                </ajax:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <ajax:UpdatePanel ID="updNovoTransporte" runat="server">
                    <ContentTemplate>
                        <sgr:Panel ID="pnlNovoTransporte" runat="server" Width="100%" Visible="false">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <sgr:Label ID="Label2" runat="server">Data:</sgr:Label>
                                    </td>
                                    <td colspan="3">
                                        <sgr:TextBox ID="txtData" runat="server"></sgr:TextBox><sgrAjax:Calendar ID="Calendar1" runat="server" TargetControlID="txtData">
                                        </sgrAjax:Calendar>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="70">
                                        <sgr:Label ID="lblQuantidade" runat="server">Quantidade:</sgr:Label>
                                    </td>
                                    <td colspan="3">
                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <sgr:TextBox ID="txtQuantidade" runat="server"></sgr:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <sgr:Label ID="lblUnidadeMedida" runat="server"></sgr:Label>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                    <td style="width: 95px">
                                                        <sgr:Label ID="lblTransportadosText" runat="server" >Transportados:</sgr:Label>
                                                    </td>
                                                    <td>
                                                        <sgr:Label ID="lblTransportados" runat="server"></sgr:Label>
                                                    </td>
                                                    <td style="width: 67px">
                                                        <sgr:Label ID="lblPermitidoText" runat="server">Permitido:</sgr:Label>
                                                    </td>
                                                    <td>
                                                        <sgr:Label ID="lblPermitido" runat="server"></sgr:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="70">
                                        <sgr:Label ID="Label3" runat="server">Transportadora:</sgr:Label>
                                    </td>
                                    <td colspan="3">
                                        <sgr:TextBox ID="txtTransportadora" runat="server" Width="99%"></sgr:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="4">
                                        <sgr:Button ID="btnGravar" OnClick="btnGravar_Click" runat="server" Text="Gravar" ></sgr:Button>
                                        <sgr:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click">
                                        </sgr:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="70">
                                    </td>
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <sgr:Label ID="Label4" runat="server">Últimos transportes</sgr:Label></td>
                                                    <td style="width: 6px">
                                                    </td>
                                                    <td align="right">
                                                        &nbsp;</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <sgr:GridView ID="gdvUtimosTransportes" runat="server" Width="100%" OnRowDataBound="GridView1_RowDataBound"
                                            AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="Data" HeaderText="Data"></asp:BoundField>
                                                <asp:BoundField DataField="Quantidade" HeaderText="Qtde"></asp:BoundField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
                                                        <sgr:ImageButton id="imgEditar" runat="server" Text="Editar" OnCommand="imgEditar_Command" CommandName="0" ImageUrl="~/Images/Padrao/editar.gif" CausesValidation="false" ></sgr:ImageButton> 
                                                    
</itemtemplate>
                                                    <itemstyle width="20px"></itemstyle>
                                                </asp:TemplateField>
                                                <asp:TemplateField ShowHeader="False">
                                                    <itemtemplate>
<sgr:ImageButton id="imgExcluir" runat="server" Text="Excluir" CausesValidation="false" ImageUrl="~/Images/Padrao/excluir.gif" CommandName="1" OnCommand="imgExcluir_Command" __designer:wfdid="w2"></sgr:ImageButton> 
</itemtemplate>
                                                    <itemstyle width="20px"></itemstyle>
                                                </asp:TemplateField>
                                            </Columns>
                                        </sgr:GridView>
                                    </td>
                                </tr>
                            </table>
                        </sgr:Panel>
                    </ContentTemplate>
                </ajax:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
    <uc1:Confirm ID="Confirm" runat="server" />
</asp:Content>
