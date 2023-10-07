using System;
using System.Collections.Generic;

namespace Charity.Core.Data;

public partial class CharityPage
{
    public decimal Id { get; set; }

    public string? Content { get; set; }

    public string? Slide1 { get; set; }

    public string? Slide2 { get; set; }

    public string? Slide3 { get; set; }

    public string? Logo { get; set; }

    public string? Title { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<CharityContact> CharityContacts { get; set; } = new List<CharityContact>();
}
