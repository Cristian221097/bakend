using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using miPropiedad.Dtos;
using miPropiedad.interfaces;
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
    public class FotoController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IFotoRepositorio _foto;
        public FotoController(IFotoRepositorio foto, IMapper mapper)
        {
            _foto = foto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFotos()
        {
            Repuesta respuesta = new Repuesta();
           
            var fotos = await _foto.GetFotos();
            var fotosDtos = _mapper.Map<IEnumerable<FotoDtos>>(fotos);
            respuesta.Data = fotosDtos;
            respuesta.Exito = 1;
            respuesta.Mensaje = "200";

            return Ok(respuesta);
        }
    }
}
