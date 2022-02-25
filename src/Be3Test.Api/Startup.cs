using AutoMapper;
using Be3Test.Api.Models;
using Be3Test.Api.Models.Base;
using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Be3Test.Domain.Repositories;
using Be3Test.Domain.Services;
using Be3Test.Infra.Context;
using Be3Test.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Text.Json.Serialization;

namespace Be3Test.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "be3 Test - Leandro Romanelli",
                        Version = "v1",
                        Description = "be3 Test - Leandro Romanelli",
                        Contact = new OpenApiContact
                        {
                            Name = "Leandro Romanelli",
                            Url = new Uri("https://github.com/leandroromanelli")
                        }
                    });

                c.IncludeXmlComments("Be3Test.Api.xml");
            });

            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();

            services.AddScoped<IInsuranceRepository, InsuranceRepository>();
            services.AddScoped<IInsuranceService, InsuranceService>();

            services.AddScoped<IInsuranceCardRepository, InsuranceCardRepository>();
            services.AddScoped<IInsuranceCardService, InsuranceCardService>();
            
            services.AddScoped<IRepository<BaseEntity>, Repository<BaseEntity>>();
            services.AddScoped<IService<BaseEntity>, Service<BaseEntity>>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PatientResponseModel, Patient>();
                cfg.CreateMap<Patient, PatientResponseModel>();

                cfg.CreateMap<InsuranceResponseModel, Insurance>();
                cfg.CreateMap<Insurance, InsuranceResponseModel>();

                cfg.CreateMap<InsuranceCardResponseModel, InsuranceCard>();
                cfg.CreateMap<InsuranceCard, InsuranceCardResponseModel>();

                cfg.CreateMap<BaseResponseModel, BaseEntity>();
                cfg.CreateMap<BaseEntity, BaseResponseModel>();
                
                cfg.CreateMap<PatientRequestModel, Patient>();
                cfg.CreateMap<Patient, PatientRequestModel>();

                cfg.CreateMap<InsuranceRequestModel, Insurance>();
                cfg.CreateMap<Insurance, InsuranceRequestModel>();

                cfg.CreateMap<InsuranceCardRequestModel, InsuranceCard>();
                cfg.CreateMap<InsuranceCard, InsuranceCardRequestModel>();

                cfg.CreateMap<BaseRequestModel, BaseEntity>();
                cfg.CreateMap<BaseEntity, BaseRequestModel>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<Be3TestContext>(options => options.UseInMemoryDatabase("Be3Test"));

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "be3 Test - Leandro Romanelli");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
