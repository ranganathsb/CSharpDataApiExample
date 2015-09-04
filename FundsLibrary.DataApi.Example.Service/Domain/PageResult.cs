using System.Collections.Generic;

namespace FundsLibrary.DataApi.Example.Service.Domain
{
	public interface IPageResult<out T>
	{
		int Count { get; }
		IEnumerable<T> Value { get; }
	}

	public class PageResult<T> : IPageResult<T>
	{
		public int Count { get; set; }
		public IEnumerable<T> Value { get; set; }
	}
}
