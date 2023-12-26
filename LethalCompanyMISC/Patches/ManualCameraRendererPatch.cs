using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using LethalCompanyMISC;

namespace LethalCompanyMISC.Patches
{
    [HarmonyPatch(typeof(ManualCameraRenderer))]
    internal class ManualCameraRendererPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void ManualCameraRendererStart(ManualCameraRenderer __instance)
        {
            if (__instance.gameObject.name != "CameraMonitorScript")
                return;

            //MISCModBase.Instance.PublicLogger.LogInfo($"DISPLAYING MONITOR HIERARCHY:{Environment.NewLine}{MISCModBase.PrintTreeOfGameObject(__instance.transform.parent, 0)}");

            var cubeParent = __instance.transform.parent;
            var onButton = cubeParent.Find("CameraMonitorOnButton");
            var switchButton = cubeParent.Find("CameraMonitorSwitchButton");

            //MISCModBase.Instance.PublicLogger.LogInfo($"OnButton Transform: {onButton.transform.localPosition}");
            //MISCModBase.Instance.PublicLogger.LogInfo($"SwitchButton Transform: {switchButton.transform.localPosition}");

            var onButtonPos = onButton.transform.localPosition;
            onButtonPos.y = -0.1f;
            onButtonPos.x = 0;
            onButton.transform.localPosition = onButtonPos;

            var switchButtonPos = switchButton.transform.localPosition;
            switchButtonPos.y = -0.1f;
            switchButtonPos.x = 0;
            switchButton.transform.localPosition = switchButtonPos;

            //MISCModBase.Instance.PublicLogger.LogInfo($"OnButton Transform: {onButton.transform.localPosition}");
            //MISCModBase.Instance.PublicLogger.LogInfo($"SwitchButton Transform: {switchButton.transform.localPosition}");
        }
    }
}
