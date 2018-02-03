using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoUniversidade.Dados;
using Swashbuckle.AspNetCore.Swagger;

namespace ProjetoUniversidade
{
    public class Startup
    {
        IConfiguration Configuration;

        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UniversidadeContexto>(options=>options.UseSqlServer(Configuration.GetConnectionString("BancoUniversidade")));
            services.AddMvc();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("V1", new Info{
                    Version="V1",
                    Title="Cursos Online",
                    Description="Documentação da API de Cursos Online",
                    TermsOfService="none",
                    Contact = new Contact
                    {
                        Name = "Amanda Moraes",
                        Email = "a.bmoraesti@gmail.com",
                        Url = "www.uniapi.com"
                    }
                });
                
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath,"CursosOnline.xml");

                c.IncludeXmlComments(xmlPath);
        });

                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
/// <summary>
/// Configure os serviços
/// </summary>
/// <param name="app">app</param>
/// <param name="env">env</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c=>{
                c.SwaggerEndpoint("/swagger/V1/swagger.json","API v1");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
