using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;
using WindowsMediaControls.Media;



namespace WindowsMediaControls.ViewModel
{
    public class MediaControlViewModel : INotifyPropertyChanged
    {



        #region Properties
   


        private KeyGesture _playPauseGesture = new KeyGesture(Key.A, ModifierKeys.Alt);
        public KeyGesture PlayGesture
        {
            get { return _playPauseGesture; }
            set
            {
                _playPauseGesture = value;
                OnPropertyChanged("PlayGesture");
            }
        }

        private bool _isStopFocused;
        public bool IsStopFocused
        {
            get { return _isStopFocused; }
            set
            {
                _isStopFocused = value;
                OnPropertyChanged("IsStopFocused");
            }
        }
        private bool _isPlayFocused;
        public bool IsPlayFocused
        {
            get { return _isPlayFocused; }
            set
            {
                _isPlayFocused = value;
                OnPropertyChanged("IsPlayFocused");
            }
        }
        private bool _isForwardFocused;
        public bool IsForwardFocused
        {
            get { return _isForwardFocused; }
            set
            {
                _isForwardFocused = value;
                OnPropertyChanged("IsForwardFocused");
            }
        }
        private bool _isBackwardFocused;
        public bool IsBackwardFocused
        {
            get { return _isBackwardFocused; }
            set
            {
                _isBackwardFocused = value;
                OnPropertyChanged("IsBackwardFocused");
            }
        }
        private bool _isPlusVolumeFocused;
        public bool IsPlusVolumeFocused
        {
            get { return _isPlusVolumeFocused; }
            set
            {
                _isPlusVolumeFocused = value;
                OnPropertyChanged("IsPlusVolumeFocused");
            }
        }
        private bool _isMinusVolumeFocused;
        public bool IsMinusVolumeFocused
        {
            get { return _isMinusVolumeFocused; }
            set
            {
                _isMinusVolumeFocused = value;
                OnPropertyChanged("IsMinusVolumeFocused");
            }
        }
        private bool _isMuteFocused;
        public bool IsMuteFocused
        {
            get { return _isMuteFocused; }
            set
            {
                _isMuteFocused = value;
                OnPropertyChanged("IsMuteFocused");
            }
        }

        #endregion

        public RelayCommand EnableGestures { get; private set; }
        public RelayCommand SetStop { get; private set; }
        public RelayCommand Forward { get; private set; }
        public RelayCommand Backward { get; private set; }
        public RelayCommand Mute { get; private set; }
        public RelayCommand PlayPause { get; private set; }
        public RelayCommand PlusVolume { get; private set; }
        public RelayCommand MinusVolume { get; private set; }

        public RelayCommand<Window> CloseWindow { get; private set; }
        public RelayCommand<EventArgs> PlayPausePreviewKeyDown { get; private set; }
        public RelayCommand<EventArgs> StopPreviewKeyDown { get; private set; }
        public RelayCommand<EventArgs> VolumeUpPreviewKeyDown { get; private set; }
        public RelayCommand<EventArgs> VolumeDownPreviewKeyDown { get; private set; }
        public RelayCommand<EventArgs> MutePreviewKeyDown { get; private set; }
        public RelayCommand<EventArgs> ForwardPreviewKeyDown { get; private set; }
        public RelayCommand<EventArgs> BackwardPreviewKeyDown { get; private set; }

        public RelayCommand<MouseButtonEventArgs> WindowMouseDown { get; private set; }

        public RelayCommand Startup { get; private set; }

