using System.Web.Mvc;

namespace FundsLibrary.DataApi.Example.WebUI
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
