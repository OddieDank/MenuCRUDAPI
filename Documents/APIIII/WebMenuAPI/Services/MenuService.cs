using WebMenuAPI.Contracts;
using WebMenuAPI.Interfaces;
using WebMenuAPI.Context;
using WebMenuAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WebMenuAPI.Services
{
    public class ComentarioServices : IComentarioServices
    {
        private readonly ContextoBD _context;
        private readonly ILogger<ComentarioServices> _logger;
        private readonly IMapper _mapper;

        public ComentarioServices(ContextoBD context, ILogger<ComentarioServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Comentario>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all comments from the database.");

            if (_context.Comentarios == null)
            {
                _logger.LogWarning("Comentarios DbSet is null.");
                return new List<Comentario>();
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
    public class PagoServices : IPagoServices
    {
        private readonly ContextoBD _context;
        private readonly ILogger<PagoServices> _logger;
        private readonly IMapper _mapper;

        public PagoServices(ContextoBD context, ILogger<PagoServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Pago>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all payments from the database.");

            if (_context.Pagos == null)
            {
                _logger.LogWarning("Pagos DbSet is null.");
                return new List<Pago>();
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

    public class LocacionServices : ILocacionServices
    {
        private readonly ContextoBD _context;
        private readonly ILogger<LocacionServices> _logger;
        private readonly IMapper _mapper;

        public LocacionServices(ContextoBD context, ILogger<LocacionServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Locacion>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all locations from the database.");

            if (_context.Locaciones == null)
            {
                _logger.LogWarning("Locaciones DbSet is null.");
                return new List<Locacion>();
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

    public class UsuarioServices : IUsuarioServices
    {
        private readonly ContextoBD _context;
        private readonly ILogger<UsuarioServices> _logger;
        private readonly IMapper _mapper;

        public UsuarioServices(ContextoBD context, ILogger<UsuarioServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all users from the database.");

            if (_context.Usuarios == null)
            {
                _logger.LogWarning("Usuarios DbSet is null.");
                return new List<Usuario>();
            }

            var usuarios = await _context.Usuarios.ToListAsync();
            _logger.LogInformation($"Retrieved {usuarios.Count} users.");

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
    }

    public class ProductoServices : IProductoServices
    {
        private readonly ContextoBD _context;
        private readonly ILogger<ProductoServices> _logger;
        private readonly IMapper _mapper;

        public ProductoServices(ContextoBD context, ILogger<ProductoServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all products from the database.");

            if (_context.Productos == null)
            {
                _logger.LogWarning("Productos DbSet is null.");
                return new List<Producto>();
            }

            var productos = await _context.Productos.ToListAsync();
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

    public class OrdenServices : IOrdenServices
    {
        private readonly ContextoBD _context;
        private readonly ILogger<OrdenServices> _logger;
        private readonly IMapper _mapper;

        public OrdenServices(ContextoBD context, ILogger<OrdenServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Orden>> GetAllAsync()
        {
            _logger.LogInformation("Retrieving all orders from the database.");

            if (_context.Ordenes == null)
            {
                _logger.LogWarning("Ordenes DbSet is null.");
                return new List<Orden>();
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

 public class OrdenDetalleServices : IOrdenDetalleServices
{
    private readonly ContextoBD _context;
    private readonly ILogger<OrdenDetalleServices> _logger;
    private readonly IMapper _mapper;

    public OrdenDetalleServices(ContextoBD context, ILogger<OrdenDetalleServices> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DetalleOrden>> GetAllAsync()
    {
        _logger.LogInformation("Retrieving all order details from the database.");

        if (_context.DetalleOrdenes == null)
        {
            _logger.LogWarning("OrdenDetalles DbSet is null.");
            return new List<DetalleOrden>(); 
        }

        var ordenDetalles = await _context.DetalleOrdenes.ToListAsync();
        _logger.LogInformation($"Retrieved {ordenDetalles.Count} order details.");

        return _mapper.Map<IEnumerable<DetalleOrden>>(ordenDetalles); 
    }

    public async Task<DetalleOrden> GetByIdAsync(int id)
    {
        _logger.LogInformation($"Retrieving order detail with ID {id}.");

        var ordenDetalle = await _context.DetalleOrdenes.FindAsync(id);
        if (ordenDetalle == null)
        {
            _logger.LogWarning($"OrdenDetalle with ID {id} not found.");
            throw new Exception("OrdenDetalle no encontrado");
        }

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


}
