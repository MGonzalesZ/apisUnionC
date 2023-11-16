using HERRAMIENTAS;
using ENTIDADES.EPostgrado;
using SWADUnivalleInfo.DbContext;
using Firebase.Database;
using Firebase.Database.Query;

namespace SWADUnivalleInfo.SWADPostgrado
{
	/// <summary>
	/// Clase que proporciona funcionalidad para operaciones relacionadas con los postgrados.
	/// </summary>
	public class SWADPostgrado
	{
		#region Atributos
		private readonly FirebaseClient _firebaseDbContext;
		private const string NODO_POSTGRADOS = SDatosGlobales.NODO_POSTGRADOS;
		#endregion

		/// <summary>
		/// Inicializa una nueva instancia de la clase SWADPostgrado.
		/// </summary>
		public SWADPostgrado()
		{
			_firebaseDbContext = new FirebaseDbContext().FirebaseClient;
		}

		/// <summary>
		/// Obtiene una lista de postgrados desde Firebase Realtime Database.
		/// </summary>
		/// <returns>Un EResponse que indica si la operación fue exitosa y contiene una lista de postgrados.</returns>
		public async Task<EResponse<List<EIPostgrado>>> Obtener_Postgrados()
		{
			var response = new EResponse<List<EIPostgrado>>();
			try
			{
				var ColeccionPostgrados = await _firebaseDbContext.Child(NODO_POSTGRADOS).OnceAsync<EIPostgrado>();

				var listEIPostgrado = new List<EIPostgrado>();

				foreach (var postgrado in ColeccionPostgrados)
				{
					var userData = postgrado.Object;
					userData.Id = postgrado.Key;
					listEIPostgrado.Add(userData);
				}

				response.Exitoso = true;
				response.Mensaje = "Lista de postgrados obtenida exitosamente.";
				response.Datos = listEIPostgrado;

			}
			catch (Exception ex)
			{
				response.Exitoso = false;
				response.Mensaje = "Error al obtener la lista de postgrados desde Firebase.";
				response.Excepcion = ex.Message;
			}
			return response;
		}

		/// <summary>
		/// Agrega un postgrado en Firebase Realtime Database.
		/// </summary>
		/// <param name="eIPostgrado">Los datos del postgrado que se va a insertar.</param>
		/// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
		public async Task<EResponse<string>> Adicionar_Postgrado_EIPostgrado(EIPostgrado eIPostgrado)
		{
			var response = new EResponse<string>();
			try
			{
				var result = await _firebaseDbContext.Child(NODO_POSTGRADOS).PostAsync(eIPostgrado);
				response.Exitoso = true;
				response.Mensaje = "Postgrado agregado exitosamente.";
				response.Datos = result.Key;
			}
			catch (Exception ex)
			{
				response.Exitoso = false;
				response.Mensaje = "Error al agregar el Postgrado en Firebase.";
				response.Excepcion = ex.Message;
			}
			return response;
		}

		/// <summary>
		/// Actualiza un postgrado en Firebase Realtime Database.
		/// </summary>
		/// <param name="id">El identificador único del postgrado que se va a actualizar.</param>
		/// <param name="eIPostgrado">Los datos del postgrado que se van a actualizar.</param>
		/// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
		public async Task<EResponse<bool>> Actualizar_Postgrado_EIPostgrado(string id, EIPostgrado eIPostgrado)
		{
			var response = new EResponse<bool>();
			try
			{
				await _firebaseDbContext.Child(NODO_POSTGRADOS).Child(id).PutAsync(eIPostgrado);
				response.Exitoso = true;
				response.Mensaje = "Postgrado actualizado exitosamente.";
				response.Datos = true;
			}
			catch (Exception ex)
			{
				response.Exitoso = false;
				response.Mensaje = "Error al actualizar el Postgrado en Firebase.";
				response.Excepcion = ex.Message;
			}
			return response;
		}

		/// <summary>
		/// Elimina un postgrado desde Firebase Realtime Database por su identificador único.
		/// </summary>
		/// <param name="id">El identificador único del postgrado que se va a eliminar.</param>
		/// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
		public async Task<EResponse<bool>> Eliminar_Postgrado_PostgradoId(string id)
		{
			var response = new EResponse<bool>();
			try
			{
				await _firebaseDbContext.Child(NODO_POSTGRADOS).Child(id).DeleteAsync();
				response.Exitoso = true;
				response.Mensaje = "Postgrado eliminado exitosamente.";
				response.Datos = true;
			}
			catch (Exception ex)
			{
				response.Exitoso = false;
				response.Mensaje = "Error al eliminar el Postgrado en Firebase.";
				response.Excepcion = ex.Message;
			}
			return response;
		}
	}
}
