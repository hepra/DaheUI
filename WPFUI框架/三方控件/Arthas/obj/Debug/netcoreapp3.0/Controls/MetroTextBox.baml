   M S B A M L   `   `   `  ����A  =Arthas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Arthas.ControlsArthas.Controls  5      E'clr-namespace:Arthas.Controls.ConverterArthas.Controls.Converter  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source2    ,Arthas.Controls.Converter.StringToVisibility   StringToVisibility  buttonStyle �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard	 �� 
TargetName
 �� TargetProperty	 W� To g� Duration ��Name J� Opacity"   Arthas.Controls.MetroTextBox 	 Brush � ColumnDefinitions ��Name   TitleMinWidth$   Arthas.Controls.MetroTextBlock  Name   TitleForeground   Title ��Name   CornerRadius �� CornerRadius �Name   Icon   	InputHint J� IsHitTestVisible ��Name ��Name   ButtonTitle �Name  � AllowsTransparency! � VerticalOffset" � HorizontalOffset# � PlacementTarget$ �� ElementName% �� 	Converter&   	PopupHint' �Name( � Points) �� Triggers* P� Property+ P� Value, �� 
TargetName- �� RelativeSource. ]� 
Conditions/ �� Property0 �� Value�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      'Metroclr-namespace:Arthas.Controls  5      5	Converter'clr-namespace:Arthas.Controls.Converter  5        5      �� 5   
   $/ )/Arthas;component/Controls/MetroBase.xaml?�6   %�  &	        &	      '       7  7  7      5	      6#   �� 5      " ��6    .�5   
   ��  �@�FocusVisualStyle 6-   Z� �� 5   
    �@J�SnapsToDevicePixels$
 True��60   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �  5        5      CommonStates��. 5   "     
Normal��6.     5   "   	MouseOver��. 5   &   �� .��5   *   W� $	 title��6:   $
 (UIElement.Opacity)�6X    0.96�   $ 0:0:0.1D�6�   5   '   5   #     5   "   Pressed��. 5   &   �� .��5   *   W� $	 title��6:   $
 (UIElement.Opacity)�6X    0.56�   $ 0:0:0.1D�6�   5   '   5   #     5   "   Disabled��6.   5       .+�5"      �� $ title��6$   #��z��63   $
 0.65Q�6T   $��Center=�6c   $	��8,0q�6~   5#      5$      5&      5'      �� 5)      "  6   .�5*   
   ��  �@�FocusVisualStyle 6-   Z� �� 5+   
    �@J�SnapsToDevicePixels$
 True��60   �� 5-   
    �@��AcceptsReturn$ False��6*   �� 5.   
    �@��TextWrapping$ NoWrap=�6)   �� 50   
    � �� �	#FFFFFFFF6'   �� 51   
    �@ MouseMoveBackground �	#FFFFFFFF60   �� 52   
    � ��8   6(   �� 53   
    � �� �	#A50000006'   �� 54   
    �@ TitleForeground �	#A50000006,   �� 55   
    �@ TitleMinWidth$ 80Q�6*   �� 56   
    � ��$ 1q�6,   �� 57   
    �@ CornerRadius$ 2��6)   �� 58   
    � �� 59      �� 5:      "  6"   .R�5;      �  5<      �� 5=      $ titleWidth1��6g   #��z 6/   $
��Auto �6Z   6g   �� 5>      $ titleWidth2��6:   $��10 �6/   6:   �� 5?      .+�5A        $ title��6/   $��0��6>   #��z 6N   #��z 6}   $��Right=�6�   $	��Top=�6�   $	��0,6q�6�   �� 5B      $
 back��6!   $��2��6/   # z 6?   #��z��6m   ._�5C      � .+�5D   "   �� $ border��6)   #��z��69   # z 6m   ���	#FF000000$
 0.15Q�6�   �� 5E   "   $ 
bordermove��6)   #��z��6=   # z 6q   #��z��6�   $ 0Q�6�   �� 5F   "   $ 
bordertrue��6)   #��z��6=   # z 6q   ���	#FF99cb8a$y�Hidden=�6�   �� 5G   "   $ borderfalse��6)   #��z��6>   # z 6r   ���	#FFe99595$y�Hidden=�6�   � 5H   "   $ content��6'    5I   &   �� 5J   *   $ 	iconWidth��6H   $
��Auto �6;   6H   �� 5K   *   �� 5L   *   $ buttonWidth1��6H   $
��Auto �6;   6H   �� 5M   *   $ buttonWidth2��6H   $
��Auto �6;   6H   .+�5O   &   �� $��0��6,   $��16��6<   $��16��6G   $��6,6,0,6q�6S   #��z 6d   #��z��6�   � 5P   &   $ hideInputHint��6+   $ 0Q�6B   $��1��6N   .+�5Q   *     $ 	inputHint��6?   $��6,5,5,5q�6R   #��z��6c   #��z 6�   $
��Left=�6�   #��z��6�   $ 0Q�6
  $ False��6  5R   '   �� 5S   &   $ PART_ContentHost��6C   $��1��63   $��5q�6]   $|�false��6h   $��Hidden=�6z   $��Hidden=�6�   #��z��6�   �� 5U   &   $��2��60   $��1��6@   $��11��6J   $��5,9,0,0q�6V   ���	#FF000000$
 0.15Q�6x   $	��Top=�6�   �� 5V   &   $ button��6-   $|�False��6=   $��3��6O   #��z 6_   $	��0,6q�6�   8�� #��z��6�   $+��%Metro:MetroTextBox.ButtonClickCommand��6�   5W   #   5X      5Y      � 5Z      $ 	popupHint��6    $
  True��6l   $|�False��6�   $��RelativePoint=�6�   $	! -42��6�   $	" -14��6�   $
��Fade=�6�   # 63   �� $$ PART_ContentHost��.��5[      � .+�5\   "   �� y�6-   �� *	PopupHint+8%  .+�5]   &   �� $ popupborder��6-   $ 2��6B   #��z��6S   ._�5^   *     $ 	popupText��6?   #��z& 6R   $	��8,6q�6u   ���	#FFFFFFFF$��Center=�6�   $��Center=�6�   5_   '   � 5`   &   $' popuppolygon��6.   ( �   ��� @KL @KL #��z��6^   $��10,0,0,0q�6�   5a   #   5b      5c      5d      ) 5e      P� 5f      * � {�$+ false��67   . �5g      �� $, content��68    �@J�Opacity$	 0.5Q�6M   �� 5h      $, title��68    �@J�Opacity$
 0.35Q�6K   �� 5i      $
