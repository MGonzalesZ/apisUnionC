using System.Runtime.Serialization;

namespace ENTIDADES.EDeportes
{
	[DataContract]
	public class EIDeportes
	{
		#region Variables

		/// <summary>
		/// Obtiene o establece el identificador del postgrado.
		/// </summary>
		[DataMember]
		public string Id { get; set; }

		/// <summary>
		/// Obtiene o establece el tipo de postgrado.
		/// </summary>
		[DataMember]
		public string Deporte { get; set; }

		/// <summary>
		/// Obtiene o establece la descripción del postgrado.
		/// </summary>
		[DataMember]
		public string Descripcion { get; set; }

		/// <summary>
		/// Obtiene o establece los requisitos del postgrado.
		/// </summary>
		[DataMember]
		public string Horarios { get; set; }

		#endregion
	}
}
