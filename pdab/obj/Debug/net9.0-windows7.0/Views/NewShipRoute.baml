   M S B A M L   `   `   `  ����?  ;pdab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:pdab.Views
pdab.Views  5          pdab.Views.NewShipRoute   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:pdab.Views     5      .��5	      � 
�������  � ColumnDefinitions  5
   
   �� 5      $	��150 �6   �� 5      $	��200 �6   �� 5      $��50 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   .+�5   
   �� $��0��6   $��0��6    $��0,8,0,8q�6-   $
��Name��6>   �� 5   
   $��1��6   $��0��6"   $��0,8,0,8q�6/   ��6@   ��  �� Path$
 Name� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��0��6   $��1��6    $��0,8,0,8q�6-   $
��Ship��6>   �� 5   
   $��1��6   $��1��6#   $��0,8,0,8q�60    �� DisplayMemberPath$ Value��5       �� SelectedValuePath$	 Key��5      ��5      �� *	ShipItems+ �� SelectedValue 5       �� $ ShipId� �� Mode$ TwoWay=��� 5#   
   $��0��6   $��2��6    $��0,8,0,8q�6-   $��Departure Date��6>   (  "System.Windows.Controls.DatePicker  5$   
   $��1��6   $��2��6%   $��0,8,0,8q�62      SelectedDate 6C   �� $ DepartureDate�$ PropertyChanged=��� 5&   
   $��0��6   $��3��6    $��0,8,0,8q�6-   $��Arrival Date��6>     5'   
   $��1��6   $��3��6%   $��0,8,0,8q�62    6C   �� $ ArrivalDate�$ PropertyChanged=��� 5)   
   $��0��6   $��4��6    $��0,8,0,8q�6-   $��Departure Port��6>   �� 50   
   $��1��6   $��4��6"   ${�False��6/   $��0,8,0,8q�6A   ��6R   �� $
 Name�$ PropertyChanged=��� 51   
   $	��...��6   $��3��6   $��4��6/   $��8,8,0,8q�6<   ��6M   �� *	ShowPorts+�� 53   
   $��0��6   $��5��6    $��0,8,0,8q�6-   $��Arrival Port��6>   �� 54   
   $��1��6   $��5��6#   $��0,8,0,8q�60   $ Value��56      $	 Key��57      ��55      �� *	PortItems+ 58      �� $ ArrivalPortId�$ TwoWay=��� 5<   
   $��0��6   $��6��6    $��0,8,0,8q�6-   $��Contract��6>   �� 5=   
   $��1��6   $��6��6#   $��0,8,0,8q�60   $ Value��5?      $	 Key��5@      ��5>      �� *ContractItems+ 5A      �� $ 
ContractId�$ TwoWay=�5C      5D      