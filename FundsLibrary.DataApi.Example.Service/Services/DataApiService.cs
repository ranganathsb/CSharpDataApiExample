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

		public async Task<IPageResult<FundUnit>> GetPage(int page, int take)
		{
			return await GetPagedResponse(() => client
				.For<FundUnit>()
				.Skip((page - 1) * take)
				.Top(take));
		}

		public Task<FundUnit> GetUnitWhereSedol(string sedol)
		{
			return client
				.For<FundUnit>()
				.Filter(unit => unit.StaticData.Identification.SedolCode == sedol)
				.FindEntryAsync();
		}

		public async Task<IPageResult<FundUnit>> GetUnitsWhereInitialChargesGreaterThan(decimal charge, int page, int take)
		{
			return await GetPagedResponse(() => client
				.For<FundUnit>()
				.Filter(unit => unit.StaticData.Charges.Initial > charge)
				.Skip((page - 1) * take)
				.Top(take));
		}

		public async Task<IPageResult<FundUnit>> GetUnitsWhereIaSector(string sector, int page, int take)
		{
			return await GetPagedResponse(() => client
				.For<FundUnit>()
				.Filter(unit => unit.StaticData.Essentials.IaSector == sector)
				.Skip((page - 1) * take)
				.Top(take));
		}

		public async Task<IPageResult<FundUnit>> GetUnitsWhereChargesToCapital(bool charged, int page, int take)
		{
			return await GetPagedResponse(() => client
				.For<FundUnit>()
				.Filter(unit => unit.StaticData.Risks.ChargesToCapital == charged)
				.Skip((page - 1) * take)
				.Top(take));
		}

		public async Task<IEnumerable<FundUnit>> GetUnitsWithLotsOfFilters(decimal? initialCharge, string sector, bool? chargesToCapital)
		{
			var query = client.For<FundUnit>();

			if (initialCharge.HasValue)
				query.Filter(unit => unit.StaticData.Charges.Initial > initialCharge);

			if (!string.IsNullOrWhiteSpace(sector))
				query.Filter(unit => unit.StaticData.Essentials.IaSector == sector);

			if (chargesToCapital.HasValue)
				query.Filter(unit => unit.StaticData.Risks.ChargesToCapital == chargesToCapital);

			return await query
				.FindEntriesAsync();
		}

		private async Task<IPageResult<FundUnit>> GetPagedResponse(Func<IBoundClient<FundUnit>> request)
		{
			var annotations = new ODataFeedAnnotations();

			var response = await request()
							.FindEntriesAsync(annotations);

			return new PageResult<FundUnit>
			{
				Count = annotations.Count.HasValue ? (int)annotations.Count : 0,
				Value = response.ToList()
			};
		}
	}
}
