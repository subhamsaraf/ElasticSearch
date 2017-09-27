using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Elasticsearch.Net;
using SupportLibraryElasticSearch;
using System.Diagnostics;
using System.Net;

namespace UIConsole
{
    class Program
    {
        public static Uri node;
        public static ConnectionSettings settings;
        public static ElasticClient client;

        static void Main(string[] args)
        {
            node = new Uri("http://172.16.14.205:9200");
            settings = new ConnectionSettings(node).DefaultIndex("refactored_search");
            client = new ElasticClient(settings);
            var elasticSearch = new ElasticSearch(client);
            LogEntry logEntry = new LogEntry();
            

            Console.WriteLine("Enter the choice, what do you wanna perform , 1 to create index, 2 to search index");
            logEntry.RequestTime = DateTime.Now;
            string hostName = Dns.GetHostName();
            logEntry.IPAddress = Dns.GetHostEntry(hostName).AddressList[1].ToString();
            logEntry.ID = Guid.NewGuid().ToString();
            var choice = Console.ReadLine();


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            if (choice == "1")
            {
                Console.WriteLine(elasticSearch.CreateIndex());
                stopwatch.Stop();
                logEntry.RequestType = "Created Request";
            }
            else if(choice == "2")
            {
                elasticSearch.SearchResult();
                stopwatch.Stop();
                logEntry.RequestType = "Searched for a Request";
            }
            

            logEntry.RespondTime = stopwatch.Elapsed;

            Log log = new Log(logEntry, client);

            log.CreateLogIndex();
            Console.Clear();
            log.SearchLogIndex();
            Console.ReadKey(true);
        }




    }
}
