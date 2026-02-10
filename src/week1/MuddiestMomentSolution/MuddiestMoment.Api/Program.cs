using MuddiestMoment.Api.Student;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
// Add the services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddValidation();
var app = builder.Build();

app.MapStudentEndpoints();

app.MapDefaultEndpoints();
app.Run();