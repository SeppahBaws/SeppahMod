using System;
using System.Reflection;

using HarmonyLib;
using BepInEx;
using BepInEx.Harmony;

using UnityEngine;
using GoodCompany;

namespace SeppahMod
{
	[BepInPlugin("com.github.seppahbaws.seppahmod", "SeppahMod", "1.0.0.0")]
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

	[HarmonyPatch(typeof(GameRoot))]
	[HarmonyPatch("Update")]
	[HarmonyPatch(new Type[] { })]
    class GameRoot_Update_Patch
    {
	    static void Postfix(GameRoot __instance)
	    {
		    Vector2 scroll = Input.mouseScrollDelta;

		    if (__instance.MainCamera.MainCamera.fieldOfView > 1)
			    __instance.MainCamera.MainCamera.fieldOfView -= scroll.y;
		    Debug.Log("zoom: " + __instance.MainCamera.MainCamera.fieldOfView);
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
