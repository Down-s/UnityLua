using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace UnityLua
{
	public static partial class LuaLibraries
	{
		private static int Mathf_Clamp()
		{
            float Value = LuaManager.Ls.GetNumber(1);
            float Min = LuaManager.Ls.GetNumber(2);
            float Max = LuaManager.Ls.GetNumber(3);
			
            LuaManager.Ls.PushNumber(Mathf.Clamp(Value, Min, Max));
			return 1;
		}

		public static void Load_Mathf()
		{
			LuaManager.Ls.NewTable(); // Mathf

			LuaManager.Ls.PushFunction(Mathf_Clamp);
			LuaManager.Ls.SetField(-2, "Clamp");

			LuaManager.Ls.SetGlobal("Mathf");
		}
	}
}