using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace WebApiExample.Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            CondigureMessageFormat(config);
        }

        private static void CondigureMessageFormat(HttpConfiguration config)
        {
            var formatter = config.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();   // Use camel case
            formatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;              // Ignore circular references
        }
    }
}