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
            //Console.WriteLine(_logEntry.RespondTime);
            //Console.WriteLine(_logEntry.RequestTime);
            //Console.WriteLine(_logEntry.RequestType);
            //Console.WriteLine(_logEntry.IPAddress);
            var logResponse = _client.Index(_logEntry);
            _client.Index<LogEntry>(_logEntry, i => i.Index("elasticsearch_log").Type("logentry").Id(_logEntry.ID));
            //SearchLogIndex();
        }
        public void SearchLogIndex()
        {
            var searchRespose = _client.Search<LogEntry>(s => s.From(0).Size(10).Index("elasticsearch_log").Type("logentry")
           .Query(q => q.Match(m => m.Field(f => f.RequestType)
           .Query("Searched "))));
            var documents = searchRespose.Documents;
            foreach (var document in documents)
            {
                Console.WriteLine($"User {document.RequestType} on {document.RequestTime} and got the response in {document.RespondTime} milliseconds. Users Ip is {document.IPAddress}");
            }
        }

    }
}
