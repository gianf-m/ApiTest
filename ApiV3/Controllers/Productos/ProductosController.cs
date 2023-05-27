using Api.Logs;
using Api.Productos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Productos {
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : Controller {
        private readonly IProductoAppServices _productoAppServices;
        public ProductosController(IProductoAppServices productoAppServices) {
            _productoAppServices = productoAppServices;
        }

        [HttpGet]
        [Route("Get-Productos")]
        public List<ProductoDto> GetListProducts() {
            return _productoAppServices.GetListProducts(false);
        }

        [HttpPost]
        [Route("Add-Producto")]
        public void AddProducts(ProductoDto producto) {
            _productoAppServices.AddProduct(producto);
        }

        [HttpGet]
        [Route("Get")]
        public ProductoDto? GetListProducts(long id) {
            return _productoAppServices.GetProduct(id);
        }

        [HttpPut]
        [Route("Update-Producto")]
        public void UpdateProduct(long id, ProductoDto EditingProducto) {
            _productoAppServices.UpdateProduct(id, EditingProducto);
        }

        [HttpDelete]
        [Route("Delete-Producto")]
        public void DeleteProduct(long id) {
            _productoAppServices.DeleteProduct(id);
        }

        [HttpPut]
        [Route("Update-All-Precio-Producto")]
        public void UpdateAllPrecio(decimal valPrecio) {
            _productoAppServices.UpdateAllPrecio(valPrecio);
        }

        [HttpPut]
        [Route("Update-All-Existencia-Producto")]
        public void UpdateAllExistencia(int valExistencia) {
            _productoAppServices.UpdateAllExistencia(valExistencia);
        }

    }
}
