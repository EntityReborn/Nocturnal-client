using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.SDKBase;

namespace Nocturnal.Wrappers
{
    public static class RPCS
    {
        public static GameObject eventahndeler;

        public static VRC_EventHandler.VrcEvent sendevent(string name)
        {


            var eventgmj = new VRC_EventHandler.VrcEvent()
            {
                EventType = VRC_EventHandler.VrcEventType.SendRPC,
                Name = "SendRPC",
                ParameterObject = eventahndeler.gameObject,
                ParameterInt = Extentions.LocalPlayer.field_Private_VRCPlayerApi_0.playerId,
                ParameterFloat = 0f,
                ParameterString = "UdonSyncRunProgramAsRPC",
                ParameterBoolOp = VRC_EventHandler.VrcBooleanOp.Unused,
                ParameterBytes = VRC.SDKBase.Networking.EncodeParameters(new Il2CppSystem.Object[] { name })
            };
            return eventgmj;
        }


    }
}
