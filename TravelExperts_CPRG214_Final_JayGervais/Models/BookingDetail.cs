using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelExperts_CPRG214_Final_JayGervais.Models
{
    public class BookingDetail
    {
        public int BookingId { get; set; }

        public string Description { get; set; }

        public string Destination { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal BasePrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal AgencyCommission { get; set; }
    }
}