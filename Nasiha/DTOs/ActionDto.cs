using System.ComponentModel.DataAnnotations;

namespace Nasiha.DTOs
{
    public class ActionDto
    {
        [Required]
        public int AdviceId { get; set; }

        [Required]
        public bool AddOrNot { get; set; }
    }
}