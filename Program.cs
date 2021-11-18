using System;
using System.IO;
using System.Text;
using NLua;

namespace LuaInterop
{
    class Program
    {
        static void Main(string[] args)
        {
            var luaString1 =
                "luanet.load_assembly \"System\"" +
                "Console = luanet.import_type \"System.Console\"" +
                "Math = luanet.import_type \"System.Math\"" +
                "Directory = luanet.import_type \"System.IO.Directory\"" +
                "Console.WriteLine(\"we are at {0}\",Directory.GetCurrentDirectory())" +
                "Console.WriteLine(\"sqrt(2) is {0}\",Math.Sqrt(2))";

            var luaString2 = File.ReadAllText("socket.lua");

            using (Lua lua = new Lua())
            {
                lua.State.Encoding = Encoding.UTF8;
                lua.DoString(luaString2);
            }
            
            Console.WriteLine("Hello World!");
        }
    }
}
