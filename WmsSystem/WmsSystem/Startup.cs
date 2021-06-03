using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.Swagger;
using WmsSystem.Domain.Interfaces.Repositories;
using WmsSystem.Domain.Interfaces.Services;
using WmsSystem.Domain.Services;
using WmsSystem.Repository.Repositories;

namespace WmsSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //SERVICES
            services.AddSingleton<IProdutosServices, ProdutosServices>();
            services.AddSingleton<ICategoriasServices, CategoriasServices>();
            services.AddSingleton<IComprasServices, ComprasServices>();
            services.AddSingleton<IVendasServices, VendasServices>();

            //REPOSITORY
            services.AddSingleton<IProdutosRepository, ProdutoRepository>();
            services.AddSingleton<ICategoriasRepository, CategoriaRepository>();
            services.AddSingleton<IComprasRepository, ComprasRepository>();
            services.AddSingleton<IVendasRepository, VendaRepository>();

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            //services.AddSwaggerGen(opt =>
            //{
            //    opt.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "Todo API",
            //        Description = "Um exemplo de aplica��o ASP.NET Core Web API",
            //        TermsOfService = "N�o aplic�vel",
            //        Contact = new Contact
            //        {
            //            Name = "Wladimilson",
            //            Email = "contato@treinaweb.com.br",
            //            Url = "https://treinaweb.com.br"
            //        },
            //        License = new License
            //        {
            //            Name = "CC BY",
            //            Url = "https://creativecommons.org/licenses/by/4.0"
            //        }
            //    });

            //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //    opt.IncludeXmlComments(xmlPath);

            //    var security = new Dictionary<string, IEnumerable<string>>
            //    {
            //        {"Bearer", new string[] { }},
            //    };

            //    opt.AddSecurityDefinition(
            //        "Bearer",
            //        new ApiKeyScheme
            //        {
            //            In = "header",
            //            Description = "Copie 'Bearer ' + token'",
            //            Name = "Authorization",
            //            Type = "apiKey"
            //        });

            //    opt.AddSecurityRequirement(security);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {           

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
