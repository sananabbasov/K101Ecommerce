using System;
using Web.Models;

namespace Web.ViewModels
{
	public class DetailVM
	{
		public Product Product { get; set; }
		public List<Product> RelatedProducts{ get; set; }
	}
}

