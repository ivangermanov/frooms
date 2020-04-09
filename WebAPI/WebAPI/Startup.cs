using Froom.Data.Database;
using Froom.Data.Repositories;
using Froom.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;
using WebAPI.Helpers;
using WebAPI.Services;
using WebAPI.Services.Interfaces;

namespace WebAPI
{
    public class Startup
    {
        private readonly string AllowLocalHost = "_allowLocalHost";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FroomContext>(options =>
            {
                options.UseSqlServer(
                    Configuration["ConnectionString:FontysDB"],
                    x => x.MigrationsAssembly("Froom.Data"));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
            }).AddOpenIdConnect(options =>
            {
                options.ClientId = AppSettings.ClientId;
                options.ClientSecret = AppSettings.ClientSecret;
                options.Authority = Constants.AuthorizeEndpoint;

                // Configure the scope
                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("fhict");
                options.Scope.Add("fhict_personal");
                options.Scope.Add("profile");
                options.Scope.Add("email");
                options.Scope.Add("roles");

                options.CallbackPath = "/signin-oidc";

                options.SaveTokens = true;

                options.ResponseType = "code";
                options.ResponseMode = "query";

                options.GetClaimsFromUserInfoEndpoint = true;
                options.UsePkce = false;
            });

            services.AddCors(options =>
            {
                options.AddPolicy(AllowLocalHost,
                    builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            });

            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddTransient<IRoomService, RoomService>();

            services.AddControllers();
            services.AddSpaStaticFiles(opt => opt.RootPath = "vue/dist");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCookiePolicy();

            if (env.IsDevelopment()) app.UseCors(AllowLocalHost);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // NOTE: VueCliProxy is meant for developement and hot module reload
                // NOTE: SSR has not been tested
                // Production systems should only need the UseSpaStaticFiles() (above)
                // You could wrap this proxy in either
                // if (System.Diagnostics.Debugger.IsAttached)
                // or a preprocessor such as #if DEBUG

                endpoints.MapToVueCliProxy(
                    "{*path}",
                    new SpaOptions {SourcePath = "vue/"},
                    env.IsDevelopment() ? "dev" : null,
                    regex: "Compiled successfully",
                    forceKill: true
                );
            });
        }
    }
}