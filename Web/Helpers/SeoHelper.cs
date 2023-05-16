using System;
namespace Web.Helpers
{
	public static class SeoHelper
	{
		public static string SeoUrlCreater(string contentTitle)
		{
			var result = contentTitle
				     .ToLower()
					 .Replace(" ","-")
					 .Replace("ə", "e")
					 .Replace("ı", "i")
					 .Replace(".", "");
            return result;
		}
	}
}

