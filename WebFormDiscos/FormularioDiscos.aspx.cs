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
    public partial class FormularioDiscos : System.Web.UI.Page
    {
        public bool ConfirmarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmarEliminacion = false;
            try
            {
                if (!IsPostBack)
                {
                    DatosEstilos estilos = new DatosEstilos();
                    DatosEdiciones ediciones = new DatosEdiciones();
                    List<Estilos> listaEstilos = estilos.listarEstilos();
                    List<TiposEdicion> listaEdiciones = ediciones.listaEdiciones();

                    ddlEstilo.DataSource = listaEstilos;
                    ddlEstilo.DataValueField = "Id";
                    ddlEstilo.DataTextField = "Descripcion";
                    ddlEstilo.DataBind();

                    ddlFormato.DataSource = listaEdiciones;
                    ddlFormato.DataValueField = "Id";
                    ddlFormato.DataTextField = "Descripcion";
                    ddlFormato.DataBind();
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : string.Empty;
                if(id != string.Empty && !IsPostBack)
                {
                    DatosDiscos negocio = new DatosDiscos();
                    Dominio.Discos seleccionado = (negocio.listarDiscos(id))[0];

                    Session.Add("discoSeleccionado", seleccionado);

                    txtId.Text = seleccionado.Id.ToString();
                    txtTitulo.Text = seleccionado.Titulo;
                    txtFecha.Text = seleccionado.FechaLanzamiento.ToString("yyyy-MM-dd");
                    txtCantCanciones.Text = seleccionado.CantidadCanciones.ToString();
                    txtImagenUrl.Text = seleccionado.UrlImagen;
                    
                    ddlEstilo.SelectedValue = seleccionado.Estilo.Id.ToString();
                    ddlFormato.SelectedValue = seleccionado.Formato.Id.ToString();
                    imgDisco.ImageUrl = txtImagenUrl.Text;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Dominio.Discos disco = new Dominio.Discos();
                DatosDiscos negocio = new DatosDiscos();

                disco.Titulo = txtTitulo.Text;
                disco.FechaLanzamiento = DateTime.Parse(txtFecha.Text);
                disco.CantidadCanciones = int.Parse(txtCantCanciones.Text);
                disco.UrlImagen = txtImagenUrl.Text;

                disco.Estilo = new Estilos();
                disco.Estilo.Id = int.Parse(ddlEstilo.SelectedValue);
                disco.Formato = new TiposEdicion();
                disco.Formato.Id = int.Parse(ddlFormato.SelectedValue);


                if (Request.QueryString["id"] != null)
                {
                    disco.Id = int.Parse(txtId.Text);
                    negocio.ModificarDiscoConSP(disco);
                }
                else
                {
                    negocio.AgregarDiscoConSP(disco);
                }

                Response.Redirect("ListaDiscos.aspx", false);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgDisco.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmacionEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if(chkConfirmarEliminacion.Checked)
                {
                    DatosDiscos datosDiscos = new DatosDiscos();
                    datosDiscos.Eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListaDiscos.aspx");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}