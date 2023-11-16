using SWLNUnivalleInfo;
using Microsoft.AspNetCore.Mvc;
using ENTIDADES.EPlataforma; // Reemplaza "EFotocopiadora" por "EPlataforma" para reflejar el cambio de nombre del objeto

namespace SWUnivalleInfo.Controllers.CPlataforma // Cambia el nombre del controlador a "CPlataforma"
{
    [ApiController]
    [Route("c")]
    public class CPlataforma : ControllerBase // Cambia el nombre del controlador a "CPlataforma"
    {
        #region Atributos

        /// <summary>
        /// Instancia de la clase LNUnivalleInfo para realizar operaciones relacionadas con la plataforma.
        /// </summary>
        private readonly LNUnivalleInfo LNUnivalleInfo;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase CPlataforma que inicializa la instancia de LNUnivalleInfo.
        /// </summary>
        public CPlataforma()
        {
            LNUnivalleInfo = new LNUnivalleInfo();
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Endpoint HTTP GET para obtener la lista de plataformas.
        /// </summary>
        /// <returns>Un IActionResult que contiene la lista de plataformas.
        [HttpGet("ObtenerPlataforma")] // Cambia el nombre del método a "ObtenerPlataformas"
        public async Task<IActionResult> Obtener_Plataformas() // Cambia el nombre del método a "Obtener_Plataformas"
        {
            var response = await LNUnivalleInfo.Obtener_Plataformas(); // Cambia el nombre del método a "Obtener_Plataformas"
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP POST para insertar una plataforma.
        /// </summary>
        /// <param name="eIPlataforma">Los datos de la plataforma que se va a insertar.
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.
        [HttpPost("AdicionarPlataforma")] // Cambia el nombre del método a "AdicionarPlataforma"
        public async Task<IActionResult> Adicionar_Plataforma([FromBody] EIPlataforma eIPlataforma) // Cambia el nombre del método a "Adicionar_Plataforma"
        {
            if (string.IsNullOrEmpty(eIPlataforma.InformacionPlataforma) || // Cambia el nombre de los campos y objetos a "Plataforma"
                string.IsNullOrEmpty(eIPlataforma.Descripcion) ||
                string.IsNullOrEmpty(eIPlataforma.DetallesInfoPlataforma))
            {
                return BadRequest("Faltan datos obligatorios en la plataforma.");
            }

            var response = await LNUnivalleInfo.Adicionar_Plataforma_EIPlataforma(eIPlataforma); // Cambia el nombre del método a "Adicionar_Plataforma"
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP PUT para actualizar una plataforma.
        /// </summary>
        /// <param name="eIPlataforma">Los datos de la plataforma que se va a actualizar.
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.
        [HttpPut("ActualizarPlataforma/{plataformaKey}")] // Cambia el nombre del método a "ActualizarPlataforma"
        public async Task<IActionResult> Actualizar_Plataforma(string plataformaKey, [FromBody] EIPlataforma eIPlataforma) // Cambia el nombre del método a "Actualizar_Plataforma"
        {
            if (string.IsNullOrEmpty(eIPlataforma.InformacionPlataforma) || // Cambia el nombre de los campos y objetos a "Plataforma"
                string.IsNullOrEmpty(eIPlataforma.Descripcion) ||
                string.IsNullOrEmpty(eIPlataforma.DetallesInfoPlataforma))
            {
                return BadRequest("Faltan datos obligatorios en la plataforma.");
            }
            var response = await LNUnivalleInfo.Actualizar_Plataforma_EIPlataforma(plataformaKey, eIPlataforma); // Cambia el nombre del método a "Actualizar_Plataforma"
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP DELETE para eliminar una plataforma por su identificador.
        /// </summary>
        /// <param name="plataformaId">El identificador de la plataforma que se va a eliminar.
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.
        [HttpDelete("EliminarPlataforma/{plataformaKey}")] // Cambia el nombre del método a "EliminarPlataforma"
        public async Task<IActionResult> Eliminar_Plataforma(string plataformaKey) // Cambia el nombre del método a "Eliminar_Plataforma"
        {
            if (string.IsNullOrEmpty(plataformaKey))
            {
                return BadRequest("El identificador de la plataforma no puede estar vacío.");
            }

            var response = await LNUnivalleInfo.Eliminar_Plataforma_PlataformaId(plataformaKey); // Cambia el nombre del método a "Eliminar_Plataforma"
            if (!response.Exitoso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        #endregion
    }
}
