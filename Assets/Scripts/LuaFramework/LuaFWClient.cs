/***
*
*	Title:"Lua框架"项目
*			启动Lua代码
*
*	Description:
*		功能：
*			启动Lua
*
*	Author: Zhaiyurong
*
*	Date: 2023.5
*
*	Modify:
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XLua;
using System.Text;
using System;
using System.IO;

namespace LuaFramework
{
    public class LuaFWClient : MonoBehaviour
    {
        //Update事件
        private Action LuaUpdate;
        private Action LuaFixedUpdate;
        private Action LuaLateUpdate;


        void Start()
        {
            //解释一遍lua脚本
            InitLuaScripts();
            //定义Update
            LuaUpdate = LuaClientMgr.Instance.GetXLuaEnv().Global.Get<Action>("Update");
            LuaFixedUpdate = LuaClientMgr.Instance.GetXLuaEnv().Global.Get<Action>("FixedUpdate");
            LuaLateUpdate = LuaClientMgr.Instance.GetXLuaEnv().Global.Get<Action>("LateUpdate");
        }
        public void InitLuaScripts()
        {
            //添加loader
            LuaClientMgr.Instance.GetXLuaEnv().AddLoader(LuaLoader);
            //开始执行Lua代码
            LuaClientMgr.Instance.GetXLuaEnv().DoString(LuaFWDefine.LUA_START);
        }

        /// <summary>
        /// 自定义Loader
        /// </summary>
        /// <param name="filepath">require语句中填的lua文件路径</param>
        /// <returns></returns>
        public byte[] LuaLoader(ref string filepath)
        {
            //拼接Lua文件下载路径
            string loadPath = LuaFWPathTool.GetLuaScriptPath() + "/" + filepath + ".lua";
            Debug.Log("lua filepath = " + loadPath);

            //读取Lua文件内容
            string content = File.ReadAllText(loadPath);
            //Debug.Log("lua text = "+ content);

            return Encoding.UTF8.GetBytes(content);
        }


        // Update is called once per frame
        void Update()
        {
            LuaUpdate();
        }

        void LateUpdate()
        {
            LuaLateUpdate();
        }

        void FixedUpdate()
        {
            LuaFixedUpdate();
        }


        void OnDestroy()
        {
            Debug.Log("GameManager Destroyed");

            //清理引用数据
            LuaUpdate = null;
            LuaLateUpdate = null;
            LuaFixedUpdate = null;

            //释放资源
            LuaClientMgr.Instance.GetXLuaEnv().Dispose();
        }
    }

}
