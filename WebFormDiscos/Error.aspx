<%@ Page Title="" Language="C#" MasterPageFile="~/DiscosMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebFormDiscos.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Hubo un problema</h2>
    <asp:Label runat="server" ID="lblError"></asp:Label>
</asp:Content>
