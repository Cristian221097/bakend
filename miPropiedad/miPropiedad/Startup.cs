using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using miPropiedad.data;
using miPropiedad.interfaces;
using miPropiedad.Repositorio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace miPropiedad
{
    public class Startup
    {
        readonly string Micros = "Micors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddCors(options => {
                options.AddPolicy(name: Micros,
                                   builder =>
                                   {
                                       builder.WithHeaders("*");
                                       builder.WithOrigins("*");
                                       builder.WithMethods("*");
                                   });
            });


            services.AddControllers();

            services.Configure<FormOptions>(o =>{
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
                
            });

           services.AddDbContext<miPropiedadContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("miPropiedad"))
               
            );

            
            services.AddScoped<IPropiedadRepositorio, PropiedadRepositorio>();
            services.AddScoped<IPropietarioRepositorio, PropietarioRepositorio>();
            services.AddScoped<IFotoRepositorio, FotoRepositorio>();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(Micros);


           


            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                 Path.Combine(Directory.GetCurrentDirectory(), "Recursos")),
                RequestPath = "/Recursos"
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
