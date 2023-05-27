using Api.EntityFrameWork;
using Api.Logs;
using Microsoft.EntityFrameworkCore;


namespace Api.Productos {
    public class ProductoRepository : IProductoRepository {

        private readonly ApiDbContext galacDbContext;
        public ProductoRepository(ApiDbContext galacDbContext) {
            this.galacDbContext = galacDbContext;
        }

        public void AddProduct(Producto producto) {
            producto.ProductoEliminado = false;
            producto.DeletedTime = null;
            galacDbContext.Productos.Add(producto);
            Log vLog = new Log();
            vLog.FechaDeEjecucion = DateTime.Now.Date;
            vLog.Acciones = Enums.Acciones.Crear;
            galacDbContext.Logs.Add(vLog);
            galacDbContext.SaveChanges();

        }

        public Producto? GetProduct(long id) {
            Producto? producto = new Producto();
            producto = galacDbContext.Productos.FirstOrDefault(x => x.Id == id);
            Log vLog = new Log();
            vLog.FechaDeEjecucion = DateTime.Now.Date;
            vLog.Acciones = Enums.Acciones.Consultar;
            vLog.InformacionAdicional = $"Se consultó la información del producto {producto.Descripcion}";
            galacDbContext.Logs.Add(vLog);

            return producto;
        }

        public List<Producto> GetListProducts(bool valObtenerEliminados) {
            List<Producto> products = new List<Producto>();

            if (valObtenerEliminados) {
                products = galacDbContext.Productos.ToList();
            } else {
                products = galacDbContext.Productos.Where(x => x.ProductoEliminado == false).ToList();
            }

            return products;
        }

        public void UpdateProduct(long id, Producto EditingProducto) {
            Producto producto = new Producto();
            producto = galacDbContext.Productos.First(x => x.Id == id);
            producto.Descripcion = EditingProducto.Descripcion;
            producto.Existencia = EditingProducto.Existencia;
            producto.Precio = EditingProducto.Precio;
            producto.ProductoEliminado = false;
            galacDbContext.Productos.Update(producto);
            Log vLog = new Log();
            vLog.FechaDeEjecucion = DateTime.Now.Date;
            vLog.Acciones = Enums.Acciones.Editar;
            vLog.InformacionAdicional = "Se actualizó la información del producto " + producto.Descripcion;
            galacDbContext.Logs.Add(vLog);
            galacDbContext.SaveChanges();

        }

        public void DeleteProduct(long id) {
            Producto? producto = new Producto();

            producto = GetProduct(id);
            if (producto == null) {
                throw new NullReferenceException("No se encontro el producto");
            }
            producto.DeletedTime = DateTime.Now;
            producto.ProductoEliminado = true;
            galacDbContext.Productos.Update(producto);
            Log vLog = new Log();
            vLog.FechaDeEjecucion = DateTime.Now.Date;
            vLog.Acciones = Enums.Acciones.Eliminar;
            vLog.InformacionAdicional = "Se eliminó la información del producto " + producto.Descripcion;
            galacDbContext.Logs.Add(vLog);
            galacDbContext.SaveChanges();

        }

        public void UpdateAllPrecio(decimal valPrecio) {
            List<Producto> listaProductos = new List<Producto>();

            listaProductos = GetListProducts(false);
            foreach (var vProducto in listaProductos) {
                vProducto.Precio = valPrecio;
                galacDbContext.Productos.Update(vProducto);
            }
            Log vLog = new Log();
            vLog.FechaDeEjecucion = DateTime.Now.Date;
            vLog.Acciones = Enums.Acciones.Editar;
            vLog.InformacionAdicional = $"Se actualizó la información de {listaProductos.Count} producto(s) a un precio de {valPrecio}";
            galacDbContext.Logs.Add(vLog);
            galacDbContext.SaveChanges();

        }

        public void UpdateAllExistencia(int valExistencia) {
            List<Producto> listaProductos = new List<Producto>();
            listaProductos = GetListProducts(false);
            foreach (var vProducto in listaProductos) {
                vProducto.Existencia = valExistencia;
                galacDbContext.Productos.Update(vProducto);
            }
            Log vLog = new Log();
            vLog.FechaDeEjecucion = DateTime.Now.Date;
            vLog.Acciones = Enums.Acciones.Editar;
            vLog.InformacionAdicional = $"Se actualizó la información de {listaProductos.Count} producto(s) con una existencia de {valExistencia}";
            galacDbContext.Logs.Add(vLog);
            galacDbContext.SaveChanges();

        }
    }
}
