<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="arriendo.aspx.cs" Inherits="arriendo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 280px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style3">SELECCIONE PELICULA</td>
            <td>
                <asp:DropDownList ID="ddl_pelicula" runat="server" DataSourceID="SqlDataSource1" DataTextField="title" DataValueField="film_id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sakilaConnectionString %>" SelectCommand="SELECT [title], [film_id] FROM [film]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">SELECCIONE TIENDA</td>
            <td>
                    <asp:DropDownList ID="ddl_tienda" runat="server" DataSourceID="SqlDataSource2" DataTextField="address" DataValueField="store_id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sakilaConnectionString %>" SelectCommand="SELECT store.store_id, dbo.address.address FROM store INNER JOIN address ON store.address_id = address.address_id;"></asp:SqlDataSource>
                </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="txt_siguiente" runat="server" PostBackUrl="~/Arriendo/renta.aspx" Text="Siguiente" />
            </td>
            <td>
                <asp:Button ID="txt_Cancelar" runat="server" OnClick="txt_Cancelar_Click" Text="Cancelar" />
                <asp:Label ID="lbl_estado" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

