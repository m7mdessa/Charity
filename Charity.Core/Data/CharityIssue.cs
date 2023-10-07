using System;
using System.Collections.Generic;

namespace Charity.Core.Data;

public partial class CharityIssue
{
    public decimal Id { get; set; }

    public string? Issuedescription { get; set; }

    public DateTime? Datereported { get; set; }

    public decimal? Userid { get; set; }

    public string? Status { get; set; }

    public string? Response { get; set; }

    public virtual CharityUser? User { get; set; }
}
