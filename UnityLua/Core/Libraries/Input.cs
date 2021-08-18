using UnityEngine;

namespace UnityLua
{
	public static partial class LuaLibraries
	{
		private static int Input_GetAxis()
		{
			string Axis = LuaManager.Ls.GetString(1);
			LuaManager.Ls.PushNumber(Input.GetAxis(Axis));

			return 1;
		}

		private static int Input_GetKey()
		{
			int Key = (int) LuaManager.Ls.GetNumber(1);
			LuaManager.Ls.PushBoolean(Input.GetKey((KeyCode) Key));

			return 1;
		}

		private static int Input_GetKeyDown()
		{
			int Key = (int) LuaManager.Ls.GetNumber(1);
			LuaManager.Ls.PushBoolean(Input.GetKeyDown((KeyCode) Key));

			return 1;
		}

		public static void Load_Input()
		{
			LuaManager.Ls.NewTable();

			LuaManager.Ls.PushFunction(Input_GetAxis);
			LuaManager.Ls.SetField(-2, "GetAxis");

			LuaManager.Ls.PushFunction(Input_GetKey);
			LuaManager.Ls.SetField(-2, "GetKey");

			LuaManager.Ls.PushFunction(Input_GetKey);
			LuaManager.Ls.SetField(-2, "GetKeyDown");

			LuaManager.Ls.SetGlobal("Input");
		}
	}
}