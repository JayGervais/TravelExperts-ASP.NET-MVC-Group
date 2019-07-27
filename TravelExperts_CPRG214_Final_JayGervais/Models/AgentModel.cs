using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelExperts_CPRG214_Final_JayGervais.Models
{
    public class AgentModel
    {
        [Required]
        [RegularExpression("([0-9]+)")]
        public int AgentId { get; set; }

        [Required]
        [StringLength(20)]
        public string AgtFirstName { get; set; }

        [Required]
        [StringLength(5)]
        public string AgtMiddleInitial { get; set; }

        [Required]
        [StringLength(20)]
        public string AgtLastName { get; set; }

        [Required]
        [StringLength(20)]
        public string AgtBusPhone { get; set; }

        [Required]
        [StringLength(20)]
        public string AgtEmail { get; set; }

        [Required]
        [StringLength(20)]
        public string AgtPosition { get; set; }

        [RegularExpression("([0-9]+)")]
        public int AgencyId { get; set; }
    }
}