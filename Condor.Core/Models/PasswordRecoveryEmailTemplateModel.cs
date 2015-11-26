using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Condor.Models
{
    public class PasswordRecoveryEmailTemplateModel
    {
        public string UserName { get; set; }
        public string UserID { get; set; }
    }
}