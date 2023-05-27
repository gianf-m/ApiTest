
namespace Api.Productos {
    public interface IProductoAppServices  {
        void AddProduct(ProductoDto producto);
        ProductoDto? GetProduct(long id);
        List<ProductoDto> GetListProducts(bool valObtenerEliminados);
        void UpdateProduct(long id, ProductoDto EditingProducto);
        void DeleteProduct(long id);
        void UpdateAllPrecio(decimal valPrecio);
        void UpdateAllExistencia(int valExistencia);

    }
}
