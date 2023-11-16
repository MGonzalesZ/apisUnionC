using SWLNUnivalleInfo;
using Microsoft.AspNetCore.Mvc;
using ENTIDADES.EPostgrado;

namespace SWUnivalleInfo.Controllers.CPostgrado
{
	[ApiController]
	[Route("c")]
	public class CPostgrado : ControllerBase
	{
		#region Atributos

		/// <summary>
		/// Instancia de la clase LNUnivalleInfo para realizar operaciones relacionadas con el postgrado.
		/// </summary>
		private readonly LNUnivalleInfo LNUnivalleInfo;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor de la clase CPostgrado que inicializa la instancia de LNUnivalleInfo.
		/// </summary>
		public CPostgrado()
		{
			LNUnivalleInfo = new LNUnivalleInfo();
		}

		#endregion

		#region Metodos Publicos

		/// <summary>
		/// Endpoint HTTP GET para obtener la lista de postgrados.
		/// </summary>
		/// <returns>Un IActionResult que contiene la lista de postgrados.</returns>
		[HttpGet("ObtenerPostgrado")]
		public async Task<IActionResult> Obtener_Postgrados()
		{
			var response = await LNUnivalleInfo.Obtener_Postgrados();
			return Ok(response);
		}

		/// <summary>
		/// Endpoint HTTP POST para insertar un postgrado.
		/// </summary>
		/// <param name="eIPostgrado">Los datos del postgrado que se va a insertar.</param>
		/// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.</returns>
		[HttpPost("AdicionarPostgrado")]
		public async Task<IActionResult> Adicionar_Postgrado([FromBody] EIPostgrado eIPostgrado)
		{
			if (string.IsNullOrEmpty(eIPostgrado.TipoPostgrado) ||
				string.IsNullOrEmpty(eIPostgrado.Descripcion) ||
				string.IsNullOrEmpty(eIPostgrado.RequisitosPostgrado))
			{
				return BadRequest("Faltan datos obligatorios en el postgrado.");
			}

			var response = await LNUnivalleInfo.Adicionar_Postgrado_EIPostgrado(eIPostgrado);
			return Ok(response);
		}

		/// <summary>
		/// Endpoint HTTP PUT para actualizar un postgrado.
		/// </summary>
		/// <param name="eIPostgrado">Los datos del postgrado que se va a actualizar.</param>
		/// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.</returns>
		[HttpPut("ActualizarPostgrado/{postgradoKey}")]
		//[HttpPut("{id}")]
		public async Task<IActionResult> Actualizar_Postgrado(string postgradoKey, [FromBody] EIPostgrado eIPostgrado)
		{
			if (string.IsNullOrEmpty(eIPostgrado.TipoPostgrado) ||
				string.IsNullOrEmpty(eIPostgrado.Descripcion) ||
				string.IsNullOrEmpty(eIPostgrado.RequisitosPostgrado))
			{
				return BadRequest("Faltan datos obligatorios en el postgrado.");
			}
			var response = await LNUnivalleInfo.Actualizar_Postgrado_EIPostgrado(postgradoKey, eIPostgrado);
			return Ok(response);
		}

		/// <summary>
		/// Endpoint HTTP DELETE para eliminar un postgrado por su identificador.
		/// </summary>
		/// <param name="postgradoId">El identificador del postgrado que se va a eliminar.</param>
		/// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.</returns>
		[HttpDelete("EliminarPostgrado/{postgradoKey}")]
		public async Task<IActionResult> Eliminar_Postgrado(string postgradoKey)
		{
			if (string.IsNullOrEmpty(postgradoKey))
			{
				return BadRequest("El identificador del postgrado no puede estar vacío.");
			}

			var response = await LNUnivalleInfo.Eliminar_Postgrado_PostgradoId(postgradoKey);

			if (!response.Exitoso)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}

		#endregion
	}
}
