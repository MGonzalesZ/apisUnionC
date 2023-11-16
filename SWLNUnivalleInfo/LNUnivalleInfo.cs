using ENTIDADES.EPostgrado;
using ENTIDADES.EFotocopiadora;
using ENTIDADES.EClinicaOdontologica;
using HERRAMIENTAS;
using SWADUnivalleInfo.SWADPostgrado;
using SWADUnivalleInfo.SWADFotocopiadora;
using SWADUnivalleInfo.SWADClinicaOdontologica;
using ENTIDADES.EDeportes;
using SWADUnivalleInfo.SWADDeportes;
using ENTIDADES.EPlataforma;
using SWADUnivalleInfo.SWADPlataforma;
using ENTIDADES.ENAF;
using SWADUnivalleInfo.SWADNAF;

namespace SWLNUnivalleInfo
{
	/// <summary>
	/// Clase que proporciona funcionalidad para operaciones relacionadas con los postgrados.
	/// </summary>
	public class LNUnivalleInfo
	{
		#region Atributos

		/// <summary>
		/// Instancia de la clase SWADPostgrado para realizar operaciones relacionadas con los postgrados.
		/// </summary>
		public SWADPostgrado swadPostgrado;
		public SWADFotocopiadora swadFotocopiadora;
		public SWADClinicaOdontologica swadClinicaOdontologica;
        public SWADDeportes swadDeportes;
        public SWADPlataforma swadPlataforma;
        public SWADNAF swadNAF;
		#endregion

		#region Constructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase LNUnivalleInfo.
		/// </summary>
		public LNUnivalleInfo()
		{
			swadPostgrado = new SWADPostgrado();
			swadFotocopiadora = new SWADFotocopiadora();
			swadClinicaOdontologica = new SWADClinicaOdontologica();
            swadDeportes = new SWADDeportes();
            swadPlataforma = new SWADPlataforma();
            swadNAF = new SWADNAF();
		}

		#endregion

		#region Metodos Publicos

		/// <summary>
		/// Agrega un postgrado utilizando los datos proporcionados en el objeto EIPostgrado.
		/// </summary>
		/// <param name="eIPostgrado">Los datos del postgrado que se va a insertar.</param>
		/// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
		public async Task<EResponse<string>> Adicionar_Postgrado_EIPostgrado(EIPostgrado eIPostgrado)
		{
			EResponse<string> response = await swadPostgrado.Adicionar_Postgrado_EIPostgrado(eIPostgrado);
			return response;
		}

		/// <summary>
		/// Obtiene una lista de postgrados.
		/// </summary>
		/// <returns>Un EResponse que indica si la operación fue exitosa y contiene una lista de postgrados.</returns>
		public async Task<EResponse<List<EIPostgrado>>> Obtener_Postgrados()
		{
			EResponse<List<EIPostgrado>> response = await swadPostgrado.Obtener_Postgrados();
			return response;
		}

		/// <summary>
		/// Actualiza un postgrado utilizando los datos proporcionados en el objeto EIPostgrado.
		/// </summary>
		/// <param name="id">El identificador único del postgrado que se va a actualizar.</param>
		/// <param name="eIPostgrado">Los datos del postgrado que se van a actualizar.</param>
		/// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
		public async Task<EResponse<bool>> Actualizar_Postgrado_EIPostgrado(string id, EIPostgrado eIPostgrado)
		{
			EResponse<bool> response = await swadPostgrado.Actualizar_Postgrado_EIPostgrado(id, eIPostgrado);
			return response;
		}

		/// <summary>
		/// Elimina un postgrado utilizando su identificador único.
		/// </summary>
		/// <param name="postgradoId">El identificador único del postgrado que se va a eliminar.</param>
		/// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
		public async Task<EResponse<bool>> Eliminar_Postgrado_PostgradoId(string postgradoId)
		{
			EResponse<bool> response = await swadPostgrado.Eliminar_Postgrado_PostgradoId(postgradoId);
			return response;
		}
        /// <summary>
        /// Agrega una fotocopiadora utilizando los datos proporcionados en el objeto EIFotocopiadora.
        /// </summary>
        /// <param name="eIFotocopiadora">Los datos de la fotocopiadora que se va a insertar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<string>> Adicionar_Fotocopiadora_EIFotocopiadora(EIFotocopiadora eIFotocopiadora)
        {
            EResponse<string> response = await swadFotocopiadora.Adicionar_Fotocopiadora_EIFotocopiadora(eIFotocopiadora);
            return response;
        }

