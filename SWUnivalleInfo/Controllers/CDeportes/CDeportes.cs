using SWLNUnivalleInfo;
using Microsoft.AspNetCore.Mvc;
using ENTIDADES.EDeportes;

namespace SWUnivalleInfo.Controllers.CDeportes
{
    [ApiController]
    [Route("c")]
    public class CDeportes : ControllerBase
    {
        #region Atributos

        /// <summary>
        /// Instancia de la clase LNUnivalleInfo para realizar operaciones relacionadas con los deportes.
        /// </summary>
        private readonly LNUnivalleInfo LNUnivalleInfo;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase CDeportes que inicializa la instancia de LNUnivalleInfo.
        /// </summary>
        public CDeportes()
        {
            LNUnivalleInfo = new LNUnivalleInfo();
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Endpoint HTTP GET para obtener la lista de deportes.
        /// </summary>
        /// <returns>Un IActionResult que contiene la lista de deportes.</returns>
        [HttpGet("ObtenerDeportes")]
        public async Task<IActionResult> Obtener_Deportes()
        {
            var response = await LNUnivalleInfo.Obtener_Deportes();
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP POST para insertar un deporte.
        /// </summary>
        /// <param name="eIDeportes">Los datos del deporte que se va a insertar.</param>
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.</returns>
        [HttpPost("AdicionarDeporte")]
        public async Task<IActionResult> Adicionar_Deporte([FromBody] EIDeportes eIDeportes)
        {
            if (string.IsNullOrEmpty(eIDeportes.Deporte) ||
                string.IsNullOrEmpty(eIDeportes.Descripcion) ||
                string.IsNullOrEmpty(eIDeportes.Horarios))
            {
                return BadRequest("Faltan datos obligatorios en el deporte.");
            }

            var response = await LNUnivalleInfo.Adicionar_Deporte_EIDeportes(eIDeportes);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP PUT para actualizar un deporte.
        /// </summary>
        /// <param name="eIDeportes">Los datos del deporte que se va a actualizar.</param>
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.</returns>
        [HttpPut("ActualizarDeporte/{deporteKey}")]
        public async Task<IActionResult> Actualizar_Deporte(string deporteKey, [FromBody] EIDeportes eIDeportes)
        {
            if (string.IsNullOrEmpty(eIDeportes.Deporte) ||
                string.IsNullOrEmpty(eIDeportes.Descripcion) ||
                string.IsNullOrEmpty(eIDeportes.Horarios))
            {
                return BadRequest("Faltan datos obligatorios en el deporte.");
            }
            var response = await LNUnivalleInfo.Actualizar_Deporte_EIDeportes(deporteKey, eIDeportes);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP DELETE para eliminar un deporte por su identificador.
        /// </summary>
        /// <param name="deporteId">El identificador del deporte que se va a eliminar.</param>
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.</returns>
        [HttpDelete("EliminarDeporte/{deporteKey}")]
        public async Task<IActionResult> Eliminar_Deporte(string deporteKey)
        {
            if (string.IsNullOrEmpty(deporteKey))
            {
                return BadRequest("El identificador del deporte no puede estar vacío.");
            }

            var response = await LNUnivalleInfo.Eliminar_Deporte_DeporteId(deporteKey);

            if (!response.Exitoso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        #endregion
    }
}
