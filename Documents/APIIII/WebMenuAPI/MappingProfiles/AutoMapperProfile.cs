using AutoMapper;
using WebMenuAPI.Models;
using WebMenuAPI.Contracts;  // Asegúrate de incluir la carpeta de los contratos

namespace WebMenuAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Crear los mapeos de Create
            CreateMap<CrearOrdenReq, Orden>();  // Mapea los campos de CrearOrdenReq a la entidad Orden
            CreateMap<CrearUsuarioReq, Usuario>();  // Mapea CrearUsuarioReq a Usuario
            CreateMap<CrearComentarioReq, Comentario>();  // Mapea CrearComentarioReq a Comentario
            CreateMap<CrearLocacionReq, Locacion>();  // Mapea CrearLocacionReq a Locacion
            CreateMap<CrearProductoReq, Producto>();  // Mapea CrearProductoReq a Producto
            CreateMap<CrearOrdenDetalleReq, DetalleOrden>();  // Mapea CrearOrdenDetalleReq a DetalleOrden
            CreateMap<CrearPagoReq, Pago>();  // Mapea CrearPagoReq a Pago

            // Crear los mapeos de Update
            CreateMap<ActualizarOrdenReq, Orden>();  // Mapea los campos de ActualizarOrdenReq a la entidad Orden
            CreateMap<ActualizarUsuarioReq, Usuario>();  // Mapea ActualizarUsuarioReq a Usuario
            CreateMap<ActualizarComentarioReq, Comentario>();  // Mapea ActualizarComentarioReq a Comentario
            CreateMap<ActualizarLocacionReq, Locacion>();  // Mapea ActualizarLocacionReq a Locacion
            CreateMap<ActualizarProductoReq, Producto>();  // Mapea ActualizarProductoReq a Producto
            CreateMap<ActualizarOrdenDetalleReq, DetalleOrden>();  // Mapea ActualizarOrdenDetalleReq a DetalleOrden
        }
    }
}
