using NegocioDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace WebFormDiscos
{
    public partial class Discos : System.Web.UI.Page
    {
        private List<Dominio.Discos> listaDiscos;
        protected void Page_Load(object sender, EventArgs e)
        {
            DatosDiscos datos = new DatosDiscos();
            Session.Add("listaDiscos", datos.listaConSP());
            if (!IsPostBack)
            {
                cargarDiscos.DataSource = Session["listaDiscos"];
                cargarDiscos.DataBind();
            }

        }
        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("Detalle.aspx?id=" + id);
        }
    }
}