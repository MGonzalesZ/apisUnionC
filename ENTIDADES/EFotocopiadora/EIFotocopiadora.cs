using System.Runtime.Serialization;

namespace ENTIDADES.EFotocopiadora
{
	[DataContract]
	public class EIFotocopiadora
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
		public string InformacionFotocopiadora { get; set; }

		/// <summary>
		/// Obtiene o establece la descripción de la fotocopiadora.
		/// </summary>
		[DataMember]
		public string Descripcion { get; set; }

		/// <summary>
		/// Obtiene o establece los detalles de la tarjeta de informacion de la fotocopiadora.
		/// </summary>
		[DataMember]
		public string DetallesInfoFotocopiadora { get; set; }

		#endregion
	}
}
