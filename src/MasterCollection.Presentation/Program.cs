using MasterCollection.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseHttpsRedirection();

await app.RunAsync();
