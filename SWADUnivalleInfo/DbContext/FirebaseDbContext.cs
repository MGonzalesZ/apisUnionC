using Firebase.Database;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace SWADUnivalleInfo.DbContext
{
	/// <summary>
	/// Clase que proporciona acceso a Firebase Realtime Database.
	/// </summary>
	public class FirebaseDbContext
	{
		#region Atributos

		/// <summary>
		/// Cliente de Firebase Realtime Database para acceder a la base de datos.
		/// </summary>
		public FirebaseClient FirebaseClient { get; private set; }

		#region Campos Privados

		/// <summary>
		/// Ruta al archivo de credenciales de Firebase.
		/// </summary>
		private string credentialsFile = Path.Combine(Directory.GetCurrentDirectory(), "FirebasePrivateKey.json");

		/// <summary>
		/// URL de la base de datos Firebase Realtime Database.
		/// </summary>
		private string firebaseUrl = "https://dbnetinfovalle-default-rtdb.firebaseio.com/";

		#endregion

		#endregion

		#region Constructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase FirebaseDbContext.
		/// </summary>
		public FirebaseDbContext()
		{
			// Verifica si ya existe una instancia de FirebaseApp.
			if (FirebaseApp.DefaultInstance == null)
			{
				// Carga las credenciales desde el archivo de servicio y crea una instancia de FirebaseApp.
				var credential = GoogleCredential.FromFile(this.credentialsFile);
				FirebaseApp.Create(new AppOptions
				{
					Credential = credential,
				});
			}

			// Inicializa el cliente de Firebase Realtime Database.
			FirebaseClient = new FirebaseClient(this.firebaseUrl);
		}
		#endregion
	}
}