        public MediaControlViewModel()
        {
            Startup = new RelayCommand(OnStartUp);
            CloseWindow = new RelayCommand<Window>((Window obj) => { obj?.Close(); Application.Current.MainWindow = null; });
            EnableGestures = new RelayCommand(OnEnanbleGestures);
            PlayPausePreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.PlayPauseGesture)));
            StopPreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.StopGesture)));
            VolumeUpPreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.PlusVolumeGesture)));
            VolumeDownPreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.MinusVolumeGesture)));
            MutePreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.MuteGesture)));
            ForwardPreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.ForwardGesture)));
            BackwardPreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.BackwardGesture)));

            SetStop = new RelayCommand(() => IsStopFocused = true);
            Forward = new RelayCommand(() => IsForwardFocused = true);
            Backward = new RelayCommand(() => IsBackwardFocused = true);
            Mute = new RelayCommand(() => IsMuteFocused = true);
            PlayPause = new RelayCommand(() => IsPlayFocused = true);
            PlusVolume = new RelayCommand(() => IsPlusVolumeFocused = true);
            MinusVolume = new RelayCommand(() => IsMinusVolumeFocused = true);
            WindowMouseDown = new RelayCommand<MouseButtonEventArgs>(OnWindowMouseDown);
           

        }

        private void OnStartUp()
        {
            Properties.Settings.Default.Save();
            bool isChecked = Properties.Settings.Default.IsStartup;

            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                var wpfAssembly = (AppDomain.CurrentDomain
                                .GetAssemblies()
                                .Where(item => item.EntryPoint != null)
                                .Select(item =>
                                    new { item, applicationType = item.GetType(item.GetName().Name + ".App", false) })
                                .Where(a => a.applicationType != null && typeof(Application)
                                    .IsAssignableFrom(a.applicationType))
                                    .Select(a => a.item))
                                .FirstOrDefault();
                rk.SetValue("WindowsMediaControl", wpfAssembly.Location);
            }
            else
            {
                rk.DeleteValue("WindowsMediaControl", false);
            }
        }

        private void OnEnanbleGestures()
        {
            Properties.Settings.Default.GesturesEnabled = (Properties.Settings.Default.GesturesEnabled) ? false : true;
            Properties.Settings.Default.Save();
        }

        private void OnWindowMouseDown(MouseButtonEventArgs e)
        {
            var er = e.Source as Window;
            er?.DragMove();
        }



        private void SaveKeybinding(EventArgs m, string nameOfSetting)
        {
            var e = (m != null) ? (KeyEventArgs)m : null;
            e.Handled = true;
            Key key = (e.Key == Key.System ? e.SystemKey : e.Key);

            if (CanGetShortcut(Properties.Settings.Default.PlayPauseGesture, key))
            {
                Properties.Settings.Default.GesturesEnabled = false;
                Properties.Settings.Default.Save();
                Properties.Settings.Default[nameOfSetting] = GetShortcut(key);
                Properties.Settings.Default.Save();
                Properties.Settings.Default.GesturesEnabled = true;
                Properties.Settings.Default.Save();
            }
            else
                return;
        }


        private string GetShortcut(Key key)
        {
            StringBuilder shortcutText = new StringBuilder();
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                shortcutText.Append("Ctrl+");
            }
            if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0)
            {
                shortcutText.Append("Shift+");
            }
            if ((Keyboard.Modifiers & ModifierKeys.Alt) != 0)
            {
                shortcutText.Append("Alt+");
            }
            return shortcutText.Append(key.ToString()).ToString();
        }
        private bool CanGetShortcut(string gesture, Key key)
        {
            // Ignore modifier keys.
            if (key == Key.LeftShift || key == Key.RightShift
                || key == Key.LeftCtrl || key == Key.RightCtrl
                || key == Key.LeftAlt || key == Key.RightAlt
                || key == Key.LWin || key == Key.RWin)
            {
                return false;
            }
            else if (key == Key.Escape)
            {
                UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
                
                FocusNavigationDirection focusDirection = FocusNavigationDirection.Down;

                // MoveFocus takes a TraveralReqest as its argument.
                TraversalRequest request = new TraversalRequest(focusDirection);
                // Change keyboard focus.
                if (elementWithFocus != null)
                {
                    elementWithFocus.MoveFocus(request);
                }
                return false;
            }
            else if (key == Key.Delete)
            {
                TextBox elementWithFocus = Keyboard.FocusedElement as TextBox;
                if (elementWithFocus != null)
                {
                    Properties.Settings.Default.GesturesEnabled = false;
                    elementWithFocus.Text = "";
                    Properties.Settings.Default.Save();
                }
                return false;
            }
            else
                return true;
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
