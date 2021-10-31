using System;
using Commander.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Commander.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Commander.Helpers;
using Commander.Services;
using Commander.Middlewares;

namespace Commander
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
            services.AddCors();
            services.AddControllers();
            // connect the database here
            services.AddDbContext<CommanderContext>(opt => opt.UseMySQL(Configuration.GetConnectionString("CommanderConnection")));
            // add custom filter to all controller
            // services.AddControllers(options =>
            // {
            //     options.Filters.Add(new RequireHttpsOrCloseAttribute());
            // });

            // add JWT Bearer authentication
            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            // .AddJwtBearer(opt =>
            // {
            //     opt.Audience = Configuration["ADD:ResourceId"];
            //     opt.Authority = $"{Configuration["ADD:InstanceId"]}{Configuration["ADD:TenantId"]}";
            // });

            // for JSON and JSON PATCH
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepo, MockUserRepo>();
            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddScoped<ICommanderRepo, MySQlCommanderRepo>();
            // replace the MockCommanderRepo with actual repo class
            // services.AddScoped<ICommanderRepo, MockCommanderRepo>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // * DO NOT USE USE HTTPS REDIRECTION
            // ! reason: https://stackoverflow.com/questions/28564961/authorization-header-is-lost-on-redirect
            // app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors();

            // * UseAuthorization should appear between app.UseRouting() and app.UseEndpoints(..) for authorization to be correctly evaluated
            // app.UseAuthorization();

            // custom jwt auth middleware
            app.UseMiddleware<AuthMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
