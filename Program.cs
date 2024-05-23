
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Versioning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ---------------  Configuring versioning-------
            //builder.Services.AddApiVersioning(option =>
            //{
            //    option.DefaultApiVersion = new ApiVersion(1, 0);
            //    option.AssumeDefaultVersionWhenUnspecified = true;
            //    option.ReportApiVersions = true;
            //    option.ApiVersionReader = new UrlSegmentApiVersionReader();
            //});
            builder.Services.AddApiVersioning(
  options =>
  {
      options.DefaultApiVersion = new ApiVersion(1, 0);
      options.AssumeDefaultVersionWhenUnspecified = true;
      options.ReportApiVersions = true;
      options.ApiVersionReader = new UrlSegmentApiVersionReader();
  })
.AddApiExplorer(
  options =>
  {
      options.GroupNameFormat = "'v'VVV";
      options.SubstituteApiVersionInUrl = true;
  });


            // -------------- Registering dependency for ConfigureSwaggerOptions class created------
            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var descriptions = app.Services.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions;
                    foreach (var description in descriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
