<%@ Page Title="" Language="C#" MasterPageFile="~/DiscosMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebFormDiscos.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center">Detalles:</h2>
    <div class="container">
        <div class="row">
            <div class="col-3"></div>
            <div class="col-sm-6">
                <div class="card mb-3 text-center">
                    <img src="<%: discoDetalle.UrlImagen %>" class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title"><%: discoDetalle.Titulo %></h5>
                        <p class="card-text">Cantidad de canciones: <%: discoDetalle.CantidadCanciones %></p>
                        <p class="card-text">Estilo: <%: discoDetalle.Estilo.Descripcion %></p>
                        <p class="card-text">Formato: <%: discoDetalle.Formato.Descripcion %></p>
                        <p class="card-text"><small class="text-body-secondary">Fecha de lanzamiento: <%: discoDetalle.FechaLanzamiento.ToString("dd/MM/yyyy") %></small></p>
                    </div>
                </div>
                <a class="icon-link text-center" href="Discos.aspx">Regresar</a>
            </div>
            <div class="col-3"></div>
        </div>
</asp:Content>
