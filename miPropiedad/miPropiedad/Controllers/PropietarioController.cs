using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miPropiedad.data;
using miPropiedad.Model;
using miPropiedad.resquest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miPropiedad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(Propietario propietario)
        {
            Repuesta repuesta = new Repuesta();

            using (miPropiedadContext db = new miPropiedadContext())
            {
                db.Propietario.Add(propietario);
                db.SaveChanges();

            }

            repuesta.Exito = 1;
            repuesta.Data = propietario;
            repuesta.Mensaje = "guardado correctamente";
            return Ok(repuesta);
        }


    }
}
