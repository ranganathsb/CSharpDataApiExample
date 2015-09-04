using System.Configuration;

namespace FundsLibrary.DataApi.Example.Service.Configuration
{
	public class FundsLibraryApiConfiguration : IFundsLibraryApiConfiguration
	{
		private readonly FundsLibraryApiConfigurationSection configuration;

		public FundsLibraryApiConfiguration()
		{
			configuration = (FundsLibraryApiConfigurationSection)ConfigurationManager.GetSection("fundslibraryApi");
		}

		public string Url
		{
			get { return configuration.Url; }
		}

		public string AuthorizationKey
		{
			get { return configuration.AuthorizationKey; }
		}
	}
}
