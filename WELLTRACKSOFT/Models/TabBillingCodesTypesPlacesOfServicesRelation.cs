using System;
using System.Collections.Generic;

namespace WELLTRACKSOFT.Models;

public partial class TabBillingCodesTypesPlacesOfServicesRelation
{
    public long Id { get; set; }

    public long TabBillingCodesTypesRelationId { get; set; }

    public int TabPlacesOfServiceId { get; set; }
}
