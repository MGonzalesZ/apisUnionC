using ENTIDADES.EClinicaOdontologica;
using Firebase.Database;
using Firebase.Database.Query;
using HERRAMIENTAS;
using SWADUnivalleInfo.DbContext;

namespace SWADUnivalleInfo.SWADClinicaOdontologica
{
	public class SWADClinicaOdontologica
	{
        #region Atributos
        private readonly FirebaseClient _firebaseDbContext;
        private const string NODO_CLINICA_ODONTOLOGICA = SDatosGlobales.NODO_CLINICA_ODONTOLOGICA;
        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase SWADClinicaOdontologica.
        /// </summary>
        public SWADClinicaOdontologica()
        {
            _firebaseDbContext = new FirebaseDbContext().FirebaseClient;
        }

        /// <summary>
        /// Obtiene una lista de clínicas odontológicas desde Firebase Realtime Database.
        /// </summary>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene una lista de clínicas odontológicas.</returns>
        public async Task<EResponse<List<EIClinicaOdontologica>>> Obtener_ClinicaOdontologica()
        {
            var response = new EResponse<List<EIClinicaOdontologica>>();
            try
            {
                var ColeccionClinicaOdontologica = await _firebaseDbContext.Child(NODO_CLINICA_ODONTOLOGICA).OnceAsync<EIClinicaOdontologica>();

                var listEIClinicaOdontologica = new List<EIClinicaOdontologica>();

                foreach (var clinicaOdontologica in ColeccionClinicaOdontologica)
                {
                    var userData = clinicaOdontologica.Object;
                    userData.Id = clinicaOdontologica.Key;
                    listEIClinicaOdontologica.Add(userData);
                }

                response.Exitoso = true;
                response.Mensaje = "Lista de clínica odontológica obtenida exitosamente.";
                response.Datos = listEIClinicaOdontologica;

            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al obtener la lista de clínicas odontológicas desde Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Agrega una clínica odontológica en Firebase Realtime Database.
        /// </summary>
        /// <param name="eIClinicaOdontologica">Los datos de la clínica odontológica que se va a insertar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<string>> Adicionar_ClinicaOdontologica_EIClinicaOdontologica(EIClinicaOdontologica eIClinicaOdontologica)
        {
            var response = new EResponse<string>();
            try
            {
                var result = await _firebaseDbContext.Child(NODO_CLINICA_ODONTOLOGICA).PostAsync(eIClinicaOdontologica);
                response.Exitoso = true;
                response.Mensaje = "Clínica odontológica agregada exitosamente.";
                response.Datos = result.Key;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al agregar la Clínica Odontológica en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Actualiza una clínica odontológica en Firebase Realtime Database.
        /// </summary>
        /// <param name="id">El identificador único de la clínica odontológica que se va a actualizar.</param>
        /// <param name="eIClinicaOdontologica">Los datos de la clínica odontológica que se van a actualizar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Actualizar_ClinicaOdontologica_EIClinicaOdontologica(string id, EIClinicaOdontologica eIClinicaOdontologica)
        {
            var response = new EResponse<bool>();
            try
            {
                await _firebaseDbContext.Child(NODO_CLINICA_ODONTOLOGICA).Child(id).PatchAsync(eIClinicaOdontologica);
                response.Exitoso = true;
                response.Mensaje = "Clínica odontológica actualizada exitosamente.";
                response.Datos = true;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al actualizar la Clínica Odontológica en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Elimina una clínica odontológica desde Firebase Realtime Database por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la clínica odontológica que se va a eliminar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Eliminar_ClinicaOdontologica_ClinicaOdontologicaId(string id)
        {
            var response = new EResponse<bool>();
            try
            {
                await _firebaseDbContext.Child(NODO_CLINICA_ODONTOLOGICA).Child(id).DeleteAsync();
                response.Exitoso = true;
                response.Mensaje = "Clínica odontológica eliminada exitosamente.";
                response.Datos = true;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al eliminar la Clínica Odontológica en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

    }
}
