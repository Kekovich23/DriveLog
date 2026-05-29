using DriveLog.WebAPI.Extensions;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    var modelsXmlPath = Path.Combine(AppContext.BaseDirectory, "DriveLog.WebAPI.Models.xml");
    if (File.Exists(modelsXmlPath)) {
        options.IncludeXmlComments(modelsXmlPath);
    }
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.json");
    app.UseSwaggerUI(options => {
        options.RoutePrefix = string.Empty;
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "DriveLog API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
