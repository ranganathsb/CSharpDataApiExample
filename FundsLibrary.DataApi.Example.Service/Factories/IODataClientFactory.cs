using Simple.OData.Client;

namespace FundsLibrary.DataApi.Example.Service.Factories
{
	public interface IODataClientFactory
	{
		IODataClient GetClient();
	}
}
