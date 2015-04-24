using System;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.WebPages;
using GPMS.Core.Entities;
using GPMS.Core.IServices;
using GPMS.Setting;

namespace GPMS.Core.WebData
{
    public class GpmsMembershipProvider : MembershipProvider
    {
        private const int TokenSizeInBytes = 16;
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        #region login
        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param> 
        /// <returns></returns>
        public override bool ValidateUser(string username, string password)
        {
            var failreason = string.Empty;
            return ValidateUser(username, password, ref failreason);
        }

        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="failreason">失败原因</param>
        /// <returns></returns>
        public bool ValidateUser(string username, string password, ref string failreason)
        {
            if (username.IsEmpty())
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "username");
            }
            if (password.IsEmpty())
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "password");
            }

            var userService = Ioc.Resolve<IUserService>();
            var user = userService.FindUserByName(username);

            if (user == null)
            {
                failreason = "用户名不正确。";
                return false;
            }

            if (VerifyUserIsAllowLogin(user, ref failreason))
            {
                var passwordIsVerified = CheckPassword(password, user, ref failreason);
                if (passwordIsVerified)
                {
                    user.LastLoginSuccessedDateTime = DateTime.Now;
                    userService.Update(user);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 验证用户是否确认,以及是否超过密码错误次数
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="failReason"></param>
        /// <returns>结果</returns>
        private bool VerifyUserIsAllowLogin(User user, ref string failReason)
        {
            if (user.IsConfirmed)
            {
                if (user.PasswordFailuresSinceLastSuccess >= PcSetting.PasswordErrorCount)
                {
                    if (user.LastPasswordFailureDate != null && user.LastPasswordFailureDate.Value.AddMinutes(PcSetting.PasswordErrorTimesapn).CompareTo(DateTime.Now) > 0)
                    {
                        TimeSpan timaSpan = user.LastPasswordFailureDate.Value.AddMinutes(PcSetting.PasswordErrorTimesapn).Subtract(DateTime.Now);
                        failReason = string.Format("失败次数超过{0}次，请{1}分钟后重试", PcSetting.PasswordErrorCount, timaSpan.Minutes + 1);
                        return false;
                    }
                    else
                    {
                        user.PasswordFailuresSinceLastSuccess = 0;
                        Ioc.Resolve<IUserService>().Update(user);
                        return true;
                    }

                }
                return true;
            }

            failReason = string.Format("账户没确认。");
            return false;
        }

        /// <summary>
        /// 验证密码，如果验收失败，更新失败次数,失败时间
        /// </summary>
        /// <param name="password"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool CheckPassword(string password, User user, ref string failReason)
        {
            bool verificationSucceeded = (user.Password != null && Crypto.VerifyHashedPassword(user.Password, password));
            if (verificationSucceeded)
            {
                user.PasswordFailuresSinceLastSuccess = 0;
            }
            else
            {
                if (user.PasswordFailuresSinceLastSuccess != -1)
                {
                    user.PasswordFailuresSinceLastSuccess = user.PasswordFailuresSinceLastSuccess + 1;
                    user.LastPasswordFailureDate = DateTime.Now;
                    failReason = string.Format("密码错误，你还有{0}次机会尝试！", PcSetting.PasswordErrorCount - user.PasswordFailuresSinceLastSuccess);
                    Ioc.Resolve<IUserService>().Update(user);
                }
            }

            return verificationSucceeded;
        }
        #endregion
        #region register
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="email">邮件地址</param>
        /// <param name="status">创建状态</param>
        /// <returns></returns>
        public bool CreateUser(string username, string password, string email)
        {
            if (username.IsEmpty())
            {
                throw new MembershipCreateUserException(MembershipCreateStatus.InvalidUserName);
            }
            if (password.IsEmpty())
            {
                throw new MembershipCreateUserException(MembershipCreateStatus.InvalidPassword);
            }
            if (email.IsEmpty())
            {
                throw new MembershipCreateUserException(MembershipCreateStatus.InvalidEmail);
            }

            var userService = Ioc.Resolve<IUserService>();
            var user = userService.FindUserByName(username);
            if (user == null)
            {
                //判断是否有存在此Email的用户
                var userByEamil = userService.GetEntityByAction(x => x.EmailAddress.Equals(email));
                if (userByEamil == null)
                {
                    user = new User
                    {
                        CreateDate = DateTime.Now,
                        EmailAddress = email,
                        UserName = username,
                        Password = GetHashedPassword(password),
                        ConfirmationToken = GenerateToken()
                    };
                    userService.Save(user);
                    return true;
                }
                else
                {
                    throw new MembershipCreateUserException(MembershipCreateStatus.DuplicateEmail);
                }
            }
            else
            {
                //不为空，证明存在用户名
                throw new MembershipCreateUserException(MembershipCreateStatus.DuplicateUserName);
            }
        }
        /// <summary>
        /// 获取加密的密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns>加密后的密码</returns>
        private string GetHashedPassword(string password)
        {
            if (password.IsEmpty())
            {
                throw new MembershipCreateUserException(MembershipCreateStatus.InvalidPassword);
            }
            var hashedPassword = Crypto.HashPassword(password);
            if (hashedPassword.Length > 128)
            {
                throw new MembershipCreateUserException(MembershipCreateStatus.InvalidPassword);
            }
            return hashedPassword;
        }
        /// <summary>
        /// 创建标识
        /// </summary>
        /// <returns></returns>
        private string GenerateToken()
        {
            using (var prng = new RNGCryptoServiceProvider())
            {
                var tokenBytes = new byte[TokenSizeInBytes];
                prng.GetBytes(tokenBytes);
                return HttpServerUtility.UrlTokenEncode(tokenBytes);
            }
        }

        #endregion


        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new System.NotImplementedException();
        }



        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new System.NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new System.NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new System.NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new System.NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new System.NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new System.NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new System.NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new System.NotImplementedException();
        }

    }
}
