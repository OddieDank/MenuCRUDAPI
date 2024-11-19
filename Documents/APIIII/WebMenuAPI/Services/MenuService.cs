using WebMenuAPI.Contracts;
using WebMenuAPI.Interfaces;
using WebMenuAPI.Context;
using WebMenuAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WebMenuAPI.Services
{
    public class ComentarioServices(ContextoBD context, ILogger<ComentarioServices> logger, IMapper mapper) : IComentarioServices
    {
        private readonly ContextoBD _context = context;
        private readonly ILogger<ComentarioServices> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<Comentario>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all comments from the database.");

            if (_context.Comentarios == null)
            {
                _logger.LogWarning("Comentarios DbSet is null.");
                return [];
            }

            var comentarios = await _context.Comentarios.ToListAsync();
            _logger.LogInformation($"Retrieved {comentarios.Count} comments.");

            return comentarios;
        }

        public async Task<Comentario> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Retrieving comment with ID {id}.");

            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                _logger.LogWarning($"Comentario with ID {id} not found.");
                throw new Exception("Comentario no encontrado");
            }

            return comentario;
        }

        public async Task CreateComentarioAsync(CrearComentarioReq request)
        {
            _logger.LogInformation("Creating a new comment.");

            if (_context.Comentarios == null)
            {
                _logger.LogError("Comentarios DbSet is not available.");
                throw new InvalidOperationException("La base de datos no está disponible.");
            }

            var comentario = _mapper.Map<Comentario>(request);
            comentario.UpdatedOn = DateTime.UtcNow;

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Comentario with ID {comentario.ComentarioId} has been created.");
        }

        public async Task UpdateComentarioAsync(int id, ActualizarComentarioReq request)
        {
            _logger.LogInformation($"Updating comentario with ID {id}.");

            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                _logger.LogWarning($"Comentario with ID {id} not found.");
                throw new Exception("Comentario no encontrado");
            }

            comentario = _mapper.Map(request, comentario);
            comentario.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Comentario with ID {id} has been updated.");
        }

        public async Task DeleteComentarioAsync(int id)
        {
            _logger.LogInformation($"Deleting comentario with ID {id}.");

            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                _logger.LogWarning($"Comentario with ID {id} not found.");
                throw new Exception("Comentario no encontrado");
            }

            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Comentario with ID {id} has been deleted.");
        }
    }
    public class PagoServices(ContextoBD context, ILogger<PagoServices> logger, IMapper mapper) : IPagoServices
    {
        private readonly ContextoBD _context = context;
        private readonly ILogger<PagoServices> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<Pago>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all payments from the database.");

            if (_context.Pagos == null)
            {
                _logger.LogWarning("Pagos DbSet is null.");
                return [];
            }

            var pagos = await _context.Pagos.ToListAsync();
            _logger.LogInformation($"Retrieved {pagos.Count} payments.");

            return pagos;
        }

        public async Task<Pago> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Retrieving payment with ID {id}.");

            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                _logger.LogWarning($"Pago with ID {id} not found.");
                throw new Exception("Pago no encontrado");
            }

            return pago;
        }

        public async Task CreatePagoAsync(CrearPagoReq request)
        {
            _logger.LogInformation("Creating a new payment.");

            if (_context.Pagos == null)
            {
                _logger.LogError("Pagos DbSet is not available.");
                throw new InvalidOperationException("La base de datos no está disponible.");
            }

            var pago = _mapper.Map<Pago>(request);
            pago.UpdatedOn = DateTime.UtcNow;

            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Pago with ID {pago.PagoId} has been created.");
        }

        public async Task DeletePagoAsync(int id)
        {
            _logger.LogInformation($"Deleting payment with ID {id}.");

            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                _logger.LogWarning($"Pago with ID {id} not found.");
                throw new Exception("Pago no encontrado");
            }

            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Pago with ID {id} has been deleted.");
        }
    }

    public class LocacionServices(ContextoBD context, ILogger<LocacionServices> logger, IMapper mapper) : ILocacionServices
    {
        private readonly ContextoBD _context = context;
        private readonly ILogger<LocacionServices> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<Locacion>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all locations from the database.");

            if (_context.Locaciones == null)
            {
                _logger.LogWarning("Locaciones DbSet is null.");
                return [];
            }

            var locaciones = await _context.Locaciones.ToListAsync();
            _logger.LogInformation($"Retrieved {locaciones.Count} locations.");

            return locaciones;
        }

        public async Task<Locacion> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Retrieving location with ID {id}.");

            var locacion = await _context.Locaciones.FindAsync(id);
            if (locacion == null)
            {
                _logger.LogWarning($"Locacion with ID {id} not found.");
                throw new Exception("Locacion no encontrada");
            }

            return locacion;
        }

        public async Task CreateLocacionAsync(CrearLocacionReq request)
        {
            _logger.LogInformation("Creating a new location.");

            if (_context.Locaciones == null)
            {
                _logger.LogError("Locaciones DbSet is not available.");
                throw new InvalidOperationException("La base de datos no está disponible.");
            }

            var locacion = _mapper.Map<Locacion>(request);
            locacion.UpdatedOn = DateTime.UtcNow;

            _context.Locaciones.Add(locacion);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Locacion with ID {locacion.LocacionId} has been created.");
        }

        public async Task UpdateLocacionAsync(int id, ActualizarLocacionReq request)
        {
            _logger.LogInformation($"Updating locacion with ID {id}.");

            var locacion = await _context.Locaciones.FindAsync(id);
            if (locacion == null)
            {
                _logger.LogWarning($"Locacion with ID {id} not found.");
                throw new Exception("Locacion no encontrada");
            }

            locacion = _mapper.Map(request, locacion);
            locacion.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Locacion with ID {id} has been updated.");
        }

        public async Task DeleteLocacionAsync(int id)
        {
            _logger.LogInformation($"Deleting locacion with ID {id}.");

            var locacion = await _context.Locaciones.FindAsync(id);
            if (locacion == null)
            {
                _logger.LogWarning($"Locacion with ID {id} not found.");
                throw new Exception("Locacion no encontrada");
            }

            _context.Locaciones.Remove(locacion);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Locacion with ID {id} has been deleted.");
        }
    }

    public class UsuarioServices(ContextoBD context, ILogger<UsuarioServices> logger, IMapper mapper) : IUsuarioServices
    {
        private readonly ContextoBD _context = context;
        private readonly ILogger<UsuarioServices> _logger = logger;
        private readonly IMapper _mapper = mapper;

    
        public async Task<IEnumerable<Usuario>> GetAllUsersAsync()
    {
        _logger.LogInformation("Retrieving all users from the database without filters.");

        if (_context.Usuarios == null)
        {
            _logger.LogWarning("Usuarios DbSet is null.");
            return new List<Usuario>(); // Devuelve una lista vacía si no hay usuarios
        }

        var usuarios = await _context.Usuarios.ToListAsync();

        _logger.LogInformation($"Retrieved {usuarios.Count} users.");

        return usuarios;
    }
    
    
    
    public async Task<IEnumerable<Usuario>> GetAllAsync(string? email = null, string? password = null)
    {
        _logger.LogInformation("Retrieving users from the database with optional filters.");

        if (_context.Usuarios == null)
        {
            _logger.LogWarning("Usuarios DbSet is null.");
            return new List<Usuario>(); // Devuelve una lista vacía si no hay usuarios
        }

        var query = _context.Usuarios.AsQueryable();

        // Solo aplica los filtros si los parámetros no son nulos ni vacíos
        if (!string.IsNullOrEmpty(email))
        {
            query = query.Where(u => u.Email == email);
        }

        if (!string.IsNullOrEmpty(password))
        {
            query = query.Where(u => u.Password == password);
        }

        var usuarios = await query.ToListAsync();

        _logger.LogInformation($"Retrieved {usuarios.Count} users with the specified filters.");

        return usuarios;
    }


        public async Task<Usuario> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Retrieving user with ID {id}.");

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                _logger.LogWarning($"Usuario with ID {id} not found.");
                throw new Exception("Usuario no encontrado");
            }

            return usuario;
        }

        public async Task CreateUsuarioAsync(CrearUsuarioReq request)
        {
            _logger.LogInformation("Creating a new user.");

            if (_context.Usuarios == null)
            {
                _logger.LogError("Usuarios DbSet is not available.");
                throw new InvalidOperationException("La base de datos no está disponible.");
            }

            var usuario = _mapper.Map<Usuario>(request);
            usuario.UpdatedOn = DateTime.UtcNow;

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Usuario with ID {usuario.UsuarioId} has been created.");
        }

        public async Task UpdateUsuarioAsync(int id, ActualizarUsuarioReq request)
        {
            _logger.LogInformation($"Updating user with ID {id}.");

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                _logger.LogWarning($"Usuario with ID {id} not found.");
                throw new Exception("Usuario no encontrado");
            }

            usuario = _mapper.Map(request, usuario);
            usuario.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Usuario with ID {id} has been updated.");
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            _logger.LogInformation($"Deleting user with ID {id}.");

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                _logger.LogWarning($"Usuario with ID {id} not found.");
                throw new Exception("Usuario no encontrado");
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Usuario with ID {id} has been deleted.");
        }

        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class ProductoServices(ContextoBD context, ILogger<ProductoServices> logger, IMapper mapper) : IProductoServices
    {
        private readonly ContextoBD _context = context;
        private readonly ILogger<ProductoServices> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all products with their categories from the database.");

            if (_context.Productos == null)
            {
                _logger.LogWarning("Productos DbSet is null.");
                return new List<Producto>(); // Retorna una lista vacía si no hay productos
            }

            // Usamos Include para cargar la propiedad 'Categoria' junto con los productos
            var productos = await _context.Productos
                                        .Include(p => p.Categoria) // Eager loading de la categoría
                                        .ToListAsync();

            _logger.LogInformation($"Retrieved {productos.Count} products.");

            return productos;
        }


        public async Task<Producto> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Retrieving product with ID {id}.");

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                _logger.LogWarning($"Producto with ID {id} not found.");
                throw new Exception("Producto no encontrado");
            }

            return producto;
        }

        public async Task CreateProductoAsync(CrearProductoReq request)
        {
            _logger.LogInformation("Creating a new product.");
            const int maxSize = 2 * 1024 * 1024; 

            if (request.Imagen != null && request.Imagen.Length > maxSize)
            {
                throw new ArgumentException("El tamaño de la imagen es demasiado grande. Máximo permitido: 2 MB.");
            }
            if (request.Imagen != null)
            {
                try
                {
                    byte[] imagenBytes = Convert.FromBase64String(request.Imagen);
                }
                catch (FormatException)
                {
                    throw new ArgumentException("La imagen proporcionada no es una cadena base64 válida.");
                }
            }
            if (_context.Productos == null)
            {
                _logger.LogError("Productos DbSet is not available.");
                throw new InvalidOperationException("La base de datos no está disponible.");
            }

            var producto = _mapper.Map<Producto>(request);
            producto.UpdatedOn = DateTime.UtcNow;

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Producto with ID {producto.ProductoId} has been created.");
        }

        public async Task UpdateProductoAsync(int id, ActualizarProductoReq request)
        {
            _logger.LogInformation($"Updating product with ID {id}.");

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                _logger.LogWarning($"Producto with ID {id} not found.");
                throw new Exception("Producto no encontrado");
            }

            const int maxSize = 2 * 1024 * 1024; // 2 MB

            if (request.Imagen != null && request.Imagen.Length > maxSize)
            {
                throw new ArgumentException("El tamaño de la imagen es demasiado grande. Máximo permitido: 2 MB.");
            }

            if (request.Imagen != null)
            {
                try
                {
                    byte[] imagenBytes = Convert.FromBase64String(request.Imagen);
                    producto.Imagen = imagenBytes;
                }
                catch (FormatException)
                {
                    throw new ArgumentException("La imagen proporcionada no es una cadena base64 válida.");
                }
            }

            // Mapear el resto de los campos de la solicitud
            producto = _mapper.Map(request, producto);
            producto.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Producto with ID {id} has been updated.");
        }


        public async Task DeleteProductoAsync(int id)
        {
            _logger.LogInformation($"Deleting product with ID {id}.");

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                _logger.LogWarning($"Producto with ID {id} not found.");
                throw new Exception("Producto no encontrado");
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Producto with ID {id} has been deleted.");
        }
    }

    public class OrdenServices(ContextoBD context, ILogger<OrdenServices> logger, IMapper mapper) : IOrdenServices
    {
        private readonly ContextoBD _context = context;
        private readonly ILogger<OrdenServices> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<Orden>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all orders from the database.");

            if (_context.Ordenes == null)
            {
                _logger.LogWarning("Ordenes DbSet is null.");
                return [];
            }

            var ordenes = await _context.Ordenes.ToListAsync();
            _logger.LogInformation($"Retrieved {ordenes.Count} orders.");

            return ordenes;
        }

        public async Task<Orden> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Retrieving order with ID {id}.");

            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                _logger.LogWarning($"Orden with ID {id} not found.");
                throw new Exception("Orden no encontrada");
            }

            return orden;
        }

        public async Task CreateOrdenAsync(CrearOrdenReq request)
        {
            _logger.LogInformation("Creating a new order.");

            if (_context.Ordenes == null)
            {
                _logger.LogError("Ordenes DbSet is not available.");
                throw new InvalidOperationException("La base de datos no está disponible.");
            }

            var orden = _mapper.Map<Orden>(request);
            orden.UpdatedOn = DateTime.UtcNow;

            _context.Ordenes.Add(orden);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Orden with ID {orden.OrdenId} has been created.");
        }

        public async Task UpdateOrdenAsync(int id, ActualizarOrdenReq request)
        {
            _logger.LogInformation($"Updating order with ID {id}.");

            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                _logger.LogWarning($"Orden with ID {id} not found.");
                throw new Exception("Orden no encontrada");
            }

            orden = _mapper.Map(request, orden);
            orden.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Orden with ID {id} has been updated.");
        }

        public async Task DeleteOrdenAsync(int id)
        {
            _logger.LogInformation($"Deleting order with ID {id}.");

            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                _logger.LogWarning($"Orden with ID {id} not found.");
                throw new Exception("Orden no encontrada");
            }

            _context.Ordenes.Remove(orden);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Orden with ID {id} has been deleted.");
        }
    }

    public class OrdenDetalleServices(ContextoBD context, ILogger<OrdenDetalleServices> logger, IMapper mapper) : IOrdenDetalleServices
{
    private readonly ContextoBD _context = context;
    private readonly ILogger<OrdenDetalleServices> _logger = logger;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<DetalleOrden>> GetAllAsync()
    {
        _logger.LogInformation("Retrieving all order details with their orders and products from the database.");

        if (_context.DetalleOrdenes == null)
        {
            _logger.LogWarning("OrdenDetalles DbSet is null.");
            return new List<DetalleOrden>(); // Retorna una lista vacía si no hay detalles de orden
        }

        // Usamos Include para cargar las entidades relacionadas 'Orden' y 'Producto'
        var ordenDetalles = await _context.DetalleOrdenes
                                          .Include(dt => dt.Orden)  // Eager loading de la orden
                                          .Include(dt => dt.Producto) // Eager loading del producto
                                          .ToListAsync();

        _logger.LogInformation($"Retrieved {ordenDetalles.Count} order details.");

        return _mapper.Map<IEnumerable<DetalleOrden>>(ordenDetalles);
    }

