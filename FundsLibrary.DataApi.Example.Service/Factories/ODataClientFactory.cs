using FundsLibrary.DataApi.Example.Service.Configuration;
using Simple.OData.Client;

namespace FundsLibrary.DataApi.Example.Service.Factories
{
	public class ODataClientFactory : IODataClientFactory
	{
		private readonly IFundsLibraryApiConfiguration configuration;

		public ODataClientFactory()
			: this(new FundsLibraryApiConfiguration())
		{ }

		public ODataClientFactory(IFundsLibraryApiConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public IODataClient GetClient()
		{
			return new ODataClient(new ODataClientSettings(configuration.Url)
			{
				BeforeRequest = message => message.Headers.Add(
					"X-Authorization-key",
					configuration.AuthorizationKey)
			});
		}
	}
}