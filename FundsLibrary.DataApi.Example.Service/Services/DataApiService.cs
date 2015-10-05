using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundsLibrary.DataApi.Example.Service.Domain;
using FundsLibrary.DataApi.Example.Service.Domain.FundsLibrary.DataApi.Domain;
using FundsLibrary.DataApi.Example.Service.Factories;
using Simple.OData.Client;

namespace FundsLibrary.DataApi.Example.Service.Services
{
	public class DataApiService : IDataApiService
	{
		private readonly IODataClient client;

		public DataApiService()
			: this(new ODataClientFactory().GetClient())
		{ }

		public DataApiService(IODataClient client)
		{
			this.client = client;
		}

		public async Task<IPageResult<Security>> GetPage(int page, int take)
		{
			return await GetPagedResponse(() => client
				.For<Security>()
				.Skip((page - 1) * take)
				.Top(take));
		}

		public Task<Security> GetSecurityWhereSedol(string sedol)
		{
			return client
				.For<Security>()
				.Filter(unit => unit.StaticData.Identification.SedolCode == sedol)
				.FindEntryAsync();
		}

		public async Task<IPageResult<Security>> GetSecuritiesWhereInitialChargesGreaterThan(decimal charge, int page, int take)
		{
			return await GetPagedResponse(() => client
				.For<Security>()
				.Filter(unit => unit.StaticData.Charges.Initial > charge)
				.Skip((page - 1) * take)
				.Top(take));
		}

		public async Task<IPageResult<Security>> GetSecuritiesWhereIaSector(string sector, int page, int take)
		{
			return await GetPagedResponse(() => client
				.For<Security>()
				.Filter(unit => unit.StaticData.Essentials.IaSector == sector)
				.Skip((page - 1) * take)
				.Top(take));
		}

		public async Task<IPageResult<Security>> GetSecuritiesWhereChargesToCapital(bool charged, int page, int take)
		{
			return await GetPagedResponse(() => client
				.For<Security>()
				.Filter(unit => unit.StaticData.Risks.ChargesToCapital == charged)
				.Skip((page - 1) * take)
				.Top(take));
		}

		public async Task<IEnumerable<Security>> GetSecuritiesWithLotsOfFilters(decimal? initialCharge, string sector, bool? chargesToCapital)
		{
			var query = client.For<Security>();

			if (initialCharge.HasValue)
				query.Filter(unit => unit.StaticData.Charges.Initial > initialCharge);

			if (!string.IsNullOrWhiteSpace(sector))
				query.Filter(unit => unit.StaticData.Essentials.IaSector == sector);

			if (chargesToCapital.HasValue)
				query.Filter(unit => unit.StaticData.Risks.ChargesToCapital == chargesToCapital);

			return await query
				.FindEntriesAsync();
		}

		public async Task<IEnumerable<Security>> GetSecuritiesBySedols(string[] sedols)
		{
			var query = client.For<Security>()
						   .Function("FL.GetSedols")
						   .Set(new { Sedols = sedols });

			return await query
				  .ExecuteAsEnumerableAsync();
		}

		private async Task<IPageResult<Security>> GetPagedResponse(Func<IBoundClient<Security>> request)
		{
			var annotations = new ODataFeedAnnotations();

			var response = await request()
							.FindEntriesAsync(annotations);

			return new PageResult<Security>
			{
				Count = annotations.Count.HasValue ? (int)annotations.Count : 0,
				Value = response.ToList()
			};
		}
	}
}
