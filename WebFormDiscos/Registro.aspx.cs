using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using NegocioDatos;

namespace WebFormDiscos
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                Usuario usuario = new Usuario();
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                usuario.Id = usuarioNegocio.registrarUsuario(usuario);
                Session.Add("usuario", usuario);
                Response.Redirect("Inicio.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}