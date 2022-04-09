using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Nocturnal.Apis.Desktopui
{
     class Main_page
    {
        public static GameObject menu;
        public static GameObject gamemenu()
        {
           

            var handler = GameObject.Instantiate(GameObject.Find("/UserInterface").transform.Find("MenuContent"), GameObject.Find("/UserInterface").transform);
            handler.name = "DesktopUImanager";
           foreach (var acc in handler.GetComponentsInChildren<RectTransform>(true))
            {
                try
                {
                    if (acc.name != "DesktopUImanager")
                    GameObject.DestroyImmediate(acc.gameObject);
                }
                catch { }
            }

            var a =  GameObject.Instantiate(GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Background").gameObject, handler.transform);
            a.transform.localScale = new Vector3(1, 1, 1);
            a.transform.localRotation = new Quaternion(0, 0, 0, 0);
            a.transform.localPosition = new Vector3(0, 0, 0);

            var img = a.GetComponent<UnityEngine.UI.Image>();
            img.sprite = null;
            img.color = new Color(0, 0, 0, 0.7f);
            menu = handler.gameObject;
            menu.SetActive(false);
            a.gameObject.SetActive(true);
            a.gameObject.transform.localPosition = new Vector3(0, 0, 650);
            Component.DestroyImmediate(handler.gameObject.GetComponent<UnityEngine.BoxCollider>());
            return handler.gameObject;
        }


    }
}
