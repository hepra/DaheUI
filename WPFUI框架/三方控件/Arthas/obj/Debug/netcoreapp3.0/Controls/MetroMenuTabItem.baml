   M S B A M L   `   `   `  ����A  =Arthas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Arthas.ControlsArthas.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source&     Arthas.Controls.MetroMenuTabItem �� 
TargetType �� Property �� Value �� 
TargetType � ColumnDefinitions ��Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup	   States   System.Windows.VisualState
   
Storyboard �� 
TargetName �� TargetProperty	 W� To g� Duration	 �� To ��Name J� Opacity ��Name    IconMove    Icon$   Arthas.Controls.MetroTextBlock  Name    TextHorizontalAlignment �� Triggers P� Property P� Value �� 
TargetName�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      'Metroclr-namespace:Arthas.Controls  5        5      �� 5   
   $/ )/Arthas;component/Controls/MetroBase.xaml?�6   %�  '         �� 5      "   6   .�5	   
   ��  �@�FocusVisualStyle 6-   Z� �� 5
   
    �@J�SnapsToDevicePixels$
 True��60   �� 5   
    � ��$	 150��6%   �� 5   
    � �� 5      �� 5      "   6"   .R�5      � ���	#00000000 5      �� 5      $ 	iconWidth��6/   $
��Auto �6B   �� 5      $ contentWidth��6/    5        5      CommonStates��.	 5   "     
Normal��6.     5   "   	MouseOver��.
 5   &   �� .��5   *   W� $
 back��6:   $ (UIElement.Opacity)�6W    16�   $ 0:0:0.2D�6�   �� 5   *   $ title��69   $4 .(TextBlock.Foreground).(SolidColorBrush.Color)�6W    	#A50000006�   $ 0:0:0.2D�6�   W� 5   *   $
 icon��6:   $ (UIElement.Opacity)�6W    06�   $ 0:0:0.2D�6�   W� 5   *   $ iconMove��6:   $ (UIElement.Opacity)�6[    16�   $ 0:0:0.2D�6�   5   '   5   #     5    "   Pressed��6.     5!   "   Disabled��6.   5"      .+�5$      �� $
 back��6$   $��2��62   ���#f3f3f3$ 0Q�6U   �� 5%      $ iconMove��6    $��24��62   $��24��6=   $
��10,8q�6I   #��z 6W   $ 0Q�6{   �� 5&      $
 icon��6    $��24��6.   $��24��69   $
��10,8q�6E   #��z 6S     5'      $ title��6/   $��2��6>   #��z��6N   ���	#E5FFFFFF$��0,0,15,0q�6�   $��Center=�6�   #��z 6�   5(       5)      P� 5*       �@��
IsSelected$
 True��6A   . �5+      �� $
 back��6%    �@J�Opacity$ 1Q�6J   �� 5,      $ title��6%    � �� �	#A50000006N   �� 5-      $
 icon��6%    �@J�Opacity$ 0Q�6J   �� 5.      $ iconMove��6%    �@J�Opacity$ 1Q�6N   5/      58      5:      5;      5<      