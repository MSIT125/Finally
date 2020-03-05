using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebIndexHotel.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "姓")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "名")]
        public string FirstName { get; set; }

        
        [Display(Name = "身分證號碼(optional)")]
        public string PersonalID { get; set; }

        [Required]
        [Display(Name = "電話")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "生日")]
        public System.DateTime? BirthDate { get; set; }

        [Required]
        [Display(Name = "國家")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "地址")]
        public string Address { get; set; }
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
        [Display(Name = "代碼")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "記住此瀏覽器?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "電子郵件")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [Display(Name = "記住我?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼和確認密碼不相符。")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "姓")]
        public string FirstName { get;  set; }
        [Required]
        [Display(Name = "名")]
        public string LastName { get;  set; }
        
        [Display(Name = "身分證號碼(optional)")]
        public string PersonalID { get;  set; }
        [Required]
        [Display(Name = "電話")]
        public string PhoneNumber { get;  set; }
        [Required]
        [Display(Name = "生日")]
        public DateTime? BirthDate { get;  set; }
        [Required]
        [Display(Name = "國家")]
        public string Country { get;  set; }
        //drop down list
        //public System.Web.Mvc.SelectList CountryList { get; set; }
        [Required]
        [Display(Name = "地址")]
        public string Address { get;  set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 的長度至少必須為 {2} 個字元。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼和確認密碼不相符。")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }
    }
}
