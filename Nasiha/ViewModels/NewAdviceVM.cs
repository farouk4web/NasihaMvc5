using Nasiha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nasiha.ViewModels
{
    public class NewAdviceVM
    {
        public Advice Advice { get; set; }
        public ApplicationUser Receiver { get; set; }
    }
}