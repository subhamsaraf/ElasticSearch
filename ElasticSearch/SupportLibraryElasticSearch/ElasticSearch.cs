using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace SupportLibraryElasticSearch
{
    public class ElasticSearch
    {
        private ElasticClient _client;

        public ElasticClient Client
        {
            get { return _client; }
            set { _client = value; }
        }
        public ElasticSearch(ElasticClient client)
        {
            _client = client;
        }
        public void SearchResult()
        {
            var searchRespose = _client.Search<Postdocument>(s => s.From(0).Size(10)
           .Query(q => q.Match(m => m.Field(f => f.PostText)
           .Query("This is"))));
            var documents = searchRespose.Documents;
            foreach (var document in documents)
            {
                Console.WriteLine($" Date posted is : {document.PostDate} User ID : {document.UserId}  POst Text = {document.PostText}");
            }
        }


        public string CreateIndex()
        {
            Console.WriteLine("Enter the User ID");
            var userid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Text You want to Enter");
            var text = Console.ReadLine();
            var postDocumenttest = new Postdocument { UserId = userid, PostDate = DateTime.Now, PostText = text };
            var indexRespose = _client.Index(postDocumenttest);
            return "Index Created";
        }
    }
}
