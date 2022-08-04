using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProyectoCrud.Common.Entities;
using System.Data;
using System.Xml.Linq;

namespace ProyectoCrud.AplicacionWeb.Controllers
{
    public class MasterDetailController : Controller
    {
        private readonly string _cadenaSql;
        public MasterDetailController(IConfiguration _config)
        {
            _cadenaSql = _config.GetConnectionString("DefaultConnection");
        }
        public IActionResult Index()
        {
            return View();
        }

        //reference models
        //reference System.Xml.Linq;
        [HttpPost]
        public JsonResult GuardarVenta([FromBody] Venta body)
        {

            XElement venta = new XElement("Venta",
                new XElement("NumeroDocumento", body.NumeroDocumento),
                new XElement("RazonSocial", body.RazonSocial),
                new XElement("Total", body.Total)
            );

            XElement oDetalleVenta = new XElement("Detalle_Venta");
            foreach (Detalle_Venta item in body.lstDetalleVenta)
            {
                oDetalleVenta.Add(new XElement("Item",
                    new XElement("Producto", item.Producto),
                    new XElement("Precio", item.Precio),
                    new XElement("Cantidad", item.Cantidad),
                    new XElement("Total", item.Total)
                    ));
            }
            venta.Add(oDetalleVenta);

            using (SqlConnection oconexion = new SqlConnection(_cadenaSql))
            {
                oconexion.Open();
                SqlCommand cmd = new SqlCommand("sp_GuardarVenta", oconexion);
                cmd.Parameters.Add("venta_xml", SqlDbType.Xml).Value = venta.ToString();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }

            return Json(new { respuesta = true });
        }

    }
}
