using APIPruebas.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPruebas.algoritmo
{
    public interface IProductoLogic
    {
        List<Producto> GetProduct();
        Producto GetProductId(int idProducto);
        void SaveProducto(Producto producto);
        void EditProduct(Producto producto);
        void DeleteProduct(int idProducto);
    }
}
