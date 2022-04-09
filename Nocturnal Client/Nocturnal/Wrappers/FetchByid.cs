using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
namespace Nocturnal.Wrappers
{
    class FetchByid
    {
        public static VRC.Core.APIUser fetchbyid(string id)
        {
            VRC.Core.APIUser usr = null;
            VRC.Core.APIUser.FetchUser(id, new Action<VRC.Core.APIUser>((a) => { usr = a; }), new Action<string>((a) => { Style.Consoles.consolelogger(a); }));
            return usr;
        }
    }
}
