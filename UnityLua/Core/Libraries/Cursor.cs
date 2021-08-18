using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace UnityLua
{
	public static partial class LuaLibraries
	{
        public static int Cursor_SetLockState()
        {
            Cursor.lockState = (CursorLockMode) LuaManager.Ls.GetNumber(1);
            return 0;
        }

		public static void Load_Cursor()
		{
			LuaManager.Ls.NewTable(); // CursorLockMode

			// Fill CursorLockMode table
			foreach (int key in Enum.GetValues(typeof(CursorLockMode)))
			{
				string Name = Enum.GetName(typeof(CursorLockMode), key);
				LuaManager.Ls.PushNumber(key);
				LuaManager.Ls.SetField(-2, Name);
			}

			LuaManager.Ls.SetGlobal("CursorLockMode");

            LuaManager.Ls.NewTable(); // Cursor
            
            LuaManager.Ls.PushFunction(Cursor_SetLockState);
            LuaManager.Ls.SetField(-2, "SetLockState");

            LuaManager.Ls.SetGlobal("Cursor");
		}
	}
}