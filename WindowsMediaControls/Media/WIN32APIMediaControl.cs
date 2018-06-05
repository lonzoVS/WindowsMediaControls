using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsMediaControls.Media.WindowsMessageBehaviours;

namespace WindowsMediaControls.Media
{
    public class WIN32APIMediaControl : BasicMediaControl
    {
        public WIN32APIMediaControl()
        {
            NextTrack = new MediaWindowsMessageNext();
            PrevTrack = new MediaWindowsMessagePrev();
            Mute = new MediaWindowsMessageMute();
            PlayOrPayse = new MediaWindowsMessagePlayOrPause();
            DecreaseVolume = new MediaWindowsMessageDecreaseVolume();
            IncreaseVolume = new MediaWindowsMessageIncreaseVolume();
            Stop = new MediaWindowsMessageStop();
        }

    }
}
