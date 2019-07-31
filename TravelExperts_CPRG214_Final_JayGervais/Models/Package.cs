using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
/// <summary>
/// Packages Constructor by Jay Gervais
/// </summary>
namespace TravelExperts_CPRG214_Final_JayGervais.Models
{
    public class Package
    {
        [Required]
        public int PackageId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Package Name")]
        public string PkgName { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",
           ApplyFormatInEditMode = true)]
        public DateTime PkgStartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",
           ApplyFormatInEditMode = true)]
        public DateTime PkgEndDate { get; set; }

        [StringLength(50)]
        [DisplayName("Description")]
        public string PkgDesc { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Base Price")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float PkgBasePrice { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Agency Commission")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public float PkgAgencyCommission { get; set; }

        [DisplayName("Image")]
        [StringLength(50)]
        public string PkgImage { get; set; }
    }
}