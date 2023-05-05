--[[
    Title:
        Lua UI 框架

    Description:
        Lua程序入口

    Author : PenhPhnom

    Date:2023.5

    Modify:

]]


GameObject = CS.UnityEngine.GameObject
Input = CS.UnityEngine.Input
Transform = CS.UnityEngine.Transform

UIManager = require 'UIManager'
local speed = 1000
local r = CS.UnityEngine.Vector3.up * CS.UnityEngine.Time.deltaTime * speed
local c = GameObject.Find("Cube")
local function Main()
    print("Main Func Run")
end

Main()
function Update()
    c.transform:Rotate(r)
end

function LateUpdate()
    --print("lua LateUpdate Run")
end

function FixedUpdate()
    --print("lua FixedUpdate Run")
end
--监控_G
local mt = {}

mt.__index = function(t, k)
    print("正在调用不存在的全局变量--", k)
    return rawget(t, k)
end

mt.__newindex = function(t, k, v)
    print("此处定义了全局变量--", k, debug.traceback())
    rawset(t, k, v)
end

setmetatable(_G, mt)