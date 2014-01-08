using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DebugExample
{
    public class API
    {
        [DllImport("API.dll",EntryPoint = "API_AddChatMessage",CallingConvention = CallingConvention.Cdecl)]
		public static extern int API_AddChatMessage(UInt32 color,string text);
        [DllImport("API.dll", EntryPoint = "API_GetChatLine", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_GetChatLine(int line, ref String text);
        [DllImport("API.dll", EntryPoint = "API_ImageCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_ImageCreate(String path);
        [DllImport("API.dll", EntryPoint = "API_ImageShow", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_ImageShow(int id);
        [DllImport("API.dll", EntryPoint = "API_ImageDestroy", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_ImageDestroy(int id);
        [DllImport("API.dll", EntryPoint = "API_ImageSetPos", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_ImageSetPos(int id,int width,int height);
    }
}
