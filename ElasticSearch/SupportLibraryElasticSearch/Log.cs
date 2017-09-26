using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace SupportLibraryElasticSearch
{
    public class Log
    {
        private ElasticClient _client;
        private LogEntry _logEntry;
        public Log(LogEntry logEntry, ElasticClient client)
        {
            _client = client;
            _logEntry = logEntry;             
        }
        public void CreateLogIndex()
        {
            _client.CreateIndex("elasticsearch_log");
            Console.WriteLine(_logEntry.RespondTime);
            Console.WriteLine(_logEntry.RequestTime);
            Console.WriteLine(_logEntry.RequestType);
            Console.WriteLine(_logEntry.IPAddress);
            var logResponse = _client.Index(_logEntry);
            _client.Index<LogEntry>(_logEntry, i => i.Index("elasticsearch_log"));
            //Console.WriteLine("Enter the User ID");
            //var userid = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter the Text You want to Enter");
            //var text = Console.ReadLine();
            //var postDocumenttest = new Postdocument { UserId = userid, PostDate = DateTime.Now, PostText = text };
            //var indexRespose = _client.Index(postDocumenttest);
            //return "Index Created";
        }
    }
}
