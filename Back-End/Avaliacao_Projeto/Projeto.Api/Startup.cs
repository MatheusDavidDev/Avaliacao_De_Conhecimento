using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Projeto.Domain.Handlers;
using Projeto.Domain.Handlers.Empresa;
using Projeto.Domain.Handlers.Funcionario;
using Projeto.Domain.Handlers.PessoaFisica;
using Projeto.Domain.Handlers.PessoaJuridica;
using Projeto.Domain.Repository;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projeto.Api
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

            //services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            //services.AddControllers().AddJsonOptions(x =>
            //x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            // CONTEXT DO BANCO
            services.AddDbContext<ProjetoContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Projeto.Api", Version = "v1" });
            });

            // CORS
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod());
            });

            


            // Injecoes de dependecia

            #region Injecoes de dependencias Emrpesa
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<CadastrarEmpresaHandler, CadastrarEmpresaHandler>();
            services.AddTransient<ListarEmpresaHandler, ListarEmpresaHandler>();
            #endregion

            #region Injecoes de dependencias do Fornecedor
            services.AddTransient<IFornecedorRepository, FornecedorRepository>();
            services.AddTransient<ListarFornecedorHandler, ListarFornecedorHandler>();
            #endregion

            #region Injecoes de dependencias Pessoa fisica
            services.AddTransient<IPessoaFisicaRepository, PessoaFisicaRepository>();
            services.AddTransient<CadastrarPessoaFisicaHandler, CadastrarPessoaFisicaHandler>();
            services.AddTransient<ListarPessoaFisicaHandler, ListarPessoaFisicaHandler>();
            #endregion

            #region Injecoes de dependencias Pessoa Juridica
            services.AddTransient<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
            services.AddTransient<CadastrarPessoaJuridicaHandler, CadastrarPessoaJuridicaHandler>();
            services.AddTransient<ListarPessoaJuridicaHandler, ListarPessoaJuridicaHandler>();
            #endregion

            #region Telefone
            services.AddTransient<ITelefoneRepository, TelefoneRepository>();
            services.AddTransient<CadastrarTelefoneHandler, CadastrarTelefoneHandler>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // SWAGGER
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto.Api v1"));
            }

            //CORS

            app.UseCors("CorsPolicy");

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
