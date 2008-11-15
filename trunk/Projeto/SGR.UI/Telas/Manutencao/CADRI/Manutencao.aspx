<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Manutencao.aspx.cs" Inherits="Telas_Manutencao_CADRI_Manutencao" Title="Untitled Page" %>

<%@ Register Src="../../../Controles/ListaResiduos.ascx" TagName="ListaResiduos"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajax:ScriptManager id="ScriptManager1" runat="server">
    </ajax:ScriptManager>
    <script language="javascript" src="../../../Script/Telas.js"></script>
        <sgr:Label id="lblTitulo" runat="server" Text="CADRI"></sgr:Label>
    <br />
    <br />
    <table width="100%">
        <tr>
            <td colspan="4" rowspan="5" valign="top">
                <sgr:Panel ID="Panel1" runat="server" Height="100%">
                    <table>
                        <tr>
                            <td style="width: 100px">
                <sgr:Label ID="Label1" runat="server" Font-Bold="True">Número:</sgr:Label></td>
                            <td colspan="3">
                <sgr:TextBox ID="txtNumero" runat="server" Width="98%"></sgr:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                <sgr:Label ID="Label3" runat="server" Font-Bold="True">Destino:</sgr:Label></td>
                            <td colspan="3">
                <sgr:TextBox ID="txtDestino" runat="server" Width="98%"></sgr:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                <sgr:Label ID="Label4" runat="server" Font-Bold="True">Quantidade:</sgr:Label></td>
                            <td colspan="3">
                <sgr:TextBox ID="txtQuantidade" runat="server" Width="98%"></sgr:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                <sgr:Label ID="Label5" runat="server" Font-Bold="True">OI:</sgr:Label></td>
                            <td style="width: 100px">
                <sgr:TextBox ID="txtOI" runat="server" ></sgr:TextBox></td>
                            <td style="width: 100px">
                <sgr:Label ID="Label6" runat="server" Font-Bold="True">Validade:</sgr:Label></td>
                            <td style="width: 100px">
                                <sgrAjax:Calendar ID="cldValidade"
                    runat="server" TargetControlID="txtValidade">
                </sgrAjax:Calendar>
                <sgr:TextBox ID="txtValidade" runat="server"></sgr:TextBox></td>
                        </tr>
                    </table>
                </sgr:Panel>
            </td>

            <td rowspan="6" width="50%" valign="top">
                <uc1:ListaResiduos ID="lstResiduo" runat="server" />
            </td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
    &nbsp;<br />
    <sgr:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
    <sgr:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Content>

