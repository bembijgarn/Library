using Lemondo.Helper;
using Lemondo.Interface;
using Lemondo.Services;
using LemondoDATA;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Lemondo
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
            services.AddDbContext<Lcontext>(opt =>
              opt.UseSqlServer(Configuration.GetConnectionString("Databaseconnection"))
                 .EnableSensitiveDataLogging()
                 .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lemondo", Version = "v1" });
            });

            var SettingsSection = Configuration.GetSection("Settings");
            services.Configure<AppSettings>(SettingsSection);
            var appSettings = SettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretWord);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                   .AddJwtBearer(x =>
                   {
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
            services.AddScoped<IAuthBookService, AuthBookService>();
            services.AddScoped<IBookActions, BookActionService>();
            services.AddScoped<IAuthorActions, AuthorActionsService>();
            services.AddScoped<ILoginRegistration, LoginRegistrationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lemondo v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
