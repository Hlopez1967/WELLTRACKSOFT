using System;
using System.Collections.Generic;

namespace WELLTRACKSOFT.Models;

public partial class TabPayersCatalog
{
    public long Id { get; set; }

    public string? PayerId { get; set; }

    public string? PayerName { get; set; }

    /// <summary>
    /// I - Institutional; P - Private
    /// </summary>
    public string? PayerType { get; set; }

    public DateTime? DateCreated { get; set; }
}