    public async Task<IEnumerable<DetalleOrden>> GetByOrdenIdAsync(int ordenId)
    {
        _logger.LogInformation($"Retrieving order details for OrdenId {ordenId}.");

        var detallesOrden = await _context.DetalleOrdenes
            .Where(d => d.OrdenId == ordenId)
            .Include(d => d.Orden)
            .Include(d => d.Producto)
            .ToListAsync();

        if (detallesOrden == null || detallesOrden.Count == 0)
        {
            _logger.LogWarning($"No details found for OrdenId {ordenId}.");
            throw new Exception("No se encontraron detalles de la orden");
        }

        _logger.LogInformation($"Retrieved {detallesOrden.Count} details for OrdenId {ordenId}.");

        return _mapper.Map<IEnumerable<DetalleOrden>>(detallesOrden);
    }

    public async Task<DetalleOrden> GetByIdAsync(int id)
    {
        _logger.LogInformation($"Retrieving order detail with ID {id}.");

        var ordenDetalle = await _context.DetalleOrdenes
            .Include(dt => dt.Orden)  // Cargar la orden relacionada
            .Include(dt => dt.Producto) // Cargar el producto relacionado
            .FirstOrDefaultAsync(dt => dt.OrdenDtId == id); // Usamos FirstOrDefaultAsync para buscar por el id

        if (ordenDetalle == null)
        {
            _logger.LogWarning($"OrdenDetalle with ID {id} not found.");
            throw new Exception("OrdenDetalle no encontrado");
        }

        _logger.LogInformation($"Retrieved order detail with ID {id}.");

        return _mapper.Map<DetalleOrden>(ordenDetalle);
    }

