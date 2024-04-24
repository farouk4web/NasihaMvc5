using System.ComponentModel.DataAnnotations;

namespace Nasiha.DTOs
{
    public class UserDto
    {
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Zء-ي ]*$")]
        public string FullName { get; set; }

        //[UniqueNickname]
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]*$")]
        public string Nickname { get; set; }

        public string ProfileImageSrc { get; set; }

    }
}