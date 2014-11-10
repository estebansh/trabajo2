<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="agregar_pelicula.aspx.cs" Inherits="Pelicula_agregar_pelicula" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
        AGREGAR PELICULA<br />
        <br />
        <asp:Label ID="lbl_estado" runat="server"></asp:Label>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Nombre:</td>
                <td>
                    <asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nombre" ErrorMessage="INGRESE NOMBRE"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Descripcion:</td>
                <td>
                    <asp:TextBox ID="txt_descripcion" runat="server" Width="367px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_descripcion" ErrorMessage="INGRESE DESCRIPCION"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Año de estreno:</td>
                <td>
                    <asp:TextBox ID="txt_año" runat="server" TextMode="DateTime"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Idioma:</td>
                <td>
                    <asp:DropDownList ID="ddl_idioma" runat="server" DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="language_id">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sakilaConnectionString %>" SelectCommand="SELECT * FROM [language]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Duracion de la renta:</td>
                <td>
                    <asp:TextBox ID="txt_renta" runat="server" TextMode="Number" SkinID="##"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_renta" ErrorMessage="INGRESE DIAS DE LA RENTA"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Valorizacion de la pelicula:</td>
                <td>
                    <asp:TextBox ID="txt_rating" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_rating" ErrorMessage="INGRESE VALORIZACION"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Duracion:</td>
                <td>
                    <asp:TextBox ID="txt_duracion" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_duracion" ErrorMessage="INGRESE DURACION DE LA PELICULA"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Costo de la renta:</td>
                <td>
                    <asp:TextBox ID="txt_costo" runat="server" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_costo" ErrorMessage="INGRESE VALOR DE LA RENTA"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Clasificacion:</td>
                <td>
                    <asp:DropDownList ID="ddl_clasificacion" runat="server">
                        <asp:ListItem>NC-17</asp:ListItem>
                        <asp:ListItem>R</asp:ListItem>
                        <asp:ListItem>PG-13</asp:ListItem>
                        <asp:ListItem>PG</asp:ListItem>
                        <asp:ListItem>G</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Contenido especiales:</td>
                <td>
                    <asp:CheckBoxList ID="cbl_especial" runat="server">
                        <asp:ListItem>Trailers</asp:ListItem>
                        <asp:ListItem>Commentaries</asp:ListItem>
                        <asp:ListItem>Deleted Scenes</asp:ListItem>
                        <asp:ListItem>Behind the Scenes</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="cmd_Agregar" runat="server" Text="Agregar" OnClick="cmd_Agregar_Click" />
                </td>
                <td>
                    <asp:Button ID="cmd_Cancelar" runat="server" Text="Cancelar" OnClick="cmd_Cancelar_Click" />
                </td>
            </tr>
        </table>
    
    </div>
</asp:Content>