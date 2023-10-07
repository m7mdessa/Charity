using System;
using System.Collections.Generic;

namespace Charity.Core.Data;

public partial class CharityContact
{
    public decimal Id { get; set; }

    public string? Contactname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public DateTime? Datecreated { get; set; }

    public decimal? Pageid { get; set; }

    public virtual CharityPage? Page { get; set; }
}
