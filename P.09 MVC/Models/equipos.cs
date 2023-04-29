using System.ComponentModel.DataAnnotations;

namespace P._09_MVC.Models
{
    public class equipos
    {
        [Key]
        public int marca_id { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }

    }
}
