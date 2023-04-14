namespace Intex2Group22.Controllers
{
    public class AppSettingsConnection
    {
        public class MySettings
        {
            public ConnectionStringsSettings ConnectionStrings { get; set; }
        }

        public class ConnectionStringsSettings
        {
            public string DefaultConnection { get; set; }
        }
    }
}
