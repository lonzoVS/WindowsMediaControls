using GalaSoft.MvvmLight;
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
    public class MediaControlViewModel : ViewModelBase
    {



        #region Properties
   
        private bool _isStopFocused;
        public bool IsStopFocused
        {
            get => _isStopFocused;
            set => Set(ref _isStopFocused, value);
            
        }
        private bool _isPlayFocused;
        public bool IsPlayFocused
        {
            get => _isPlayFocused;
            set => Set(ref _isPlayFocused, value);
        }
        private bool _isForwardFocused;
        public bool IsForwardFocused
        {
            get => _isForwardFocused;
            set => Set(ref _isForwardFocused, value);
        }
        private bool _isBackwardFocused;
        public bool IsBackwardFocused
        {
            get => _isBackwardFocused;
            set => Set(ref _isBackwardFocused, value);
        }
        private bool _isPlusVolumeFocused;
        public bool IsPlusVolumeFocused
        {
            get => _isPlusVolumeFocused;
            set => Set(ref _isPlusVolumeFocused, value);
        }
        private bool _isMinusVolumeFocused;
        public bool IsMinusVolumeFocused
        {
            get => _isMinusVolumeFocused;
            set => Set(ref _isMinusVolumeFocused, value);
        }
        private bool _isMuteFocused;
        public bool IsMuteFocused
        {
            get => _isMuteFocused;
            set => Set(ref _isMuteFocused, value);
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
            CloseWindow = new RelayCommand<Window>((Window obj) => { obj?.Close(); Application.Current.MainWindow = null; }, keepTargetAlive: true);
            EnableGestures = new RelayCommand(OnEnanbleGestures);
            PlayPausePreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.PlayPauseGesture)), keepTargetAlive: true);
            StopPreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.StopGesture)), keepTargetAlive: true);
            VolumeUpPreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.PlusVolumeGesture)), keepTargetAlive: true);
            VolumeDownPreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.MinusVolumeGesture)), keepTargetAlive: true);
            MutePreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.MuteGesture)), keepTargetAlive: true);
            ForwardPreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.ForwardGesture)), keepTargetAlive: true);
            BackwardPreviewKeyDown = new RelayCommand<EventArgs>((EventArgs e) => SaveKeybinding(e, nameof(Properties.Settings.Default.BackwardGesture)), keepTargetAlive: true);

            SetStop = new RelayCommand(() => IsStopFocused = true, keepTargetAlive: true);
            Forward = new RelayCommand(() => IsForwardFocused = true, keepTargetAlive: true);
            Backward = new RelayCommand(() => IsBackwardFocused = true, keepTargetAlive: true);
            Mute = new RelayCommand(() => IsMuteFocused = true, keepTargetAlive: true);
            PlayPause = new RelayCommand(() => IsPlayFocused = true, keepTargetAlive: true);
            PlusVolume = new RelayCommand(() => IsPlusVolumeFocused = true, keepTargetAlive: true);
            MinusVolume = new RelayCommand(() => IsMinusVolumeFocused = true, keepTargetAlive: true);
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
            
            Key key = (e.Key == Key.System ? e.SystemKey : e.Key);
            
            e.Handled = true;
            if (CanGetShortcut(Properties.Settings.Default.PlayPauseGesture, key))
            {
                System.Diagnostics.Debug.WriteLine(GetShortcut(key) + " --inside");
                Properties.Settings.Default.GesturesEnabled = false;
                Properties.Settings.Default.Save();
                Properties.Settings.Default[nameOfSetting] = GetShortcut(key);
                Properties.Settings.Default.Save();
                Properties.Settings.Default.GesturesEnabled = true;
                Properties.Settings.Default.Save();
                e.Handled = false;
            }
            else
            {
                e.Handled = false;
                return;
            }
                
        }


        private string GetShortcut(Key key)
        {
            StringBuilder shortcutText = new StringBuilder();
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
            {
                shortcutText.Append("Ctrl+");
            }
            else if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0)
            {
                shortcutText.Append("Shift+");
            }
            else if ((Keyboard.Modifiers & ModifierKeys.Alt) != 0)
            {
                shortcutText.Append("Alt+");
            }
            else if(Keyboard.Modifiers == ModifierKeys.None)
            {
                return "";
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
                    Properties.Settings.Default.GesturesEnabled = true;
                }
                return false;
            }
          
           // else if (key.)
            else
                return true;
        }

    }
}
