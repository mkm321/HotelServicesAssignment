using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Filters;
using Cassandra;

namespace HotelApiService.Attribute
{
    public class LoggerAttribute : ResultFilterAttribute, IActionFilter
    {
        public static string request = "";
        public static string response = "";
        public static string comment = "";
        public static string exception = "";
        private static Object _lock = typeof(LoggerAttribute);

        public void OnActionExecuted(ActionExecutedContext context)
        {

            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("hotels");
            Guid guid = new Guid();
            var ps = session.Prepare("INSERT INTO logger (id,request, response,exception,comment) values(?,?,?,?,?)");
            var statement = ps.Bind(guid,request, response,exception,comment);
            session.Execute(statement);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
