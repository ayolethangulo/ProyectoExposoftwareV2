using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class DescripcionCalificacion
    {
        [Key]
        public int IdDescripcion { get; set; }
        public int IdCalificacion { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
    }
}