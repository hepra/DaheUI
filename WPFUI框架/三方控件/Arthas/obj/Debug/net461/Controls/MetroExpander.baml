   M S B A M L   `   `   `  ����A  =Arthas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Arthas.ControlsArthas.Controls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source#    Arthas.Controls.MetroExpander �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value �� 
TargetType'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty	 W� To g� Duration �� ElementName �� Path � RowDefinitions � ColumnDefinitions ��Name    Icon J� Opacity$   Arthas.Controls.MetroTextBlock    Header!   Arthas.Controls.MetroBorder   AutoCornerRadius    HintBackground    Hint    HintForeground � Points J� RenderTransformOrigin �� Angle&    Arthas.Controls.MetroFocusButton   MouseMoveForeground    BorderThickness!   MouseMoveBorderThickness" �Name# ��Name$ �� Triggers% �� 
TargetName�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      'Metroclr-namespace:Arthas.Controls  5        5      �� 5   
   $/ )/Arthas;component/Controls/MetroBase.xaml?�6   %b  '         �� 5      "   6   .�5	   
   ��  �@�FocusVisualStyle 6-   Z� �� 5
   
    �@J�SnapsToDevicePixels$
 True��60   �� 5   
    � ��$	 180��6%   �� 5   
    �@  CanHide$
 True��6$   �� 5   
    �@  
IsExpanded$ False��6'   �� 5   
    �@  Hint 6!   Z� �� 5   
    �@  HintBackground �	#7F0000006+   �� 5   
    �@  HintForeground �#FFFFFF6+    5   
   P� 5       �@  CanHide$
 True��6)   . �5      ��  � �� 5      �� 5      "   6*   .R�5      � ���	#7FFFFFFF	 5   "     5   &   .
 5   *     
Normal��. 5   .   �� .��5   2   W� $ height��6B   $ (Height)�6a    06�   $ 0:0:0.15D�6�   W� 5   2   $ angle��6B   $ (Angle)�6`    06�   $ 0:0:0.15D�6�   5   /   5    +     5!   *   StartNormal��. 5"   .   �� .��5#   2   W� $ height��6B   $ (Height)�6a    06�   $ 0:0:0D�6�   W� 5$   2   $ angle��6B   $ (Angle)�6`    06�   $ 0:0:0D�6�   5%   /   5&   +     5'   *   
Expand��. 5(   .   �� .��5)   2   W� $ height��6B   $ (Height)�6a   $ 0:0:0.15D�6�    6�   �� $ content��$ ActualHeight�6�   W� 5*   2   $ angle��6B   $ (Angle)�6`    906�   $ 0:0:0.15D�6�   5+   /   5,   +     5-   *   StartExpand��. 5.   .   �� .��5/   2   W� $ height��6B   $ (Height)�6a   $ 0:0:0D�6�    6�   �� $ content��$ ActualHeight�6�   W� 50   2   $ angle��6B   $ (Angle)�6`    906�   $ 0:0:0D�6�   51   /   52   +   53   '    55   "   �� 56   &   $
��Auto �64   �� 57   &   $
��Auto �64   .+�59   "   �� ���#e6e6e6$��0,0,0,1q�6?   ._�5:   &   �  5;   *   �� 5<   .   $ 	iconWidth��6?   $
��Auto �6R   �� 5=   .   �� 5>   .   $ 	hintWidth��6?   $
��Auto �6R   �� 5?   .   $ 
algleWidth��6?   $
��Auto �6S   .+�5A   *   �� $��12��60   $��12��6;   $��10,0,0,0q�6G   $��Center=�6Y   #��z 6t   $	 0.7Q�6�     5B   *   $��1��6?   #��z 6O   $��10,8,5,8q�6o   $��Center=�6�   $
��Left=�6�   $
 0.65Q�6�     5C   *   $��2��6?   $
 True��6O   $��0,0,5,0q�6g   $��Center=�6x   #��z 6�   ._�5D   .     $��Center=�6C   $	��8,1q�6^   #��z 6k   #��z 6�   5E   +   � 5F   *   $��3��6/   $
��10,0q�6?   $��Center=�6M   .+�5G   .   �  �   @KL @KL ��� ���#000000$ 0.5,0.5&�6^   $
 0.65Q�6~   z�5H   2   V� 5I   6   .~�5J   :   �� 	angle��$ 0Q�6Y   5K   7   5M   /   5N   +     5O   *   $��4��6A   ���	#00000000 �	#0C000000$  0Q�6�   $! 0Q�6�   $,��&Metro:MetroExpander.ButtonClickCommand��6�   5P   '   5Q   #   � 5R   "   $" height��6'   $��1��67   ���	#00000000$
}�True��6�   ��6[   �� *ActualHeight+$ content��.+�5S   &   �� $# canvas��6-   ��6=   �� *ActualHeight+$ content����6q   �� *ActualWidth+$ content��.+�5T   *   � $" content��6/   $
}�True��6@   ��6T   �� *ActualWidth+$ canvas��.+�5U   .   �� 5V   +   5W   '   5X   #   5Y      $ 5Z      P� 5[   "    6:   Z�  �@  Hint. �5\   &   �� $% 	hintWidth��6-    � ��$ 0 �6U   5]   #   P� 5^   "    6:   Z�  �@  Icon. �5_   &   �� $% 	iconWidth��6-    � ��$ 0 �6U   5`   #   P� 5a   "    6=   Z�  � ��. �5b   &   �� $% 
algleWidth��6-    � ��$ 0��6Y   5c   #   5e      5g      5h      P� 5i       �@  CanHide$ False��6)   . �5j      ��  � �� 5k      �� 5l      "   6*   .R�5m      � ���	#7FFFFFFF 5n   "   �� 5o   &   $
��Auto �64   �� 5p   &   $
��Auto �64   .+�5r   "   �� ���#e6e6e6$��0,0,0,1q�6?   ._�5s   &   �  5t   *   �� 5u   .   $ 	iconWidth��6?   $
��Auto �6R   �� 5v   .   �� 5w   .   $ 	hintWidth��6?   $
��Auto �6R   .+�5y   *   �� $��12��60   $��12��6;   $��10,0,0,0q�6G   $��Center=�6Y   #��z 6t   $	 0.7Q�6�     5z   *   $��1��6?   #��z 6O   $��10,8,5,8q�6o   $��Center=�6�   $
��Left=�6�   $
 0.65Q�6�     5{   *   $��2��6?   $
 True��6O   $��0,0,5,0q�6g   $��Center=�6x   #��z 6�   ._�5|   .     $��Center=�6C   $	��8,1q�6^   #��z 6k   #��z 6�   5}   +   5~   '   5   #   �� 5�   "   $��1��6)   ���	#7FFFFFFF���#e6e6e6$��0,0,0,1q�6c   ._�5�   &   �� 5�   #   5�      $ 5�      P� 5�   "    6:   Z�  �@  Hint. �5�   &   �� $% 	hintWidth��6-    � ��$ 0 �6U   5�   #   P� 5�   "    6:   Z�  �@  Icon. �5�   &   �� $% 	iconWidth��6-    � ��$ 0 �6U   5�   #   5�      5�      5�      5�      5�      