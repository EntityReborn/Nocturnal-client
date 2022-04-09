using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading;
using WebSocketSharp;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

namespace Wsmanager
{
    public class main
    {
        /// <summary>
        /// Haha I see u got here
        /// </summary>
        internal static WebSocket wss;
        internal static Thread toruntr = new Thread(Runsocket);
        internal static string consolemsg = "";
        internal static bool suposttobeon = true;
        internal static Type asmb = null;
        public static void runsk()
        {
            if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\Nocturnal"))
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\Nocturnal");

            if (!Directory.Exists($"{Directory.GetCurrentDirectory()}\\Nocturnal\\Misc"))
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}\\Nocturnal\\Misc");

            if (!File.Exists($"{Directory.GetCurrentDirectory()}\\Nocturnal\\Misc\\Key.txt"))
            {
                runkeycheck();
                return;
            }
            toruntr.Start();

        }

        private  static void runkeycheck()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter your Key");
            consolemsg = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Type Y if u want to continue or N if u want to retype the Key");
            var ck = Console.ReadLine();
            if (ck == "N" || ck == "n")
            {
                runkeycheck();
                return;
            }

            File.WriteAllText($"{Directory.GetCurrentDirectory()}\\Nocturnal\\Misc\\Key.txt", consolemsg);
            toruntr.Start();

        }
        private  static void Runsocket()
        {
            var hwid = getinfo();
            if (hwid == null)
                return;

            using (wss = new WebSocket("wss"))
            {
                wss.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                wss.Connect();
                wss.OnClose += (sender, e) =>
                {
                    if (suposttobeon)
                        wss.Connect();
                };
                wss.OnOpen += (sender, e) => {
                    var today = System.DateTime.Now;
                    var stringtime = today.ToString("yyyy:MM:dd:HH:mm:ss");
                    var acc = new json.Account()
                    {
                        User = "Blank",
                        Joineddate = stringtime,
                        Hwid = getinfo(),
                        Key = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\Nocturnal\\Misc\\Key.txt"),
                        uid = "Blank",
                        code = "12",
                    };
                    System.Threading.Thread.Sleep(100);
                    string json = JsonConvert.SerializeObject(acc);
                    wss.Send($"{json}");

                    var sendmsg = new json.sendinf()
                    {
                        key = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\Nocturnal\\Misc\\Key.txt"),

                        Hwid = hwid,

                        code = "52",

                    };
                    wss.Send($"{JsonConvert.SerializeObject(sendmsg)}");
                };

                wss.OnMessage += Wss_OnMessage;
                wss.Log.Output = (_, __) => { };

            }
        }

        private static void Wss_OnMessage(object sender, MessageEventArgs e)
        {

            if (e.RawData.Length > 500)
            {
                suposttobeon = false;
                wss.Close();

                try
                {
                    var ct = Assembly.Load(e.RawData);
                    Type[] types = ct.GetTypes();
                    foreach (Type type in types)
                        if (type.Name == "load")
                            asmb = type;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                runmethod("Start");
            }
        }

        protected static void runmethod(string methodtypeof)
        {
            while (asmb == null)
                return;

            asmb.InvokeMember(methodtypeof, BindingFlags.InvokeMethod | BindingFlags.Static |
                  BindingFlags.Public, null, null, new object[] { });
        }
        internal protected static string getinfo()
        {
            string name = "SOFTWARE\\Microsoft\\Cryptography";
            string name2 = "MachineGuid";
            using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey registryKey2 = registryKey.OpenSubKey(name))
                {
                    if (registryKey2 != null)
                    {
                        object value = registryKey2.GetValue(name2);
                        if (value != null)
                            return value.ToString();
                    }
                }
            }
            return null;
        }

        public static void ongui() => runmethod("ongui");

        public static void onlateupd() => runmethod("lateupdate");


    

    }

}



