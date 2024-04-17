using Nasiha.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nasiha.Models
{


    // here only classes we are used on this app from accountViewModel
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [EmailAddress(ErrorMessageResourceName = "ValidEmail", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "Email", ResourceType = typeof(ModelsKeys))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(ModelsKeys))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(ModelsKeys))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [RealEmail]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [EmailAddress(ErrorMessageResourceName = "ValidEmail", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "Email", ResourceType = typeof(ModelsKeys))]
        public string Email { get; set; }

        [UniqueNickname]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MinLength(4, ErrorMessageResourceName = "Min4", ErrorMessageResourceType = typeof(ModelsKeys)), MaxLength(50, ErrorMessageResourceName = "Max50", ErrorMessageResourceType = typeof(ModelsKeys))]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessageResourceName = "VlaidUserNameMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "Nickname", ResourceType = typeof(ModelsKeys))]
        public string Nickname { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MinLength(4, ErrorMessageResourceName = "Min4", ErrorMessageResourceType = typeof(ModelsKeys)), MaxLength(50, ErrorMessageResourceName = "Max50", ErrorMessageResourceType = typeof(ModelsKeys))]
        [RegularExpression("^[a-zA-Zء-ي ]*$", ErrorMessageResourceName = "VlaidFullNameMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "FullName", ResourceType = typeof(ModelsKeys))]
        public string FullName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MinLength(6, ErrorMessageResourceName = "Min6", ErrorMessageResourceType = typeof(ModelsKeys)), MaxLength(100, ErrorMessageResourceName = "Max100", ErrorMessageResourceType = typeof(ModelsKeys)),]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(ModelsKeys))]
        public string Password { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [EmailAddress(ErrorMessageResourceName = "ValidEmail", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "Email", ResourceType = typeof(ModelsKeys))]
        public string Email { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [EmailAddress(ErrorMessageResourceName = "ValidEmail", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "Email", ResourceType = typeof(ModelsKeys))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MinLength(6, ErrorMessageResourceName = "Min6", ErrorMessageResourceType = typeof(ModelsKeys)), MaxLength(100, ErrorMessageResourceName = "Max100", ErrorMessageResourceType = typeof(ModelsKeys)),]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(ModelsKeys))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword", ResourceType = typeof(ModelsKeys))]
        [Compare("Password", ErrorMessageResourceName = "ConfirmPasswordErrorMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }






















    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "Email", ResourceType = typeof(ModelsKeys))]
        public string Email { get; set; }
    }

}
