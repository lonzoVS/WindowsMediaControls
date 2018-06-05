using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsMediaControls.Media.Behavirours;

namespace WindowsMediaControls.Media
{
    public abstract class BasicMediaControl
    {
        public IMediaIncreaseolume IncreaseVolume { private get; set; }
        public IMediaDecreaseVolume DecreaseVolume { private get; set; }
        public IMediaMute Mute { private get; set; }
        public IMediaNext NextTrack { private get; set; }
        public IMediaPrev PrevTrack { private get; set; }
        public IMediaStop Stop { private get; set; }
        public IMediaPlayOrPause PlayOrPayse { private get; set; }

        virtual public void DoVolumeUp()
        {
            IncreaseVolume.AddVolume();
        }

        virtual public void DoVolumeDown()
        {
            DecreaseVolume.DecreaseVolume();
        }

        virtual public void DoMute()
        {
            Mute.MuteVolume();
        }

        virtual public void DoNextTrack()
        {
            NextTrack.NextTrack();
        }

        virtual public void DoPrevTrack()
        {
            PrevTrack.PreviousTrack();
        }

        virtual public void DoPlayOrPause()
        {
            PlayOrPayse.PlayOrPause();
        }

        virtual public void DoStop()
        {
            Stop.Stop();
        }

    }
}
