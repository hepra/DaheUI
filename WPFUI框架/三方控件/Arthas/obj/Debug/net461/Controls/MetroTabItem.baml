   M S B A M L   `   `   `  ����A  =Arthas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Arthas.ControlsArthas.Controls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source"    Arthas.Controls.MetroTabItem �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard	 �� 
TargetName
 �� TargetProperty	 �� To g� Duration	 t� To	 W� To ��Name �Name � ColumnDefinitions ��Name ��Name    Icon J� Opacity$   Arthas.Controls.MetroTextBlock  Name �� Triggers P� Property P� Value �� 
TargetName�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      'Metroclr-namespace:Arthas.Controls  5        5      �� 5   
   $/ )/Arthas;component/Controls/MetroBase.xaml?�6   %�  '         �� 5      "   6   .�5	   
   ��  �@�FocusVisualStyle 6-   Z� �� 5
   
    �@J�SnapsToDevicePixels$
 True��60   �� 5   
    � ��$ -1,0,0,0q�6#   �� 5   
    � ��$ 80��6%   �� 5   
    � �� 5      �� 5      "   6"   .R�5      � $��38��6   ���	#00000000 5        5      CommonStates��. 5   "     
Normal��6.     5   "   	MouseOver��. 5   &   �� .��5   *   �� $	 border��69   $1
 +(Border.Background).(SolidColorBrush.Color)�6X    #f3f3f36�   $ 0:0:0.1D�6�   t� 5   *   $	 border��6=   $
 (Margin)�6\    0,7,0,06�   $ 0:0:0.1D�6�   t� 5   *   $	 border1��6=   $
 (Margin)�6]    0,0,0,-16�   $ 0:0:0.1D�6�   W� 5   *   $	 title��6:   $
 (UIElement.Opacity)�6X    0.656�   $ 0:0:0.1D�6�   5   '   5   #     5   "   Pressed��6.     5   "   Disabled��6.   5      .+�5       �� $ border��6!   $��0,13,0,1q�61   ���#e7e7e7$��1,1,1,0q�6X   ���#dadada._�5!      � $ border1��6#   $��Center=�64    5"   "   �� 5#   &   $ 	iconWidth��67   $
��Auto �6J   �� 5$   &   $
��Auto �67   .+�5&   "   �� $
 icon��6(   $��0��66   $��12��6F   $��12��6Q   $��	10,0,-5,0q�6]   $��Center=�6p   #��z 6�   $	 0.7Q�6�     5'   "   $ title��67   $��1��6F   #��z��6V   $��Center=�6v   $
��10,0q�6�   $	 0.5Q�6�   5(      5)      5*       5+      P� 5,       �@��
IsSelected$
 True��6A   . �5-      �� $ border��6;    � �� �#f3f3f36O   �� 5.      $ border��67    � ��$ 0,7,0,0q�6K   �� 5/      $ border1��67    � ��$ 0,0,0,-1q�6L   �� 50      $ title��68    �@J�Opacity$
 0.65Q�6K   �� 51      $
 icon��68    �@J�Opacity$ 1Q�6J   52      P� 53       62   Z�  �@  Icon. �54      �� $ 	iconWidth��66    � ��$ 0 �6M   55      57      59      5:      5;      