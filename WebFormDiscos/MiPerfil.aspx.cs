using Dominio;
using NegocioDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormDiscos
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sessionActiva(Session["usuario"]))
                    {
                        Usuario usuario = (Usuario)Session["usuario"];
                        txtEmail.Text = usuario.Email;
                        txtEmail.Enabled = false;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;
                        txtFechaNacimiento.Text = usuario.FechaNacimiento.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = $"~/Images/{usuario.ImagenPerfil}";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = (Usuario)Session["usuario"];
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./images/");
                    txtImagen.PostedFile.SaveAs($"{ruta}perfil-{usuario.Id}.jpg");
                    usuario.ImagenPerfil = $"perfil-{usuario.Id}.jpg";
                }
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                usuarioNegocio.actualizar(usuario);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = $"~/Images/{usuario.ImagenPerfil}";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}