# SeppahMod

This is a small mod made during the Good Company Public Test phase 1.

It's mainly just for exploring the possibilities through modding.


## Setup

### For using the mod

1. Download the latest version of BepInEx from the [github page](https://github.com/BepInEx/BepInEx/releases) and extract it in the root of the game folder.
2. Copy `SeppahMod.dll` in the `BepInEx/plugins` folder.

### For developing the mod

requirements:
```
0Harmony.dll
Assembly-CSharp.dll
BepInEx.dll
BepInEx.Harmony.dll
TextMeshPro-1.0.55.56.0b12.dll
UnityEngine.dll
UnityEngine.UI.dll
```

1. Copy the required libraries listed above from `Good Company Beta\GoodCompany_Data\Managed` into the `Libs` directory next to this README file.
2. Download the latest version of BepInEx from the [github page](https://github.com/BepInEx/BepInEx/releases) and extract it in the root of the game folder.
3. Edit the Post-Build event in the Visual Studio solution so that it copies this mod library into the `BepInEx/plugins` folder.
