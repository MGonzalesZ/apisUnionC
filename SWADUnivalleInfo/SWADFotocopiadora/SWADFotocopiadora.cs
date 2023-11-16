using ENTIDADES.EFotocopiadora;
using Firebase.Database;
using Firebase.Database.Query;
using HERRAMIENTAS;
using SWADUnivalleInfo.DbContext;

namespace SWADUnivalleInfo.SWADFotocopiadora
{
	public class SWADFotocopiadora
	{
        #region Atributos
        private readonly FirebaseClient _firebaseDbContext;
        private const string NODO_FOTOCOPIADORA = SDatosGlobales.NODO_FOTOCOPIADORA;
        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase SWADFotocopiadora.
        /// </summary>
        public SWADFotocopiadora()
        {
            _firebaseDbContext = new FirebaseDbContext().FirebaseClient;
        }

        /// <summary>
        /// Obtiene una lista de fotocopiadoras desde Firebase Realtime Database.
        /// </summary>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene una lista de fotocopiadoras.</returns>
        public async Task<EResponse<List<EIFotocopiadora>>> Obtener_Fotocopiadoras()
        {
            var response = new EResponse<List<EIFotocopiadora>>();
            try
            {
                var ColeccionFotocopiadoras = await _firebaseDbContext.Child(NODO_FOTOCOPIADORA).OnceAsync<EIFotocopiadora>();

                var listEIFotocopiadora = new List<EIFotocopiadora>();

                foreach (var fotocopiadora in ColeccionFotocopiadoras)
                {
                    var userData = fotocopiadora.Object;
                    userData.Id = fotocopiadora.Key;
                    listEIFotocopiadora.Add(userData);
                }

                response.Exitoso = true;
                response.Mensaje = "Lista de fotocopiadoras obtenida exitosamente.";
                response.Datos = listEIFotocopiadora;

            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al obtener la lista de fotocopiadoras desde Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Agrega una fotocopiadora en Firebase Realtime Database.
        /// </summary>
        /// <param name="eIFotocopiadora">Los datos de la fotocopiadora que se va a insertar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<string>> Adicionar_Fotocopiadora_EIFotocopiadora(EIFotocopiadora eIFotocopiadora)
        {
            var response = new EResponse<string>();
            try
            {
                var result = await _firebaseDbContext.Child(NODO_FOTOCOPIADORA).PostAsync(eIFotocopiadora);
                response.Exitoso = true;
                response.Mensaje = "Fotocopiadora agregada exitosamente.";
                response.Datos = result.Key;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al agregar la Fotocopiadora en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Actualiza una fotocopiadora en Firebase Realtime Database.
        /// </summary>
        /// <param name="id">El identificador único de la fotocopiadora que se va a actualizar.</param>
        /// <param name="eIFotocopiadora">Los datos de la fotocopiadora que se van a actualizar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Actualizar_Fotocopiadora_EIFotocopiadora(string id, EIFotocopiadora eIFotocopiadora)
        {
            var response = new EResponse<bool>();
            try
            {
                await _firebaseDbContext.Child(NODO_FOTOCOPIADORA).Child(id).PatchAsync(eIFotocopiadora);
                response.Exitoso = true;
                response.Mensaje = "Fotocopiadora actualizada exitosamente.";
                response.Datos = true;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al actualizar la Fotocopiadora en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Elimina una fotocopiadora desde Firebase Realtime Database por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la fotocopiadora que se va a eliminar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Eliminar_Fotocopiadora_FotocopiadoraId(string id)
        {
            var response = new EResponse<bool>();
            try
            {
                await _firebaseDbContext.Child(NODO_FOTOCOPIADORA).Child(id).DeleteAsync();
                response.Exitoso = true;
                response.Mensaje = "Fotocopiadora eliminada exitosamente.";
                response.Datos = true;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al eliminar la Fotocopiadora en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }
    }
}
