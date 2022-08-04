using Microsoft.AspNetCore.Mvc;
using ProyectoCrud.AplicacionWeb.Models;
using ProyectoCrud.AplicacionWeb.Models.ViewModels;
using ProyectoCrud.Common.Entities;
using ProyectoCrud.Common.Responses;
using ProyectoCrud.Common.Services;
using System.Diagnostics;
using System.Globalization;

namespace ProyectoCrud.AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContactoService _contactoService;

        public HomeController(ILogger<HomeController> logger, IContactoService contactoServ)
        {
            _logger = logger;
            _contactoService = contactoServ;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {

            Response<Contacto> queryContactoSQL = await _contactoService.ObtenerTodosAsync();

            List<ContactsVM> lista = queryContactoSQL.ListResult
                                                     .Select(c => new ContactsVM()
                                                     {
                                                         IdContacto = c.IdContacto,
                                                         Nombre = c.Nombre,
                                                         Telefono = c.Telefono,
                                                         FechaNacimiento = c.FechaNacimiento.Value.ToString("dd/MM/yyyy")
                                                     }).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);

        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] ContactsVM modelo)
        {

            Contacto NuevoModelo = new Contacto()
            {
                Nombre = modelo.Nombre,
                Telefono = modelo.Telefono,
                FechaNacimiento = DateTime.ParseExact(modelo.FechaNacimiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"))
            };

            Response<Contacto> respuesta = await _contactoService.InsertarAsync(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta.IsSuccess });

        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ContactsVM modelo)
        {

            Contacto NuevoModelo = new Contacto()
            {
                IdContacto = modelo.IdContacto,
                Nombre = modelo.Nombre,
                Telefono = modelo.Telefono,
                FechaNacimiento = DateTime.ParseExact(modelo.FechaNacimiento, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"))
            };

            Response<Contacto> respuesta = await _contactoService.ActualizarAsync(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta.IsSuccess });

        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {

            Response<Contacto> respuesta = await _contactoService.EliminarAsync(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta.IsSuccess });

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}