using BepInEx;
using HarmonyLib;

namespace Trainer
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    public class BepInExLoader : BepInEx.IL2CPP.BasePlugin
    {
        public const string
            MODNAME = "PlaylistUnlock",
            AUTHOR = "Yentis",
            GUID = "com." + AUTHOR + "." + MODNAME,
            VERSION = "1.0.0";

        public static BepInEx.Logging.ManualLogSource log;

        public BepInExLoader()
        {
            log = Log;
        }

        public override void Load()
        {
            log.LogMessage("[PlaylistUnlock] Loading");

            try
            {
                var harmony = new Harmony("yentis.playlistunlock.il2cpp");

                harmony.Patch(
                    typeof(MetaArcadeSongProgress).GetMethod(nameof(MetaArcadeSongProgress.isUnlocked)),
                    postfix: new HarmonyMethod(typeof(Patches).GetMethod(nameof(Patches.isUnlocked)))
                );
            }
            catch
            {
                log.LogError("[PlaylistUnlock] Harmony - FAILED to Apply Patches!");
            }
        }
    }
}