using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Nocturnal.Main.Loaders
{
     class Install
    {
        public static UnityEngine.Texture2D image;
        public static void onstartfiles()
        {
            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\Shaderslogged"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\Shaderslogged");
            }
            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Nocturnal"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Nocturnal");
            }
            if (!Directory.Exists($"{MelonUtils.GameDirectory}Nocturnal"))
            {
                Directory.CreateDirectory($"{Path.GetTempPath()}Nocturnal");
            }
            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\aseetbundles"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Nocturnal\\aseetbundles");
            }
            if (!Directory.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc"))
            {
                Directory.CreateDirectory($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc");
            }

            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\LoadingVid.mp4"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Media/loading.mp4", $"{MelonUtils.GameDirectory}\\Nocturnal\\LoadingVid.mp4");

            }
            if (!File.Exists($"{Path.GetTempPath()}Nocturnal\\dev.mp4"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Media/Obliterate.mp4", $"{Path.GetTempPath()}Nocturnal\\dev.mp4");

            }
            if (!File.Exists($"{Path.GetTempPath()}Nocturnal\\devF.mp4"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Media/Dark%20Aesthetics.mp4", $"{Path.GetTempPath()}Nocturnal\\devF.mp4");

            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\aseetbundles\\box"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/box", $"{MelonUtils.GameDirectory}\\Nocturnal\\aseetbundles\\box");

            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\CustomTag.txt"))
            {
                FileStream fs = File.Create($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\CustomTag.txt");
                byte[] author = new UTF8Encoding(true).GetBytes("");
                fs.Write(author, 0, author.Length);
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Loading screen music.mp3"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Media/Loading%20screen%20music.mp3", $"{MelonUtils.GameDirectory}\\Nocturnal\\Loading screen music.mp3");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Qmmusic.mp3"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Qmmusic.mp3", $"{MelonUtils.GameDirectory}\\Nocturnal\\Qmmusic.mp3");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\JoinSound.mp3"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Media/JoinSound.mp3", $"{MelonUtils.GameDirectory}\\Nocturnal\\JoinSound.mp3");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\WorldHistory.json"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/Assets/WorldHistory.json", $"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\WorldHistory.json");
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\Key.txt"))
            {
                FileStream fs = File.Create($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\Key.txt");
                byte[] author = new UTF8Encoding(true).GetBytes("");
                fs.Write(author, 0, author.Length);
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\Avatars.json"))
            {
                FileStream fs = File.Create($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\Avatars.json");
                byte[] author = new UTF8Encoding(true).GetBytes("");
                fs.Write(author, 0, author.Length);
                fs.Close();
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\StyleConfig.json"))
            {
              File.Create($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\StyleConfig.json").Close();
            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\Mainconfig.json"))
            {
                File.Create($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\Mainconfig.json").Close();

            }
            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\Password.txt"))
            {
                FileStream fs = File.Create($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\Password.txt");
                byte[] author = new UTF8Encoding(true).GetBytes("");
                fs.Write(author, 0, author.Length);
            }

            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\discord-rpc.dll"))
            {
                var wc = new WebClient();
                wc.DownloadFile("http://nocturnal-client.xyz/cl/Download/discord-rpc.dll", $"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\discord-rpc.dll");


            }
            var wcs = new WebClient();
           settings.Anticrash.Anti.shaderlistst = wcs.DownloadString("https://nocturnal-client.xyz/cl/anticrashshader.txt");

            if (!File.Exists($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\UserWhitelist.erp"))
            {
                File.Create($"{MelonUtils.GameDirectory}\\Nocturnal\\Misc\\UserWhitelist.erp").Close();

            }
        }




    }
    }
