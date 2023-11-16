using System.Runtime.Serialization;

namespace ENTIDADES.EPlataforma
{
	[DataContract]
	public class EIPlataforma
	{
		#region Variables

		/// <summary>
		/// Obtiene o establece el identificador del postgrado.
		/// </summary>
		[DataMember]
		public string Id { get; set; }

		/// <summary>
		/// Obtiene o establece el titulo de la tarjeta de informacion de la fotocopiadora.
		/// </summary>
		[DataMember]
		public string InformacionPlataforma { get; set; }

		/// <summary>
		/// Obtiene o establece la descripción de la fotocopiadora.
		/// </summary>
		[DataMember]
		public string Descripcion { get; set; }

		/// <summary>
		/// Obtiene o establece los detalles de la tarjeta de informacion de la fotocopiadora.
		/// </summary>
		[DataMember]
		public string DetallesInfoPlataforma { get; set; }

		#endregion
	}
}
