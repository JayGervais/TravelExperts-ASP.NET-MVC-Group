using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
/// <summary>
/// Customer Login Constructor by Jay Gervais
/// </summary>
namespace TravelExperts_CPRG214_Final_JayGervais.Models
{
    public class CustomerLogin
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Customer ID")]
        public string CustID { get; set; }

        [Required]
        [StringLength(250)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string CustPass { get; set; }
    }
}