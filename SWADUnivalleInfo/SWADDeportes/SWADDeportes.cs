
using ENTIDADES.EDeportes;
using Firebase.Database;
using Firebase.Database.Query;
using HERRAMIENTAS;
using SWADUnivalleInfo.DbContext;

namespace SWADUnivalleInfo.SWADDeportes
{
    public class SWADDeportes
    {
        #region Atributos
        private readonly FirebaseClient _firebaseDbContext;
        private const string NODO_DEPORTES = SDatosGlobales.NODO_DEPORTES;
        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase SWADDeportes.
        /// </summary>
        public SWADDeportes()
        {
            _firebaseDbContext = new FirebaseDbContext().FirebaseClient;
        }

        /// <summary>
        /// Obtiene una lista de deportes desde Firebase Realtime Database.
        /// </summary>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene una lista de deportes.</returns>
        public async Task<EResponse<List<EIDeportes>>> Obtener_Deportes()
        {
            var response = new EResponse<List<EIDeportes>>();
            try
            {
                var ColeccionDeportes = await _firebaseDbContext.Child(NODO_DEPORTES).OnceAsync<EIDeportes>();

                var listEIDeportes = new List<EIDeportes>();

                foreach (var deporte in ColeccionDeportes)
                {
                    var userData = deporte.Object;
                    userData.Id = deporte.Key;
                    listEIDeportes.Add(userData);
                }

                response.Exitoso = true;
                response.Mensaje = "Lista de deportes obtenida exitosamente.";
                response.Datos = listEIDeportes;

            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al obtener la lista de deportes desde Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Agrega un deporte en Firebase Realtime Database.
        /// </summary>
        /// <param name="eIDeportes">Los datos del deporte que se va a insertar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<string>> Adicionar_Deporte_EIDeportes(EIDeportes eIDeportes)
        {
            var response = new EResponse<string>();
            try
            {
                var result = await _firebaseDbContext.Child(NODO_DEPORTES).PostAsync(eIDeportes);
                response.Exitoso = true;
                response.Mensaje = "Deporte agregado exitosamente.";
                response.Datos = result.Key;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al agregar el Deporte en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Actualiza un deporte en Firebase Realtime Database.
        /// </summary>
        /// <param name="id">El identificador único del deporte que se va a actualizar.</param>
        /// <param name="eIDeportes">Los datos del deporte que se van a actualizar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Actualizar_Deporte_EIDeportes(string id, EIDeportes eIDeportes)
        {
            var response = new EResponse<bool>();
            try
            {
                await _firebaseDbContext.Child(NODO_DEPORTES).Child(id).PatchAsync(eIDeportes);
                response.Exitoso = true;
                response.Mensaje = "Deporte actualizado exitosamente.";
                response.Datos = true;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al actualizar el Deporte en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Elimina un deporte desde Firebase Realtime Database por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del deporte que se va a eliminar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Eliminar_Deporte_DeporteId(string id)
        {
            var response = new EResponse<bool>();
            try
            {
                await _firebaseDbContext.Child(NODO_DEPORTES).Child(id).DeleteAsync();
                response.Exitoso = true;
                response.Mensaje = "Deporte eliminado exitosamente.";
                response.Datos = true;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al eliminar el Deporte en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }
    }
}
