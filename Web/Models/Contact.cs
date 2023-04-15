using System;
namespace Web.Models
{
	public class Contact
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
	}
}

// add-migration dfsfjlkas
// update-database


// dotnet tool install --global dotnet-ef
// dotnet ef migrations add hskjf
// dotnet ef database update