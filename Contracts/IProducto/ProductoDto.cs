

namespace GalacTest.Productos {
    public class ProductoDto {

        public long Id { get; set; }

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Existencia { get; set; }

        public bool ProductoEliminado { get; set; }

        public DateTime? DeletedTime { get; set; }

        public ProductoDto() {

        }

    }
}
