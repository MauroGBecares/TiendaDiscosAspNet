<%@ Page Title="" Language="C#" MasterPageFile="~/DiscosMaster.Master" AutoEventWireup="true" CodeBehind="Discos.aspx.cs" Inherits="WebFormDiscos.Discos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="cargarDiscos">
            <ItemTemplate>
                    <div class="col">
                        <div class="card mx-5">
                            <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Titulo") %></h5>
                                <p class="card-text">Fecha de lanzamiento: <%#Eval("FechaLanzamiento", "{0:dd/MM/yyyy}") %>.</p>
                                <asp:Button Text="Detalle" ID="btnDetalle" CssClass="btn btn-primary" runat="server" OnClick="btnDetalle_Click" CommandArgument='<%#Eval("Id") %>' CommandName="DiscoId" />
                            </div>
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
