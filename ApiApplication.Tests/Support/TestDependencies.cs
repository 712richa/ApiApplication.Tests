using ApiApplication.Tests.Autofac;
using Autofac;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace ApiApplication.Tests.Support
{
    public class TestDependencies
    {
        [ScenarioDependencies]
        public static ContainerBuilder Container()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new TestSettingsAutofacConfig());

            builder.RegisterTypes(typeof(TestDependencies).Assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))).ToArray()).SingleInstance();

            builder.RegisterType<TestContext>().AsSelf().InstancePerDependency();

            builder.RegisterType <HttpClientHelper>().AsSelf().SingleInstance();

            return builder;
        }
    }
}
