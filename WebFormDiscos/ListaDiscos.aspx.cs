using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioDatos;

namespace WebFormDiscos
{
    public partial class ListaDiscos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        public bool esFecha { get; set; }     
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (ddlCampo.Text == "Fecha de Lanzamiento")
                    esFecha = true;
                if (!IsPostBack)
                {
                    DatosDiscos datosDiscos = new DatosDiscos();
                    Session.Add("listaDiscos", datosDiscos.listaConSP());
                }
                dgvDiscos.DataSource = Session["listaDiscos"];
                dgvDiscos.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dgvDiscos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvDiscos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioDiscos.aspx?id=" + id);
        }

        protected void dgvDiscos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvDiscos.PageIndex = e.NewPageIndex;
            dgvDiscos.DataBind();
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Dominio.Discos> lista = (List<Dominio.Discos>)Session["listaDiscos"];
            List<Dominio.Discos> listaFiltrada = lista.FindAll(x => x.Titulo.ToUpper().Contains(txtFiltroRapido.Text.ToUpper()));
            dgvDiscos.DataSource = listaFiltrada;
            dgvDiscos.DataBind();
        }

        protected void btnBuscarAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                DatosDiscos datosDiscos = new DatosDiscos();
                dgvDiscos.DataSource = esFecha ? datosDiscos.FiltroAvanzado(txtFiltroAvanzadoFecha.Text, ddlCampo.SelectedItem.ToString())
                    : datosDiscos.FiltroAvanzado(txtFiltroAvanzado.Text, ddlCampo.SelectedValue.ToString());
                dgvDiscos.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkFiltroAvanzado.Checked;
            txtFiltroRapido.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlCampo.Text == "Fecha de Lanzamiento")
                esFecha = true;
        }
    }
}