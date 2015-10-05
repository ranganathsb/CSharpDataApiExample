using System.Collections.Generic;
using System.Threading.Tasks;
using FundsLibrary.DataApi.Example.Service.Domain;
using FundsLibrary.DataApi.Example.Service.Domain.FundsLibrary.DataApi.Domain;

namespace FundsLibrary.DataApi.Example.Service.Services
{
	public interface IDataApiService
	{
		Task<IPageResult<Security>> GetPage(int page, int take);
		Task<Security> GetSecurityWhereSedol(string sedol);
		Task<IPageResult<Security>> GetSecuritiesWhereInitialChargesGreaterThan(decimal charge, int page, int take);
		Task<IPageResult<Security>> GetSecuritiesWhereIaSector(string sector, int page, int take);
		Task<IPageResult<Security>> GetSecuritiesWhereChargesToCapital(bool charged, int page, int take);
		Task<IEnumerable<Security>> GetSecuritiesWithLotsOfFilters(decimal? initialCharge, string sector, bool? chargesToCapital);
		Task<IEnumerable<Security>> GetSecuritiesBySedols(string[] sedols);
	}
}