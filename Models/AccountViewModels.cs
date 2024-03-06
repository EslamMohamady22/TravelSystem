using Microsoft.Owin.Security.DataHandler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
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
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "UserName ")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password ")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        
    }

    public class RegisterViewModel
    {
        
        
        public int Id { get; set; }

        [Required]
        [Display(Name ="UserName ")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "FirstName ")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName ")]
        public string LastName { get; set; }

        
        [Display(Name = "UserImage")]
        public string UserImage { get; set; }


        [Required]
        [Display(Name = "PhoneNamper")]
        public string PhoneNumber { get; set; }



        [Required]
        [Display(Name = "Account Type ")]
        public string UserType { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email ")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repeat Password ")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AdminRegisterViewModel
    {


        public int Id { get; set; }

        [Required]
        [Display(Name = "UserName ")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "FirstName ")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName ")]
        public string LastName { get; set; }


        [Display(Name = "UserImage")]
        public string UserImage { get; set; }


        [Required]
        [Display(Name = "PhoneNamper")]
        public string PhoneNumber { get; set; }



        [Required]
        [Display(Name = "Account Type ")]
        public string UserType { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email ")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repeat Password ")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }



    public class EditProfileViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Phone Numper")]
        public string PhoneNumper { get; set; }

        [Required]
        [Display(Name = "User Type")]
        public string UserType { get; set; }


        [Display(Name = "UserImage")]
        public string UserImage { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Add Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "كلمات السر المدخلة غير متوافقة، رجاء قم بالتصحيح")]
        public string ConfirmPassword { get; set; }
    }









    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
