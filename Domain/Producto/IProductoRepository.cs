using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Productos {
    public interface IProductoRepository {
        void AddProduct(Producto producto);
        Producto? GetProduct(long id);
        List<Producto> GetListProducts(bool valObtenerEliminados);
        void UpdateProduct(long id, Producto EditingProducto);
        void DeleteProduct(long id);
        void UpdateAllPrecio(decimal valPrecio);
        void UpdateAllExistencia(int valExistencia);
    }
}
