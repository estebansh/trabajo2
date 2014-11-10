<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="nomina_Pelicula.aspx.cs" Inherits="nomina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        NOMINA PELICULAS<br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="film_id" DataSourceID="SqlDataSource1" Height="114px" Width="554px">
            <Columns>
                <asp:BoundField DataField="title" HeaderText="pelicula" SortExpression="title" />
                <asp:BoundField DataField="description" HeaderText="descripcion" SortExpression="description" />
                <asp:BoundField DataField="release_year" HeaderText="año lanzamiento" SortExpression="release_year" />
                <asp:BoundField DataField="name" HeaderText="lenguaje" SortExpression="name" />
                <asp:BoundField DataField="rating" HeaderText="categoria" SortExpression="rating" />
                <asp:BoundField DataField="special_features" HeaderText="Contenido especial" SortExpression="special_features" />
                <asp:HyperLinkField DataNavigateUrlFields="film_id" DataNavigateUrlFormatString="modificar_pelicula.aspx?c={0}" Text="Actualizar" />
                <asp:HyperLinkField DataNavigateUrlFields="film_id" DataNavigateUrlFormatString="eliminar_Pelicula.aspx?c={0}" Text="Eliminar" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sakilaConnectionString %>" SelectCommand="SELECT film.film_id, film.title, film.description, film.release_year,film.rating,film.special_features, category.name  FROM film INNER JOIN language AS category ON film.language_id = category.language_id"></asp:SqlDataSource>
    
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Pelicula/agregar_pelicula.aspx">Agregar Pelicula</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Cliente/nomina_cliente.aspx">Nomina Clientes</asp:HyperLink>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Arriendo/arriendo.aspx">Arrendar pelicula</asp:HyperLink>
        <br />
</asp:Content>
