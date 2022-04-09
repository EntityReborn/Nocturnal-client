using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Apis.Desktopui;
using MelonLoader;
using UnityEngine;
namespace Nocturnal.Main
{
     class desktopui
    {
        public static void setupui()
        {
            if (!settings.nconfig.DESKTOPUI) return;
            var mainmenu = Main_page.gamemenu();
            SubPage.Createsubmenu("Main Page",true, mainmenu);
        }
    }
}
