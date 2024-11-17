using Microsoft.AspNetCore.Mvc;
using WebMenuAPI.Interfaces; 
using WebMenuAPI.Models;
using WebMenuAPI.Contracts;    

namespace WebMenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IComentarioServices _comentarioServices;
        private readonly IPagoServices _pagoServices;
        private readonly ILocacionServices _locacionServices;
        private readonly IUsuarioServices _usuarioServices;
        private readonly IProductoServices _productoServices;
        private readonly IOrdenServices _ordenServices;
        private readonly IOrdenDetalleServices _ordenDetalleServices;

        // Constructor que inyecta todos los servicios necesarios
        public MenuController(
            IComentarioServices comentarioServices,
            IPagoServices pagoServices,
            ILocacionServices locacionServices,
            IUsuarioServices usuarioServices,
            IProductoServices productoServices,
            IOrdenServices ordenServices,
            IOrdenDetalleServices ordenDetalleServices)
        {
            _comentarioServices = comentarioServices;
            _pagoServices = pagoServices;
            _locacionServices = locacionServices;
            _usuarioServices = usuarioServices;
            _productoServices = productoServices;
            _ordenServices = ordenServices;
            _ordenDetalleServices = ordenDetalleServices;
        }

        // Endpoint para obtener todos los comentarios
        [HttpGet("comentarios")]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetAllComentariosAsync()
        {
            var comentarios = await _comentarioServices.GetAllAsync();
            return Ok(comentarios);
        }

        // Endpoint para obtener un comentario por ID
        [HttpGet("comentarios/{id}")]
        public async Task<ActionResult<Comentario>> GetComentarioByIdAsync(int id)
        {
            try
            {
                var comentario = await _comentarioServices.GetByIdAsync(id);
                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Endpoint para crear un comentario
        [HttpPost("comentarios")]
        public async Task<ActionResult> CreateComentarioAsync([FromBody] CrearComentarioReq request)
        {
            try
            {
                await _comentarioServices.CreateComentarioAsync(request);
                return CreatedAtAction(nameof(GetComentarioByIdAsync), new { id = request.UsuarioId }, request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint para actualizar un comentario
        [HttpPut("comentarios/{id}")]
        public async Task<ActionResult> UpdateComentarioAsync(int id, [FromBody] ActualizarComentarioReq request)
        {
            try
            {
                await _comentarioServices.UpdateComentarioAsync(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint para eliminar un comentario
        [HttpDelete("comentarios/{id}")]
        public async Task<ActionResult> DeleteComentarioAsync(int id)
        {
            try
            {
                await _comentarioServices.DeleteComentarioAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Aquí se añadirían los métodos de los demás servicios (Pago, Usuario, Producto, etc.)
        // Ejemplo para obtener todos los productos
        [HttpGet("productos")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAllProductosAsync()
        {
            var productos = await _productoServices.GetAllAsync();
            return Ok(productos);
        }

        // Ejemplo para obtener un producto por ID
        [HttpGet("productos/{id}")]
        public async Task<ActionResult<Producto>> GetProductoByIdAsync(int id)
        {
            try
            {
                var producto = await _productoServices.GetByIdAsync(id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Aquí agregaríamos métodos para Pagos, Locaciones, Usuarios, Ordenes, etc.
    }
}