    public async Task CreateOrdenDetalleAsync(CrearOrdenDetalleReq request)
    {
        _logger.LogInformation("Creating a new order detail.");

        if (_context.DetalleOrdenes == null)
        {
            _logger.LogError("OrdenDetalles DbSet is not available.");
            throw new InvalidOperationException("La base de datos no está disponible.");
        }

        var ordenDetalle = _mapper.Map<DetalleOrden>(request);
        ordenDetalle.UpdatedOn = DateTime.UtcNow;

        _context.DetalleOrdenes.Add(ordenDetalle);
        await _context.SaveChangesAsync();

        _logger.LogInformation($"OrdenDetalle with ID {ordenDetalle.OrdenDtId} has been created.");
    }

    public async Task UpdateOrdenDetalleAsync(int id, ActualizarOrdenDetalleReq request)
    {
        _logger.LogInformation($"Updating order detail with ID {id}.");

        var ordenDetalle = await _context.DetalleOrdenes.FindAsync(id);
        if (ordenDetalle == null)
        {
            _logger.LogWarning($"OrdenDetalle with ID {id} not found.");
            throw new Exception("OrdenDetalle no encontrado");
        }

        ordenDetalle = _mapper.Map(request, ordenDetalle);
        ordenDetalle.UpdatedOn = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        _logger.LogInformation($"OrdenDetalle with ID {id} has been updated.");
    }

