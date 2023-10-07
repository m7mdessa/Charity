using System;
using System.Collections.Generic;

namespace Charity.Core.Data;

public partial class Charitys
{
    public decimal Id { get; set; }

    public string? Charityname { get; set; }

    public string? Mission { get; set; }

    public string? Image { get; set; }

    public string? Status { get; set; }

    public string? Address { get; set; }

    public DateTime? Createddate { get; set; }

    public decimal? Categoryid { get; set; }

    public decimal? Price { get; set; }

    public int? Totalprice { get; set; }

    public int? Minprice { get; set; }

    public int? Goalprice { get; set; }

    public decimal? Longitude { get; set; }

    public decimal? Latitude { get; set; }
    public decimal? Userid { get; set; }

    public virtual CharityCategory? Category { get; set; }

    public virtual ICollection<CharityDonation> CharityDonations { get; set; } = new List<CharityDonation>();

    public virtual CharityUser? User { get; set; }
}
