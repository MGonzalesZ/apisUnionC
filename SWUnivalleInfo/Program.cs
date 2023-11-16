using SWADUnivalleInfo.DbContext;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices
/// <summary>
/// Configuración de servicios.
/// </summary>
builder.Services.AddControllers(); // Agrega soporte para controladores
builder.Services.AddEndpointsApiExplorer(); // Agrega el generador de la API de exploración de puntos finales
builder.Services.AddSwaggerGen(); // Agrega el generador de Swagger para documentación

// Configuración de la polú‘ica CORS
builder.Services.AddCors(options =>
{
	options.AddPolicy("ReactCorsPolicy", app =>
	{
		app
			// .WithOrigins("enlace de la aplicación React")
			.AllowAnyOrigin() // Permite cualquier origen
			.AllowAnyHeader() // Permite cualquier encabezado
			.AllowAnyMethod(); // Permite cualquier método HTTP
	});
});
#endregion

var app = builder.Build();

#region Configure
/// <summary>
/// Configuración del pipeline de solicitud HTTP.
/// </summary>

//if (app.Environment.IsDevelopment()) {
	app.UseSwagger(); // Habilita Swagger
	app.UseSwaggerUI(); // Habilita la interfaz de usuario de Swagger
//}

app.UseCors("ReactCorsPolicy"); // Habilita la polú‘ica CORS configurada

app.UseHttpsRedirection(); // Redirección HTTPS
app.UseAuthorization(); // Habilita la autorización
app.MapControllers(); // Mapea los controladores
app.Run(); // Inicia la aplicación
#endregion