        /// <summary>
        /// Obtiene una lista de fotocopiadoras.
        /// </summary>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene una lista de fotocopiadoras.</returns>
        public async Task<EResponse<List<EIFotocopiadora>>> Obtener_Fotocopiadoras()
        {
            EResponse<List<EIFotocopiadora>> response = await swadFotocopiadora.Obtener_Fotocopiadoras();
            return response;
        }

        /// <summary>
        /// Actualiza una fotocopiadora utilizando los datos proporcionados en el objeto EIFotocopiadora.
        /// </summary>
        /// <param name="id">El identificador único de la fotocopiadora que se va a actualizar.</param>
        /// <param name="eIFotocopiadora">Los datos de la fotocopiadora que se van a actualizar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Actualizar_Fotocopiadora_EIFotocopiadora(string id, EIFotocopiadora eIFotocopiadora)
        {
            EResponse<bool> response = await swadFotocopiadora.Actualizar_Fotocopiadora_EIFotocopiadora(id, eIFotocopiadora);
            return response;
        }

        /// <summary>
        /// Elimina una fotocopiadora utilizando su identificador único.
        /// </summary>
        /// <param name="fotocopiadoraId">El identificador único de la fotocopiadora que se va a eliminar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Eliminar_Fotocopiadora_FotocopiadoraId(string fotocopiadoraId)
        {
            EResponse<bool> response = await swadFotocopiadora.Eliminar_Fotocopiadora_FotocopiadoraId(fotocopiadoraId);
            return response;
        }
        public async Task<EResponse<string>> Adicionar_ClinicaOdontologica_EIClinicaOdontologica(EIClinicaOdontologica eIClinicaOdontologica)
        {
            EResponse<string> response = await swadClinicaOdontologica.Adicionar_ClinicaOdontologica_EIClinicaOdontologica(eIClinicaOdontologica);
            return response;
        }

        /// <summary>
        /// Obtiene una lista de clínicas odontológicas.
        /// </summary>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene una lista de clínicas odontológicas.</returns>
        public async Task<EResponse<List<EIClinicaOdontologica>>> Obtener_ClinicaOdontologicas()
        {
            EResponse<List<EIClinicaOdontologica>> response = await swadClinicaOdontologica.Obtener_ClinicaOdontologica();
            return response;
        }

        /// <summary>
        /// Actualiza una clínica odontológica utilizando los datos proporcionados en el objeto EIClinicaOdontologica.
        /// </summary>
        /// <param name="id">El identificador único de la clínica odontológica que se va a actualizar.</param>
        /// <param name="eIClinicaOdontologica">Los datos de la clínica odontológica que se van a actualizar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Actualizar_ClinicaOdontologica_EIClinicaOdontologica(string id, EIClinicaOdontologica eIClinicaOdontologica)
        {
            EResponse<bool> response = await swadClinicaOdontologica.Actualizar_ClinicaOdontologica_EIClinicaOdontologica(id, eIClinicaOdontologica);
            return response;
        }

        /// <summary>
        /// Elimina una clínica odontológica utilizando su identificador único.
        /// </summary>
        /// <param name="clinicaOdontologicaId">El identificador único de la clínica odontológica que se va a eliminar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Eliminar_ClinicaOdontologica_ClinicaOdontologicaId(string clinicaOdontologicaId)
        {
            EResponse<bool> response = await swadClinicaOdontologica.Eliminar_ClinicaOdontologica_ClinicaOdontologicaId(clinicaOdontologicaId);
            return response;
        }
        /// <summary>
        /// Agrega un deporte utilizando los datos proporcionados en el objeto EIDeportes.
        /// </summary>
        /// <param name="eIDeportes">Los datos del deporte que se va a insertar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<string>> Adicionar_Deporte_EIDeportes(EIDeportes eIDeportes)
        {
            EResponse<string> response = await swadDeportes.Adicionar_Deporte_EIDeportes(eIDeportes);
            return response;
        }

