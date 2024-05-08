using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WELLTRACKSOFT.Models;

public partial class TabBillingCodesTypesRelation
{
    public long Id { get; set; }

    [Display(Name ="Code Type:")]
    public int TabBillingCodeTypeId { get; set; }

   
     [Display(Name ="Billing Code:")]
    public string BillingCode { get; set; } = null!;
    [Display(Name = "Description:")]
    public string BillingCodeDesc { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    [NotMapped]
    [Display(Name ="Modifiers:")]
    public string modifiercodes { get; set; }


    [NotMapped]
    [Display(Name = "Allowed Places of Service:")]
    public string places { get; set; }

}
