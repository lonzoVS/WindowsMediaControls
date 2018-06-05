using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsMediaControls.Media.WindowsMessageBehaviours
{
    public static class Win32Api
    {

            [DllImport("user32.dll")]
            private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();
            
            // ¯\_(ツ)_/¯
            public static IntPtr GethWnd()
            {
                return GetForegroundWindow(); 
            }

            public enum WM : uint
            {
                 WM_APPCOMMAND = 0x319,
            }
        
            public static int WIN32_SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, int lParam)
            {
                return (int)SendMessage(hWnd, Msg, wParam, (IntPtr)(lParam << 16));
            }
    }
}

