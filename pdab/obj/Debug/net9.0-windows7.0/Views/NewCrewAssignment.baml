   M S B A M L   `   `   `  ����?  ;pdab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:pdab.Views
pdab.Views  5      "    pdab.Views.NewCrewAssignment   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:pdab.Views     5      .��5	      � 
�������  � ColumnDefinitions  5
   
   �� 5      $	��150 �6   �� 5      $��24.158 �6   �� 5      $��175.842 �6   �� 5      $��50 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   .+�5   
   �� $��0��6   $��0��6    $��0,8,0,8q�6-   $��
Ship Route��6>   �� 5   
   $��1��6   $��0��6"   ${�False��6/   $��0,8,0,8q�6A   $��2��6�   ��6R   ��  �� Path$ ShipRouteName� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $	��...��6   $��3��6   $��0��6/   $��8,8,0,8q�6<   ��6M   �� *ShowShipRoutes+�� 5   
   $��0��6   $��1��6    $��0,8,0,8q�6-   $��Crew Member��6>   �� 5   
   $��1��6   $��1��6"   ${�False��6/   $��0,8,0,8q�6A   $��2��6�   ��6R   �� $ CrewMemberName�$ PropertyChanged=�6�   �� 5    
   $	��...��6   $��3��6   $��1��6/   $��8,8,0,8q�6<   ��6M   �� *ShowCrewMembers+5(      5)      