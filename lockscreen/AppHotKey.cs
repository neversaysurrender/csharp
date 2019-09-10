﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace lockscreen
{
    class AppHotKey
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,                //要定义热键的窗口的句柄  
            int id,                     //定义热键ID（不能与其它ID重复）            
            KeyModifiers fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效  
            Keys vk                     //定义热键的内容  
            );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //要取消热键的窗口的句柄  
            int id                      //要取消热键的ID  
            );

        //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）  
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }

        public static void RegKey(IntPtr hwnd, int hotKey_id, KeyModifiers keyModifiers, Keys key)
        {
            try
            {
                if (!RegisterHotKey(hwnd, hotKey_id, keyModifiers, key))
                {
                    if (Marshal.GetLastWin32Error() == 1409)
                        Console.WriteLine("热键被占用 ！");
                    else
                        Console.WriteLine("注册热键失败！");
                }
            }
            catch (Exception) { }
        }

        public static void UnRegKey(IntPtr hwnd, int hotKey_id)
        {
            UnregisterHotKey(hwnd, hotKey_id);
        }
    }
}
