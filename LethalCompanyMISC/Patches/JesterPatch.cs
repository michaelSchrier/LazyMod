using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using LethalCompanyMISC;

namespace LethalCompanyMISC.Patches
{
    [HarmonyPatch(typeof(JesterAI))]
    internal class JesterPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void JesterStart(JesterAI __instance)
        {
            __instance.popGoesTheWeaselTheme = MISCModBase.Instance.UltraInstinctClip;           
        }
    }
}
