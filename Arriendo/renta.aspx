<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="renta.aspx.cs" Inherits="renta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 168px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style3">NOMBRE DEL CLIENTE</td>
            <td>
                <asp:DropDownList ID="ddl_cliente" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="ID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sakilaConnectionString %>" SelectCommand="SELECT [ID], [name] FROM [customer_list]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">ADMINISTRADOR</td>
            <td>
                <asp:DropDownList ID="ddl_staff" runat="server" DataSourceID="SqlDataSource2" DataTextField="name" DataValueField="ID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sakilaConnectionString %>" SelectCommand="SELECT [name], [ID] FROM [staff_list]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">FECHA</td>
            <td>
                <asp:Calendar ID="cld_devolucion" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lbl_estado" runat="server"></asp:Label>
                <asp:HiddenField ID="hdn_idinventory" runat="server" />
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="txt_siguiente" runat="server" PostBackUrl="~/Arriendo/pago.aspx" Text="Siguiente" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="txt_cancelar" runat="server" OnClick="txt_cancelar_Click" Text="Cancelar" />
            </td>
        </tr>
    </table>
</asp:Content>

