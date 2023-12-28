using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioDatos;
using Dominio;

namespace WebFormDiscos
{
    public partial class DiscosMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            if (!(Page is Login || Page is Registro || Page is Inicio || Page is Discos || Page is Detalle || Page is Error))
            {
                if (!Seguridad.sessionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }
            if (Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (!string.IsNullOrEmpty(usuario.ImagenPerfil))
                    imgAvatar.ImageUrl = "~/Images/" + usuario.ImagenPerfil;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}