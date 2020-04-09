namespace WebAPI.Helpers
{
    public static class AppSettings
    {
        public static readonly string ClientId = Startup.Configuration["ClientId"];
        public static readonly string ClientSecret = Startup.Configuration["ClientSecret"];
    }
}