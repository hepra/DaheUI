   M S B A M L   `   `   `  ����A  =Arthas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Arthas.ControlsArthas.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   repeatButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType  
thumbStyle'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard	 �� 
TargetName
 �� TargetProperty	 W� To g� Duration ��Name J� Opacity  thumbStyle1  scrollBarStyle J� SnapsToDevicePixels ]�Name J� IsMouseOver ]� DecreaseRepeatButton �� PageUpCommand ]� IncreaseRepeatButton �� PageDownCommand ]� Thumb  scrollBarStyle1 �� PageLeftCommand �� PageRightCommand'   !Arthas.Controls.MetroScrollViewer � RowDefinitions ��Name � ColumnDefinitions ��Name ��Name   VerticalMargin4  .System.Windows.Automation.AutomationProperties   AutomationId  � Cursor*! �� #ComputedVerticalScrollBarVisibility" �� ScrollableHeight# � Maximum$ � Minimum% �� ViewportHeight& �� ViewportSize' � Value( �� Mode) �� RelativeSource*   HorizontalMargin,+ �� %ComputedHorizontalScrollBarVisibility, �� ScrollableWidth- �� ViewportWidth. �� Orientation/ �� Triggers0 P� Property1 P� Value2 �� 
TargetName3 ]� 
Conditions4 �� Property5 �� Value�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      'Metroclr-namespace:Arthas.Controls  5        5      �� 5   
   $/ )/Arthas;component/Controls/MetroBase.xaml?�6   %�  &	        &	 �     &	 L    &	 �    7   7   7  &	 �    7   7   7  '      7  7  �� 5      " ��6&   .�5	   
   ��  �@J�SnapsToDevicePixels$
 true��60   �� 5
   
    � �� 5      �� 5      " ��6"   .R�5      �� ���	#000000006    5      5      5      �� 5      " n�6   .�5   
   ��  �@J�SnapsToDevicePixels$
 true��60   �� 5   
    �@�FocusVisualStyle 6-   Z� �� 5   
    � �� 5      �� 5      " n�6"   .R�5      � ���	#00000000 5        5      CommonStates��. 5   "     
Normal��. 5   &   �� .��5   *   W� $
	 rect��6:   $
 (UIElement.Opacity)�6W    0.36�   $ 0:0:0.1D�6�   W� 5   *   $
	 rect��6:   $
 (Rectangle.Width)�6W    106�   $ 0:0:0.1D�6�   5   '   5    #     5!   "   	MouseOver��. 5"   &   �� .��5#   *   W� $
	 rect��6:   $
 (UIElement.Opacity)�6W    0.36�   $ 0:0:0.1D�6�   W� 5$   *   $
	 rect��6:   $
 (Rectangle.Width)�6W    106�   $ 0:0:0.1D�6�   5%   '   5&   #     5'   "   Pressed��. 5(   &   �� .��5)   *   W� $
	 rect��6:   $
 (UIElement.Opacity)�6W    0.16�   $ 0:0:0.1D�6�   W� 5*   *   $
	 rect��6:   $
 (Rectangle.Width)�6W    106�   $ 0:0:0.1D�6�   5+   '   5,   #     5-   "   Disabled��. 5.   &   �� .��5/   *   W� $
	 rect��6:   $
 (UIElement.Opacity)�6W    0.26�   $ 0:0:0.1D�6�   W� 50   *   $
	 rect��6:   $
 (Rectangle.Width)�6W    36�   $ 0:0:0.1D�6�   51   '   52   #   53      .+�55      �� $
 rect��6$   #��z��62   $	 0.2Q�6W   $��0��6e   $��Right=�6o   56      57      59      5:      �� 5;      " n�6    .�5<   
   ��  �@J�SnapsToDevicePixels$
 true��60   �� 5=   
    �@�FocusVisualStyle 6-   Z� �� 5>   
    � �� 5?      �� 5@      " n�6"   .R�5A      � ���	#00000000 5B        5C      CommonStates��. 5D   "     
Normal��. 5E   &   �� .��5F   *   W� $
	 rect��6:   $
 (UIElement.Opacity)�6W    0.36�   $ 0:0:0.1D�6�   W� 5G   *   $
	 rect��6:   $
 (Rectangle.Height)�6W    106�   $ 0:0:0.1D�6�   5H   '   5I   #     5J   "   	MouseOver��. 5K   &   �� .��5L   *   W� $
	 rect��6:   $
 (UIElement.Opacity)�6W    0.36�   $ 0:0:0.1D�6�   W� 5M   *   $
	 rect��6:   $
 (Rectangle.Height)�6W    106�   $ 0:0:0.1D�6�   5N   '   5O   #     5P   "   Pressed��. 5Q   &   �� .��5R   *   W� $
	 rect��6:   $
 (UIElement.Opacity)�6W    0.16�   $ 0:0:0.1D�6�   W� 5S   *   $
	 rect��6:   $
 (Rectangle.Height)�6W    106�   $ 0:0:0.1D�6�   5T   '   5U   #     5V   "   Disabled��. 5W   &   �� .��5X   *   W� $
	 rect��6:   $
 (UIElement.Opacity)�6W    0.26�   $ 0:0:0.1D�6�   W� 5Y   *   $
	 rect��6:   $
 (Rectangle.Height)�6W    36�   $ 0:0:0.1D�6�   5Z   '   5[   #   5\      .+�5^      �� $
 rect��6$   #��z��62   $	 0.2Q�6W   $��0��6e   $��Bottom=�6p   5_      5`      5b      5c      �� 5d      " ��6#   .�5e   
   ��  �@J�SnapsToDevicePixels$
 true��60   �� 5f   
    �@�FocusVisualStyle 6-   Z� �� 5g   
    �@�ContextMenu 6(   Z� �� 5h   
    � �� 5i      �� 5j      " ��6"   .R�5k      � $
 true��6   .+�5l      ]� $ 
