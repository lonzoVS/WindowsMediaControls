   M S B A M L   `   `   `  ���� O  KWindowsMediaControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WindowsMediaControls.ViewWindowsMediaControls.View  O,clr-namespace:WindowsMediaControls.ViewModelWindowsMediaControls.ViewModel  Q-clr-namespace:WindowsMediaControls.ConvertersWindowsMediaControls.Converters  Q-clr-namespace:WindowsMediaControls.PropertiesWindowsMediaControls.Properties  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F BNHotkey.Wpf, Version=1.2.1.0, Culture=neutral, PublicKeyToken=nullW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null   SysTrayMenu  m� Command3   -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  
NotifyIcon    
IconSource    ToolTipText � ContextMenu � 	Resources2   ,WindowsMediaControls.Converters.KeyConverter  Key7   1WindowsMediaControls.Converters.ModifierConverter � DataContext8   2WindowsMediaControls.ViewModel.NotifyIconViewModel J� InputBindings
 �� Key.  (WindowsMediaControls.Properties.Settings   Default	 �� Source
 �� Path  KeyConverter �� 	Converter �� 	Modifiers  ModifierConverter �� Command  NHotkey.Wpf.HotkeyManager   RegisterGlobalHotkey�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     1local'clr-namespace:WindowsMediaControls.View  )tb http://www.hardcodet.net/taskbar  ;
viewModels,clr-namespace:WindowsMediaControls.ViewModel  <
converters-clr-namespace:WindowsMediaControls.Converters  <
properties-clr-namespace:WindowsMediaControls.Properties  %i  &	       &	 d     7   7  7  7  7  7  7  7  7  7  7  7  7  7  7  �� .@�m� $��Settings��  �� *
Settings+�� m� $
��Exit��  �� *ExitApplication+   $ /icon/NotifyIcon.ico��$3 -Double-click for window, right-click for menu��8    ��  KeyConverter   ModifierConverter     ��  �� #	 Z $
 PlayPauseGesture�8   �� #	 Z $
 PlayPauseGesture�8   �� *	PlayPause+ �� #	 Z $
 GesturesEnabled���  �� #	 Z $
 StopGesture�8   �� #	 Z $
 StopGesture�8   �� *Stop+ �� #	 Z $
 GesturesEnabled���  �� #	 Z $
 ForwardGesture�8   �� #	 Z $
 ForwardGesture�8   �� *	Forward+ �� #	 Z $
 GesturesEnabled���  �� #	 Z $
 BackwardGesture�8   �� #	 Z $
 BackwardGesture�8   �� *
Backward+ �� #	 Z $
 GesturesEnabled���  �� #	 Z $
 MuteGesture�8 	  �� #	 Z $
 MuteGesture�8 
  �� *Mute+ �� #	 Z $
 GesturesEnabled���  �� #	 Z $
 PlusVolumeGesture�8   �� #	 Z $
 PlusVolumeGesture�8   �� *
VolumeUp+ �� #	 Z $
 GesturesEnabled���  �� #	 Z $
 MinusVolumeGesture�8   �� #	 Z $
 MinusVolumeGesture�8   �� *
VolumeDown+ �� #	 Z $
 GesturesEnabled