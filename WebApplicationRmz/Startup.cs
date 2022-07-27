using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplicationRmz.Data;
using WebApplicationRmz.Service.ElectricityMeterService;

namespace WebApplicationRmz
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

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "GitHub";
            })
              .AddCookie()
              .AddOAuth("GitHub", options =>
              {
                  options.ClientId = Configuration["GitHub:ClientId"];
                  options.ClientSecret = Configuration["GitHub:ClientSecret"];
                  options.CallbackPath = new PathString("/github-oauth");
                  options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
                  options.TokenEndpoint = "https://github.com/login/oauth/access_token";
                  options.UserInformationEndpoint = "https://api.github.com/user";
                  options.SaveTokens = true;
                  options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                  options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
                  options.ClaimActions.MapJsonKey("urn:github:login", "login");
                  options.ClaimActions.MapJsonKey("urn:github:url", "html_url");
                  options.ClaimActions.MapJsonKey("urn:github:avatar", "avatar_url");
                  options.Events = new OAuthEvents
                  {
                      OnCreatingTicket = async context =>
                      {
                          var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                          request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                          request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
                          var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                          response.EnsureSuccessStatusCode();
                          var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                          context.RunClaimActions(json.RootElement);
                      }
                  };
              });



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplicationRmz", Version = "v1" });
            });
            services.AddScoped<IElectricityMeterService, ElectricityMeterService>();
            services.AddScoped<ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NewRmzConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplicationRmz v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });


            app.UseAuthentication();
            app.UseAuthorization();

        }
    }
}
