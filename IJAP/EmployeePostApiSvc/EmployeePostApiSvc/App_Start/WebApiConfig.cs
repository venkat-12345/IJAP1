using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EmployeePostApiSvc
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            ListenForIntegrationEvents()

            // Web API routes
            config.MapHttpAttributeRoutes();



            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
        private static void ListenForIntegrationEvents()
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (mode, ea) => {
                var contextOptions = new DbContextOptionsBuilder<StudentDBContext>().UseNpgsql(@"Server=localhost; Database=EmpPostDB; user id=postgres; password=root").Options;
                var dbContext = new StudentDBContext(contextOptions);
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var data = JObject.Parse(message);
                var type = ea.RoutingKey;
                if (type == "jobpost.add")
                {
                    dbContext.EmpPost.Add(new EmpPost() { PostId = data["PostId"].Value<string>() });
                    dbContext.SaveChanges();
                }
            };
        }
}
