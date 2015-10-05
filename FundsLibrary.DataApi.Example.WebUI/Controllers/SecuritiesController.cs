using System.Threading.Tasks;
using System.Web.Mvc;
using FundsLibrary.DataApi.Example.Service.Domain.FundsLibrary.DataApi.Domain;
using FundsLibrary.DataApi.Example.Service.Services;
using FundsLibrary.DataApi.Example.WebUI.Models;

namespace FundsLibrary.DataApi.Example.WebUI.Controllers
{
	public class SecuritiesController : Controller
	{
		private readonly IDataApiService service;

		public SecuritiesController()
			: this(new DataApiService())
		{ }

		public SecuritiesController(IDataApiService service)
		{
			this.service = service;
		}

		public async Task<ActionResult> Index(int page = 1, int take = 20)
		{
			var items = await service.GetPage(page, take);

			return View(new PagedResultViewModel<Security>(page, take, items.Value, items.Count));
		}

		[HttpGet]
		[Route("securities/filter")]
		public ActionResult Filter()
		{
			return View(new FilterSecuritiesViewModel());
		}

		[HttpPost]
		[Route("securities/filter")]
		public async Task<ActionResult> Filter(FilterSecuritiesViewModel model)
		{
			var items = await service.GetSecuritiesWithLotsOfFilters(
							model.InitialCharge,
							model.Sector,
							model.ChargesToCapital);

			return View(new FilterSecuritiesViewModel(items));
		}

		[Route("securities/{sedol}")]
		public async Task<ActionResult> Security(string sedol)
		{
			return View(await service.GetSecurityWhereSedol(sedol));
		}
	}
}