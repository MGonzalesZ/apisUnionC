using SWLNUnivalleInfo;
using Microsoft.AspNetCore.Mvc;
using ENTIDADES.ENAF; // Reemplaza "EFotocopiadora" por "ENAF" para reflejar el cambio de nombre del objeto

namespace SWUnivalleInfo.Controllers.CNAF // Cambia el nombre del espacio de nombres a "CNAF"
{
    [ApiController]
    [Route("c")]
    public class CNAF : ControllerBase // Cambia el nombre de la clase a "CNAF"
    {
        #region Atributos

        /// <summary>
        /// Instancia de la clase LNUnivalleInfo para realizar operaciones relacionadas con el NAF.
        /// </summary>
        private readonly LNUnivalleInfo LNUnivalleInfo;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase CNAF que inicializa la instancia de LNUnivalleInfo.
        /// </summary>
        public CNAF()
        {
            LNUnivalleInfo = new LNUnivalleInfo();
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Endpoint HTTP GET para obtener la lista de NAF.
        /// </summary>
        /// <returns>Un IActionResult que contiene la lista de NAF.
        [HttpGet("ObtenerNAF")] // Cambia el nombre del endpoint a "ObtenerNAF"
        public async Task<IActionResult> Obtener_NAFs()
        {
            var response = await LNUnivalleInfo.Obtener_NAFs(); // Cambia el nombre del método a "Obtener_NAFs"
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP POST para insertar un NAF.
        /// </summary>
        /// <param name="eENAF">Los datos del NAF que se va a insertar.
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.
        [HttpPost("AdicionarNAF")] // Cambia el nombre del endpoint a "AdicionarNAF"
        public async Task<IActionResult> Adicionar_NAF([FromBody] EINAF eENAF)
        {
            if (string.IsNullOrEmpty(eENAF.InformacionNAF) ||
                string.IsNullOrEmpty(eENAF.Descripcion) ||
                string.IsNullOrEmpty(eENAF.DetallesInfoNAF))
            {
                return BadRequest("Faltan datos obligatorios en el NAF.");
            }

            var response = await LNUnivalleInfo.Adicionar_NAF_EENAF(eENAF); // Cambia el nombre del método a "Adicionar_NAF_EENAF"
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP PUT para actualizar un NAF.
        /// </summary>
        /// <param name="eENAF">Los datos del NAF que se va a actualizar.
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.
        [HttpPut("ActualizarNAF/{nafKey}")] // Cambia el nombre del endpoint a "ActualizarNAF"
        public async Task<IActionResult> Actualizar_NAF(string nafKey, [FromBody] EINAF eENAF)
        {
            if (string.IsNullOrEmpty(eENAF.InformacionNAF) ||
                string.IsNullOrEmpty(eENAF.Descripcion) ||
                string.IsNullOrEmpty(eENAF.DetallesInfoNAF))
            {
                return BadRequest("Faltan datos obligatorios en el NAF.");
            }
            var response = await LNUnivalleInfo.Actualizar_NAF_EENAF(nafKey, eENAF); // Cambia el nombre del método a "Actualizar_NAF_EENAF"
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP DELETE para eliminar un NAF por su identificador.
        /// </summary>
        /// <param name="nafId">El identificador del NAF que se va a eliminar.
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.
        [HttpDelete("EliminarNAF/{nafKey}")] // Cambia el nombre del endpoint a "EliminarNAF"
        public async Task<IActionResult> Eliminar_NAF(string nafKey)
        {
            if (string.IsNullOrEmpty(nafKey))
            {
                return BadRequest("El identificador del NAF no puede estar vacío.");
            }

            var response = await LNUnivalleInfo.Eliminar_NAF_NAFId(nafKey); // Cambia el nombre del método a "Eliminar_NAF_NAFId"

            if (!response.Exitoso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        #endregion
    }
}
