using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyContacts.Core;
using MyContacts.Core.Services;
using MyContacts.Data;
using MyContacts.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.API
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

            services.AddControllers().AddNewtonsoftJson(options =>
           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Configuration for SQL server
            services.AddDbContext<MyContactsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("MyContacts.Data")));

            //Dependancy Injection
            services.AddScoped<IUnitOfWork, UnitOfWork>(); ;

            //Services 
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IExpertiseService, ExpertiseService>();
            services.AddTransient<IContactSkillExpertiseService, ContactSkillExpertiseService>();
           

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyContacts.API", Version = "v1" });
            });

            // Automapper
            services.AddAutoMapper(typeof(Startup));

            /*
            //Jwt 
            services.AddTransient<IUserService, UserService>();
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("AppSettings:Secret"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            //Return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            */
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Swagger 
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyContacts.API v1");
                });
                
        }
    }
}
