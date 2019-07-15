using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;
using System.Net.Http.Headers;

namespace AuthorBook
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Authors Web API

            // Get One Author 
            config.Routes.MapHttpRoute(
          name: "getAuthorList",
          routeTemplate: "api/AuthorAPI/GetAuthorList/{AuthorID}",
          defaults: new { controller = "AuthorAPI", action = "GetAuthorList" },
              constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
          );

            // Get All Authors
            config.Routes.MapHttpRoute(
           name: "getAllAuthor",
           routeTemplate: "api/AuthorAPI/getAllAuthor/",
           defaults: new { controller = "AuthorAPI", action = "getAllAuthor" },
               constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
           );



            // Delete Authors
            config.Routes.MapHttpRoute(
              name: "deleteAuthor",
              routeTemplate: "api/AuthorApi/DeleteAuthor/{ID}",
              defaults: new { controller = "AuthorApi", action = "DeleteAuthor" },
              constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
             );


            // Create New Author
            config.Routes.MapHttpRoute(
              name: "postNewAuthor",
              routeTemplate: "api/AuthorApi/PostNewAuthor/",
              defaults: new { controller = "AuthorApi", action = "PostNewAuthor" },
              constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
             );


            // Edit Author
            config.Routes.MapHttpRoute(
             name: "putAuthor",
             routeTemplate: "api/AuthorApi/PutAuthor/",
             defaults: new { controller = "AuthorApi", action = "PutAuthor" },
             constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );


            // Book Web API

            // Get One Book
            config.Routes.MapHttpRoute(
          name: "getBookList",
          routeTemplate: "api/BookAPI/GetBookList/{ID}",
          defaults: new { controller = "BookAPI", action = "GetBookList" },
              constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
          );

            // Get All Books
            config.Routes.MapHttpRoute(
           name: "getAllBook",
           routeTemplate: "api/BookAPI/getAllBook/",
           defaults: new { controller = "BookAPI", action = "getAllBook" },
               constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
           );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/Json"));
        }
    }
}
