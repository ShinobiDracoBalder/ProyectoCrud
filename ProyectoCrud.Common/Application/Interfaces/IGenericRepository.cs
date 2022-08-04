using ProyectoCrud.Common.Responses;

namespace ProyectoCrud.Common.Application.Interfaces
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<Response<TEntityModel>> InsertarAsync(TEntityModel modelo);
        Task<Response<TEntityModel>> ActualizarAsync(TEntityModel modelo);
        Task<Response<TEntityModel>> EliminarAsync(int id);
        Task<Response<TEntityModel>> ObtenerAsync(int id);
        Task<Response<TEntityModel>> ObtenerTodosAsync();
    }
}
