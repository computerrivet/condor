using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condor.Models
{
    public class ManagerInviteEmailTemplateModel
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int ManagerID { get; set; }
        public string FullName { get; set; }
        public string CoachName { get; set; }
    }
}