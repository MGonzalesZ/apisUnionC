using ENTIDADES.ENAF; // Reemplaza "EFotocopiadora" por "ENAF" para reflejar el cambio de nombre del objeto
using Firebase.Database;
using Firebase.Database.Query;
using HERRAMIENTAS;
using SWADUnivalleInfo.DbContext;

namespace SWADUnivalleInfo.SWADNAF // Cambia el nombre del espacio de nombres a "SWADNAF"
{
    public class SWADNAF // Cambia el nombre de la clase a "SWADNAF"
    {
        #region Atributos
        private readonly FirebaseClient _firebaseDbContext;
        private const string NODO_NAF = SDatosGlobales.NODO_NAF; // Cambia el nombre de la constante a "NODO_NAF"
        #endregion

        /// <summary>
        /// Inicializa una nueva instancia de la clase SWADNAF.
        /// </summary>
        public SWADNAF() // Cambia el nombre del constructor a "SWADNAF"
        {
            _firebaseDbContext = new FirebaseDbContext().FirebaseClient;
        }

        /// <summary>
        /// Obtiene una lista de NAF desde Firebase Realtime Database.
        /// </summary>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene una lista de NAF.
        public async Task<EResponse<List<EINAF>>> Obtener_NAFs() // Cambia el nombre del método a "Obtener_NAFs"
        {
            var response = new EResponse<List<EINAF>>();
            try
            {
                var ColeccionNAF = await _firebaseDbContext.Child(NODO_NAF).OnceAsync<EINAF>();

                var listENAF = new List<EINAF>();

                foreach (var naf in ColeccionNAF)
                {
                    var userData = naf.Object;
                    userData.Id = naf.Key;
                    listENAF.Add(userData);
                }

                response.Exitoso = true;
                response.Mensaje = "Lista de NAF obtenida exitosamente.";
                response.Datos = listENAF;

            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al obtener la lista de NAF desde Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Agrega un NAF en Firebase Realtime Database.
        /// </summary>
        /// <param name="eENAF">Los datos del NAF que se va a insertar.
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.
        public async Task<EResponse<string>> Adicionar_NAF_EENAF(EINAF eENAF) // Cambia el nombre del método a "Adicionar_NAF_EENAF"
        {
            var response = new EResponse<string>();
            try
            {
                var result = await _firebaseDbContext.Child(NODO_NAF).PostAsync(eENAF);
                response.Exitoso = true;
                response.Mensaje = "NAF agregado exitosamente.";
                response.Datos = result.Key;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al agregar el NAF en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Actualiza un NAF en Firebase Realtime Database.
        /// </summary>
        /// <param name="id">El identificador único del NAF que se va a actualizar.
        /// <param name="eENAF">Los datos del NAF que se van a actualizar.
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.
        public async Task<EResponse<bool>> Actualizar_NAF_EENAF(string id, EINAF eENAF) // Cambia el nombre del método a "Actualizar_NAF_EENAF"
        {
            var response = new EResponse<bool>();
            try
            {
                await _firebaseDbContext.Child(NODO_NAF).Child(id).PatchAsync(eENAF);
                response.Exitoso = true;
                response.Mensaje = "NAF actualizado exitosamente.";
                response.Datos = true;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al actualizar el NAF en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Elimina un NAF desde Firebase Realtime Database por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único del NAF que se va a eliminar.
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.
        public async Task<EResponse<bool>> Eliminar_NAF_NAFId(string id) // Cambia el nombre del método a "Eliminar_NAF_NAFId"
        {
            var response = new EResponse<bool>();
            try
            {
                await _firebaseDbContext.Child(NODO_NAF).Child(id).DeleteAsync();
                response.Exitoso = true;
                response.Mensaje = "NAF eliminado exitosamente.";
                response.Datos = true;
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al eliminar el NAF en Firebase.";
                response.Excepcion = ex.Message;
            }
            return response;
        }
    }
}
