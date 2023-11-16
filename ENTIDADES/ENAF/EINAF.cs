using System.Runtime.Serialization;

namespace ENTIDADES.ENAF
{
	[DataContract]
	public class EINAF
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
		public string InformacionNAF { get; set; }

		/// <summary>
		/// Obtiene o establece la descripción de la fotocopiadora.
		/// </summary>
		[DataMember]
		public string Descripcion { get; set; }

		/// <summary>
		/// Obtiene o establece los detalles de la tarjeta de informacion de la fotocopiadora.
		/// </summary>
		[DataMember]
		public string DetallesInfoNAF { get; set; }

		#endregion
	}
}
