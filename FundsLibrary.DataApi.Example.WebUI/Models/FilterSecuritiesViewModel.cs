using System.Collections.Generic;
using FundsLibrary.DataApi.Example.Service.Domain.FundsLibrary.DataApi.Domain;

namespace FundsLibrary.DataApi.Example.WebUI.Models
{
	public class FilterSecuritiesViewModel
	{
		public decimal? InitialCharge { get; set; }
		public string Sector { get; set; }
		public bool? ChargesToCapital { get; set; }

		public IEnumerable<Security> Results { get; set; }

		public FilterSecuritiesViewModel()
		{
		}

		public FilterSecuritiesViewModel(IEnumerable<Security> results)
		{
			Results = results;
		}
	}
}