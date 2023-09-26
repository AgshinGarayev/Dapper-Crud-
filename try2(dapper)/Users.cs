using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace try2_dapper_
{
    internal class Users
    {
        public int user_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public DateTime join_date { get; set; }
    }
}
