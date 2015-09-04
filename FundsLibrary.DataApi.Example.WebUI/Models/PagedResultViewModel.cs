using System.Collections.Generic;

namespace FundsLibrary.DataApi.Example.WebUI.Models
{
	public class PagedResultViewModel<T>
	{
		public int Page { get; set; }
		public int Size { get; set; }
		public int Count { get; set; }
		public IEnumerable<T> Items { get; set; }

		public PagedResultViewModel(int page, int size, IEnumerable<T> items, int count)
		{
			Page = page;
			Size = size;
			Items = items;
			Count = count;
		}
	}
}