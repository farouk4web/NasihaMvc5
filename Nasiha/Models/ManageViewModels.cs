using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Nasiha.Resources;

namespace Nasiha.Models
{

    // classes we are used on this app
    public class EditProfile
    {
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MinLength(4, ErrorMessageResourceName = "Min4", ErrorMessageResourceType = typeof(ModelsKeys)), MaxLength(50, ErrorMessageResourceName = "Max50", ErrorMessageResourceType = typeof(ModelsKeys)),]
        [RegularExpression("^[a-zA-Zء-ي ]*$", ErrorMessageResourceName = "VlaidFullNameMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "FullName", ResourceType = typeof(ModelsKeys))]
        public string FullName { get; set; }

        //[UniqueNickname]
        //[Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        //[MinLength(4, ErrorMessageResourceName = "Min4", ErrorMessageResourceType = typeof(ModelsKeys)), MaxLength(50, ErrorMessageResourceName = "Max50", ErrorMessageResourceType = typeof(ModelsKeys)),]
        //[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessageResourceName = "VlaidUserNameMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        //[Display(Name = "Nickname", ResourceType = typeof(ModelsKeys))]
        //public string Nickname { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [DataType(DataType.Password)]
        [Display(Name = "CurrentPassword", ResourceType = typeof(ModelsKeys))]
        public string OldPassword { get; set; }

        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessageResourceName = "Min6", ErrorMessageResourceType = typeof(ModelsKeys)), MaxLength(100, ErrorMessageResourceName = "Max100", ErrorMessageResourceType = typeof(ModelsKeys)),]
        [Display(Name = "NewPassword", ResourceType = typeof(ModelsKeys))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword", ResourceType = typeof(ModelsKeys))]
        [Compare("NewPassword", ErrorMessageResourceName = "ConfirmPasswordErrorMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        public string ConfirmPassword { get; set; }
    }



















    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}