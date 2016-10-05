using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiExample.Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            ConfigureMessageFormat(config);
            ConfigureCORS(config);
        }

        private static void ConfigureMessageFormat(HttpConfiguration config)
        {
            var formatter = config.Formatters.JsonFormatter;
            formatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();   // Use camel case
            formatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;              // Ignore circular references
        }

        private static void ConfigureCORS(HttpConfiguration config)
        {
            EnableCorsAttribute corsAttribute = new EnableCorsAttribute("http://webapiexample.com", "*", "GET,POST,DELETE,PUT");
            config.EnableCors(corsAttribute);
        }
    }
}