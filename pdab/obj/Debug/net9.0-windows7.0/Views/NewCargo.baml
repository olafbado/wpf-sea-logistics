   M S B A M L   `   `   `  ����?  ;pdab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:pdab.Views
pdab.Views  5          pdab.Views.NewCargo   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:pdab.Views     5      .��5	      � 
�������  � ColumnDefinitions  5
   
   �� 5      $	��150 �6   �� 5      $	��200 �6   �� 5      $��50 �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   .+�5   
   �� $��0��6   $��0��6    $��0,8,0,8q�6-   $��Description��6>   �� 5   
   $��1��6   $��0��6"   $��0,8,0,8q�6/   ��6@   �� *Description+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�    =� ErrorTemplate 5      �� 5      .R�5      �� .+�5      ��  ��Name$ textBox��64   �� 5      
���  ����6$   �� *[0].ErrorContent+6F   5      5       .��5!   (   5"      �� 5$   
   $��0��6   $��1��6    $��0,8,0,8q�6-   $��Weight��6>   �� 5&   
   $��1��6   $��1��6"   $��0,8,0,8q�6/   ��6@   �� *Weight+$ PropertyChanged=�.��6}    5'      �� 5(      .R�5)      �� .+�5+      �� $ textBox��64   �� 5,      
���  ����6$   �� *[0].ErrorContent+6F   5-      5.      .��5/   (   50      �� 52   
   $��0��6   $��2��6    $��0,8,0,8q�6-   $
��Type��6>   �� 53   
   $��1��6   $��2��6#   $��0,8,0,8q�60    �� DisplayMemberPath$ Value��55       �� SelectedValuePath$	 Key��56      ��54      �� *CargoTypesItems+ �� SelectedValue 57      ��  �� Path$ CargoTypeId�	 �� Mode$	 TwoWay=�59      5:      