using LuaFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaClientMgr : MonoSingleton<LuaClientMgr>
{
    //����Lua����
    public LuaEnv luaenv = new LuaEnv();
    public LuaEnv GetXLuaEnv()
    {
       
        return luaenv;
    }
    public LuaFWClient GetLuaFWClient()
    {
        var client = GameObject.Find("LuaFWClient").GetComponent<LuaFWClient>();
        return client;
    }
}
