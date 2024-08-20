namespace Menu.Infrastructure
{
    using Microsoft.Extensions.Configuration;
    public static class ConfigurationLoader
    {
        public static IConfigurationRoot LoadConfiguration()
    {
        var basePath = Path.GetDirectoryName(typeof(ConfigurationLoader).Assembly.Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        return builder.Build();
    }
    }
}