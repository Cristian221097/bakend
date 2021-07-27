using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miPropiedad.data;
using miPropiedad.Dtos;
using miPropiedad.interfaces;
using miPropiedad.Mappings;
using miPropiedad.Model;
using miPropiedad.resquest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miPropiedad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadController : ControllerBase
    {

        private readonly IMapper _mapping;
        private readonly IPropiedadRepositorio _IPropiedad;
        public PropiedadController(IPropiedadRepositorio IPropiedad, IMapper mapping)
        {
            _IPropiedad = IPropiedad;
            _mapping = mapping;
            
            
        }

        [HttpPost]
        public async Task<IActionResult> insertarPost([FromForm] PropiedadDtos PropiedadModel,[FromForm] List<IFormFile> fotos)
        {
            Repuesta repuesta  = new Repuesta();
            var propiedad = _mapping.Map<Propiedad>(PropiedadModel);
             await  _IPropiedad.InsertarPropiedad(propiedad,fotos);
            var propiedadDtos = _mapping.Map<PropiedadDtos>(propiedad);
            repuesta.Data = propiedadDtos;
            repuesta.Exito = 1;
            repuesta.Mensaje = "200";
           return Ok(repuesta);
        }



         [HttpGet]
         public async Task<IActionResult> GetPropiedades() {
             Repuesta repuesta = new Repuesta();
             var data = await _IPropiedad.GetPropiedades();
             var dataDtos =  _mapping.Map<IEnumerable<PropiedadDtos>>(data);
             repuesta.Exito = 1;
             repuesta.Mensaje = "200";
             repuesta.Data = dataDtos;
             return Ok(repuesta);

         }

        [HttpGet("{idPropiedad}")]
        public async Task<IActionResult> getById(int idPropiedad)
        {
            Repuesta repuesta = new Repuesta();
            var propiedadId = await _IPropiedad.GetByidPropiedad(idPropiedad);
            var propiedadDtos = _mapping.Map<PropiedadDtos>(propiedadId);
            repuesta.Data = propiedadDtos;
            repuesta.Exito = 1;
            repuesta.Mensaje = "probando";
            return Ok(repuesta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropiedad(int id)
        {

            Repuesta repuesta = new Repuesta();
            await _IPropiedad.DeletePropiedad(id);
            repuesta.Exito = 1;
            repuesta.Mensaje = "200";
            return Ok(repuesta);

        }

        [HttpPut]
        public async Task<IActionResult> UpdatePropiedad([FromForm]PropiedadDtos propiedad, [FromForm] List<IFormFile> fotos)
        {
            Repuesta repuesta = new Repuesta();
            var propie = _mapping.Map<Propiedad>(propiedad);
            await _IPropiedad.UpdatePropiedad(propie,fotos);
            var propiedadDtos = _mapping.Map<PropiedadDtos>(propie);
            repuesta.Exito = 1;
            repuesta.Mensaje = "200";
            repuesta.Data = propiedadDtos;
            return Ok(repuesta);

        }
        
       
    }
}
