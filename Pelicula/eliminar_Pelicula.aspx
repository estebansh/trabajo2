<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="eliminar_Pelicula.aspx.cs" Inherits="eliminar_Pelicula" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        ¿Desea eliminar la pelicula?<br />
        <br />
        <asp:Label ID="lbl_estado" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="cmd_Eliminar" runat="server" OnClick="cmd_Eliminar_Click" Text="Eliminar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="cmd_Cancelar" runat="server" OnClick="cmd_Cancelar_Click" Text="Cancelar" />
    
    </div>
</asp:Content>
