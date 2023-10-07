using System;
using System.Collections.Generic;

namespace Charity.Core.Data;

public partial class CharityVisaCard
{
    public decimal Id { get; set; }

    public string? Cardnumber { get; set; }

    public string? Cardholdernumber { get; set; }

    public string? Expirationdate { get; set; }

    public string? Cvv { get; set; }

    public decimal? Balance { get; set; }
}
