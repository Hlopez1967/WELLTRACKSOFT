using System;
using System.Collections.Generic;

namespace WELLTRACKSOFT.Models;

public partial class TabStreetAddress
{
    public long Id { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? Phone { get; set; }
}
