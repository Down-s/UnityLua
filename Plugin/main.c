#define CFunc _declspec(dllexport)

#pragma comment(lib, "lua54/liblua54.a")

#include "lua54/lua.h"
#include "lua54/lualib.h"
#include "lua54/lauxlib.h"

lua_State* Ls;

CFunc void InitLua()
{
	Ls = luaL_newstate();
	luaL_openlibs(Ls);
}

CFunc int EXT_luaL_dostring(const char* str)
{
	return luaL_dostring(Ls, str);
}

CFunc int EXT_luaL_dofile(const char* dir)
{
	return luaL_dofile(Ls, dir);
}

CFunc void EXT_lua_getglobal(const char* varname)
{
	lua_getglobal(Ls, varname);
}

CFunc float EXT_lua_tonumber(int stackindex)
{
	return (float) lua_tonumber(Ls, stackindex);
}

CFunc const char* EXT_lua_tostring(int stackindex)
{
	return lua_tostring(Ls, stackindex);
}

CFunc int EXT_lua_gettop()
{
	return lua_gettop(Ls);
}

CFunc void EXT_lua_pop(int index)
{
	return lua_pop(Ls, index);
}

//
// Push Vars
//

CFunc void EXT_lua_pushnumber(float num)
{
	lua_pushnumber(Ls, num);
}

CFunc void EXT_lua_pushstring(const char* str)
{
	lua_pushstring(Ls, str);
}

CFunc void EXT_lua_pushboolean(int boolean)
{
	lua_pushboolean(Ls, boolean == 1);
}

CFunc void EXT_lua_pushvalue(int index)
{
	lua_pushvalue(Ls, index);
}

//
// Is Vars
//

CFunc int EXT_lua_isfunction(int index)
{
	return lua_isfunction(Ls, index);
}

//
// Functions
//

CFunc void EXT_lua_pushcfunction(lua_CFunction func)
{
	lua_pushcfunction(Ls, func);
}

CFunc int EXT_lua_pcall(int args, int results, int errh)
{
	return lua_pcall(Ls, args, results, errh);
}

//
// Tables
//
CFunc void EXT_lua_newtable()
{
	lua_newtable(Ls);
}

CFunc int EXT_lua_gettable(int index)
{
	return lua_gettable(Ls, index);
}

CFunc void EXT_lua_settable(int index)
{
	lua_settable(Ls, index);
}

CFunc void EXT_lua_setfield(int index, const char* name)
{
	lua_setfield(Ls, index, name);
}

CFunc int EXT_lua_getfield(int index, const char* name)
{
	return lua_getfield(Ls, index, name);
}

//
// Variables
//

CFunc void EXT_lua_setglobal(const char* name)
{
	lua_setglobal(Ls, name);
}

//
// Metatables
//

CFunc int EXT_lua_getmetatable(int index)
{
	return lua_getmetatable(Ls, index);
}

CFunc void EXT_luaL_getmetatable(const char* name)
{
	luaL_getmetatable(Ls, name);
}

CFunc int EXT_luaL_newmetatable(const char* name)
{
	return luaL_newmetatable(Ls, name);
}

CFunc int EXT_lua_setmetatable(int index)
{
	return lua_setmetatable(Ls, index);
}

CFunc void EXT_luaL_setmetatable(const char* name)
{
	luaL_setmetatable(Ls, name);
}

CFunc int EXT_luaL_ref(int index)
{
	return luaL_ref(Ls, index);
}
