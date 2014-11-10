<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="pago.aspx.cs" Inherits="Arriendo_pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 232px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style3">NOMBRE DEL CLIENTE</td>
            <td>
                <asp:Label ID="lbl_nombre" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">NOMBRE DEL ADMINITRADOR</td>
            <td>
                <asp:Label ID="lbl_staff" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">PRECIO</td>
            <td>
                <asp:TextBox ID="txt_precio" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">FECHA</td>
            <td>
                <asp:Calendar ID="cld_fechaPago" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="cmd_arrendar" runat="server" OnClick="cmd_arrendar_Click" Text="ARRENDAR" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="cancelar" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lbl_estado" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:HiddenField ID="hdn_renta" runat="server" />
                <asp:HiddenField ID="hdn_cliente" runat="server" />
                <asp:HiddenField ID="hdn_staff" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

