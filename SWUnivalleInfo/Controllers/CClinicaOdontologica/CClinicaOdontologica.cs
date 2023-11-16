using SWLNUnivalleInfo;
using Microsoft.AspNetCore.Mvc;
using ENTIDADES.EClinicaOdontologica;

namespace SWUnivalleInfo.Controllers.CClinicaOdontologica
{
    [ApiController]
    [Route("c")]
    public class CClinicaOdontologica : ControllerBase
    {
        #region Atributos

        /// <summary>
        /// Instancia de la clase LNUnivalleInfo para realizar operaciones relacionadas con la clínica odontológica.
        /// </summary>
        private readonly LNUnivalleInfo LNUnivalleInfo;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase CClinicaOdontologica que inicializa la instancia de LNUnivalleInfo.
        /// </summary>
        public CClinicaOdontologica()
        {
            LNUnivalleInfo = new LNUnivalleInfo();
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Endpoint HTTP GET para obtener la lista de clínicas odontológicas.
        /// </summary>
        /// <returns>Un IActionResult que contiene la lista de clínicas odontológicas.</returns>
        [HttpGet("ObtenerClinicaOdontologica")]
        public async Task<IActionResult> Obtener_ClinicaOdontologicas()
        {
            var response = await LNUnivalleInfo.Obtener_ClinicaOdontologicas();
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP POST para insertar una clínica odontológica.
        /// </summary>
        /// <param name="eIClinicaOdontologica">Los datos de la clínica odontológica que se va a insertar.</param>
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.</returns>
        [HttpPost("AdicionarClinicaOdontologica")]
        public async Task<IActionResult> Adicionar_ClinicaOdontologica([FromBody] EIClinicaOdontologica eIClinicaOdontologica)
        {
            if (string.IsNullOrEmpty(eIClinicaOdontologica.InformacionClinicaOdontologica) ||
                string.IsNullOrEmpty(eIClinicaOdontologica.Descripcion) ||
                string.IsNullOrEmpty(eIClinicaOdontologica.DetallesInfoClinicaOdontologica))
            {
                return BadRequest("Faltan datos obligatorios en la clínica odontológica.");
            }

            var response = await LNUnivalleInfo.Adicionar_ClinicaOdontologica_EIClinicaOdontologica(eIClinicaOdontologica);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP PUT para actualizar una clínica odontológica.
        /// </summary>
        /// <param name="clinicaOdontologicaKey">El identificador de la clínica odontológica que se va a actualizar.</param>
        /// <param name="eIClinicaOdontologica">Los datos de la clínica odontológica que se van a actualizar.</param>
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.</returns>
        [HttpPut("ActualizarClinicaOdontologica/{clinicaOdontologicaKey}")]
        public async Task<IActionResult> Actualizar_ClinicaOdontologica(string clinicaOdontologicaKey, [FromBody] EIClinicaOdontologica eIClinicaOdontologica)
        {
            if (string.IsNullOrEmpty(eIClinicaOdontologica.InformacionClinicaOdontologica) ||
                string.IsNullOrEmpty(eIClinicaOdontologica.Descripcion) ||
                string.IsNullOrEmpty(eIClinicaOdontologica.DetallesInfoClinicaOdontologica))
            {
                return BadRequest("Faltan datos obligatorios en la clínica odontológica.");
            }
            var response = await LNUnivalleInfo.Actualizar_ClinicaOdontologica_EIClinicaOdontologica(clinicaOdontologicaKey, eIClinicaOdontologica);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP DELETE para eliminar una clínica odontológica por su identificador.
        /// </summary>
        /// <param name="clinicaOdontologicaKey">El identificador de la clínica odontológica que se va a eliminar.</param>
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.</returns>
        [HttpDelete("EliminarClinicaOdontologica/{clinicaOdontologicaKey}")]
        public async Task<IActionResult> Eliminar_ClinicaOdontologica(string clinicaOdontologicaKey)
        {
            if (string.IsNullOrEmpty(clinicaOdontologicaKey))
            {
                return BadRequest("El identificador de la clínica odontológica no puede estar vacío.");
            }

            var response = await LNUnivalleInfo.Eliminar_ClinicaOdontologica_ClinicaOdontologicaId(clinicaOdontologicaKey);

            if (!response.Exitoso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        #endregion
    }
}
