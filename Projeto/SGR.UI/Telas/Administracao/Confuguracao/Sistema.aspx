<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="Sistema.aspx.cs" Inherits="Telas_Administracao_Confuguracao_Sistema"
    Title="Untitled Page" %>

<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Common" TagPrefix="cc3" %>
<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit, Version=1.0.20229.20821, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Src="UserControl/TabelaDominio.ascx" TagName="TabelaDominio" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <cc1:TabContainer ID="tbcSistemas" runat="server" ActiveTabIndex="1">
        <cc2:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <headertemplate>
            Gerais
            
</headertemplate>
        </cc2:TabPanel>
        <cc2:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <headertemplate>
            Tabelas
            
</headertemplate>
            <contenttemplate>
<TABLE width="100%"><TBODY><TR><TD><cc3:Label id="Label1" runat="server" __designer:wfdid="w8">Tipo de Resíduo</cc3:Label> </TD><TD style="WIDTH: 100px"><cc3:Label id="Label2" runat="server" __designer:wfdid="w8" Width="138px">Classe</cc3:Label></TD></TR><TR><TD><asp:UpdatePanel id="UpdatePanel1" runat="server" __designer:wfdid="w1"><ContentTemplate>
<uc1:TabelaDominio id="tbdTipoResiduo" runat="server" OnRemover="tbdTipoResiduo_Remover" OnEditar="tbdTipoResiduo_Editar" OnAdicionar="tbdTipoResiduo_Adicionar" ></uc1:TabelaDominio>
</ContentTemplate>
</asp:UpdatePanel> </TD><TD style="WIDTH: 50%"><asp:UpdatePanel id="UpdatePanel2" runat="server" __designer:wfdid="w13"><ContentTemplate>
<uc1:TabelaDominio id="tbdClasse" runat="server" OnRemover="tbdClasse_Remover" OnEditar="tbdClasse_Editar" OnAdicionar="tbdClasse_Adicionar" ></uc1:TabelaDominio> 
</ContentTemplate>
</asp:UpdatePanel></TD></TR></TBODY></TABLE>
</contenttemplate>
        </cc2:TabPanel>
    </cc1:TabContainer>
</asp:Content>
