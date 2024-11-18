using Microsoft.AspNetCore.Mvc;
using WebMenuAPI.Interfaces; 
using WebMenuAPI.Models;
using WebMenuAPI.Contracts;    

namespace WebMenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController(
        IComentarioServices comentarioServices,
        IPagoServices pagoServices,
        ILocacionServices locacionServices,
        IUsuarioServices usuarioServices,
        IProductoServices productoServices,
        IOrdenServices ordenServices,
        IStatusOrdenServices statusOrdenServices,
        ICategoriaServices categoriaServices,
        IOrdenDetalleServices ordenDetalleServices) : ControllerBase
    {
        private readonly IComentarioServices _comentarioServices = comentarioServices;
        private readonly IPagoServices _pagoServices = pagoServices;
        private readonly ILocacionServices _locacionServices = locacionServices;
        private readonly IUsuarioServices _usuarioServices = usuarioServices;
        private readonly IProductoServices _productoServices = productoServices;
        private readonly IOrdenServices _ordenServices = ordenServices;
        private readonly IStatusOrdenServices _statusOrdenServices = statusOrdenServices;
        private readonly ICategoriaServices _categoriaServices = categoriaServices;
        private readonly IOrdenDetalleServices _ordenDetalleServices = ordenDetalleServices;

        [HttpGet("usuarios")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                var userList = await _usuarioServices.GetAllAsync();
                return Ok(userList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los estados", error = ex.Message });
            }
        }
        
        [HttpGet("usuarios/{id}")]
        public async Task<IActionResult> GetUserAsync(int id)
        {
            try
            {
                var userList = await _usuarioServices.GetByIdAsync(id);
                return Ok(userList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los estados", error = ex.Message });
            }
        }
        


        [HttpPost("usuarios")]
        public async Task<IActionResult> CreateUsuarioAsync([FromBody] CrearUsuarioReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _usuarioServices.CreateUsuarioAsync(request);
                return Ok(new { message = "Usuario creado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el usuario", error = ex.Message });
            }
        }

        [HttpPut("usuarios/{id}")]
        public async Task<IActionResult> UpdateUsuarioAsync(int id, [FromBody] ActualizarUsuarioReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _usuarioServices.UpdateUsuarioAsync(id, request);
                return Ok(new { message = "Usuario actualizado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el usuario", error = ex.Message });
            }
        }

        [HttpDelete("usuarios/{id}")]
        public async Task<IActionResult> DeleteUsuarioAsync(int id)
        {
            try
            {
                await _usuarioServices.DeleteUsuarioAsync(id);
                return Ok(new { message = "Usuario eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el usuario", error = ex.Message });
            }
        }

        [HttpGet("productos")]
        public async Task<IActionResult> GetProductosAsync()
        {
            try
            {
                var productos = await _productoServices.GetAllAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los productos", error = ex.Message });
            }
        }

        [HttpGet("productos/{id}")]
        public async Task<IActionResult> GetProductoByIdAsync(int id)
        {
            try
            {
                var producto = await _productoServices.GetByIdAsync(id);
                if (producto == null)
                    return NotFound(new { message = "Producto no encontrado" });
                
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el producto", error = ex.Message });
            }
        }

        // Métodos para Productos
        [HttpPost("productos")]
        public async Task<IActionResult> CreateProductoAsync([FromBody] CrearProductoReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _productoServices.CreateProductoAsync(request);
                return Ok(new { message = "Producto creado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el producto", error = ex.Message });
            }
        }

        [HttpPut("productos/{id}")]
        public async Task<IActionResult> UpdateProductoAsync(int id, [FromBody] ActualizarProductoReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _productoServices.UpdateProductoAsync(id, request);
                return Ok(new { message = "Producto actualizado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el producto", error = ex.Message });
            }
        }

        [HttpDelete("productos/{id}")]
        public async Task<IActionResult> DeleteProductoAsync(int id)
        {
            try
            {
                await _productoServices.DeleteProductoAsync(id);
                return Ok(new { message = "Producto eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el producto", error = ex.Message });
            }
        }
        [HttpGet("ordenes")]
        public async Task<IActionResult> GetAllOrdenesAsync()
        {
            try
            {
                var ordenes = await _ordenServices.GetAllAsync();
                return Ok(ordenes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener las órdenes", error = ex.Message });
            }
        }

        [HttpGet("ordenes/{id}")]
        public async Task<IActionResult> GetOrdenByIdAsync(int id)
        {
            try
            {
                var orden = await _ordenServices.GetByIdAsync(id);
                if (orden == null)
                    return NotFound(new { message = "Orden no encontrada" });

                return Ok(orden);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener la orden", error = ex.Message });
            }
        }

        // Métodos para Ordenes
        [HttpPost("ordenes")]
        public async Task<IActionResult> CreateOrdenAsync([FromBody] CrearOrdenReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _ordenServices.CreateOrdenAsync(request);
                return Ok(new { message = "Orden creada con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear la orden", error = ex.Message });
            }
        }

        [HttpPut("ordenes/{id}")]
        public async Task<IActionResult> UpdateOrdenAsync(int id, [FromBody] ActualizarOrdenReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _ordenServices.UpdateOrdenAsync(id, request);
                return Ok(new { message = "Orden actualizada con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar la orden", error = ex.Message });
            }
        }

        [HttpDelete("ordenes/{id}")]
        public async Task<IActionResult> DeleteOrdenAsync(int id)
        {
            try
            {
                await _ordenServices.DeleteOrdenAsync(id);
                return Ok(new { message = "Orden eliminada con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar la orden", error = ex.Message });
            }
        }

        // Métodos GET para Pagos
        [HttpGet("pagos")]
        public async Task<IActionResult> GetAllPagosAsync()
        {
            try
            {
                var pagos = await _pagoServices.GetAllAsync();
                return Ok(pagos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los pagos", error = ex.Message });
            }
        }

        [HttpGet("pagos/{id}")]
        public async Task<IActionResult> GetPagoByIdAsync(int id)
        {
            try
            {
                var pago = await _pagoServices.GetByIdAsync(id);
                if (pago == null)
                    return NotFound(new { message = "Pago no encontrado" });

                return Ok(pago);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el pago", error = ex.Message });
            }
        }        

        // Métodos para Pagos
        [HttpPost("pagos")]
        public async Task<IActionResult> CreatePagoAsync([FromBody] CrearPagoReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _pagoServices.CreatePagoAsync(request);
                return Ok(new { message = "Pago creado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el pago", error = ex.Message });
            }
        }

        [HttpDelete("pagos/{id}")]
        public async Task<IActionResult> DeletePagoAsync(int id)
        {
            try
            {
                await _pagoServices.DeletePagoAsync(id);
                return Ok(new { message = "Pago eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el pago", error = ex.Message });
            }
        }

        [HttpGet("locaciones")]
        public async Task<IActionResult> GetAllLocacionesAsync()
        {
            try
            {
                var locaciones = await _locacionServices.GetAllAsync();
                return Ok(locaciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener las locaciones", error = ex.Message });
            }
        }

        [HttpGet("locaciones/{id}")]
        public async Task<IActionResult> GetLocacionByIdAsync(int id)
        {
            try
            {
                var locacion = await _locacionServices.GetByIdAsync(id);
                if (locacion == null)
                    return NotFound(new { message = "Locación no encontrada" });

                return Ok(locacion);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener la locación", error = ex.Message });
            }
        }

        // Métodos para Locaciones
        [HttpPost("locaciones")]
        public async Task<IActionResult> CreateLocacionAsync([FromBody] CrearLocacionReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _locacionServices.CreateLocacionAsync(request);
                return Ok(new { message = "Locación creada con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear la locación", error = ex.Message });
            }
        }

        [HttpPut("locaciones/{id}")]
        public async Task<IActionResult> UpdateLocacionAsync(int id, [FromBody] ActualizarLocacionReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _locacionServices.UpdateLocacionAsync(id, request);
                return Ok(new { message = "Locación actualizada con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar la locación", error = ex.Message });
            }
        }

        [HttpDelete("locaciones/{id}")]
        public async Task<IActionResult> DeleteLocacionAsync(int id)
        {
            try
            {
                await _locacionServices.DeleteLocacionAsync(id);
                return Ok(new { message = "Locación eliminada con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar la locación", error = ex.Message });
            }
        }

                [HttpGet("comentarios")]
        public async Task<IActionResult> GetAllComentariosAsync()
        {
            try
            {
                var comentarios = await _comentarioServices.GetAllAsync();
                return Ok(comentarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los comentarios", error = ex.Message });
            }
        }

        [HttpGet("comentarios/{id}")]
        public async Task<IActionResult> GetComentarioByIdAsync(int id)
        {
            try
            {
                var comentario = await _comentarioServices.GetByIdAsync(id);
                if (comentario == null)
                    return NotFound(new { message = "Comentario no encontrado" });

                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el comentario", error = ex.Message });
            }
        }


        // Métodos para Comentarios
        [HttpPost("comentarios")]
        public async Task<IActionResult> CreateComentarioAsync([FromBody] CrearComentarioReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _comentarioServices.CreateComentarioAsync(request);
                return Ok(new { message = "Comentario creado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el comentario", error = ex.Message });
            }
        }

        [HttpPut("comentarios/{id}")]
        public async Task<IActionResult> UpdateComentarioAsync(int id, [FromBody] ActualizarComentarioReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _comentarioServices.UpdateComentarioAsync(id, request);
                return Ok(new { message = "Comentario actualizado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el comentario", error = ex.Message });
            }
        }

        [HttpDelete("comentarios/{id}")]
        public async Task<IActionResult> DeleteComentarioAsync(int id)
        {
            try
            {
                await _comentarioServices.DeleteComentarioAsync(id);
                return Ok(new { message = "Comentario eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el comentario", error = ex.Message });
            }
        }
        
         [HttpGet("status")]
        public async Task<IActionResult> GetAllStatusAsync()
        {
            try
            {
                var statusList = await _statusOrdenServices.GetAllAsync();
                return Ok(statusList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los estados", error = ex.Message });
            }
        }

        [HttpGet("status/{id}")]
        public async Task<IActionResult> GetStatusByIdAsync(int id)
        {
            try
            {
                var status = await _statusOrdenServices.GetByIdAsync(id);
                if (status == null)
                    return NotFound(new { message = "Estado no encontrado" });

                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el estado", error = ex.Message });
            }
        }

        // Métodos solo de lectura para Categoria
        [HttpGet("categorias")]
        public async Task<IActionResult> GetAllCategoriasAsync()
        {
            try
            {
                var categoriaList = await _categoriaServices.GetAllAsync();
                return Ok(categoriaList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener las categorías", error = ex.Message });
            }
        }

        [HttpGet("categorias/{id}")]
        public async Task<IActionResult> GetCategoriaByIdAsync(int id)
        {
            try
            {
                var categoria = await _categoriaServices.GetByIdAsync(id);
                if (categoria == null)
                    return NotFound(new { message = "Categoría no encontrada" });

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener la categoría", error = ex.Message });
            }
        }

        // Métodos CRUD para DetalleOrden
        [HttpPost("detalleorden")]
        public async Task<IActionResult> CreateDetalleOrdenAsync([FromBody] CrearOrdenDetalleReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _ordenDetalleServices.CreateOrdenDetalleAsync(request);
                return Ok(new { message = "Detalle de orden creado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al crear el detalle de la orden", error = ex.Message });
            }
        }

        [HttpGet("detalleorden/{id}")]
        public async Task<IActionResult> GetDetalleOrdenByIdAsync(int id)
        {
            try
            {
                var detalleOrden = await _ordenDetalleServices.GetByIdAsync(id);
                if (detalleOrden == null)
                    return NotFound(new { message = "Detalle de orden no encontrado" });

                return Ok(detalleOrden);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el detalle de la orden", error = ex.Message });
            }
        }

        [HttpPut("detalleorden/{id}")]
        public async Task<IActionResult> UpdateDetalleOrdenAsync(int id, [FromBody] ActualizarOrdenDetalleReq request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _ordenDetalleServices.UpdateOrdenDetalleAsync(id, request);
                return Ok(new { message = "Detalle de orden actualizado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al actualizar el detalle de la orden", error = ex.Message });
            }
        }

        [HttpDelete("detalleorden/{id}")]
        public async Task<IActionResult> DeleteDetalleOrdenAsync(int id)
        {
            try
            {
                await _ordenDetalleServices.DeleteOrdenDetalleAsync(id);
                return Ok(new { message = "Detalle de orden eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar el detalle de la orden", error = ex.Message });
            }
        }

    }
}
