var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Habilita los endpoints para Swagger
builder.Services.AddSwaggerGen();          // Agrega Swagger

var app = builder.Build();

// Configura el pipeline HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                     // Middleware Swagger
    app.UseSwaggerUI();                  // Interfaz de usuario de Swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
