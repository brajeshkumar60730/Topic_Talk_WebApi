namespace TopicTalks.Web.Configs
{
    internal static class SettingsFetcher
    {
        private static IConfiguration _configuration;

        public static void AddSettingFetcher(this WebApplicationBuilder builder)
        {
            _configuration = builder.Configuration;
        }

        public static string ApiBaseUrl => _configuration.GetValue<string>("ApiBaseUrl");

        public static string JwtKey => _configuration.GetValue<string>("Jwt:Key");
    }
}
