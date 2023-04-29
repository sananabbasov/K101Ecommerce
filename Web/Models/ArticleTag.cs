using System;
namespace Web.Models
{
	public class ArticleTag
	{
		public int Id { get; set; }
        // ArticleId references foreign key Article(Id)
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        // TagId references foreign key Tag(Id)
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}