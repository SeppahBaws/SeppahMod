using System;
using System.Reflection;

using HarmonyLib;
using BepInEx;
using BepInEx.Harmony;

using UnityEngine;
using GoodCompany;

namespace SeppahMod
{
	[BepInPlugin("com.github.seppahbaws.seppahmod", "SeppahMod", "0.1.0.0")]
    public class Mod : BaseUnityPlugin
    {
	    void Awake()
	    {
			Harmony harmony = new Harmony("com.github.seppahbaws.seppahmod");
			harmony.PatchAll(Assembly.GetExecutingAssembly());
	    }
    }

	[HarmonyPatch(typeof(GameRoot))]
	[HarmonyPatch("GetVersion")]
	[HarmonyPatch(new Type[] { })]
    class GameRoot_GetVersion_Patch
    {
	    static void Postfix(GameRoot __instance, ref string __result)
	    {
		    __result += " Modded";
	    }
    }

    [HarmonyPatch(typeof(GoodCompany.GUI.MainMenu))]
    [HarmonyPatch("OnSessionStarted")]
    [HarmonyPatch(new Type[] { })]
	class MainMenu_OnSessionStarted_Patch
    {
	    static void Postfix(GoodCompany.GUI.MainMenu __instance, ref CanvasGroup ____buttonsCanvasGroup)
	    {
			Debug.Log("Session Started");
	    }
    }

    [HarmonyPatch(typeof(GameRoot))]
	[HarmonyPatch("Update")]
	[HarmonyPatch(new Type[] { })]
    class GameRoot_Update_Patch
    {
	    private static float zoom = -1.0f;
	    static void Postfix(GameRoot __instance)
	    {
		    Vector2 scroll = Input.mouseScrollDelta;

		    if (zoom == -1.0f)
			    zoom = __instance.MainCamera.MainCamera.fieldOfView;

		    zoom -= scroll.y;
		    zoom = Mathf.Clamp(zoom, 3.0f, 50.0f);

		    __instance.MainCamera.MainCamera.fieldOfView = zoom;
	    }
	}

    // [HarmonyPatch(typeof(GoodCompany.GUI.MainMenu))]
    // [HarmonyPatch("Initialize")]
    // [HarmonyPatch(new Type[] { })]
    // class MainMenu_VersionLabel_Patch
    // {
    // 	static void Postfix(GoodCompany.GUI.MainMenu __instance, ref TMP_Text ___version)
    // 	{
    // 		___version.transform.position = Vector3.zero;
    // 		Debug.Log("Moving version text!");
    // 	}
    // }
}
