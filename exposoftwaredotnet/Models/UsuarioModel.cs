using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exposoftwaredotnet.Models
{
    public class UsuarioInputModel
    { 
        public string NombreUser { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

    }

     public class UsuarioViewModel : UsuarioInputModel
        {
          public string Token { get; set; }

        }

}