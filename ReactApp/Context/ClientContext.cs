namespace ReactApp.Context
{
    public class ClientContext
    {
        private ApplicationContext Ctx { get; set; }
        //private UserProfileClient UserProfile { get; set; }
        public ClientContext()
        {

        }
        public ClientContext(ApplicationContext ctx)
        {
            Ctx = ctx;
        }
    }
}
