using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WELLTRACKSOFT.Models;

public partial class TabPlacesOfService
{
    public int Id { get; set; }

    [Display(Name ="Place Code")]
    public string PlaceOfServiceCode { get; set; } = null!;
    [Display(Name = "Place Description")]
    public string PlaceOfServiceDesc { get; set; } = null!;
}
