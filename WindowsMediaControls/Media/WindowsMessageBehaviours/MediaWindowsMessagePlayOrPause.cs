using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using WindowsMediaControls.Media.Behavirours;

namespace WindowsMediaControls.Media.WindowsMessageBehaviours
{
    public class MediaWindowsMessagePlayOrPause : IMediaPlayOrPause
    {
      
        //private const int HWND_BROADCAST = 0xFFFF;
        public void PlayOrPause()
        {
          
           // var hWnd = new WindowInteropHelper(Application.Current.MainWindow).Handle;
            Win32Api.WIN32_SendMessage(Win32Api.GethWnd(), (uint)Win32Api.WM.WM_APPCOMMAND, IntPtr.Zero, (int)AppCommands.APPCOMAND_PLAY_OR_PAUSE);
        }
    }
}
