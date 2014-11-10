<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="agregar_cliente.aspx.cs" Inherits="Cliente_agregar_cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        AGREGAR CLIENTE<br />
        <br />
        <asp:Label ID="lbl_estado" runat="server"></asp:Label>
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Nombre:</td>
                <td>
                    <asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nombre" ErrorMessage="INGRESE NOMBRE"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Apellido:</td>
                <td>
                    <asp:TextBox ID="txt_apellido" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_apellido" ErrorMessage="INGRESE APELLIDO"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Direccion:</td>
                <td>
                    <asp:DropDownList ID="ddl_direccion" runat="server" DataSourceID="SqlDataSource1" DataTextField="address" DataValueField="address_id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sakilaConnectionString %>" SelectCommand="SELECT [address], [address_id] FROM [address]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Tienda:</td>
                <td>
                    <asp:DropDownList ID="ddl_tienda" runat="server" DataSourceID="SqlDataSource2" DataTextField="address" DataValueField="store_id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sakilaConnectionString %>" SelectCommand="SELECT store.store_id, dbo.address.address FROM store INNER JOIN address ON store.address_id = address.address_id;"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email:</td>
                <td>
                    <asp:TextBox ID="txt_correo" runat="server" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_correo" ErrorMessage="INGRESE EMAIL"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="cmd_Agregar" runat="server" OnClick="cmd_Agregar_Click" Text="Agregar" />
                </td>
                <td>
                    <asp:Button ID="cmd_Cancelar" runat="server" OnClick="cmd_Cancelar_Click" Text="Cancelar" />
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>


