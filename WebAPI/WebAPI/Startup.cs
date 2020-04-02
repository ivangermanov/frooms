using Froom.Data.Database;
using Froom.Data.Repositories;
using Froom.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;
using WebAPI.Services;
using WebAPI.Services.Interfaces;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly string AllowLocalHost = "_allowLocalHost";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FroomContext>(options =>  
            {
                options.UseSqlServer(
                    Configuration["ConnectionString:FontysDB"],
                    x => x.MigrationsAssembly("Froom.Data"));
            });

#if DEBUG
            services.AddCors(options =>
            {
                options.AddPolicy(AllowLocalHost,
                    builder => { builder.AllowAnyOrigin(); });
            });
#endif

            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddTransient<IRoomService, RoomService>();

            services.AddControllers();
            services.AddSpaStaticFiles(opt => opt.RootPath = "vue/dist");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseSpaStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

#if DEBUG
            app.UseCors(AllowLocalHost);
#endif

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // NOTE: VueCliProxy is meant for developement and hot module reload
                // NOTE: SSR has not been tested
                // Production systems should only need the UseSpaStaticFiles() (above)
                // You could wrap this proxy in either
                // if (System.Diagnostics.Debugger.IsAttached)
                // or a preprocessor such as #if DEBUG

#if DEBUG
                endpoints.MapToVueCliProxy(
                    "{*path}",
                    new SpaOptions { SourcePath = "vue/" },
                    "dev",
                    regex: "Compiled successfully",
                    forceKill: true
                );
#endif
            });
        }
    }
}