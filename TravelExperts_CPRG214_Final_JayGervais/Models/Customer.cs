using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelExperts_CPRG214_Final_JayGervais.Models
{
    public class Customer
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("First Name")]
        public string CustFirstName { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Last Name")]
        public string CustLastName { get; set; }

        [Required]
        [StringLength(75)]
        [DisplayName("Address")]
        public string CustAddress { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("City")]
        public string CustCity { get; set; }

        [Required]
        [StringLength(2)]
        [DisplayName("Province")]
        public string CustProv { get; set; }

        [Required]
        [StringLength(7)]
        [DisplayName("Postal Code")]
        public string CustPostal { get; set; }

        [StringLength(25)]
        [DisplayName("Country")]
        public string CustCountry { get; set; }

        [StringLength(20)]
        [DisplayName("Home Phone")]
        public string CustHomePhone { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Business Phone")]
        public string CustBusPhone { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Email")]
        public string CustEmail { get; set; }

        public int AgentId { get; set; }

        [StringLength(250)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string CustPass { get; set; }

        [Compare("CustPass", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}