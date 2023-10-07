using System;
using System.Collections.Generic;

namespace Charity.Core.Data;

public partial class CharityUser
{
    public decimal Id { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Image { get; set; }

    public string? Verificationcode { get; set; }

    public DateTime? Verificationcodeexpiration { get; set; }

    public decimal? Roleid { get; set; }


    public virtual ICollection<Charitys> Charities { get; set; } = new List<Charitys>();


    public virtual ICollection<CharityIssue> CharityIssues { get; set; } = new List<CharityIssue>();

    public virtual ICollection<CharityNotification> CharityNotifications { get; set; } = new List<CharityNotification>();

    public virtual ICollection<CharityTestimonial> CharityTestimonials { get; set; } = new List<CharityTestimonial>();

    public virtual ICollection<CharityDonation> CharityDonations { get; set; } = new List<CharityDonation>();

    public virtual CharityRole? Role { get; set; }
}
