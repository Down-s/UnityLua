using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityLua
{
    public class LuaManager : MonoBehaviour
    {
        public static LuaState Ls = new LuaState();
        const string EntryFile = "Assets/UnityLua/main.lua";

        private void CallUEFunction(string FuncName)
        {
            Ls.GetGlobal("UE");
            Ls.GetField(-1, FuncName);

            //if (!Ls.IsFunction(-1)) return;

            Ls.PCall(0, 0, 0);
        }

        int print()
        {
            Debug.Log(Ls.GetString(1));
            
            return 0;
        }

        void Awake()
        {
            LuaLibraries.Entities.Clear();
            LuaLibraries.EntityLookup.Clear();
        }

        void Start()
        {
            Debug.Log("Staterd");
            Ls.NewTable();
            Ls.SetGlobal("UE");

            LuaLibraries.Load_Mathf();
            LuaLibraries.Load_Time();
            LuaLibraries.Load_Debug();
            LuaLibraries.Load_GameObject();
            LuaLibraries.Load_Vector();
            LuaLibraries.Load_KeyCode();
            LuaLibraries.Load_Input();
            LuaLibraries.Load_Entity();
            LuaLibraries.Load_Cursor();

            Ls.PushFunction(print);
            Ls.SetGlobal("print");

            int status = Ls.DoFile(EntryFile);
            int status1 = status;
            Ls.CheckLua(status1);
        }

        void Update()
        {
            CallUEFunction("Update");
        }
    }
}
