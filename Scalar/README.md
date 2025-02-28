## Scalar


1) Run `dotnet add package Scalar.AspNetCore --version 1.2`

2) Add the following code to `Program.cs`:
```csharp
// Program.cs

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

```
