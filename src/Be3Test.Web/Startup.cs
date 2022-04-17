using AutoMapper;
using Be3Test.Api.Models;
using Be3Test.Api.Models.Base;
using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Be3Test.Domain.Interfaces.UnitOfWork;
using Be3Test.Domain.Repositories;
using Be3Test.Domain.Services;
using Be3Test.Infra.Context;
using Be3Test.Infra.Repositories;
using Be3Test.Infra.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

namespace Be3Test.Web
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
            services.AddScoped<IUnitOfWork, UnitOfWork>();

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

            services.AddControllersWithViews().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
