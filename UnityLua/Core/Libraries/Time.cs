using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace UnityLua
{
	public static partial class LuaLibraries
	{
		private static int Time_Delta()
		{
			LuaManager.Ls.PushNumber(Time.deltaTime);
			return 1;
		}

		private static int Time_Now()
		{
			LuaManager.Ls.PushNumber(Time.time);
			return 1;
		}

		public static void Load_Time()
		{
			LuaManager.Ls.NewTable();

			LuaManager.Ls.PushFunction(Time_Delta);
			LuaManager.Ls.SetField(-2, "Delta");

			LuaManager.Ls.PushFunction(Time_Now);
			LuaManager.Ls.SetField(-2, "Now");

			LuaManager.Ls.SetGlobal("Time");
		}
	}
}