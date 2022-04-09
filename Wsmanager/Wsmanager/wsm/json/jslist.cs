using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Wsmanager.json
{
    [Serializable]
     class sendinf
    {
        public string key { get; set; }
        public string Hwid { get; set; }
        public string code { get; set; }

    }

    public class Account
    {
        public string User { get; set; }
        public string Joineddate { get; set; }
        public string Hwid { get; set; }
        public string Key { get; set; }
        public string uid { get; set; }
        public string code { get; set; }

    }
}
