using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using WindowsMediaControls.Media.Behavirours;

namespace WindowsMediaControls.Media.WindowsMessageBehaviours
{
    public class MediaWindowsMessageDecreaseVolume : IMediaDecreaseVolume
    {
        public void DecreaseVolume()
        {
            
            Win32Api.WIN32_SendMessage(Win32Api.GethWnd(), (uint)Win32Api.WM.WM_APPCOMMAND, Win32Api.GethWnd(), (int)AppCommands.APPCOMMAND_INCREASE_VOLUME);
        }
    }
}
