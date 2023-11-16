using ENTIDADES.EPlataforma;
using Firebase.Database;
using Firebase.Database.Query;
using HERRAMIENTAS;
using SWADUnivalleInfo.DbContext;

namespace SWADUnivalleInfo.SWADPlataforma
{
    public class SWADPlataforma
    {
        #region Atributos
        private readonly FirebaseClient _firebaseDbContext;
        private const string NODO_PLATAFORMA = SDatosGlobales.NODO_PLATAFORMA;
        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase SWADPlataforma.
        /// </summary>
        public SWADPlataforma()
        {
            _firebaseDbContext = new FirebaseDbContext().FirebaseClient;
        }

        /// <summary>
        /// Obtiene una lista de plataformas desde Firebase Realtime Database.
        /// </summary>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene una lista de plataformas.</returns>
        public async Task<EResponse<List<EIPlataforma>>> Obtener_Plataformas()
        {
            var response = new EResponse<List<EIPlataforma>>();
            try
            {
                var ColeccionPlataformas = await _firebaseDbContext.Child(NODO_PLATAFORMA).OnceAsync<EIPlataforma>();

                var listEIPlataforma = new List<EIPlataforma>();

                foreach (var plataforma in ColeccionPlataformas)
                {
                    var userData = plataforma.Object;
                    userData.Id = plataforma.Key;
                    listEIPlataforma.Add(userData);
                }

                response.Exitoso = true;
                response.Mensaje = "Lista de plataformas obtenida exitosamente.";
                response.Datos = listEIPlataforma;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al obtener la lista de plataformas desde Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Agrega una plataforma en Firebase Realtime Database.
        /// </summary>
        /// <param name="eIPlataforma">Los datos de la plataforma que se va a insertar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<string>> Adicionar_Plataforma_EIPlataforma(EIPlataforma eIPlataforma)
        {
            var response = new EResponse<string>();
            try
            {
                var result = await _firebaseDbContext.Child(NODO_PLATAFORMA).PostAsync(eIPlataforma);
                response.Exitoso = true;
                response.Mensaje = "Plataforma agregada exitosamente.";
                response.Datos = result.Key;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al agregar la Plataforma en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Actualiza una plataforma en Firebase Realtime Database.
        /// </summary>
        /// <param name="id">El identificador único de la plataforma que se va a actualizar.</param>
        /// <param name="eIPlataforma">Los datos de la plataforma que se van a actualizar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Actualizar_Plataforma_EIPlataforma(string id, EIPlataforma eIPlataforma)
        {
            var response = new EResponse<bool>();
            try
            {
                await _firebaseDbContext.Child(NODO_PLATAFORMA).Child(id).PatchAsync(eIPlataforma);
                response.Exitoso = true;
                response.Mensaje = "Plataforma actualizada exitosamente.";
                response.Datos = true;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al actualizar la Plataforma en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Elimina una plataforma desde Firebase Realtime Database por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la plataforma que se va a eliminar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Eliminar_Plataforma_PlataformaId(string id)
        {
            var response = new EResponse<bool>();
            try
            {
                await _firebaseDbContext.Child(NODO_PLATAFORMA).Child(id).DeleteAsync();
                response.Exitoso = true;
                response.Mensaje = "Plataforma eliminada exitosamente.";
                response.Datos = true;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al eliminar la Plataforma en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }
    }
}
