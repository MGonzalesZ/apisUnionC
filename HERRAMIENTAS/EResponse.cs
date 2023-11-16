namespace HERRAMIENTAS
{
	/// <summary>
	/// Representa una respuesta genérica que puede incluir un resultado exitoso, un mensaje,
	/// una excepción y datos de un tipo genérico.
	/// </summary>
	/// <typeparam name="T">El tipo de datos que se incluirá en la respuesta.</typeparam>
	public class EResponse<T>
	{
		/// <summary>
		/// Indica si la operación fue exitosa.
		/// </summary>
		public bool Exitoso { get; set; }

		/// <summary>
		/// Mensaje descriptivo de la operación.
		/// </summary>
		public string Mensaje { get; set; }

		/// <summary>
		/// Excepción relacionada con la operación (si se produce).
		/// </summary>
		public string Excepcion { get; set; }

		/// <summary>
		/// Datos resultantes de la operación, de un tipo genérico.
		/// </summary>
		public T Datos { get; set; }

		/// <summary>
		/// Inicializa una nueva instancia de la clase EResponse con valores predeterminados.
		/// </summary>
		public EResponse()
		{
			// Establece los valores iniciales predeterminados.
			Exitoso = false;
			Mensaje = string.Empty;
			Excepcion = string.Empty;
			Datos = default(T);
		}
	}
}
