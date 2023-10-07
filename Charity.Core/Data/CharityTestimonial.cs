using System;
using System.Collections.Generic;

namespace Charity.Core.Data;

public partial class CharityTestimonial
{
    public decimal Id { get; set; }

    public string? Testimonial { get; set; }

    public string? Status { get; set; }

    public DateTime? Datetestimonial { get; set; }

    public decimal? Userid { get; set; }

    public virtual CharityUser? User { get; set; }
}
