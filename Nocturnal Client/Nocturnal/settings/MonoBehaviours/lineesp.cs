using MelonLoader;
using System.Collections;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;
using VRC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Nocturnal.settings.MonoBehaviours
{
    class linerenderer : MonoBehaviour
    {

        public linerenderer(IntPtr ptr) : base(ptr)
        {
        }
        void Start()
        {
            var negmj = new GameObject();
            negmj.transform.parent = gameObject.transform;
            negmj.transform.position = new Vector3(0, 0.1f, 0);
            negmj.name = "Line";
            negmj.layer = 19;
            string emptystirng = "";
            Color espcolor = Color.white;
            var islinerend = negmj.AddComponent<LineRenderer>();
            islinerend.startWidth = 0.001f;
            islinerend.endWidth = 0.001f;
            islinerend.startColor = Color.white;
            islinerend.endColor = Color.white;
            var materials = islinerend.material = new Material(Shader.Find("Standard"));
            materials.EnableKeyword("_EMISSION");
            Wrappers.check_ranks.gettrsutrank(gameObject.GetComponent<VRC.Player>().field_Private_APIUser_0, ref emptystirng, ref espcolor);
            materials.color = Color.black;
            materials.SetColor("_EmissionColor", espcolor);
            InvokeRepeating("Updatelines", 0.0f, 0.01f);

        }

        void Updatelines()
        {

            try
            {
                gameObject.transform.Find("Line").GetComponent<LineRenderer>().SetPosition(0, GameObject.Find("Camera (eye)").transform.position - new Vector3(0, 0.1f, 0));
                gameObject.transform.Find("Line").GetComponent<LineRenderer>().SetPosition(1, gameObject.transform.position + new Vector3(0, 0.1f, 0));
            }
            catch { }

        }




    }
}
