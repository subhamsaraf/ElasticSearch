using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using Elasticsearch.Net;

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
            //var connectionPool = new SingleNodeConnectionPool(node);
            settings=new ConnectionSettings(node).DefaultIndex("lucene_search");            
            client = new ElasticClient(settings);

            var postDocumenttest = new Postdocument { UserId = 456, PostDate = DateTime.Now, PostText = "Hey this is my first posted Document" };
            var indexRespose = client.Index(postDocumenttest);

            var searchRespose = client.Search<Postdocument>(s => s.From(0).Size(0)
            .Query(q => q.Match(m => m.Field(f => f.PostText)
            .Query("Hey this is my first posted Document"))));
            var documents = searchRespose.Documents;
        }
    }
}
