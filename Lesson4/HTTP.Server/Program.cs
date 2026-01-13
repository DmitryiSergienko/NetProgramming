using HTTP.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => Results.BadRequest());
app.MapGet("/persons", () => new List<Person>() 
{
    new()
    {
        LastName = "Doe",
        FirstName = "John"
    },
    new()
    {
        LastName = "Doe",
        FirstName = "Jane"
    }
});

await app.RunAsync();