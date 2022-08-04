using ProyectoCrud.Common.Entities;
using ProyectoCrud.Common.Responses;

namespace ProyectoCrud.Common.Services
{
    public interface IContactoService
    {
        Task<Response<Contacto>> InsertarAsync(Contacto modelo);
        Task<Response<Contacto>> ActualizarAsync(Contacto modelo);
        Task<Response<Contacto>> EliminarAsync(int id);
        Task<Response<Contacto>> ObtenerAsync(int id);
        Task<Response<Contacto>> ObtenerTodosAsync();
        Task<Response<Contacto>> ObtenerPorNombreAsync(string nombreContacto);
    }
}
