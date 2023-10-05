namespace ReactApp.Helper
{
    public class AppSettings
    {
        public Other Other { get; set; }
        public Email Email { get; set; }
    }

    public class Other
    {
        public string Test { get; set; }
        
    }
    public class Email
    {
        public string Smtp { get; set; }

    }

}
