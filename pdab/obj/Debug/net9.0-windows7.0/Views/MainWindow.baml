   M S B A M L   `   `   `  ����?  ;pdab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:pdab.Views
pdab.Views  5   	       pdab.Views.MainWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   'vmclr-namespace:pdab.Views     5   	     � Title$  Sea Logistics��5   	   $	��300��6   $	��300��6,    � WindowState$ 	Maximized=�68    � 	Resources 5       �� Source�� 5   
   $ MainWindowResources.xaml?�6   %    .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   o� $��0��6   $��0��6   $��4��6,   $��5q�6@   $��0q�6L   ���#003B6F
�������.@�5      m� $��_File��6   m� 5      $��_View��6   .@�5      m� $��	All Ships��6   
���   �6.   m� 5      $��New Ship��6   
���   �6-   5      m� 5      $��Actions��6   m� 5      $
��Help��6   5      c� 5   
   $��0��6   $��1��6"   $��2��6/   $��0q�6C   ���#004C8C
�������.@�5      �� $
��🏠��6    � ToolTip$ 	Main page��6"   ��66   �� *NavigateHomeCommand+�� 5       $	��⚓��6   $ Fleet��6!   ��61   �� *NavigateFleetCommand+�� 5!      $
��📦��6   $ Cargo��6"   ��62   �� *NavigateCargoCommand+�� 5"      $
��👥��6   $
 Crew��6"   ��61   �� *NavigateCrewCommand+5#      �� 5$   
   $��2��6   $��0��6   ���#EAF4FC���#003B6F$��1q�6Y   ._�5%      �� $��Actions��5&         CommandsTemplate#��[  5(        MainHCCStyle#��[ 5)      ��5'      ��  �� Path$ Commands�5)      5+      �� 5,   
   $��2��6   $��1��6   
�������._�5-      �� $��	Workspace��5.        WorkspacesTemplate#��[ 50      #��[ 51      ��5/      �� $ 
Workspaces�51      54      �� 56   
   $��3��6   $��0��6!   $��2��61   ���#003B6F
�������.@�57      �� .��58      �� © 2024 Sea Logistics System69   59      5:      5<      5=      