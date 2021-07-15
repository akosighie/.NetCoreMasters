using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMasters.Keys
{
    public class Authentication
    {
        public JWT jwt { get; set; }
    }

    public class JWT
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
