﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal;
using MelonLoader;
using UnityEngine;
namespace Nocturnal.Main.Loaders
{
    public class misc
    {
        public static GameObject animator;
        public static void Load()
        {
            Style.Consoles.consolelogger("Loading Client User interface");
            MelonCoroutines.Start(Apis.AssetBundles.loadbundle());

            //Join Logger

        }
    }
}
