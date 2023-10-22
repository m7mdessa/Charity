using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity.Core.DTO
{
	public class Charities
	{
        public decimal Id { get; set; }

        public string? Charityname { get; set; }

        public string? Mission { get; set; }

        public string? Image { get; set; }

        public string? Status { get; set; }

        public string? Address { get; set; }

        public DateTime? Createddate { get; set; }


        public string? categoryname { get; set; }

        public decimal? Price { get; set; }

        public int? Totalprice { get; set; }

        public int? Minprice { get; set; }

        public int? Goalprice { get; set; }

        public decimal? Longitude { get; set; }

        public decimal? Latitude { get; set; }

        public string? Username { get; set; }
        public string? email { get; set; }



	}
}
