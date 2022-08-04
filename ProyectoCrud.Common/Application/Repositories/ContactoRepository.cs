using Microsoft.EntityFrameworkCore;
using ProyectoCrud.Common.Application.Interfaces;
using ProyectoCrud.Common.DataContext;
using ProyectoCrud.Common.Entities;
using ProyectoCrud.Common.Responses;

namespace ProyectoCrud.Common.Application.Repositories
{
    public class ContactoRepository : IGenericRepository<Contacto>
    {
        private readonly DataBaseContext _dataBaseContext;

        public ContactoRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<Response<Contacto>> ActualizarAsync(Contacto modelo)
        {
            try
            {
                _dataBaseContext.Contacto.Update(modelo);
                await SaveAllAsync();
                return new Response<Contacto>
                {
                    IsSuccess = true,
                    Message = "Win",
                    Result = modelo
                };
            }
            catch (Exception ex)
            {

                return new Response<Contacto> {
                    IsSuccess = false,
                    Message = ex.Message,   
                };
            }
        }

        public async Task<Response<Contacto>> EliminarAsync(int id)
        {
            try
            {
                Contacto modelo = _dataBaseContext.Contacto.First(c => c.IdContacto == id);
                _dataBaseContext.Contacto.Remove(modelo);
                await SaveAllAsync();
                return new Response<Contacto>
                {
                    IsSuccess = true,
                    Message = "Win",
                    Result = modelo
                };
            }
            catch (Exception ex)
            {
                return new Response<Contacto>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response<Contacto>> InsertarAsync(Contacto modelo)
        {
            try
            {
                _dataBaseContext.Contacto.Add(modelo);
                await SaveAllAsync();
                return new Response<Contacto>
                {
                    IsSuccess = true,
                    Message = "Win",
                    Result = modelo
                };
            }
            catch (Exception ex)
            {
                return new Response<Contacto>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response<Contacto>> ObtenerAsync(int id)
        {
            try
            {
                Contacto model = await _dataBaseContext.Contacto.
                FirstOrDefaultAsync(c => c.IdContacto == id);
                return new Response<Contacto>
                {
                    IsSuccess = true,
                    Message = "Win",
                    Result = model
                };
            }
            catch (Exception ex)
            {
                return new Response<Contacto>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
          
        }

        public async Task<Response<Contacto>> ObtenerTodosAsync()
        {
            try
            {
                List<Contacto> queryContactoSQL = await _dataBaseContext.Contacto.ToListAsync();
                return new Response<Contacto>
                {
                    IsSuccess = true,
                    Message = "Win",
                    ListResult = queryContactoSQL
                };
            }
            catch (Exception ex)
            {
                return new Response<Contacto>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
        private async Task<bool> SaveAllAsync()
        {
            return await _dataBaseContext.SaveChangesAsync() > 0;
        }
    }
}
