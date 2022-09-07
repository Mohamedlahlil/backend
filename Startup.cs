using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GPI.Data;
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
using Newtonsoft.Json.Serialization;

namespace GPI
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
            services.AddDbContext<GPIContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("GPIConnection")));
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IVilleRepo, SqlVilleRepo>();
            services.AddScoped<IFournisseurRepo, SqlFournisseurRepo>();
            services.AddScoped<ICategorieRepo, SqlCategorieRepo>();
            services.AddScoped<ICentreRepo, SqlCentreRepo>();
            services.AddScoped<ITypeCategorieRepo, TypeCategorieRepo>();
            services.AddScoped<ISousCategorieRepo, SousCategorieRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IServiceRepo, ServiceRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IRoleuserRepo, RoleuserRepo>();
            services.AddScoped<IAffLogicielRepo, AffLogicielRepo>();
            services.AddScoped<IAffTelephonieRepo, AffTelephonieRepo>();
            services.AddScoped<IAffArticleRepo, AffArticleRepo>();
            services.AddScoped<ITypeRepo, TypeRepo>();
            services.AddScoped<ITelephonieRepo, TelephonieRepo>();
            services.AddScoped<ILogicielRepo, LogicielRepo>();
            services.AddScoped<IArticleRepo, ArticleRepo>();
            services.AddScoped<IReparationRepo, ReparationRepo>();
            services.AddScoped<ITicketRepo, TicketRepo>();
            services.AddScoped<IPausesRepo, PausesRepo>();
            services.AddScoped<IAffHistoriqueRepo, AffHistoriqueRepo>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GPI v1"));
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
