using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class ItemsRubrica
    {
        [Key]
        public string IdRubrica { get; set; }
        public string Item { get; set; }
        public string Descripcion { get; set; }
    }
}