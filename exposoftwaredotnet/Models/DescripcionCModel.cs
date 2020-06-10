using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace exposoftwaredotnet.Models
{
    public class DescripcionCInputModel
    {
        public int IdCalificacion { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public int IdProyecto { get; set; }
    }
     public class DescripcionCViewModel : DescripcionCInputModel
    {
        public DescripcionCViewModel(){

        }
        public DescripcionCViewModel(DescripcionCalificacion descripcion){
            IdCalificacion = descripcion.IdCalificacion;
            Descripcion = descripcion.Descripcion;
            Valor = descripcion.Valor;
            IdProyecto = descripcion.IdProyecto;
        }
        public int IdDescripcion { get; set; }
        
    }
}