using System;
using System.Collections.Generic;

namespace WELLTRACKSOFT.Models;

public partial class TabBillingCodesModifier
{
    public long Id { get; set; }

    public string BcmodifierCode { get; set; } = null!;

    public string? BcmodifierDesc { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }
}
