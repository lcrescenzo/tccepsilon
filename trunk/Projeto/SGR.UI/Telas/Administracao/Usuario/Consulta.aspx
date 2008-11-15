<%@ Page Language="C#" MasterPageFile="~/Master/MasterGeral.master" AutoEventWireup="true"
    CodeFile="Consulta.aspx.cs" Inherits="Telas_Administracao_Usuario_Consulta" Title="Untitled Page" %>
<%@ Register Assembly="SGR.Web.Controls" Namespace="SGR.Web.Controls.Ajax.Sistema"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajax:ScriptManager ID="ScriptManager1" runat="server" />
        <sgr:Label id="lblTitulo" runat="server" Text="Usuário"></sgr:Label>
        <br />
        <br />

    <cc1:Filtro ID="Filtro1" runat="server" CollapsedImage="~/images/Padrao/mais.gif"
        ExpandedImage="~/images/Padrao/menos.gif">
        <MainControls>
            <sgr:Label ID="lblNome" runat="server" Text="Nome: "></sgr:Label>
            <sgr:TextBox ID="txtNome" runat="server" Width="100%"></sgr:TextBox>
        </MainControls>
        <AdvancedControls>
            <table border="0" cellpadding="3" cellspacing="0" width="100%">
                <tr>
                    <td width="80">
                        <sgr:Label ID="Label2" runat="server" Font-Bold="True">E-mail: </sgr:Label></td>
                    <td colspan="5" rowspan="1">
                        <sgr:TextBox ID="txtEmail" runat="server" Width="99%">
                        </sgr:TextBox></td>
                </tr>
                <tr>
                    <td width="80">
                        <sgr:Label ID="Label3" runat="server" Font-Bold="True">Usuário: </sgr:Label></td>
                    <td width="110">
                        <sgr:TextBox ID="txtUsuario" runat="server" Width="140px">
                        </sgr:TextBox></td>
                    <td>
                        <sgr:Label ID="lblPerfil" runat="server" Font-Bold="True">Perfil: </sgr:Label></td>
                    <td>
                        <sgr:DropDownList ID="ddlPerfil" runat="server" Width="306px">
                        </sgr:DropDownList></td>
                    <td width="80">
                        <sgr:Label ID="Label7" runat="server" Font-Bold="True">Telefone: </sgr:Label></td>
                    <td width="110">
                        <sgr:TextBox ID="txtTelefone" runat="server" Width="110px">
                        </sgr:TextBox></td>
                </tr>
            </table>
        </AdvancedControls>
    </cc1:Filtro>
    <br />
    <sgr:Panel ID="Panel3" runat="server" HorizontalAlign="Right" Width="100%">
        <sgr:Button ID="btnNovo" runat="server" OnClick="btnNovo_Click" Text="Novo" />
        <sgr:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" /></sgr:Panel>
    <br />
    <ajax:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <sgr:GridView ID="gdvLista" runat="server" Width="100%" OnRowDataBound="GridView1_RowDataBound"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Nome" HeaderText="Nome"></asp:BoundField>
                    <asp:BoundField DataField="Email" HeaderText="E-mail"></asp:BoundField>
                    <asp:TemplateField ShowHeader="False">
                        <itemtemplate>
                    <sgr:ImageButton runat="server" Text="Apagar senha" CommandName="2" CausesValidation="false" id="imgApagar" ImageUrl="~/Images/Padrao/apagar.gif" OnCommand="imgApagar_Command"></sgr:ImageButton>
                </itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <itemtemplate>
                   <sgr:ImageButton id="imgEditar" runat="server" Text="Editar" CausesValidation="false" ImageUrl="~/Images/Padrao/editar.gif" CommandName="0" OnCommand="imgEditar_Command"></sgr:ImageButton> 
                                    
                </itemtemplate>
                        <itemstyle width="20px"></itemstyle>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <itemtemplate>
                    <sgr:ImageButton id="imgExcluir" runat="server" Text="Excluir" CausesValidation="false" ImageUrl="~/Images/Padrao/excluir.gif" CommandName="1" OnCommand="imgExcluir_Command" ></sgr:ImageButton> 
                                    
                </itemtemplate>
                        <itemstyle width="20px"></itemstyle>
                    </asp:TemplateField>
                </Columns>
            </sgr:GridView>
        </ContentTemplate>
        <Triggers>
            <ajax:AsyncPostBackTrigger ControlID="btnPesquisar" EventName="Click"></ajax:AsyncPostBackTrigger>
        </Triggers>
    </ajax:UpdatePanel>
</asp:Content>
