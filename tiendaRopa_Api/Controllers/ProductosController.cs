using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using tiendaRopa_Api.Context;
using tiendaRopa_Api.Models;

namespace tiendaRopa_Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly TiendaRopaContext _productoService;

        public ProductosController(TiendaRopaContext productoService)
        {
            _productoService = productoService;
        }

        // GET: api/productos

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _productoService.Productos.ToListAsync();
        }

        // GET: api/productos/BuscarProducto

        [HttpGet("BuscarProducto")]

        public async Task<IActionResult> BuscarProducto([FromQuery] int ProductoId)
        {
            var response = new ApiResponse<Producto>();
            try
            {
                var producto = await _productoService.Productos.FirstOrDefaultAsync(p => p.ProductoId == ProductoId);

                if (producto != null)
                {
                    response.Success(200, "Producto encontrado", producto);
                    return Ok(response);
                }
                else
                {
                    response.Failed(404, "Producto no encontrado");
                    return NotFound(response);
                }
            }
            catch (Exception ex)
            {
                response.Failed(500, ex.Message);
                return StatusCode(response.Status, response);
            }
        }

        // POST: api/productos

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Producto>>> PostProductos()
        {
            return await _productoService.Productos.ToListAsync();
        }
    }
}
