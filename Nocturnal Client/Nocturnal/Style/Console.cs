using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
namespace Nocturnal.Style
{
    public class Consoles
    {
       private static string aa0 = "" +
             "\n                    [ N O C T U R N A L ]\n" +
             "=-----------------------------------------------------------=\n" +
             "                                                            \n" +
             "                     >fT*=?Y;  yM*7!7*&W                    \n" +
             "                   z*       *LF        ?@                   \n" +
             "                  4          A          ]$                  \n" +
             "                  $                      T                  \n" +
             "                  ]                     ,L                  \n" +
             "                   L                    &                   \n" +
             "                    L                 zVC                   \n" +
             "                     Y              ,FaC                    \n" +
             "                      `Y           FyF                      \n" +
             "                         *;      /y*                        \n" +
             "                           *Y, ,AC                          \n" +
             "                              *`                           \n\n" +
             "=-----------------------------------------------------------=\n";



        private static string aa1 = "" +
             "\n                    [ N O C T U R N A L ]\n" +
             "=-----------------------------------------------------------=\n" +
             "                                                            \n" +
             "                     >@*[!7*$w   ;gm44gw                    \n" +
             "                   ;&C       T  A7      *N                  \n" +
             "                   D\"       / F         ]L                 \n" +
             "                  p[        JL]C         ]B                \n" +
             "                  Lb         `V$         N[                \n" +
             "                  ]?L          T       ,M1                  \n" +
             "                   ]/L                /*A`                  \n" +
             "                    `Y*             ,F;F                    \n" +
             "                      ^W&w         4)M`                     \n" +
             "                         *uN,    MaF                        \n" +
             "                           *YC$&*=                          \n\n" +
             "=-----------------------------------------------------------=\n";


        private static string aa2 = "" +
           "\n                    [ N O C T U R N A L ]\n" +
           "=-----------------------------------------------------------=\n" +
           "                                                            \n" +
           "                    z$M*|*T&g   F}``\"]7*w                   \n" +
           "                   E=      +^  F        \"$                  \n" +
           "                  ]=       f  `m         [L                 \n" +
           "                  jr        ?y  W        HL                 \n" +
           "                   &        A? a*       FA                  \n" +
           "                   ]&     zC aC        F]\\                  \n" +
           "                    `&   *U &        a*zC                   \n" +
           "                      *;  J $      yC,P`                    \n" +
           "                       `\\M;\\$    z*yM\"                      \n" +
           "                         `V*C  ;54C                         \n" +
           "                           ?w&*7                            \n" +
           "=-----------------------------------------------------------=\n";

        private static string aa3 = "" +
         "\n                    [ N O C T U R N A L ]\n" +
         "=-----------------------------------------------------------=\n" +
         "                                                            \n" +
         "                   yf*;    ?$B    gF    *N                  \n" +
         "                 ,C        ;$L  ,P`       *.                \n" +
         "                 L         $\\  2F          P                \n" +
         "                ]w        $|  4L          )M                \n" +
         "                `N         f,  Tw        ,F                \n" +
         "                 *$         1`  Z       aC                 \n" +
         "                  `&;      +\\  F      ,F                     \n" +
         "                    ?W    &  g*     ,M`                     \n" +
         "                      *Y; Jb `L   x*                        \n" +
         "                         7N&` ],e[                          \n" +
         "                               \\                            \n\n" +
         "=-----------------------------------------------------------=\n";


        public static IEnumerator consolemsg()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Clear();
            Console.WriteLine(aa0);
            yield return new WaitForSeconds(0.3f);
            System.Console.Clear();
            Console.WriteLine(aa1);
            yield return new WaitForSeconds(0.3f);
            System.Console.Clear();
            Console.WriteLine(aa2);
            yield return new WaitForSeconds(0.3f);
            System.Console.Clear();
            Console.WriteLine(aa3);

            yield return null;    
        }

        internal static void consolelogger(string message,bool value = true)
        {
            if (!value) return;
                var today = System.DateTime.Now;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"[{today.ToString("HH:mm:ss")}]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($":");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"[ N O C T U R N A L ] ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(message);
                Console.WriteLine();
            
        }
    }
}
