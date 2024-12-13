using System.Text.Json;
using Microsoft.AspNetCore.Antiforgery;
using Stormlight.Models.Api;
using Stormlight.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAntiforgery();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAntiforgery();

// TODO:
// app.UseHttpsRedirection();

// app.MapGet("/token", (HttpContext context, IAntiforgery antiforgery) => {
//     var token = antiforgery.GetAndStoreTokens(context);

//     string json = JsonSerializer.Serialize(new {
//         value      = token.RequestToken,
//         name       = token.FormFieldName,
//         cookie     = token.CookieToken,
//     });

//     Console.WriteLine($">>>>>>>>>>>> json {json}");

//     return Results.Content(json);
// })
// .WithName("GetUpload")
// .WithOpenApi();

app.MapPost("/files/upload", FilesApi.FileUpload)
    .WithName("UploadFile")
    .WithOpenApi()
    .DisableAntiforgery()    //TODO:
;

app.Run();
