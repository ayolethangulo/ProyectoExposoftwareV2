using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class DescripcionCalificacion
    {
        [Key]
        public int IdDescripcion { get; set; }
        public decimal Valor { get; set; }
        public int IdProyecto { get; set; }
    }
}