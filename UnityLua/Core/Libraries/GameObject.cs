using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

namespace UnityLua
{
	public static partial class LuaLibraries
	{
		public struct EntityIndexPair
		{
			public Entity ent;
			public int EntIndex;
		}

		public static List<Entity> Entities = new List<Entity>();
		public static Dictionary<string, EntityIndexPair> EntityLookup = new Dictionary<string, EntityIndexPair>();

		struct Lua_GameObject
		{
			public static int Call()
			{
				string Name = LuaManager.Ls.GetString(1);
				if (string.IsNullOrEmpty(Name))
					Name = "Lua GameObject";

				GameObject obj = new GameObject(Name);
				Entities.Add(obj.AddComponent<Entity>());

				LuaManager.Ls.NewTable();

				LuaManager.Ls.PushString("Index");
				LuaManager.Ls.PushNumber(Entities.Count - 1);
				LuaManager.Ls.SetTable(-3);

				LuaManager.Ls.GetMetatable("GameObject");
				LuaManager.Ls.SetMetatable(-2);

				return 1;
			}

			public static int SetName()
			{
				LuaManager.Ls.PushString("Index");
				LuaManager.Ls.GetTable(-3);
				int Index = (int) LuaManager.Ls.GetNumber(-1);
				LuaManager.Ls.Pop(1);

				Entity ent = Entities[Index];
				if (ent == null) return 0;
				GameObject obj = ent.gameObject;

				obj.name = LuaManager.Ls.GetString(2);

				return 0;
			}

			public static int SetPos()
			{
				LuaManager.Ls.PushString("Index");
				LuaManager.Ls.GetTable(-3);
				int Index = (int) LuaManager.Ls.GetNumber(-1);
				LuaManager.Ls.Pop(1);

				Entity ent = Entities[Index];
				if (ent == null) return 0;
				GameObject obj = ent.gameObject;

				obj.transform.position = LuaManager.Ls.GetVector(2);

				return 0;
			}

			public static int SetAng()
			{
				LuaManager.Ls.PushString("Index");
				LuaManager.Ls.GetTable(-3);
				int Index = (int) LuaManager.Ls.GetNumber(-1);
				LuaManager.Ls.Pop(1);

				Entity ent = Entities[Index];
				if (ent == null) return 0;
				GameObject obj = ent.gameObject;

				obj.transform.localEulerAngles = LuaManager.Ls.GetVector(2);

				return 0;
			}

			public static int GetPos()
			{
				LuaManager.Ls.PushString("Index");
				LuaManager.Ls.GetTable(-2);
				int Index = (int) LuaManager.Ls.GetNumber(-1);
				LuaManager.Ls.Pop(1);

				Entity ent = Entities[Index];
				if (ent == null) return 0;
				GameObject obj = ent.gameObject;
				
				Lua_Vector3.CreatePush(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);

				return 1;
			}

			public static int GetAng()
			{
				LuaManager.Ls.PushString("Index");
				LuaManager.Ls.GetTable(-2);
				int Index = (int) LuaManager.Ls.GetNumber(-1);
				LuaManager.Ls.Pop(1);

				Entity ent = Entities[Index];
				if (ent == null) return 0;
				GameObject obj = ent.gameObject;
				
				Lua_Vector3.CreatePush(obj.transform.localEulerAngles.x, obj.transform.localEulerAngles.y, obj.transform.localEulerAngles.z);

				return 1;
			}

			public static int Translate()
			{
				LuaManager.Ls.PushString("Index");
				LuaManager.Ls.GetTable(-3);
				int Index = (int) LuaManager.Ls.GetNumber(-1);
				LuaManager.Ls.Pop(1);

				Entity ent = Entities[Index];
				if (ent == null) return 0;
				GameObject obj = ent.gameObject;

				obj.transform.Translate(LuaManager.Ls.GetVector(2));

				return 0;
			}
		}
		
		public static void Load_GameObject()
		{
			//Entities.Clear();

			LuaManager.Ls.PushFunction(Lua_GameObject.Call);
			LuaManager.Ls.SetGlobal("GameObject");

			LuaManager.Ls.NewMetaTable("GameObject");
			int ObjectIndex = LuaManager.Ls.GetTop();

			LuaManager.Ls.PushString("__index");
			LuaManager.Ls.PushValue(ObjectIndex);
			LuaManager.Ls.SetTable(-3);

			LuaManager.Ls.PushString("SetName");
			LuaManager.Ls.PushFunction(Lua_GameObject.SetName);
			LuaManager.Ls.SetTable(-3);

			LuaManager.Ls.PushString("SetPos");
			LuaManager.Ls.PushFunction(Lua_GameObject.SetPos);
			LuaManager.Ls.SetTable(-3);

			LuaManager.Ls.PushString("GetPos");
			LuaManager.Ls.PushFunction(Lua_GameObject.GetPos);
			LuaManager.Ls.SetTable(-3);

			LuaManager.Ls.PushString("SetAng");
			LuaManager.Ls.PushFunction(Lua_GameObject.SetAng);
			LuaManager.Ls.SetTable(-3);

			LuaManager.Ls.PushString("GetAng");
			LuaManager.Ls.PushFunction(Lua_GameObject.GetAng);
			LuaManager.Ls.SetTable(-3);

			LuaManager.Ls.PushString("Translate");
			LuaManager.Ls.PushFunction(Lua_GameObject.Translate);
			LuaManager.Ls.SetTable(-3);
		}
	}
}