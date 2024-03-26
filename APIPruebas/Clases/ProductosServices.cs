using APIPruebas.algoritmo;
using APIPruebas.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPruebas.Clases
{
    public class ProductosServices : IProductoLogic
    {
        private readonly DbapiContext _dbContext;

        public ProductosServices(DbapiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Producto> GetProduct()
        {
            try
            {
                return _dbContext.Productos.Include(producto => producto.oCategoria).ToList();
            }
            catch (Exception ex)
            {
                return new List<Producto>(); // O cualquier otra acción de manejo de errores
            }
        }

        public Producto GetProductId(int idProducto)
        {
            try
            {
                return _dbContext.Productos.Include(producto => producto.oCategoria).FirstOrDefault(productId => productId.IdProducto == idProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("El erro de lado del ID ", ex);
                throw;
            }
        }

        public void SaveProducto(Producto producto)
        {
            try
            {
                _dbContext.Productos.Add(producto);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el producto", ex);
            }
        }

        public void EditProduct(Producto producto)
        {
            try
            {
                _dbContext.Productos.Update(producto);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el producto", ex);
            }
        }

        public void DeleteProduct(int idProducto)
        {
            try
            {
                var producto = _dbContext.Productos.Find(idProducto);
                if (producto != null)
                {
                    _dbContext.Productos.Remove(producto);
                    _dbContext.SaveChangesAsync();  
                }

            }
            catch (Exception ex){
                throw new Exception("Error al elimnar el producto", ex);

            }
        }

    }
}
