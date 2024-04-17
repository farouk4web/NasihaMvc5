using Nasiha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nasiha.ViewModels
{
    public class AdvicesVM
    {
        public ApplicationUser User { get; set; }

        public string SiteDomain { get; set; }
    }
}