, back��6;    � �� �	#FFFAFAFA6M   �� 5j      $, 	inputHint��68    �@J�Opacity$	 0.5Q�6O   5k      P� 5l      * �@J�IsMouseOver$
+ true��69   . �5m      �� $, border��68    �@J�Opacity$ 0Q�6L   �� 5n      $, 
bordermove��68    �@J�Opacity$ 1Q�6P   �� 5o      $, 
bordertrue��6<    � �� �	#ff6fae5f6T   �� 5p      $, borderfalse��6<    � �� �	#ffe679796U   �� 5r      $
, back��6;    6M   �� *MouseMoveBackground+- �� *TemplatedParent+ � ��5s      P� 5t      * �@ IsPassWordBox$
+ true��6;   . �5u      �� $, PART_ContentHost��6;    � y�$ Hidden=�6Y   �� 5v       �@��PreferredImeState$	 Off=�6N   5w      P� 5x      * �@ MultipleLine$
+ true��6:   . �5y      ��  �@��AcceptsReturn$
 true��6>   �� 5z       �@��TextWrapping$
 Wrap=�6=   5{      P� 5|      * �@J�IsKeyboardFocused$
+ true��6?   . �5}      �� $, border��68    �@J�Opacity$ 0Q�6L   �� 5~      $, 
bordermove��68    �@J�Opacity$ 1Q�6P   �� 5      $, 	popupHint��67    � ��$
 true��6N   �� 5�      $, 
bordertrue��6<    � �� �	#ff6fae5f6T   �� 5�      $, borderfalse��6<    � �� �	#ffe679796U   �� 5�      $, 	inputHint��68    �@J�Opacity$ 0Q�6O   �� 5�      $
, back��6;    6M   �� *MouseMoveBackground+- �� *TemplatedParent+ � ��5�      P� 5�      * �@J�IsKeyboardFocused$+ false��6?   . �5�      �� $, 	popupHint��67    � ��$ false��6N   5�      P� 5�      * �@ Title$+  ��63   . �5�      �� $, titleWidth1��69    � ��$ 0��6R   �� 5�      $, titleWidth2��66    � ��$ 0 �6O   5�      P� 5�      * � ��$+  ��62   . �5�      �� $, hideInputHint��68    �@J�Opacity$ 1Q�6S   5�      ]� 5�      . 5�      �� 5�   "   / � ��$0  ��6<   �� 5�   "   / � {�$
0 true��6A   �� 5�   "   / �@J�IsKeyboardFocused$0 false��6I   ./�5�      �� $, 	inputHint��68    �@J�Opacity$
 0.25Q�6O   5�      P� 5�      * �@ State$
+ true��63   . �5�      �� $, border��6;    � y�$ Hidden=�6O   �� 5�      $, 
bordertrue��6;    � y�$ Visible=�6S   �� 5�      $, popupborder��6;    � �� �	#FF99cb8a6T   �� 5�      $, popuppolygon��65    � �� �	#FF99cb8a6O   5�      P� 5�      * �@ State$+ false��63   . �5�      �� $, border��6;    � y�$ Hidden=�6O   �� 5�      $, borderfalse��6;    � y�$ Visible=�6T   �� 5�      $, popupborder��6;    � �� �	#FFe995956T   �� 5�      $, popuppolygon��65    � �� �	#FFe995956O   5�      P� 5�      + 62   Z� * �@ Icon. �5�      �� $, 	iconWidth��66    � ��$ 0 �6M   5�      P� 5�      * �@ ButtonTitle$+  ��69   . �5�      �� $, buttonWidth1��66    � ��$ 0 �6P   �� 5�      $, buttonWidth2��66    � ��$ 0 �6P   5�      5�      5�      5�      5�      