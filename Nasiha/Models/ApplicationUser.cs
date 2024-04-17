using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Nasiha.Resources;

namespace Nasiha.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MinLength(4, ErrorMessageResourceName = "Min4", ErrorMessageResourceType = typeof(ModelsKeys)), MaxLength(50, ErrorMessageResourceName = "Max50", ErrorMessageResourceType = typeof(ModelsKeys))]
        [RegularExpression("^[a-zA-Zء-ي ]*$", ErrorMessageResourceName = "VlaidFullNameMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "FullName", ResourceType = typeof(ModelsKeys))]
        public string FullName { get; set; }

        //[UniqueNickname]
        [Required(ErrorMessageResourceName = "RequiredMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [MinLength(4, ErrorMessageResourceName = "Min4", ErrorMessageResourceType = typeof(ModelsKeys)), MaxLength(50, ErrorMessageResourceName = "Max50", ErrorMessageResourceType = typeof(ModelsKeys))]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessageResourceName = "VlaidUserNameMsg", ErrorMessageResourceType = typeof(ModelsKeys))]
        [Display(Name = "Nickname", ResourceType = typeof(ModelsKeys))]
        public string Nickname { get; set; }

        public string ProfileImageSrc { get; set; }


        public virtual ICollection<Advice> Advices { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}