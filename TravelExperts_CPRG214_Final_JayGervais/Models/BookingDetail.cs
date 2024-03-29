﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
/// <summary>
/// Booking Details constructor by Hilson Lloyd
/// </summary>
namespace TravelExperts_CPRG214_Final_JayGervais.Models
{
    public class BookingDetail
    {
        [DisplayName("Booking ID")]
        public int BookingId { get; set; }

        public string Description { get; set; }

        public string Destination { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]

        [DisplayName("Base Price")]
        public decimal BasePrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]

        [DisplayName("Agency Commission")]
        public decimal AgencyCommission { get; set; }
    }
}