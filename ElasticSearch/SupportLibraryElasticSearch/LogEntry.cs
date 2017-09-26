using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SupportLibraryElasticSearch
{
    public class LogEntry
    {
        private DateTime _requestTime;

        public DateTime RequestTime
        {
            get { return _requestTime; }
            set { _requestTime = value; }
        }

        private string _requestType;

        public string RequestType
        {
            get { return _requestType; }
            set { _requestType = value; }
        }
        private TimeSpan _respondTime;

        public TimeSpan RespondTime
        {
            get { return _respondTime; }
            set { _respondTime = value; }
        }
        private string _ipAdress;

        public string IPAddress
        {
            get { return _ipAdress; }
            set { _ipAdress = value; }
        }

    }
}
