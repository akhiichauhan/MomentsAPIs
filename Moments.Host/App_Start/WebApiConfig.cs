﻿using System.Web.Http;
using System.Web.Http.Cors;
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
            //config.EnableCors();
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);
            config.Formatters.Clear();
            config.Formatters.Insert(0, new JsonNetTextFormatter());
        }

        private static void SetAppDependencyInjection()
        {
            var serializerSettings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
        }
        
    }
}