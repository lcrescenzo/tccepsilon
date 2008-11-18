<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true" CodeFile="Manutencao.aspx.cs" Inherits="Telas_Manutencao_Residuos_Manutencao" Title="Untitled Page" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax" TagPrefix="cc2" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Common" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ajax:ScriptManager id="ScriptManager1" runat="server">
    </ajax:ScriptManager>
    <sgr:Label id="lblTitulo" SkinID="lblTitulo" runat="server" Text="Resíduos"></sgr:Label>&nbsp;<br />
        <br />
        &nbsp;
        &nbsp;
    <table style="width: 100%">
        <tr>
            <td style="width: 135px">
        <cc1:Label ID="Label2" runat="server" Font-Bold="True">Nome: </cc1:Label></td>
            <td colspan="3">
        <cc1:TextBox ID="txtNome" runat="server" Width="99%"></cc1:TextBox><cc1:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome" Display="None"
            ErrorMessage="Campo Nome Obrigatório" SetFocusOnError="True" ToolTip="Campo Nome Obrigatório"></cc1:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 135px">
        <cc1:Label ID="Label4" runat="server" Font-Bold="True" Width="134px">Unidade de medida:</cc1:Label></td>
            <td width="40%">
                <cc1:DropDownList
            ID="ddlUnidadeMedida" runat="server" Width="100%">
            <asp:ListItem Value="-1">Selecione...</asp:ListItem>
            <asp:ListItem Value="lts">
            </asp:ListItem>
            <asp:ListItem Value="kg">
            </asp:ListItem>
            <asp:ListItem Value="t">
            </asp:ListItem>
            <asp:ListItem Value="mc">m&#179;</asp:ListItem>
        </cc1:DropDownList><cc1:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlUnidadeMedida"
                    Display="None" ErrorMessage="Campo Unidade de Medida Obrigatório" ValueToCompare='-1' Operator="NotEqual"></cc1:CompareValidator></td>
            <td style="width: 120px">
        <cc1:Label ID="Label6" runat="server" Font-Bold="True">Classe: </cc1:Label></td>
            <td>
        <cc1:DropDownList ID="ddlClasse" runat="server" Width="100%">
        </cc1:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 135px">
        <cc1:Label id="Label3" runat="server" Font-Bold="True">Estado físico:</cc1:label></td>
            <td width="50%">
        <cc1:RadioButton id="rdbLiquido" runat="server" checked="True" groupname="grpEstadoFisico"
            text="Líquido"></cc1:radiobutton>
        <cc1:RadioButton id="rdbSolido" runat="server" groupname="grpEstadoFisico" text="Sólido"></cc1:radiobutton>
        <cc1:RadioButton id="rdbGasoso" runat="server" groupname="grpEstadoFisico" text="Gasoso"></cc1:radiobutton></td>
            <td style="width: 120px">
        <cc1:Label id="Label1" runat="server" Font-Bold="True" Width="117px">Tipo de Resíduo:</cc1:label></td>
            <td>
                <cc1:DropDownList id="ddlTipoResiduo" runat="server" Width="100%"></cc1:dropdownlist></td>
        </tr>
        <tr>
            <td style="width: 135px">
        <cc1:Label ID="Label5" runat="server" Font-Bold="True">Grupo de Resíduo:</cc1:Label></td>
            <td>
                <cc1:DropDownList id="ddlGrupoResiduo" runat="server" Width="100%">
        </cc1:DropDownList></td>
            <td style="width: 120px">
        <cc1:CheckBox ID="chkAuditoria" runat="server" Text="Auditoria" Checked="True" /></td>
            <td width="40%">
            </td>
        </tr>
    </table>
    <cc1:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br />
    <cc1:Button ID="btnGravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
    <cc1:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />
</asp:Content>

