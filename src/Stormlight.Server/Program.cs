using Stormlight.Models.Api;
using Stormlight.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

// TODO:
// app.UseHttpsRedirection();

app.MapGet("/files", FilesApi.GetFiles)
.WithName("GetFiles")
.WithOpenApi();

app.Run();
