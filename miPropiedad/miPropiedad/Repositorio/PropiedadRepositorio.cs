using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using miPropiedad.data;
using miPropiedad.Dtos;
using miPropiedad.interfaces;
using miPropiedad.Model;
using miPropiedad.resquest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace miPropiedad.Repositorio
{
    public class PropiedadRepositorio : IPropiedadRepositorio
    {
        
       private readonly miPropiedadContext _db;
        public PropiedadRepositorio(miPropiedadContext db)
        {
            _db = db;
           
        }

      
        
        public  async  Task InsertarPropiedad(Propiedad model , List<IFormFile> fotos)
        {
            int contador = 1;

             if(fotos.Count > 0)
             {
                 foreach(var foto in fotos)
                 {
                     var filePath = "C:\\Users\\Usuario\\Desktop\\miPropiedad\\miPropiedad\\miPropiedad\\Recursos\\imagenes\\" + foto.FileName;

                     using (var stream  = System.IO.File.Create(filePath))
                     {
                        await foto.CopyToAsync(stream);

                     }

                    model.Fotos = Path.GetFileName(foto.FileName);

                    if(contador == 1)
                    {
                        _db.Propiedad.Add(model);
                        await _db.SaveChangesAsync();
                        contador++;
                    }

                   
                    Foto image = new Foto();        
                    image.Imagen = Path.GetFileName(foto.FileName);
                    var ultimaPropiedadId = _db.Propiedad.Max(p => p.IdPropiedad);
                    image.IdPropiedad = ultimaPropiedadId;

                    _db.Foto.AddRange(image);
                    await _db.SaveChangesAsync();

                }
                 
             }

         }

       

        public async Task<IEnumerable<Propiedad>> GetPropiedades()
        {
            var propiedades = await  _db.Propiedad.OrderByDescending(x => x.IdPropiedad).ToListAsync();
            return propiedades;

        }

        public async Task<Propiedad> GetByidPropiedad(int idPropiedad)
        {
            var propiedadId = await _db.Propiedad.FindAsync(idPropiedad);
            return propiedadId;
        }

        public async Task UpdatePropiedad(Propiedad propiedad,List<IFormFile> fotos)
        {
            if (fotos.Count > 0)
            {
                foreach (var foto in fotos)
                {
                    var filePath = "C:\\Users\\Usuario\\Desktop\\miPropiedad\\miPropiedad\\miPropiedad\\Recursos\\imagenes\\" + foto.FileName;

                    using (var stream = System.IO.File.Create(filePath))
                    {
                     
                       await foto.CopyToAsync(stream);

                    }



                    propiedad.Fotos = Path.GetFileName(foto.FileName);


                }

            }



            var propiedadId = await _db.Propiedad.FindAsync(propiedad.IdPropiedad);
            propiedadId.Habitaciones = propiedad.Habitaciones;
            propiedadId.IdPropietario = propiedad.IdPropietario;
            propiedadId.Operacion = propiedad.Operacion;
            propiedadId.Pais = propiedad.Pais;
            propiedadId.Precio = propiedad.Precio;
            propiedadId.Sector = propiedad.Sector;
            propiedadId.Fotos = propiedad.Fotos;
            propiedadId.Direccion = propiedad.Direccion;
            propiedadId.Ciudad = propiedad.Ciudad;
            propiedadId.Caracteristica = propiedad.Caracteristica;
            propiedadId.Banos = propiedad.Banos;
            propiedadId.Fotos = propiedad.Fotos;

              _db.Propiedad.Update(propiedadId);

             await  _db.SaveChangesAsync();

            
        }

        public async Task DeletePropiedad(int id)
        {
            var propiedadId = await _db.Propiedad.FindAsync(id);

            _db.Remove(propiedadId);

            await _db.SaveChangesAsync();
        }
    }
}
