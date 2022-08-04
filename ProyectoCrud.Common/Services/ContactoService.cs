using ProyectoCrud.Common.Application.Interfaces;
using ProyectoCrud.Common.Entities;
using ProyectoCrud.Common.Responses;
using System.Linq;

namespace ProyectoCrud.Common.Services
{
    public class ContactoService : IContactoService
    {
        private readonly IGenericRepository<Contacto> _contactRepo;

        public ContactoService(IGenericRepository<Contacto> contactRepo)
        {
            _contactRepo = contactRepo;
        }
        public async Task<Response<Contacto>> ActualizarAsync(Contacto modelo)
        {
            return await _contactRepo.ActualizarAsync(modelo);
        }

        public async Task<Response<Contacto>> EliminarAsync(int id)
        {
            return await _contactRepo.EliminarAsync(id);
        }

        public async Task<Response<Contacto>> InsertarAsync(Contacto modelo)
        {
            return await _contactRepo.InsertarAsync(modelo);
        }

        public async Task<Response<Contacto>> ObtenerAsync(int id)
        {
            return await _contactRepo.ObtenerAsync(id);
        }

        public async Task<Response<Contacto>> ObtenerPorNombreAsync(string nombreContacto)
        {
            Response<Contacto> queryContactoSQL = await _contactRepo.ObtenerTodosAsync();
            Contacto contactoM =  queryContactoSQL.ListResult.Where(c => c.Nombre == nombreContacto).FirstOrDefault();
            queryContactoSQL.Result = contactoM;
            return queryContactoSQL;
        }

        public async Task<Response<Contacto>> ObtenerTodosAsync()
        {
            return await _contactRepo.ObtenerTodosAsync();
        }
    }
}
