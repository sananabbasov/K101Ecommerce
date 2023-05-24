using System;
namespace Web.DTOs
{
	public class UserCheckOutDTO
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhonoNumber { get; set; }
		public string Address { get; set; }
		public string Message { get; set; }
		public List<CartDTO> Carts { get; set; }
	}


	
}

