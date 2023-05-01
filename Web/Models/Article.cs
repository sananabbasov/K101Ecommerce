using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Web.Models
{
	public class Article
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="Basliq bos ola bilmez")]
		[MinLength(5,ErrorMessage = "Basliq 5 simvoldan az ola bilmez")]
		public string Title { get; set; }
		public string Description { get; set; }
		public string SeoUrl { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public string UserId { get; set; }
		public User User { get; set; }
		public string PhotoUrl { get; set; }
        public List<ArticleTag> ArticleTags { get; set; }
        public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
	}
}

