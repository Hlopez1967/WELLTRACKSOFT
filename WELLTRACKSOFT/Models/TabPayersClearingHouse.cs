using System;
using System.Collections.Generic;

namespace WELLTRACKSOFT.Models;

public partial class TabPayersClearingHouse
{
    public long Id { get; set; }

    public long TabPayersId { get; set; }

    public long TabClearingHousesId { get; set; }

    public bool? IsDefault { get; set; }

    public bool? IsActive { get; set; }
}
