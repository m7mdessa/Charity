using System;
using System.Collections.Generic;

namespace Charity.Core.Data;

public partial class CharityDonation
{
    public decimal Id { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? Donationdate { get; set; }

    public string? Status { get; set; }

    public decimal? Charityid { get; set; }

    public decimal? Userid { get; set; }

    public virtual Charitys? Charity { get; set; }

    public virtual CharityUser? User { get; set; }
}
