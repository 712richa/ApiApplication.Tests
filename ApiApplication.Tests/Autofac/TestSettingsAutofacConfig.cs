using ApiApplication.Tests.TestSettings;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace ApiApplication.Tests.Autofac
{
    public class TestSettingsAutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var rootDirectory = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());

            var configuration = new ConfigurationBuilder()
                    .AddJsonFile($"{Directory.GetCurrentDirectory()}/configs/config.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

            var urlSettings = new UrlSettings();
            configuration.GetSection("urls").Bind(urlSettings);
            builder.Register(c => urlSettings).AsSelf().SingleInstance();
        }
    }
}
