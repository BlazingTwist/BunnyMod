﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using BepInEx;
using HarmonyLib;
using UnityEngine;
using RogueLibsCore;

namespace BunnyMod
{
	class BunnySprites
	{
		public void Awake()
		{
			BunnyHeader.MainInstance.PatchPostfix(typeof(CharacterCreation), "Awake", GetType(), "CharacterCreation_Awake", new Type[0] { });

			BunnyHeader.MainInstance.PatchPostfix(typeof(GameResources), "SetupDics", GetType(), "GameResources_SetupDics", new Type[0] { });
		}
		public void FixedUpdate()
		{
		}
		public void Initialize_Names()
		{
		}
		public static void Initialize_Sprites()
		{
		}

		#region CharacterCreation
		public static void CharacterCreation_Awake(CharacterCreation __instance) // Postfix
		{
			__instance.facialHairTypes.Add("TestFacialHair");
			__instance.facialHairTypes.Add("TestFacialHair");
		}
		#endregion
		#region CharacterSelect
		public static void CharacterSelect_FakeStart(CharacterSelect __instance) // Postfix
		{
			__instance.facialHairTypes.Add("TestFacialHair");
		}
		#endregion
		#region GameResources
		public static void GameResources_SetupDics(GameResources __instance) // Postfix
		{
			__instance.facialHairDic.Add("TestFacialHair", __instance.facialHairList[10]);
			__instance.facialHairDic.Add("TestFacialHairSE", __instance.facialHairList[11]);

		}
		#endregion
	}
}
