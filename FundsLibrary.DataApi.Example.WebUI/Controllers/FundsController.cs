using System.Threading.Tasks;
using System.Web.Mvc;
using FundsLibrary.DataApi.Example.Service.Domain.FundsLibrary.DataApi.Domain;
using FundsLibrary.DataApi.Example.Service.Services;
using FundsLibrary.DataApi.Example.WebUI.Models;

namespace FundsLibrary.DataApi.Example.WebUI.Controllers
{
	public class FundsController : Controller
	{
		private readonly IDataApiService service;

		public FundsController()
			: this(new DataApiService())
		{ }

		public FundsController(IDataApiService service)
		{
			this.service = service;
		}

		public async Task<ActionResult> Index(int page = 1, int take = 20)
		{
			var items = await service.GetPage(page, take);

			return View(new PagedResultViewModel<FundUnit>(page, take, items.Value, items.Count));
		}

		[HttpGet]
		[Route("funds/filter")]
		public ActionResult Filter()
		{
			return View(new FilterFundsViewModel());
		}

		[HttpPost]
		[Route("funds/filter")]
		public async Task<ActionResult> Filter(FilterFundsViewModel model)
		{
			var items = await service.GetUnitsWithLotsOfFilters(
							model.InitialCharge,
							model.Sector,
							model.ChargesToCapital);

			return View(new FilterFundsViewModel(items));
		}

		[Route("funds/{sedol}")]
		public async Task<ActionResult> Fund(string sedol)
		{
			return View(await service.GetUnitWhereSedol(sedol));
		}
	}
}