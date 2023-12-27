﻿using System.ComponentModel.DataAnnotations;

namespace APIMovies.Models
{
	public class UserDetails
	{
		[Required]
		public string UserName { get; set; }
		[Required]

		public string Email { get; set; }
		[Required]

		public string Password { get; set; }
	}
}
