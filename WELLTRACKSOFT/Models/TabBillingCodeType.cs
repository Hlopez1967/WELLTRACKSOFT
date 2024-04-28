using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WELLTRACKSOFT.Models;

public partial class TabBillingCodeType
{
    public int Id { get; set; }

    [Display(Name = "Type Code")]
    public string BctypeCode { get; set; } = null!;
    [Display(Name = "Type Description")]
    public string BctypeDesc { get; set; } = null!;
}