    public async Task DeleteOrdenDetalleAsync(int id)
    {
        _logger.LogInformation($"Deleting order detail with ID {id}.");

        var ordenDetalle = await _context.DetalleOrdenes.FindAsync(id);
        if (ordenDetalle == null)
        {
            _logger.LogWarning($"OrdenDetalle with ID {id} not found.");
            throw new Exception("OrdenDetalle no encontrado");
        }

        _context.DetalleOrdenes.Remove(ordenDetalle);
        await _context.SaveChangesAsync();

        _logger.LogInformation($"OrdenDetalle with ID {id} has been deleted.");
    }
}


public class StatusOrdenServices(ContextoBD context, ILogger<StatusOrdenServices> logger, IMapper mapper) : IStatusOrdenServices
{
    private readonly ContextoBD _context = context;
    private readonly ILogger<StatusOrdenServices> _logger = logger;
    private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<StatusOrden>> GetAllAsync()
    {
        _logger.LogInformation("Retrieving all order statuses from the database.");

        if (_context.StatusOrdenes == null)
        {
            _logger.LogWarning("StatusOrdenes DbSet is null.");
            return [];
        }

        var statusOrdenes = await _context.StatusOrdenes.ToListAsync();
        _logger.LogInformation($"Retrieved {statusOrdenes.Count} order statuses.");

        return statusOrdenes;
    }

