<%@ Page Title="" Language="C#" MasterPageFile="~/DiscosMaster.Master" AutoEventWireup="true" CodeBehind="FormularioDiscos.aspx.cs" Inherits="WebFormDiscos.FormularioDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtId" class="form-label">Id</label>
                    <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtTitulo" class="form-label">Nombre: </label>
                    <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtFecha" class="form-label">Fecha: </label>
                    <asp:TextBox runat="server" TextMode="Date" ID="txtFecha" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtCantCanciones" class="form-label">Cantidad de canciones: </label>
                    <asp:TextBox runat="server" ID="txtCantCanciones" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="ddlEstilo" class="form-label">Estilo:</label>
                    <asp:DropDownList ID="ddlEstilo" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlFormato" class="form-label">Formato:</label>
                    <asp:DropDownList ID="ddlFormato" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                    <a href="ListaDiscos.aspx">Cancelar</a>
                </div>
            </div>
            <div class="col-6">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                            <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                                AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                        </div>
                        <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                            runat="server" ID="imgDisco" Width="60%" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Button runat="server" ID="btnEliminar" CssClass="btn btn-danger mx-2" Text="Eliminar" OnClick="btnEliminar_Click" />
                        </div>
                        <%if (ConfirmarEliminacion)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminacion" runat="server" ID="chkConfirmarEliminacion" CssClass="form-check" />
                            <asp:Button Text="Eliminar" runat="server" ID="btnConfirmacionEliminacion" OnClick="btnConfirmacionEliminacion_Click" CssClass="btn btn-outline-danger" />
                        </div>
                        <%} %>
                    </ContentTemplate>
                </asp:UpdatePanel>  
            </div>
        </div>
    </div>
</asp:Content>
