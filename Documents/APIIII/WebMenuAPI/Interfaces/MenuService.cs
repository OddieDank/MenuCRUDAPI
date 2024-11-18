using WebMenuAPI.Contracts;
using WebMenuAPI.Models;

namespace WebMenuAPI.Interfaces
{
        public interface IComentarioServices
    {
        Task<IEnumerable<Comentario>> GetAllAsync();
        Task<Comentario> GetByIdAsync(int id);
        Task CreateComentarioAsync(CrearComentarioReq request);
        Task UpdateComentarioAsync(int id, ActualizarComentarioReq request);
        Task DeleteComentarioAsync(int id);
    }
        public interface IPagoServices
    {
        Task<IEnumerable<Pago>> GetAllAsync();
        Task<Pago> GetByIdAsync(int id);
        Task CreatePagoAsync(CrearPagoReq request);
        Task DeletePagoAsync(int id);
    }

        public interface ILocacionServices
    {
        Task<IEnumerable<Locacion>> GetAllAsync();
        Task<Locacion> GetByIdAsync(int id);
        Task CreateLocacionAsync(CrearLocacionReq request);
        Task UpdateLocacionAsync(int id, ActualizarLocacionReq request);
        Task DeleteLocacionAsync(int id);
    }
        public interface IUsuarioServices
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task CreateUsuarioAsync(CrearUsuarioReq request);
        Task UpdateUsuarioAsync(int id, ActualizarUsuarioReq request);
        Task DeleteUsuarioAsync(int id);
    }

        public interface IProductoServices
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int id);
        Task CreateProductoAsync(CrearProductoReq request);
        Task UpdateProductoAsync(int id, ActualizarProductoReq request);
        Task DeleteProductoAsync(int id);
    }

        public interface IOrdenServices
    {
        Task<IEnumerable<Orden>> GetAllAsync();
        Task<Orden> GetByIdAsync(int id);
        Task CreateOrdenAsync(CrearOrdenReq request);
        Task UpdateOrdenAsync(int id, ActualizarOrdenReq request);
        Task DeleteOrdenAsync(int id);
    }
        public interface IOrdenDetalleServices
    {
        Task<IEnumerable<DetalleOrden>> GetAllAsync();
        Task<DetalleOrden> GetByIdAsync(int id);
        Task CreateOrdenDetalleAsync(CrearOrdenDetalleReq request);
        Task UpdateOrdenDetalleAsync(int id, ActualizarOrdenDetalleReq request);
        Task DeleteOrdenDetalleAsync(int id);
    }
        public interface IStatusOrdenServices
    {
        Task<IEnumerable<StatusOrden>> GetAllAsync();
        Task<StatusOrden> GetByIdAsync(int id);
    }

        public interface ICategoriaServices
        {
            Task<IEnumerable<Categoria>> GetAllAsync();
            Task<Categoria> GetByIdAsync(int id);
        }
}