        /// <summary>
        /// Obtiene una lista de deportes.
        /// </summary>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene una lista de deportes.</returns>
        public async Task<EResponse<List<EIDeportes>>> Obtener_Deportes()
        {
            EResponse<List<EIDeportes>> response = await swadDeportes.Obtener_Deportes();
            return response;
        }

        /// <summary>
        /// Actualiza un deporte utilizando los datos proporcionados en el objeto EIDeportes.
        /// </summary>
        /// <param name="id">El identificador único del deporte que se va a actualizar.</param>
        /// <param name="eIDeportes">Los datos del deporte que se van a actualizar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Actualizar_Deporte_EIDeportes(string id, EIDeportes eIDeportes)
        {
            EResponse<bool> response = await swadDeportes.Actualizar_Deporte_EIDeportes(id, eIDeportes);
            return response;
        }

        /// <summary>
        /// Elimina un deporte utilizando su identificador único.
        /// </summary>
        /// <param name="deporteId">El identificador único del deporte que se va a eliminar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Eliminar_Deporte_DeporteId(string deporteId)
        {
            EResponse<bool> response = await swadDeportes.Eliminar_Deporte_DeporteId(deporteId);
            return response;
        }
        public async Task<EResponse<string>> Adicionar_Plataforma_EIPlataforma(EIPlataforma eIPlataforma)
        {
            EResponse<string> response = await swadPlataforma.Adicionar_Plataforma_EIPlataforma(eIPlataforma);
            return response;
        }

        /// <summary>
        /// Obtiene una lista de plataformas.
        /// </summary>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene una lista de plataformas.</returns>
        public async Task<EResponse<List<EIPlataforma>>> Obtener_Plataformas()
        {
            EResponse<List<EIPlataforma>> response = await swadPlataforma.Obtener_Plataformas();
            return response;
        }

        /// <summary>
        /// Actualiza una plataforma utilizando los datos proporcionados en el objeto EIPlataforma.
        /// </summary>
        /// <param name="id">El identificador único de la plataforma que se va a actualizar.</param>
        /// <param name="eIPlataforma">Los datos de la plataforma que se van a actualizar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Actualizar_Plataforma_EIPlataforma(string id, EIPlataforma eIPlataforma)
        {
            EResponse<bool> response = await swadPlataforma.Actualizar_Plataforma_EIPlataforma(id, eIPlataforma);
            return response;
        }

        /// <summary>
        /// Elimina una plataforma utilizando su identificador único.
        /// </summary>
        /// <param name="plataformaId">El identificador único de la plataforma que se va a eliminar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.</returns>
        public async Task<EResponse<bool>> Eliminar_Plataforma_PlataformaId(string plataformaId)
        {
            EResponse<bool> response = await swadPlataforma.Eliminar_Plataforma_PlataformaId(plataformaId);
            return response;
        }
        public async Task<EResponse<string>> Adicionar_NAF_EENAF(EINAF eINAF)
        {
            EResponse<string> response = await swadNAF.Adicionar_NAF_EENAF(eINAF);
            return response;
        }

        /// <summary>
        /// Obtiene una lista de NAF.
        /// </summary>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene una lista de NAF.
        public async Task<EResponse<List<EINAF>>> Obtener_NAFs()
        {
            EResponse<List<EINAF>> response = await swadNAF.Obtener_NAFs();
            return response;
        }

        /// <summary>
        /// Actualiza un NAF utilizando los datos proporcionados en el objeto EINAF.
        /// </summary>
        /// <param name="id">El identificador único del NAF que se va a actualizar.</param>
        /// <param name="eINAF">Los datos del NAF que se van a actualizar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.
        public async Task<EResponse<bool>> Actualizar_NAF_EENAF(string id, EINAF eINAF)
        {
            EResponse<bool> response = await swadNAF.Actualizar_NAF_EENAF(id, eINAF);
            return response;
        }

        /// <summary>
        /// Elimina un NAF utilizando su identificador único.
        /// </summary>
        /// <param name="nafId">El identificador único del NAF que se va a eliminar.</param>
        /// <returns>Un EResponse que indica si la operación fue exitosa y contiene un mensaje y datos adicionales.
        public async Task<EResponse<bool>> Eliminar_NAF_NAFId(string nafId)
        {
            EResponse<bool> response = await swadNAF.Eliminar_NAF_NAFId(nafId);
            return response;
        }

        #endregion

    }
}
