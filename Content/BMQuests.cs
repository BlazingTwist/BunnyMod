﻿using RogueLibsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyMod.Content
{
	class BMQuests
	{
		public static GameController GC => GameController.gameController;
		public static bool Prefix(Type type, string methodName, Type patchType, string patchMethodName, Type[] types) => BMHeader.MainInstance.PatchPrefix(type, methodName, patchType, patchMethodName, types);
		public static bool Postfix(Type type, string methodName, Type patchType, string patchMethodName, Type[] types) => BMHeader.MainInstance.PatchPostfix(type, methodName, patchType, patchMethodName, types);
		public static void BMLog(string logMessage) => BMHeader.Log(logMessage);

		public void Awake()
		{

		}

		#region ExitPoint
		public static bool ExitPoint_DetermineIfCanExit(ref bool __result) // Prefix
		{
			if (GC.challenges.Contains(cChallenge.RushinRevolution))
			{
				__result = true;
				return false;
			}

			return true;
		}
		#endregion
	}
}
