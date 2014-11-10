<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="nomina_cliente.aspx.cs" Inherits="Cliente_nomina_cliente" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <body>
    <div>
        NOMINA CLIENTES<br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="customer_id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="first_name" HeaderText="Nombre" SortExpression="first_name" />
                <asp:BoundField DataField="last_name" HeaderText="Apellido" SortExpression="last_name" />
                <asp:BoundField DataField="email" HeaderText="Correo" SortExpression="email" />
                <asp:BoundField DataField="address" HeaderText="Direccion" SortExpression="address" />
                <asp:HyperLinkField DataNavigateUrlFields="customer_id" DataNavigateUrlFormatString="modificar_cliente.aspx?c={0}" Text="Actualizar" />
                <asp:HyperLinkField DataNavigateUrlFields="customer_id" DataNavigateUrlFormatString="eliminar_cliente.aspx?c={0}" Text="Eliminar" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sakilaConnectionString %>" SelectCommand="SELECT customer.first_name, customer.last_name, customer.email, address.address, customer.customer_id FROM customer INNER JOIN address ON customer.address_id = address.address_id"></asp:SqlDataSource>
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Cliente/agregar_cliente.aspx">Agregar cliente</asp:HyperLink>

        &nbsp;&nbsp;&nbsp;

        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Pelicula/nomina_Pelicula.aspx">Nomina pelicula</asp:HyperLink>
    </div>
</body>
</asp:Content>

