using Microsoft.AspNetCore.Mvc;
// Referencias del contexto 
using Microsoft.EntityFrameworkCore;
using APIPruebas.Models;
using System.Net.NetworkInformation;
using APIPruebas.Clases;
using APIPruebas.algoritmo;

namespace APIPruebas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        public readonly IProductoLogic _productoLogic;
        public ProductoController(IProductoLogic productoLogic)
        {
            _productoLogic = productoLogic;
        }


        [HttpGet]
        [Route("lista")]
        public IActionResult GetProduct()
        {
            var product = _productoLogic.GetProduct();
            return Ok(product);
        }

        [HttpGet]
        [Route("Obtener/{idProducto:int}")]
        public IActionResult Obtener(int idProducto)
        {
            var producto = _productoLogic.GetProductId(idProducto);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);    
        }



        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Producto producto)
        {
         _productoLogic.SaveProducto(producto);
            return Ok();
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Producto producto)
        {
            _productoLogic.EditProduct(producto);
            return Ok();
           
        }



        [HttpDelete]
        [Route("Eliminar/{idProducto:int}")]
        public IActionResult Elimnar(int idProducto)
        {
            _productoLogic.DeleteProduct(idProducto);
            return Ok();
        }

    }


}
