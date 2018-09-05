using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
	public partial class Devices
    {

		[Key]
		public int id { get; set; }

		[Required]
		[MaxLength(10)]
		public string name { get; set; }

		[Required]
		[MaxLength(5)]
		public string status { get; set; }

	}
}
