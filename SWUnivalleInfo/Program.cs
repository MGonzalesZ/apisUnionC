using SWADUnivalleInfo.DbContext;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices
/// <summary>
/// Configuraci�n de servicios.
/// </summary>
builder.Services.AddControllers(); // Agrega soporte para controladores
builder.Services.AddEndpointsApiExplorer(); // Agrega el generador de la API de exploraci�n de puntos finales
builder.Services.AddSwaggerGen(); // Agrega el generador de Swagger para documentaci�n

// Configuraci�n de la pol��ica CORS
builder.Services.AddCors(options =>
{
	options.AddPolicy("ReactCorsPolicy", app =>
	{
		app
			// .WithOrigins("enlace de la aplicaci�n React")
			.AllowAnyOrigin() // Permite cualquier origen
			.AllowAnyHeader() // Permite cualquier encabezado
			.AllowAnyMethod(); // Permite cualquier m�todo HTTP
	});
});
#endregion

var app = builder.Build();

#region Configure
/// <summary>
/// Configuraci�n del pipeline de solicitud HTTP.
/// </summary>

//if (app.Environment.IsDevelopment()) {
	app.UseSwagger(); // Habilita Swagger
	app.UseSwaggerUI(); // Habilita la interfaz de usuario de Swagger
//}

app.UseCors("ReactCorsPolicy"); // Habilita la pol��ica CORS configurada

app.UseHttpsRedirection(); // Redirecci�n HTTPS
app.UseAuthorization(); // Habilita la autorizaci�n
app.MapControllers(); // Mapea los controladores
app.Run(); // Inicia la aplicaci�n
#endregion
