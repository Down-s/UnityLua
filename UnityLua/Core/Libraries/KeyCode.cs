using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace UnityLua
{
	public static partial class LuaLibraries
	{
		public static void Load_KeyCode()
		{
			LuaManager.Ls.NewTable();

			// Fill KeyCode table
			foreach (int key in Enum.GetValues(typeof(KeyCode)))
			{
				string Name = Enum.GetName(typeof(KeyCode), key);
				LuaManager.Ls.PushNumber(key);
				LuaManager.Ls.SetField(-2, Name);
			}

			LuaManager.Ls.SetGlobal("KeyCode");
		}
	}
}