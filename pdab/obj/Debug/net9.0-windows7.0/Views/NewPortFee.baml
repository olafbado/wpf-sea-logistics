   M S B A M L   `   `   `  ����?  ;pdab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:pdab.Views
pdab.Views  5          pdab.Views.NewPortFee   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:pdab.Views     5      .��5	      � 
�������  � ColumnDefinitions  5
   
   �� 5      $	��150 �6   �� 5      $	��200 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   .+�5   
   �� $��0��6   $��0��6    $��0,8,0,8q�6-   $
��Port��6>   �� 5   
   $��1��6   $��0��6#   $��0,8,0,8q�60    �� DisplayMemberPath$ Value��5       �� SelectedValuePath$	 Key��5      ��5      �� *	PortItems+ �� SelectedValue 5      ��  �� Path$ PortId� �� Mode$ TwoWay=��� 5   
   $��0��6   $��1��6    $��0,8,0,8q�6-   $
��Ship��6>   �� 5   
   $��1��6   $��1��6#   $��0,8,0,8q�60   $ Value��5      $	 Key��5       ��5      �� *	ShipItems+ 5!      �� $ ShipId�$ TwoWay=��� 5$   
   $��0��6   $��2��6    $��0,8,0,8q�6-   $��Amount��6>   �� 5%   
   $��1��6   $��2��6"   $��0,8,0,8q�6/   ��6@   �� $ Amount� �� UpdateSourceTrigger$ PropertyChanged=��� 5(   
   $��0��6   $��3��6    $��0,8,0,8q�6-   $
��Date��6>   (  "System.Windows.Controls.DatePicker  5)      $��1��6   $��3��6)   $��0,8,0,8q�66      SelectedDate 6G   �� $
 Date�$ PropertyChanged=�5*      5+      