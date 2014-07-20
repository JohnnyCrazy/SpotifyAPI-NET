using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SpotifyAPI_Example
{
    public class API
    {
        [DllImport("API.dll", EntryPoint = "API_AddChatMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_AddChatMessage(UInt32 color, string text);
        [DllImport("API.dll", EntryPoint = "API_GetChatLine", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_GetChatLine(int line, ref String text);
        [DllImport("API.dll", EntryPoint = "API_BoxCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_BoxCreate(int x, int y, int width, int height, UInt32 color, Boolean show);
        [DllImport("API.dll", EntryPoint = "API_BoxSetPos", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_BoxSetPos(int id, int x, int y);
        [DllImport("API.dll", EntryPoint = "API_BoxSetWidth", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_BoxSetWidth(int id, int width);
        [DllImport("API.dll", EntryPoint = "API_BoxSetHeight", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_BoxSetHeight(int id, int height);
        [DllImport("API.dll", EntryPoint = "API_BoxSetBorderColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_BoxSetBorderColor(int id, UInt32 color);
        [DllImport("API.dll", EntryPoint = "API_BoxShow", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_BoxShow(int id);
        [DllImport("API.dll", EntryPoint = "API_DestroyAllVisual", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_DestroyAllVisual();
        [DllImport("API.dll", EntryPoint = "API_BoxSetColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_BoxSetColor(int id, UInt32 color);
        [DllImport("API.dll", EntryPoint = "API_TextCreate", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_TextCreate(String Font, int size, Boolean italic, Boolean bold, int x, int y, UInt32 color, String text, Boolean show);
        [DllImport("API.dll", EntryPoint = "API_TextSetString", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_TextSetString(int id, String text);
        [DllImport("API.dll", EntryPoint = "API_TextSetColor", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_TextSetColor(int id, UInt32 color);
        [DllImport("API.dll", EntryPoint = "API_TextSetShown", CallingConvention = CallingConvention.Cdecl)]
        public static extern int API_TextSetShown(int id, Boolean show);
    }
}
