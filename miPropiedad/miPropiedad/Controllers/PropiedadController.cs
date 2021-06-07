using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miPropiedad.data;
using miPropiedad.interfaces;
using miPropiedad.resquest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miPropiedad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadController : ControllerBase
    {
        
        private readonly IPropiedadRepositorio _IPropiedad;
        public PropiedadController(IPropiedadRepositorio IPropiedad)
        {
            _IPropiedad = IPropiedad;
            
        }

        [HttpPost]
        public async Task<IActionResult> insertarPost(Propiedad PropiedadModel)
        {
            Repuesta repuesta  = new Repuesta();

           await  _IPropiedad.InsertarPropiedad(PropiedadModel);
            repuesta.Data = PropiedadModel;
            repuesta.Exito = 1;
            repuesta.Mensaje = "agregado correctamente";
           return Ok(repuesta);
        }

        [HttpGet]
        public async Task<IActionResult> GetPropiedades() {
            Repuesta repuesta = new Repuesta();

            repuesta.Exito = 1;
            repuesta.Mensaje = "200";
            repuesta.Data = await _IPropiedad.GetPropiedades();
            return Ok(repuesta);

        }
    }
}
