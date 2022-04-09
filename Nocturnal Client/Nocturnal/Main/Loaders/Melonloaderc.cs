using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using Nocturnal.Exploits;

namespace Nocturnal.Main
{
   public class Melonloaderc : MelonMod
    {
        
       public override void OnApplicationStart() => load.Start();
       public override void OnUpdate() => load.lateupdate();

       public override void OnGUI() => load.ongui();

        

    }


}

