﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
/// <summary>
/// Customer Constructor by Jay Gervais
/// </summary>
namespace TravelExperts_CPRG214_Final_JayGervais.Models
{
    public class Customer
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Customer ID")]
        public string CustID { get; set; }

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
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^\(?([ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9])$", ErrorMessage = "Not a valid postal code")]
        [DisplayName("Postal Code")]
        public string CustPostal { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Country")]
        public string CustCountry { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DisplayName("Home Phone")]
        public string CustHomePhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [DisplayName("Business Phone")]
        public string CustBusPhone { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string CustEmail { get; set; }

        [DisplayName("Agent")]
        public int? AgentId { get; set; }

        [Required]
        [StringLength(250)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string CustPass { get; set; }

        [Compare("CustPass", ErrorMessage = "Confirm password doesn't match, Type again!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}