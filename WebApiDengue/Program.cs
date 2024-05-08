using WebApiDengue.Resources.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Configuración personalizada
ConfigurationManager config = builder.Configuration;
WebApiDengue.Resources.Data.DataAccess.cadenaConexion = config.GetConnectionString("conexionBD") ?? string.Empty;
// Fin de configuración personalizada


//servicios de Interface
builder.Services.AddScoped<IRepFuncionGenerico, RepFuncionGenerico>();


//habilitar cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("ConexionTodos", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

 app.UseCors("ConexionTodos");//habilitar Cors


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//habilitar para publicar
//app.UseSwagger();
//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API V1");
//    options.RoutePrefix = String.Empty;
//});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
