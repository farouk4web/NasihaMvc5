using Nasiha.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nasiha.Models
{
    public class Advice
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MinLength(10, ErrorMessageResourceName = "Min10", ErrorMessageResourceType = typeof(ModelsKeys)), MaxLength(500, ErrorMessageResourceName = "Max500", ErrorMessageResourceType = typeof(ModelsKeys))]
        public string Content { get; set; }

        public bool LikeIt { get; set; }
        public bool PinIt { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Sender { get; set; }

        public string ReceiverId { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
    }
}