<%@ Page Title="" Language="C#" MasterPageFile="~/DiscosMaster.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WebFormDiscos.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row my-4">
        <div class="col-1"></div>
        <div class="col-3">
            <div class="mb-3">
                <h2>Registro</h2>
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox TextMode="Email" ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe completar el texto..." ForeColor="Red" Font-Size="Small" ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Debe ser formato email..." ForeColor="Red" Font-Size="Small" ControlToValidate="txtEmail" runat="server"
                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"/>
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Contraseña</label>
                <asp:TextBox TextMode="Password" CssClass="form-control" ID="txtPass" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe completar el texto..." ForeColor="Red" Font-Size="Small" ControlToValidate="txtPass" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe completar el texto..." ForeColor="Red" Font-Size="Small" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox CssClass="form-control" ID="txtApellido" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe completar el texto..." ForeColor="Red" Font-Size="Small" ControlToValidate="txtApellido" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox TextMode="Date" CssClass="form-control" ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debe completar el texto..." ForeColor="Red" Font-Size="Small" ControlToValidate="txtFechaNacimiento" runat="server" />
            </div>
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
        </div>
    </div>
</asp:Content>
