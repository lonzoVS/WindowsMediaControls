using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;
using WindowsMediaControls.Media;

namespace WindowsMediaControls.ViewModel
{
    public class NotifyIconViewModel : INotifyPropertyChanged
    {

        private BasicMediaControl _mediaControl = new WIN32APIMediaControl(); //make DI later
        public RelayCommand PlayPause { get; private set; }
        public RelayCommand Stop { get; private set; }
        public RelayCommand Mute { get; private set; }
        public RelayCommand VolumeUp { get; private set; }
        public RelayCommand VolumeDown { get; private set; }
        public RelayCommand Forward { get; private set; }
        public RelayCommand Backward { get; private set; }

        public RelayCommand ExitApplication { get; private set; }

        public RelayCommand Settings { get; private set; }

        public NotifyIconViewModel()
        {
            PlayPause = new RelayCommand(OnPlayPause);
            Stop = new RelayCommand(OnStop);
            Mute = new RelayCommand(OnMute);
            VolumeDown = new RelayCommand(OnVolumeDown);
            VolumeUp = new RelayCommand(OnVolumeUp);
            Forward = new RelayCommand(OnForward);
            Backward = new RelayCommand(OnBackward);
            ExitApplication = new RelayCommand(OnExitApplication);
            Settings = new RelayCommand(OnSettings);
        }



        private void OnSettings()
        {
            if (Application.Current.MainWindow == null)
                Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();

        }

        private void OnExitApplication()
        {
            Application.Current.Shutdown();
        }

        private void OnBackward()
        {
            _mediaControl.DoPrevTrack();
        }

        private void OnForward()
        {
            _mediaControl.DoNextTrack();
        }

        private void OnVolumeUp()
        {
            _mediaControl.DoVolumeUp();
        }

        private void OnVolumeDown()
        {
            _mediaControl.DoVolumeDown();
        }

        private void OnMute()
        {
            _mediaControl.DoMute();
        }

        private void OnStop()
        {
            _mediaControl.DoStop();
        }

        private void OnPlayPause()
        {
            _mediaControl.DoPlayOrPause();

        }


        #region INPC-related code

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
