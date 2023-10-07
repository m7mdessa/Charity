using System;
using System.Collections.Generic;

namespace Charity.Core.Data;

public partial class CharityNotification
{
    public decimal Id { get; set; }

    public string? Notification { get; set; }

    public DateTime? Notificationdate { get; set; }

    public decimal? Userid { get; set; }

    public virtual CharityUser? User { get; set; }
}