PART_Track��6    $
��true��64   #{�z 6O   $��1��6y    5m      �� 5n   "   #��Z 6/   8��  6\    5p      �� 5q   "   #��Z 6/   8�� 6^    5s      n� 5t   "   8�� #��z��6L   5v      5w      5x      5z      5{      �� 5|      " ��6$   .�5}   
   ��  �@J�SnapsToDevicePixels$
 true��60   �� 5~   
    �@�FocusVisualStyle 6-   Z� �� 5   
    �@�ContextMenu 6(   Z� �� 5�   
    � �� 5�      �� 5�      " ��6"   .R�5�      � $
 true��6   .+�5�      ]� $ 
PART_Track��6    $
��true��64   #{�z 6O   $��1��6y    5�      �� 5�   "   #��Z 6/   8��  6^    5�      �� 5�   "   #��Z 6/   8�� 6_    5�      n� 5�   "   8�� #��z��6M   5�      5�      5�      5�      5�      �� 5�      "  6   .�5�   
   ��  � �� �	#000000006'   �� 5�   
    � �� �#0000006(   �� 5�   
    �@�FocusVisualStyle 6-   Z� �� 5�   
    � ��$ 0q�6$   �� 5�   
    � ��$
 Auto=�68   �� 5�   
    � ��$
 Auto=�6:   �� 5�   
    �@ Float$
 True��6"   �� 5�   
    �@ AutoLimitMouse$ False��6+   �� 5�   
    �@ VerticalMargin$ 0q�6+   �� 5�   
    �@ HorizontalMargin$ 0q�6-   �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      � #��z��6    5�      �� 5�      �� 5�      $ height��6,   $��0 �6<    5�      �� 5�      �� 5�      $ width��6/   $��0 �6>   .+�5�      �� #��z��61   #��z��6U   �� 5�      $ PART_VerticalScrollBar��6$   #��z 6F   $��10��6p   $��10��6~   #��z��6�   $ VerticalScrollBar��6�   $  Arrow��6�   $��1��6�   $��0��6  #y�z! 6  ## z" 6^  $$ 0Q�6�  #& z% 6�  8��  $��Right=�6N  ' 6�  �� *VerticalOffset+$( OneWay=�) �� *TemplatedParent+6N  �� 5�      $ PART_HorizontalScrollBar��6$   #��z* 6F   $��10��6r   $��10��6�   #��z��6�   $ HorizontalScrollBar��6�   $��0��6�   $��1��6  #y�z+ 6  ## z, 6V  $$ 0Q�6�  #& z- 6�  8�� $��RightToLeft=�6G  $. 
Horizontal=�6c  $��Bottom=�6|  ' 6�  �� *HorizontalOffset+$( OneWay=�) �� *TemplatedParent+6|  5�      / 5�      P� 5�      0 �@ Float$
1 true��63   . �5�      �� $2 PART_VerticalScrollBar��6<    � ��$ 0��6`   �� 5�      $2 PART_VerticalScrollBar��69    � ��$ 0��6]   �� 5�      $2 PART_HorizontalScrollBar��6<    � ��$ 0��6b   �� 5�      $2 PART_HorizontalScrollBar��69    � ��$ 0��6_   5�      P� 5�      +0 �@��#ComputedVerticalScrollBarVisibility$1 Visible=�6Q   . �5�      �� $2 width��66    � ��$ 10 �6I   5�      P� 5�      -0 �@��%ComputedHorizontalScrollBarVisibility$1 Visible=�6S   . �5�      �� $2 height��67    � ��$ 10 �6K   5�      ]� 5�      3 5�      �� 5�   "   4 �@ Float$
5 true��6=   �� 5�   "   -4 �@��%ComputedHorizontalScrollBarVisibility$5 Visible=�6]   ./�5�      �� $2 PART_VerticalScrollBar��67    � ��$ 0,0,0,10q�6[   �� 5�      $2 height��67    � ��$ 0 �6K   5�      ]� 5�      3 5�      �� 5�   "   4 �@ Float$
5 true��6=   �� 5�   "   +4 �@��#ComputedVerticalScrollBarVisibility$5 Visible=�6[   ./�5�      �� $2 PART_HorizontalScrollBar��67    � ��$ 0,0,10,0q�6]   �� 5�      $2 width��66    � ��$ 0 �6I   5�      5�      5�      5�      5�      