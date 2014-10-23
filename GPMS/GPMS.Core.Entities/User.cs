using System;

namespace GPMS.Core.Entities
{
    public class User
    {
        public virtual long ID { get; set; }
        /// <summary>
        /// 登录用户名
        /// </summary>
        public virtual string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public virtual Sex Sex { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public virtual string FirstName { get; set; }
        /// <summary>
        /// 姓氏
        /// </summary>
        public virtual string LastName { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public virtual string EmailAddress { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateDate { get; set; }
        /// <summary>
        /// 确认码
        /// </summary>
        public virtual string ConfirmationToken { get; set; }
        /// <summary>
        /// 是否确认
        /// </summary>
        public virtual bool IsConfirmed { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        public virtual DateTime? LastLoginSuccessedDateTime { get; set; }
        /// <summary>
        /// 密码失败次数距离上次成功
        /// </summary>
        public virtual int PasswordFailuresSinceLastSuccess { get; set; }
        /// <summary>
        /// 上次密码失败时间
        /// </summary>
        public virtual DateTime? LastPasswordFailureDate { get; set; }
        /// <summary>
        /// 修改密码时间
        /// </summary>
        public virtual DateTime? PasswordChangedDate { get; set; }
    }
}
