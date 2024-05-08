using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WELLTRACKSOFT.Models;

public partial class TabPayer
{
    public long Id { get; set; }

    public string? PayerId { get; set; }

    public string? PayerName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Website { get; set; }

    public string? Description { get; set; }

    public long? TabStreetAddressId { get; set; }

    public string? ExternalId { get; set; }

    public string? TradingPartnerId { get; set; }

    public byte[]? Logo { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? CreatedBy { get; set; }

    [NotMapped]

    public List<TabPayersCatalog> catalog { get; set; }
}
