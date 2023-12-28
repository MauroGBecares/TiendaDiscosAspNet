using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace NegocioDatos
{
    public class UsuarioNegocio
    {
        public int registrarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into USUARIO (Email, Pass, Nombre, Apellido, FechaNacimiento, AdminUsuario) output inserted.id values (@email, @pass, @nombre, @apellido, @fechanac, 0)");
                datos.setearParametros("@email", usuario.Email);
                datos.setearParametros("@pass", usuario.Pass);
                datos.setearParametros("@nombre", usuario.Nombre);
                datos.setearParametros("@apellido", usuario.Apellido);
                datos.setearParametros("@fechanac", usuario.FechaNacimiento);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Loguearse(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, Email, Pass, Nombre, Apellido, FechaNacimiento, ImagenPerfil, AdminUsuario from USUARIO Where Email = @email AND Pass = @pass");
                datos.setearParametros("@email", usuario.Email);
                datos.setearParametros("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Nombre = (string)datos.Lector["Nombre"];
                    usuario.Apellido = (string)datos.Lector["Apellido"];
                    usuario.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString());
                    if (!(datos.Lector["ImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["ImagenPerfil"];
                    usuario.Admin = (bool)datos.Lector["AdminUsuario"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void actualizar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USUARIO set Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @fecNac, ImagenPerfil = @img Where Id = @id");
                datos.setearParametros("@nombre", usuario.Nombre);
                datos.setearParametros("@apellido", usuario.Apellido);
                datos.setearParametros("@fecNac", usuario.FechaNacimiento);
                datos.setearParametros("@img", (object)usuario.ImagenPerfil ?? DBNull.Value);
                datos.setearParametros("@id", usuario.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            { 
                datos.cerrarConexion();
            }
        }
    }
}
