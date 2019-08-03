using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelExperts_CPRG214_Final_JayGervais.Models
{
    public class AgentDropdown
    {
        [Display(Name = "Agent ID")]
        public int SelectedAgentId { get; set; }

        public IEnumerable<SelectListItem> AgentIds { get; set; }
        

    }
}