using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace UnityLua
{
	public static partial class LuaLibraries
	{
		private static int Entity_Get()
		{
            string Index = LuaManager.Ls.GetString(1);
			
            EntityIndexPair IndexPair = LuaLibraries.EntityLookup[Index];

            LuaManager.Ls.NewTable();

            LuaManager.Ls.PushString("Index");
            LuaManager.Ls.PushNumber(IndexPair.EntIndex);
            LuaManager.Ls.SetTable(-3);

            LuaManager.Ls.GetMetatable("GameObject");
            LuaManager.Ls.SetMetatable(-2);

			return 1;
		}

		public static void Load_Entity()
		{
			LuaManager.Ls.NewTable();

			LuaManager.Ls.PushFunction(Entity_Get);
			LuaManager.Ls.SetField(-2, "Get");

			LuaManager.Ls.SetGlobal("Entity");
		}
	}
}