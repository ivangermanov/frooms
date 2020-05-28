using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Froom.Data.Database;
using Froom.Data.Entities;
using Froom.Data.Repositories;
using Froom.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
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

            services.AddCors(options =>
            {
                options.AddPolicy(AllowLocalHost,
                    builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/api/login";
                options.LogoutPath = "/api/logout";
            }).AddOpenIdConnect(options =>
            {
                options.ClientId = AppSettings.ClientId;
                options.ClientSecret = AppSettings.ClientSecret;
                options.Authority = OpenIDConstants.AuthorizeEndpoint;

                // Configure the scope
                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("fhict");
                options.Scope.Add("fhict_personal");
                options.Scope.Add("fhict_location");
                options.Scope.Add("profile");
                options.Scope.Add("email");
                options.Scope.Add("roles");

                options.CallbackPath = "/signin-oidc";

                options.SaveTokens = true;

                options.ResponseType = "code";
                options.ResponseMode = "query";

                options.GetClaimsFromUserInfoEndpoint = true;
                options.UsePkce = false;
                //Adding admin claim
                options.Events = new OpenIdConnectEvents
                {
                    OnTokenValidated = async ctx =>
                    {
                        //Get user's id from claims that came from Fontys
                        var id = new Guid(ctx.Principal.FindFirstValue(ClaimTypes.NameIdentifier));

                        //Get EF context
                        var db = ctx.HttpContext.RequestServices.GetRequiredService<FroomContext>();
                        //Check is user is an admin
                        var isAdmin = await db.User.AnyAsync(e => e.Id == id && e.Role == UserRole.ADMIN);
                        if (isAdmin)
                        {
                            //Add claim if they are
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Role, "admin")
                            };
                            var appIdentity = new ClaimsIdentity(claims);

                            ctx.Principal.AddIdentity(appIdentity);
                        }
                    }
                };
            });

            services.AddHttpContextAccessor();

            services.AddTransient<FontysAPI>();

            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddTransient<IRoomService, RoomService>();

            services.AddScoped<ICampusRepository, CampusRepository>();
            services.AddTransient<ICampusService, CampusService>();

            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IBuildingService, BuildingService>();

            services.AddScoped<IFloorRepository, FloorRepository>();
            services.AddTransient<IFloorService, FloorService>();

            services.AddScoped<IBuildingContentsRepository, BuildingContentsRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddTransient<IReservationService, ReservationService>();

            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddTransient<IChartService, ChartService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "FROOM API", Version = "v1" }); });

            services.AddSpaStaticFiles(opt => opt.RootPath = "vue/dist");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "FROOM API"); });

            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            if (env.IsDevelopment()) app.UseCors(AllowLocalHost);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCookiePolicy();

            app.UseSpaStaticFiles();

            // TODO: Find better way to route to login page before going in SPA
            app.Use(async (context, next) =>
            {
                if (!context.User.Identity.IsAuthenticated)
                    await context.ChallengeAsync();
                else
                    await next();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "vue";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization();
                // NOTE: VueCliProxy is meant for development and hot module reload
                // NOTE: SSR has not been tested
                // Production systems should only need the UseSpaStaticFiles() (above)
                // You could wrap this proxy in either
                // if (System.Diagnostics.Debugger.IsAttached)
                // or a preprocessor such as #if DEBUG

                if (env.IsDevelopment())
                    endpoints.MapToVueCliProxy(
                        "{*path}",
                        new SpaOptions { SourcePath = "vue/" },
                        "dev",
                        regex: "Compiled successfully",
                        forceKill: true
                    );
            });
        }
    }
}