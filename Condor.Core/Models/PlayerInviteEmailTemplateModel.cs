using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condor.Models
{
    public class PlayerInviteEmailTemplateModel
    {
        public string FullName { get; set; }
        public string CoachName { get; set; }
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public int PlayerID { get; set; }
    }
}