using System;
using System.Web.Security;
using GPMS.Core.WebData.Resources;

namespace GPMS.Core.WebData
{
    public class WebSecurity
    {
        private static GpmsMembershipProvider VerifyProvider()
        {
            var provider = Membership.Provider as GpmsMembershipProvider;
            if (provider == null)
            {
                throw new InvalidOperationException(WebDataResources.Security_NoExtendedMembershipProvider);
            }
            return provider;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="failReason">失败原因</param>
        /// <param name="persistCookie">记住Cookie</param>
        /// <returns></returns>
        public static bool Login(string userName, string password, ref string failReason, bool persistCookie = false)
        {
            var membershipProvider = VerifyProvider();
            bool flag = membershipProvider.ValidateUser(userName, password, ref failReason);
            if (flag)
            {
                FormsAuthentication.SetAuthCookie(userName, persistCookie);
            }
            return flag;
        }

        public static bool ChangePassword(string p1, string p2, string p3)
        {
            throw new NotImplementedException();
        }

        public static void CreateUserAndAccount(string username, string password, string emailAddress)
        {
            var provider = VerifyProvider();
            provider.CreateUser(username, password, emailAddress);
        }

        public static void Logout()
        {
            VerifyProvider();
            FormsAuthentication.SignOut();
        }

        public static int GetUserId(string name)
        {
            throw new NotImplementedException();
        }
    }
}
