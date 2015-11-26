using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condor.Models
{
    public class TeamUserInviteEmailTemplateModel
    {
        public string FullName { get; set; }
        public string SenderName { get; set; }
        public int TeamID { get; set; }
        public int TeamFanID { get; set; } 
        public string TeamName { get; set; }
    }
}