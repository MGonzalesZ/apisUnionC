using System.Runtime.Serialization;

namespace ENTIDADES.EClinicaOdontologica
{
	[DataContract]
	public class EIClinicaOdontologica
	{
		#region Variables

		/// <summary>
		/// Obtiene o establece el identificador de la info de clinica.
		/// </summary>
		[DataMember]
		public string Id { get; set; }

		/// <summary>
		/// Obtiene o establece el titulo de la tarjeta de informacion.
		/// </summary>
		[DataMember]
		public string InformacionClinicaOdontologica { get; set; }

		/// <summary>
		/// Obtiene o establece la descripción de la clinica.
		/// </summary>
		[DataMember]
		public string Descripcion { get; set; }

		/// <summary>
		/// Obtiene o establece los detalles de la informacion de la clinica.
		/// </summary>
		[DataMember]
		public string DetallesInfoClinicaOdontologica { get; set; }

		#endregion
	}
}
