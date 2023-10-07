using System.ComponentModel.DataAnnotations;

namespace Charity.Core.DTO
{
	public class Payment
	{
		public decimal Id { get; set; }

		
		public string? Cardnumber { get; set; }

		public string? Cardholdernumber { get; set; }

		public string? Expirationdate { get; set; }

		public string? Cvv { get; set; }
        public decimal UserId { get; set; }


    }
}
