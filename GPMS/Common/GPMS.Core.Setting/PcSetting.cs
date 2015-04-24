
namespace GPMS.Setting
{
    public class PcSetting
    {
        private static readonly int _passwordErrorCount;
        private static readonly int _passwordErrorTimesapn;
        static PcSetting()
        {
        }

        public static string CarouselBasePath
        {
            get { return string.Format(System.Configuration.ConfigurationManager.AppSettings["carouselBasePath"]); }
        }

        public static string LogoBasePath
        {
            get { return string.Format(System.Configuration.ConfigurationManager.AppSettings["LogoBasePath"]); }
        }

        public static string UpLoadPicDir
        {
            get { return string.Format(System.Configuration.ConfigurationManager.AppSettings["LogoBasePath"]); }
        }

        public static int PasswordErrorCount
        {
            get { return _passwordErrorCount; }
        }
        public static int PasswordErrorTimesapn
        {
            get { return _passwordErrorTimesapn; }
        }
    }
}
