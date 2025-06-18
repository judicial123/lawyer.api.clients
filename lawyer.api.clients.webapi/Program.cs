using lawyer.api.clients.application;
using lawyer.api.clients.datastore.mssql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddCors(options => {
    options.AddPolicy("all", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Lawyer API",
        Version = "v1",
        Description = "API for managing Lawyer operations."
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("all");

app.UseHttpsRedirection();

// ❌ No necesitas esto ahora: app.UseAuthorization();

app.MapControllers();

app.Run();