    public async Task<StatusOrden> GetByIdAsync(int id)
    {
        _logger.LogInformation($"Retrieving order status with ID {id}.");

        var statusOrden = await _context.StatusOrdenes.FindAsync(id);
        if (statusOrden == null)
        {
            _logger.LogWarning($"StatusOrden with ID {id} not found.");
            throw new Exception("Status de orden no encontrado");
        }

        return statusOrden;
    }
}

public class CategoriaServices(ContextoBD context, ILogger<CategoriaServices> logger, IMapper mapper) : ICategoriaServices
{
    private readonly ContextoBD _context = context;
    private readonly ILogger<CategoriaServices> _logger = logger;
    private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<Categoria>> GetAllAsync()
    {
        _logger.LogInformation("Retrieving all categories from the database.");

        if (_context.Categorias == null)
        {
            _logger.LogWarning("Categorias DbSet is null.");
            return [];
        }

        var categorias = await _context.Categorias.ToListAsync();
        _logger.LogInformation($"Retrieved {categorias.Count} categories.");

        return categorias;
    }

    public async Task<Categoria> GetByIdAsync(int id)
    {
        _logger.LogInformation($"Retrieving category with ID {id}.");

        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null)
        {
            _logger.LogWarning($"Categoria with ID {id} not found.");
            throw new Exception("Categoría no encontrada");
        }

        return categoria;
    }
}

}
