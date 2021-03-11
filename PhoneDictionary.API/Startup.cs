using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PhoneDictionary.Data.Infrastructure;
using PhoneDictionary.Data.Services;
using PhoneDictionary.Interfaces;
using PhoneDictionary.Services;
using PhoneDictionary.Services.Seed;

namespace PhoneDictionary.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string FullAccessOrigins = "FullAccessOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISeedFaker, SeedFaker>();
            services.Configure<AuthenticationConfig>(Configuration.GetSection(nameof(AuthenticationConfig)));
            services.AddScoped<IAuth, JwtAuth>();
            services.AddSingleton<IErrorMapper, ErrorMapper>();
            
            services.AddDbContext<IDbContext, AppDbContext>(options =>
            {
                var connection = new SqliteConnection(Configuration.GetConnectionString("DefaultConnection"));
                connection.CreateCollation("default", string.Compare);
                options.UseSqlite(connection);
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: FullAccessOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
            
            services.AddMediatR(CQRS.AssemblyInfo.GetAssembly());

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllers().AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "PhoneDictionary.API", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneDictionary.API v1"));
            }
            
            app.UseCors(FullAccessOrigins);

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseExceptionHandler("/error");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}