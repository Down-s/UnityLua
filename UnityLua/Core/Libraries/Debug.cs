using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace UnityLua
{
	public static partial class LuaLibraries
	{
		private static int Debug_Log()
		{
			Debug.Log(LuaManager.Ls.GetString(1));
			return 0;
		}

		private static int Debug_LogWarning()
		{
			Debug.LogWarning(LuaManager.Ls.GetString(1));
			return 0;
		}

		private static int Debug_LogError()
		{
			Debug.LogError(LuaManager.Ls.GetString(1));
			return 0;
		}

		public static void Load_Debug()
		{
			LuaManager.Ls.NewTable();

			LuaManager.Ls.PushFunction(Debug_Log);
			LuaManager.Ls.SetField(-2, "Log");

			LuaManager.Ls.PushFunction(Debug_LogWarning);
			LuaManager.Ls.SetField(-2, "LogWarning");

			LuaManager.Ls.PushFunction(Debug_LogError);
			LuaManager.Ls.SetField(-2, "LogError");

			LuaManager.Ls.SetGlobal("Debug");
		}
	}
}