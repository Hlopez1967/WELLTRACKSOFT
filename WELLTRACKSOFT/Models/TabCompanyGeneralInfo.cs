using Humanizer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WELLTRACKSOFT.Models;

public partial class TabCompanyGeneralInfo
{
    public int Id { get; set; }

    [Display(Name ="Legal Name:")]
    public string? LegalName { get; set; }

    [Display(Name = "Trade Name:")]
    public string? TradeName { get; set; }

    [Display(Name = "Email:")]
    public string? Email { get; set; }
       
    [Display(Name = "Phone Number:")]
    public string? PhoneNumber { get; set; }
    
    [Display(Name = "Fax:")]
    public string? Fax { get; set; }

    [Display(Name = "Website:")]
    public string? Website { get; set; }

   
    [Display(Name = "Employer Identification Number(EIN) :")]
    
    public string? Ein { get; set; }

   
    [Display(Name = "National Provider ID (NPI):")]
    public string? Npi { get; set; }

   
    [Display(Name = "Medicaid/Medicare Provider ID (MPI):")]
    public string? Mpi { get; set; }

    [Display(Name = "Taxonomy Code:")]
    public string? TaxonomyCode { get; set; }

    [Display(Name = "Created at:")]
    public DateTime? DateCreated { get; set; }

    [Display(Name = "Domain:")]
    public string? Domain { get; set; }

    [Display(Name = "About me:")]
    public string? AboutMe { get; set; }

    public byte[]? Logo { get; set; }
}
