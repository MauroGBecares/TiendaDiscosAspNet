<%@ Page Title="" Language="C#" MasterPageFile="~/DiscosMaster.Master" AutoEventWireup="true" CodeBehind="ListaDiscos.aspx.cs" Inherits="WebFormDiscos.ListaDiscos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <div class="row">
            <div class="col-6">
                <div class="mb-3 d-flex mx-2">
                    <label for="txtFiltroRapido" class="form-label my-1">Filtro</label>
                    <asp:TextBox runat="server" ID="txtFiltroRapido" AutoPostBack="true" OnTextChanged="txtFiltroRapido_TextChanged" CssClass="form-control mx-3" />
                </div>
            </div>
            <div class="col-6">
                <div class="form-check">
                    <asp:CheckBox runat="server" ID="chkFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged"/>
                    <asp:Label ID="lblFiltroAvanzado" CssClass="form-check-label" runat="server" Text="Activar Filtro Avanzado"></asp:Label>
                </div>
            </div>
        </div>
        <%if (chkFiltroAvanzado.Checked)
            {%>
        <div class="row">
            <div class="col-4">
                <div class="mb-3 d-flex">
                    <asp:Label Text="Campo" ID="lblCampo" runat="server" CssClass="my-1 mx-2" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-select" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Titulo" />
                        <asp:ListItem Text="Fecha de Lanzamiento" />
                        <asp:ListItem Text="Cantidad de Canciones" />
                        <asp:ListItem Text="Estilo" />
                        <asp:ListItem Text="Formato" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-4">
                <div class="mb-3 d-flex">
                    <asp:Label Text="Filtro" runat="server" CssClass="my-1 mx-2" />
                    <%if (esFecha)
                        { %>
                    <asp:TextBox runat="server" ID="txtFiltroAvanzadoFecha" CssClass="form-control" TextMode="Date" />
                    <%}
                        else
                        {%>
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                    <%} %>
                </div>
            </div>
            <div class="col-4">
                <div class="mb-3 d-flex">
                    <asp:Button Text="Buscar" runat="server" ID="btnBuscarAvanzado" OnClick="btnBuscarAvanzado_Click" CssClass="btn btn-outline-primary" />
                </div>
            </div>
        </div>
        <%} %>
        <div class="row">
            <div class="col-12">
                <asp:GridView ID="dgvDiscos" runat="server" DataKeyNames="Id" CssClass="table table-striped mx-2" AutoGenerateColumns="false"
                    OnSelectedIndexChanged="dgvDiscos_SelectedIndexChanged" OnPageIndexChanging="dgvDiscos_PageIndexChanging" AllowPaging="True" PageSize="4">
                    <Columns>
                        <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
                        <asp:BoundField HeaderText="Fecha de Lanzamiento" DataField="FechaLanzamiento" DataFormatString="{0:d}" />
                        <asp:BoundField HeaderText="Cantidad de canciones" DataField="CantidadCanciones" />
                        <asp:BoundField HeaderText="Estilo" DataField="Estilo.Descripcion" />
                        <asp:BoundField HeaderText="Formato" DataField="Formato.Descripcion" />
                        <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Modificar" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-2">
                <a href="FormularioDiscos.aspx" class="btn btn-primary mx-2">Agregar</a>
            </div>
        </div>
    </div>
</asp:Content>
