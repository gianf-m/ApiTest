using System.ComponentModel.DataAnnotations;

namespace Api.Productos {
    public class Producto {

        [Key]
        public long Id { get; set; }

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Existencia { get; set; }

        public bool ProductoEliminado { get; set; }

        public DateTime? DeletedTime { get; set; }

    }
}
