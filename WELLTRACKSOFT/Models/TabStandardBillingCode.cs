using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WELLTRACKSOFT.Models;

public partial class TabStandardBillingCode
{
    public long Id { get; set; }
    [Display (Name ="Standard Billing Code")]
    public string StdBillingCode { get; set; } = null!;
    [Display(Name = "Standard Billing Description")]
    public string StdBillingCodeDesc { get; set; } = null!;
}
