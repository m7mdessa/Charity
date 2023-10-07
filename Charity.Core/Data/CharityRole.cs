using System;
using System.Collections.Generic;

namespace Charity.Core.Data;

public partial class CharityRole
{
    public decimal Id { get; set; }

    public string? Rolename { get; set; }

    public virtual ICollection<CharityUser> CharityUsers { get; set; } = new List<CharityUser>();
}
