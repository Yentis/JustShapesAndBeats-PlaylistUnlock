using System;
using UnityEngine;

namespace Trainer
{
    public class Patches : MonoBehaviour
    {
        public Patches(IntPtr ptr) : base(ptr)
        {
            BepInExLoader.log.LogMessage("[PlaylistUnlock] Entered constructor");
        }

        public static void isUnlocked(ref bool __result)
        {
            __result = true;
        }
    }
}
