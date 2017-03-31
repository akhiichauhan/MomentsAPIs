using System.Web.Http;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Moments.Host
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            SetAppDependencyInjection();
            SetAppFilters(config);
            //config.MessageHandlers.Add(new MonitoringDelegate());

            config.Formatters.Clear();
            config.Formatters.Insert(0, new JsonNetTextFormatter());
        }

        private static void SetAppDependencyInjection()
        {
            var serializerSettings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });

            var locatorProvider = new StructureMapServiceLocator(StructureMapContainerProvider.GetContainer());
            ServiceLocator.SetLocatorProvider(() => locatorProvider);
        }

        private static void SetAppFilters(HttpConfiguration config)
        {
            Metering.Initialize(Constants.App);
            //TODO: Merge 2 contexts 
            config.MessageHandlers.Add(new ActionContextHandler(Constants.ApplicationName));
            config.MessageHandlers.Add(new MarkupCallContextInjector());
            config.MessageHandlers.Add(new ProfilerInjector(ServiceLocator.Current.GetInstance<ILogManager>()));
            config.Filters.Add(new LogActionFilterAttribute());
            config.Filters.Add(new ExceptionResponseFilterAttribute());
            config.Filters.Add(new LogExceptionFilterAttribute());
        }
    }
}