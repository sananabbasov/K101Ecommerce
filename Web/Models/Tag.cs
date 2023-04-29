using System;
namespace Web.Models
{
	public class Tag
	{
		public int Id { get; set; }
		public string TagName { get; set; }
        public List<Article> Articles { get; set; }
    }
}

