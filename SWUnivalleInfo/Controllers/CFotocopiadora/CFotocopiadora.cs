using SWLNUnivalleInfo;
using Microsoft.AspNetCore.Mvc;
using ENTIDADES.EFotocopiadora;

namespace SWUnivalleInfo.Controllers.CFotocopiadora
{
    [ApiController]
    [Route("c")]
    public class CFotocopiadora : ControllerBase
    {
        #region Atributos

        /// <summary>
        /// Instancia de la clase LNUnivalleInfo para realizar operaciones relacionadas con la fotocopiadora.
        /// </summary>
        private readonly LNUnivalleInfo LNUnivalleInfo;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase CFotocopiadora que inicializa la instancia de LNUnivalleInfo.
        /// </summary>
        public CFotocopiadora()
        {
            LNUnivalleInfo = new LNUnivalleInfo();
        }

        #endregion

        #region Metodos Publicos

        /// <summary>
        /// Endpoint HTTP GET para obtener la lista de fotocopiadoras.
        /// </summary>
        /// <returns>Un IActionResult que contiene la lista de fotocopiadoras.</returns>
        [HttpGet("ObtenerFotocopiadora")]
        public async Task<IActionResult> Obtener_Fotocopiadoras()
        {
            var response = await LNUnivalleInfo.Obtener_Fotocopiadoras();
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP POST para insertar una fotocopiadora.
        /// </summary>
        /// <param name="eIFotocopiadora">Los datos de la fotocopiadora que se va a insertar.</param>
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.</returns>
        [HttpPost("AdicionarFotocopiadora")]
        public async Task<IActionResult> Adicionar_Fotocopiadora([FromBody] EIFotocopiadora eIFotocopiadora)
        {
            if (string.IsNullOrEmpty(eIFotocopiadora.InformacionFotocopiadora) ||
                string.IsNullOrEmpty(eIFotocopiadora.Descripcion) ||
                string.IsNullOrEmpty(eIFotocopiadora.DetallesInfoFotocopiadora))
            {
                return BadRequest("Faltan datos obligatorios en la fotocopiadora.");
            }

            var response = await LNUnivalleInfo.Adicionar_Fotocopiadora_EIFotocopiadora(eIFotocopiadora);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP PUT para actualizar una fotocopiadora.
        /// </summary>
        /// <param name="eIFotocopiadora">Los datos de la fotocopiadora que se va a actualizar.</param>
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.</returns>
        [HttpPut("ActualizarFotocopiadora/{fotocopiadoraKey}")]
        public async Task<IActionResult> Actualizar_Fotocopiadora(string fotocopiadoraKey, [FromBody] EIFotocopiadora eIFotocopiadora)
        {
            if (string.IsNullOrEmpty(eIFotocopiadora.InformacionFotocopiadora) ||
                string.IsNullOrEmpty(eIFotocopiadora.Descripcion) ||
                string.IsNullOrEmpty(eIFotocopiadora.DetallesInfoFotocopiadora))
            {
                return BadRequest("Faltan datos obligatorios en la fotocopiadora.");
            }
            var response = await LNUnivalleInfo.Actualizar_Fotocopiadora_EIFotocopiadora(fotocopiadoraKey, eIFotocopiadora);
            return Ok(response);
        }

        /// <summary>
        /// Endpoint HTTP DELETE para eliminar una fotocopiadora por su identificador.
        /// </summary>
        /// <param name="fotocopiadoraId">El identificador de la fotocopiadora que se va a eliminar.</param>
        /// <returns>Un IActionResult que indica si la operación fue exitosa junto con el resultado.</returns>
        [HttpDelete("EliminarFotocopiadora/{fotocopiadoraKey}")]
        public async Task<IActionResult> Eliminar_Fotocopiadora(string fotocopiadoraKey)
        {
            if (string.IsNullOrEmpty(fotocopiadoraKey))
            {
                return BadRequest("El identificador de la fotocopiadora no puede estar vacío.");
            }

            var response = await LNUnivalleInfo.Eliminar_Fotocopiadora_FotocopiadoraId(fotocopiadoraKey);

            if (!response.Exitoso)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        #endregion
    }
}
