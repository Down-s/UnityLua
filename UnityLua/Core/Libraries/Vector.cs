using UnityEngine;

namespace UnityLua
{
    public static partial class LuaLibraries
    {
        struct Lua_Vector3
        {
            public static void CreatePush(float x = 0, float y = 0, float z = 0)
            {
                LuaManager.Ls.NewTable();
                
                LuaManager.Ls.PushString("x");
                LuaManager.Ls.PushNumber(x);
                LuaManager.Ls.SetTable(-3);

                LuaManager.Ls.PushString("y");
                LuaManager.Ls.PushNumber(y);
                LuaManager.Ls.SetTable(-3);
                
                LuaManager.Ls.PushString("z");
                LuaManager.Ls.PushNumber(z);
                LuaManager.Ls.SetTable(-3);

                LuaManager.Ls.GetMetatable("Vector3");
                LuaManager.Ls.SetMetatable(-2);
            }

            public static int Call()
            {
                float x = LuaManager.Ls.GetNumber(1);
                float y = LuaManager.Ls.GetNumber(2);
                float z = LuaManager.Ls.GetNumber(3);
                
                CreatePush(x, y, z);

                return 1;
            }

            public static int __tostring()
            {
                LuaManager.Ls.PushString("x");
                LuaManager.Ls.GetTable(-2);
                float x = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                LuaManager.Ls.PushString("y");
                LuaManager.Ls.GetTable(-2);
                float y = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);
                
                LuaManager.Ls.PushString("z");
                LuaManager.Ls.GetTable(-2);
                float z = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);
                
                LuaManager.Ls.PushString($"X: {x} Y: {y} Z: {z}");
                return 1;
            }
            
            public static int __add()
            {
                LuaManager.Ls.PushString("x");
                LuaManager.Ls.GetTable(-3);
                float x1 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                LuaManager.Ls.PushString("y");
                LuaManager.Ls.GetTable(-3);
                float y1 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);
                
                LuaManager.Ls.PushString("z");
                LuaManager.Ls.GetTable(-3);
                float z1 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                LuaManager.Ls.PushString("x");
                LuaManager.Ls.GetTable(-2);
                float x2 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                LuaManager.Ls.PushString("y");
                LuaManager.Ls.GetTable(-2);
                float y2 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);
                
                LuaManager.Ls.PushString("z");
                LuaManager.Ls.GetTable(-2);
                float z2 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                CreatePush(x1 + x2, y1 + y2, z1 + z2);
                return 1;
            }
            
            public static int __sub()
            {
                LuaManager.Ls.PushString("x");
                LuaManager.Ls.GetTable(-3);
                float x1 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                LuaManager.Ls.PushString("y");
                LuaManager.Ls.GetTable(-3);
                float y1 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);
                
                LuaManager.Ls.PushString("z");
                LuaManager.Ls.GetTable(-3);
                float z1 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                LuaManager.Ls.PushString("x");
                LuaManager.Ls.GetTable(-2);
                float x2 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                LuaManager.Ls.PushString("y");
                LuaManager.Ls.GetTable(-2);
                float y2 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);
                
                LuaManager.Ls.PushString("z");
                LuaManager.Ls.GetTable(-2);
                float z2 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                CreatePush(x1 - x2, y1 - y2, z1 - z2);
                return 1;
            }
            
            public static int __mul()
            {
                LuaManager.Ls.PushString("x");
                LuaManager.Ls.GetTable(-3);
                float x1 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                LuaManager.Ls.PushString("y");
                LuaManager.Ls.GetTable(-3);
                float y1 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);
                
                LuaManager.Ls.PushString("z");
                LuaManager.Ls.GetTable(-3);
                float z1 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);
                
                float mul = LuaManager.Ls.GetNumber(2);

                CreatePush(x1 * mul, y1 * mul, z1 * mul);
                return 1;
            }
            
            public static int __div()
            {
                LuaManager.Ls.PushString("x");
                LuaManager.Ls.GetTable(-3);
                float x1 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                LuaManager.Ls.PushString("y");
                LuaManager.Ls.GetTable(-3);
                float y1 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);
                
                LuaManager.Ls.PushString("z");
                LuaManager.Ls.GetTable(-3);
                float z1 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                LuaManager.Ls.PushString("x");
                LuaManager.Ls.GetTable(-2);
                float x2 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                LuaManager.Ls.PushString("y");
                LuaManager.Ls.GetTable(-2);
                float y2 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);
                
                LuaManager.Ls.PushString("z");
                LuaManager.Ls.GetTable(-2);
                float z2 = LuaManager.Ls.GetNumber(-1);
                LuaManager.Ls.Pop(1);

                CreatePush(x1 / x2, y1 / y2, z1 / z2);
                return 1;
            }
        }

        public static void Load_Vector()
        {
            LuaManager.Ls.PushFunction(Lua_Vector3.Call);
            LuaManager.Ls.SetGlobal("Vector3");

            LuaManager.Ls.NewMetaTable("Vector3");

            LuaManager.Ls.PushString("__tostring");
            LuaManager.Ls.PushFunction(Lua_Vector3.__tostring);
            LuaManager.Ls.SetTable(-3);

            LuaManager.Ls.PushString("__add");
            LuaManager.Ls.PushFunction(Lua_Vector3.__add);
            LuaManager.Ls.SetTable(-3);

            LuaManager.Ls.PushString("__sub");
            LuaManager.Ls.PushFunction(Lua_Vector3.__sub);
            LuaManager.Ls.SetTable(-3);

            LuaManager.Ls.PushString("__mul");
            LuaManager.Ls.PushFunction(Lua_Vector3.__mul);
            LuaManager.Ls.SetTable(-3);

            LuaManager.Ls.PushString("__div");
            LuaManager.Ls.PushFunction(Lua_Vector3.__div);
            LuaManager.Ls.SetTable(-3);

            LuaManager.Ls.PushString("__tostring");
            LuaManager.Ls.PushFunction(Lua_Vector3.__tostring);
            LuaManager.Ls.SetTable(-3);
        }
    }
}