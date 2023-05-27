

using Application;

namespace Api.Productos {
    public class ProductoAppServices : IProductoAppServices {

        private readonly IProductoRepository _productoRepository;

        public ProductoAppServices(IProductoRepository productoRepository) {
            _productoRepository = productoRepository;
        }

        public void AddProduct(ProductoDto producto) {
            var Mapper = MapperConfig.InitializeAutomapper();
            var vProducto = Mapper.Map<Producto>(producto);
            _productoRepository.AddProduct(vProducto);
        }

        public ProductoDto? GetProduct(long id) {
            var vProducto = _productoRepository.GetProduct(id);
            var Mapper = MapperConfig.InitializeAutomapper();
            return Mapper.Map<Producto, ProductoDto>(vProducto);
        }

        public List<ProductoDto> GetListProducts(bool valObtenerEliminados) {
            List<Producto> products = new List<Producto>();
            products = _productoRepository.GetListProducts(false);
            var Mapper = MapperConfig.InitializeAutomapper();
            return Mapper.Map<List<Producto>, List<ProductoDto>>(products);
        }

        public void UpdateProduct(long id, ProductoDto EditingProducto) {
            var Mapper = MapperConfig.InitializeAutomapper();
            Producto producto = Mapper.Map<Producto>(EditingProducto);
            _productoRepository.UpdateProduct(id, producto);
        }

        public void DeleteProduct(long id) {
            _productoRepository.DeleteProduct(id);
        }

        public void UpdateAllPrecio(decimal valPrecio) {
            _productoRepository.UpdateAllPrecio(valPrecio);
        }

        public void UpdateAllExistencia(int valExistencia) {
            _productoRepository.UpdateAllExistencia(valExistencia);
        }

    }
}
