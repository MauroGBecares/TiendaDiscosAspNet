using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioDatos
{
    public static class Seguridad
    {
        public static bool sessionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.Id != 0) 
            {
                return true;
            }
            return false;
        }

        public static bool esAdmin(object usuario)
        {
            Usuario user = usuario != null ? (Usuario)usuario : null;
            return user != null ? user.Admin : false;
        }
    }
}
