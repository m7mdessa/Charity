using System;
using System.Collections.Generic;

namespace Charity.Core.Data;

public partial class CharityCategory
{
    public decimal Id { get; set; }

    public string? Categoryname { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Charitys> Charities { get; set; } = new List<Charitys>();
}
