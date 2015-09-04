using System.Collections.Generic;
using FundsLibrary.DataApi.Example.Service.Domain.FundsLibrary.DataApi.Domain;

namespace FundsLibrary.DataApi.Example.WebUI.Models
{
	public class FilterFundsViewModel
	{
		public decimal? InitialCharge { get; set; }
		public string Sector { get; set; }
		public bool? ChargesToCapital { get; set; }

		public IEnumerable<FundUnit> Results { get; set; }

		public FilterFundsViewModel()
		{
		}

		public FilterFundsViewModel(IEnumerable<FundUnit> results)
		{
			Results = results;
		}
	}
}