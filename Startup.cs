using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SampleApi.DBContext;
using SampleApi.Interface;
using Serilog;

namespace SampleApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        //public readonly ILogger<Startup> _logger;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //_logger = logger;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("connectionString"));
            });
            services.AddControllers();
            //services.AddSingleton(typeof(IUser), typeof(PostInfoRepository));
            services.AddScoped<IUser, PostInfoRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Post Request Open Api",
                    Version = "v1"
                });
                c.ResolveConflictingActions(api => api.First());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //var appLifetime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();
            //appLifetime.ApplicationStopping.Register(OnShutdown);
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            //app.UseDefaultFiles();
            //app.UseStaticFiles();
        }

        private void OnShutdown()
        {
            Log.Information("Controller is Shutting Down.");
        }
    }
}
