<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">user</td>
                <td>
                    <asp:TextBox ID="txt_user" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_user" ErrorMessage="usuario o contraceña incorrecta"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">password</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_password" ErrorMessage="usuario o contraceña incorrecta"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbl_resultado" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="SIGN IN" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
 </asp:Content>
