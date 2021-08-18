using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace UnityLua
{
	public class LuaState
	{
		const string DllDir = "UnityLua";

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern int Add(int a, int b);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern int InitLua();

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern int EXT_luaL_dostring(string str);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_lua_getglobal(string varname);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern float EXT_lua_tonumber(int stackindex);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
		public static extern IntPtr EXT_lua_tostring(int stackindex);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern int EXT_luaL_dofile(string dir);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_lua_pushcfunction(Func<int> func);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_lua_pop(int index);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern int EXT_lua_gettop();

		//
		// Push Vars
		//

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_lua_pushnumber(float num);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_lua_pushstring(string str);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_lua_pushboolean(bool boolean);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_lua_pushvalue(int index);

		//
		// Functions
		//

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern int EXT_lua_pcall(int args, int result, int errh);

		//
		// Tables
		//

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_lua_newtable();

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern int EXT_lua_gettable(int index);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_lua_settable(int index);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_lua_setfield(int index, string name);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_lua_getfield(int index, string name);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_lua_setglobal(string name);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_luaL_getmetatable(string name);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern int EXT_lua_setmetatable(int index);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern void EXT_luaL_setmetatable(string name);

		[DllImport(DllDir, CallingConvention=CallingConvention.Cdecl)]
		public static extern int EXT_luaL_newmetatable(string name);

		//
		// Metatables
		//

		public void NewTable()
		{
			EXT_lua_newtable();
		}

		public int GetTable(int index)
		{
			return EXT_lua_gettable(index);
		}

		public void SetTable(int index)
		{
			EXT_lua_settable(index);
		}

		public void GetMetatable(string name)
		{
			EXT_luaL_getmetatable(name);
		}

		public int SetMetatable(int index)
		{
			return EXT_lua_setmetatable(index);
		}

		public void LSetMetatable(string name)
		{
			EXT_luaL_setmetatable(name);
		}

		public int NewMetaTable(string name)
		{
			return EXT_luaL_newmetatable(name);
		}

		public void SetField(int index, string name)
		{
			EXT_lua_setfield(index, name);
		}

		public void GetField(int index, string name)
		{
			EXT_lua_getfield(index, name);
		}

		public void SetGlobal(string name)
		{
			EXT_lua_setglobal(name);
		}

		public void GetGlobal(string name)
		{
			EXT_lua_getglobal(name);
		}

		public void Pop(int index)
		{
			EXT_lua_pop(index);
		}

		public int GetTop()
		{
			return EXT_lua_gettop();
		}

		//
		// Push Vars
		//

		public void PushNumber(float num)
		{
			EXT_lua_pushnumber(num);
		}

		public void PushString(string str)
		{
			EXT_lua_pushstring(str);
		}

		public void PushBoolean(bool boolean)
		{
			EXT_lua_pushboolean(boolean);
		}

		public void PushValue(int index)
		{
			EXT_lua_pushvalue(index);
		}

		//
		// Functions
		//

		public int PCall(int args, int results, int errh)
		{
			return EXT_lua_pcall(args, results, errh);
		}

		//
		// Stuff
		//

		public void PushFunction(Func<int> func)
		{
			EXT_lua_pushcfunction(func);
		}

		public int DoFile(string dir)
		{
			return EXT_luaL_dofile(dir);
		}

		public void PushGlobal(string varname)
		{
			EXT_lua_getglobal(varname);
		}

		public float GetNumber(int stackindex)
		{
			return EXT_lua_tonumber(stackindex);
		}

		public string GetString(int stackindex)
		{
			return Marshal.PtrToStringAnsi(EXT_lua_tostring(stackindex));
		}

		public Vector3 GetVector(int stackindex)
		{
			LuaManager.Ls.PushString("x");
			LuaManager.Ls.GetTable(2);
			float x = LuaManager.Ls.GetNumber(-1);
			LuaManager.Ls.Pop(1);

			LuaManager.Ls.PushString("y");
			LuaManager.Ls.GetTable(2);
			float y = LuaManager.Ls.GetNumber(-1);
			LuaManager.Ls.Pop(1);
			
			LuaManager.Ls.PushString("z");
			LuaManager.Ls.GetTable(2);
			float z = LuaManager.Ls.GetNumber(-1);
			LuaManager.Ls.Pop(1);

			return new Vector3(x, y, z);
		}

		public int DoString(string str)
		{
			return EXT_luaL_dostring(str);
		}

		public bool CheckLua(int result)
		{
			if (result == 0)
			{
				return true;
			}
			else
			{
				Debug.LogError(GetString(-1));
				return false;
			}
		}

		public LuaState()
		{
			InitLua(); // Load the lua state
		}
	}
}