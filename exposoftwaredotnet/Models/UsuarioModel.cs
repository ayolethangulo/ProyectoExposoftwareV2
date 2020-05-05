using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exposoftwaredotnet.Models
{
    public class UsuarioInputModel
    { 
        public string Identificacion { get; set; }
        public string UsuarioNombre { get; set; } 
        public string Contrasena { get; set; }
        public string TipoDocente { get; set; }        
    }
     public class UsuarioViewModel : UsuarioInputModel
        {
            public UsuarioViewModel()
            {

            }
            public UsuarioViewModel(Usuario usuario)
            {
                Identificacion = usuario.Identificacion;
                UsuarioNombre = usuario.UsuarioNombre;
                Contrasena = usuario.Contrasena;
                TipoDocente = usuario.TipoDocente;
                
            }
          
        }
}