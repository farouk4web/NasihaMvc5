using System;
using System.ComponentModel.DataAnnotations;

namespace Nasiha.DTOs
{
    public class AdviceDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Content { get; set; }

        public bool LikeIt { get; set; }
        public bool PinIt { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Sender { get; set; }

        public string ReceiverId { get; set; }
        public UserDto Receiver { get; set; }
    }
}