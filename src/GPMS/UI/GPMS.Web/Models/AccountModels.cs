﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace GPMS.Web.Models
{
    //public class UsersContext : DbContext
    //{
    //    public UsersContext()
    //        : base("DefaultConnection")
    //    {
    //    }

    //    public DbSet<UserProfile> UserProfiles { get; set; }
    //}

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class AccountBaseModel
    {
        [Required(ErrorMessage = @"*用户名必填字段")]
        [StringLength(18, ErrorMessage = @"{0}必须是{2}-{1}位字符", MinimumLength = 6)]
        [Display(Name = @"用户名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = @"*密码必填字段")]
        [StringLength(18, ErrorMessage = @"{0}必须是{2}-{1}位字符", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = @"密码")]
        public string Password { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少{2}-18位。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// 登录的model
    /// </summary>
    public class LoginModel : AccountBaseModel
    {
        [Display(Name = "记住我?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel:AccountBaseModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        [Required(ErrorMessage = "确认密码必填字段")]
        public string ConfirmPassword { get; set; }

         [Required(ErrorMessage = "邮箱地址必填字段")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "邮箱地址")]
        public string EmailAddress { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
