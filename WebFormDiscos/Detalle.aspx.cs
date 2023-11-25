using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormDiscos
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected Dominio.Discos discoDetalle;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"]);
                foreach (var item in (List<Dominio.Discos>)Session["listaDiscos"])
                {
                    if(id == item.Id)
                    {
                        discoDetalle = item;
                    }
                }
            }
        }
    }
}