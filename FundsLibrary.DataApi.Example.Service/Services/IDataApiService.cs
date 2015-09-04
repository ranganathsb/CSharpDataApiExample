using System.Threading.Tasks;
using FundsLibrary.DataApi.Example.Service.Domain;
using FundsLibrary.DataApi.Example.Service.Domain.FundsLibrary.DataApi.Domain;

namespace FundsLibrary.DataApi.Example.Service.Services
{
	public interface IDataApiService
	{
		Task<IPageResult<FundUnit>> GetPage(int page, int take);
		Task<FundUnit> GetUnitWhereSedol(string sedol);
		Task<IPageResult<FundUnit>> GetUnitsWhereInitialChargesGreaterThan(decimal charge, int page, int take);
		Task<IPageResult<FundUnit>> GetUnitsWhereIaSector(string sector, int page, int take);
		Task<IPageResult<FundUnit>> GetUnitsWhereChargesToCapital(bool charged, int page, int take);
		Task<IPageResult<FundUnit>> GetUnitsWithLotsOfFilters(decimal charge, string sector, bool charged, int page, int take);
	}
}