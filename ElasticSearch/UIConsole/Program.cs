using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Elasticsearch.Net;
using SupportLibraryElasticSearch;

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

            //Console.WriteLine(elasticSearch.CreateIndex());

            var documents = elasticSearch.SearchResult();
            foreach (var document in documents)
            {
                Console.WriteLine($" Date posted is : {document.PostDate} User ID : {document.UserId}  POst Text = {document.PostText}");
            }
            Console.ReadKey(true);
        }


    }
}
