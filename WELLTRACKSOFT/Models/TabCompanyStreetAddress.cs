using System;
using System.Collections.Generic;

namespace WELLTRACKSOFT.Models;

public partial class TabCompanyStreetAddress
{
    public long Id { get; set; }

    public int TabCompanyGeneralInfoId { get; set; }

    public long TabStreetAddressId { get; set; }

    public bool? IsDefault { get; set; }

    public string? Nickname { get; set; }

    public int? TabPlacesOfServiceId { get; set; }

    public DateTime? DateCreated { get; set; }
}
