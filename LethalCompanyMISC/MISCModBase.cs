using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.IO;
using LethalCompanyMISC.Patches;

namespace LethalCompanyMISC
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class MISCModBase : BaseUnityPlugin
    {
        Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

        public static MISCModBase Instance { get; private set; }

        public AudioClip UltraInstinctClip { get; private set; }

        private void Awake()
        {
            Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} has loaded!");

            if (Instance != null)
                return;

            Instance = this;

            Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} Singleton has loaded.");

            string location = Instance.Info.Location;
            string directoryPath = Path.GetDirectoryName(location);
            string bundlePath = directoryPath + @"\ultra_instinct";

            Logger.LogInfo($"{bundlePath}");

            AssetBundle audioAssetBundle = AssetBundle.LoadFromFile(bundlePath);
            if ((Object)(object)audioAssetBundle == null)
            {
                Logger.LogError("Failed to load audio assets!");
                return;
            }

            Logger.LogInfo("Loaded Asset Bundle!");

            var newSFX = audioAssetBundle.LoadAssetWithSubAssets<AudioClip>("ultra_instinct.mp3");

            Logger.LogInfo($"Loaded Sound Effect! {newSFX.Length}");

            if (newSFX.Length == 0)
                return;

            UltraInstinctClip = newSFX[0];

            harmony.PatchAll(typeof(JesterPatch));

            Logger.LogInfo("Ultra Instinct Mod Loaded.");
        }
    }
}
