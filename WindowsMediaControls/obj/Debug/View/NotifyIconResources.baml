   M S B A M L   `   `   `  ����O  KWindowsMediaControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WindowsMediaControls.ViewWindowsMediaControls.View  5      O,clr-namespace:WindowsMediaControls.ViewModelWindowsMediaControls.ViewModel  5      Q-clr-namespace:WindowsMediaControls.ConvertersWindowsMediaControls.Converters  5      Q-clr-namespace:WindowsMediaControls.PropertiesWindowsMediaControls.Properties  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F BNHotkey.Wpf, Version=1.2.1.0, Culture=neutral, PublicKeyToken=nullW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null   SysTrayMenu  m� Command3   -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  
NotifyIcon    
IconSource    ToolTipText � ContextMenu � 	Resources2   ,WindowsMediaControls.Converters.KeyConverter  Key7   1WindowsMediaControls.Converters.ModifierConverter � DataContext8   2WindowsMediaControls.ViewModel.NotifyIconViewModel J� InputBindings
 �� Key.  (WindowsMediaControls.Properties.Settings   Default	 �� Source
 �� Path  KeyConverter �� 	Converter �� 	Modifiers  ModifierConverter �� Command  NHotkey.Wpf.HotkeyManager   RegisterGlobalHotkey�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      1local'clr-namespace:WindowsMediaControls.View  5      )tb http://www.hardcodet.net/taskbar  5      ;
viewModels,clr-namespace:WindowsMediaControls.ViewModel  5      <
converters-clr-namespace:WindowsMediaControls.Converters  5      <
properties-clr-namespace:WindowsMediaControls.Properties  5      %6  &	       &	 �     7   7  7  7  7  7  7  7  7  7  7  7  7  7  7  �� 5	      .@�5
   
   m� $��Settings��6     6%   �� *
Settings+�� 5   
   m� 5   
   $
��Exit��6     6!   �� *ExitApplication+5         5      $ /icon/NotifyIcon.ico��5      $3 -Double-click for window, right-click for menu��5      8    5   
   ��  5      KeyConverter 6&     5      ModifierConverter 6+   5       5   
     5       5   
   �� 5       6   �� #	 Z $
 PlayPauseGesture�8   5      �� #	 Z $
 PlayPauseGesture�8   5      �� *	PlayPause+ 5       �� #	 Z $
 GesturesEnabled��� 5!       6   �� #	 Z $
 StopGesture�8   5"      �� #	 Z $
 StopGesture�8   5#      �� *Stop+ 5$      �� #	 Z $
 GesturesEnabled��� 5%       6   �� #	 Z $
 ForwardGesture�8   5&      �� #	 Z $
 ForwardGesture�8   5'      �� *	Forward+ 5(      �� #	 Z $
 GesturesEnabled��� 5)       6   �� #	 Z $
 BackwardGesture�8   5*      �� #	 Z $
 BackwardGesture�8   5+      �� *
Backward+ 5,      �� #	 Z $
 GesturesEnabled��� 5-       6   �� #	 Z $
 MuteGesture�8 	  5.      �� #	 Z $
 MuteGesture�8 
  5/      �� *Mute+ 50      �� #	 Z $
 GesturesEnabled��� 51       6   �� #	 Z $
 PlusVolumeGesture�8   52      �� #	 Z $
 PlusVolumeGesture�8   53      �� *
VolumeUp+ 54      �� #	 Z $
 GesturesEnabled��� 55       6   �� #	 Z $
 MinusVolumeGesture�8   56      �� #	 Z $
 MinusVolumeGesture�8   57      �� *
VolumeDown+ 58      �� #	 Z $
 GesturesEnabled�5:      5<      