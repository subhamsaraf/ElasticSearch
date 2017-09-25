using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIConsole
{
    public class Postdocument
    {

        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _postText;

        public string PostText
        {
            get { return _postText; }
            set { _postText = value; }
        }

        private DateTime dateTime;

        public DateTime PostDate
        {
            get { return dateTime; }
            set { dateTime = value; }
        }


    }
}
