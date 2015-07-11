using System;

namespace GPMS.Core.Entities
{
    public sealed class UserBasicInfo : BaseEntity<Guid>
    { 
        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 姓氏
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string EmailAddress { get; set; } 
        /// <summary>
        /// 确认码
        /// </summary>
        public string ConfirmationToken { get; set; }
        /// <summary>
        /// 是否确认
        /// </summary>
        public bool IsConfirmed { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime? LastLoginSuccessedDateTime { get; set; }
        /// <summary>
        /// 密码失败次数距离上次成功
        /// </summary>
        public int PasswordFailuresSinceLastSuccess { get; set; }
        /// <summary>
        /// 上次密码失败时间
        /// </summary>
        public DateTime? LastPasswordFailureDate { get; set; }
        /// <summary>
        /// 修改密码时间
        /// </summary>
        public DateTime? PasswordChangedDate { get; set; }
    }
}
