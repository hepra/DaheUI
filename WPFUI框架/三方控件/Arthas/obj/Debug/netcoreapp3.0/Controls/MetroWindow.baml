   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35ZAclr-namespace:System.Windows.Shell;assembly=PresentationFrameworkSystem.Windows.Shell  5      A =Arthas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Arthas.ControlsArthas.Controls 5      %   Arthas.Themes.Metro.MetroWindow^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   buttonStyle �� 
TargetType �� Property �� Value �� 
TargetType'   !System.Windows.VisualStateManager   VisualStateGroups%   System.Windows.VisualStateGroup   States    System.Windows.VisualState   
Storyboard	 �� 
TargetName
 �� TargetProperty	 W� To g� Duration ��Name J� Opacity!  Arthas.Controls.MetroWindow 	 Brush&    System.Windows.Media.TextOptions'   !System.Windows.Shell.WindowChrome   CaptionHeight   CornerRadius   GlassFrameThickness   ResizeBorderThickness   UseAeroCaptionButtons   NonClientFrameEdges ��Name   BorderBrush �� ElementName �Name � RowDefinitions � ColumnDefinitions ��Name   Menu   Arthas.Controls.MetroImage � Icon   Source   TitleForeground$  Arthas.Controls.MetroTextBlock  � Title!   IsHitTestVisibleInChrome" ��Name# J� RenderTransformOrigin$ �� Angle% J� IsHitTestVisible& �� Triggers' P� Property( P� Value) �� 
TargetName* �� RelativeSource+ �� Path   5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       :x,http://schemas.microsoft.com/winfx/2006/xaml      5      KShellAclr-namespace:System.Windows.Shell;assembly=PresentationFramework  5      'Metroclr-namespace:Arthas.Controls  5        5      �� 5   
   $/ )/Arthas;component/Controls/MetroBase.xaml?�6   %4  &	        '  �    7  7   7   7   7   �� 5
      " ��6    .�5   
   ��  �@�FocusVisualStyle 6-   Z� �� 5   
    �@J�SnapsToDevicePixels$
 True��60   �� 5   
    � ��$ 40��6"   �� 5   
    � ��$ 32��6#   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �  5        5      CommonStates��. 5   "     
Normal��. 5   &   �� .��5   *   W� $	 backRectangle��6:   $
 (UIElement.Opacity)�6`    06�   $ 0:0:0.1D�6�   5   '   5   #     5   "   	MouseOver��. 5   &   �� .��5   *   W� $	 backRectangle��6:   $
 (UIElement.Opacity)�6`    0.156�   $ 0:0:0.1D�6�   5   '   5   #     5    "   Pressed��. 5!   &   �� .��5"   *   W� $	 backRectangle��6:   $
 (UIElement.Opacity)�6`    0.056�   $ 0:0:0.1D�6�   5#   '   5$   #     5%   "   Disabled��6.   5&      .+�5(      �� $ backRectangle��6$   #��z��6;   $ 0Q�6_   �� 5)      5*      5+      5-      5.      �� 50      "  6   .�51   
   ��  �@�FocusVisualStyle 6-   Z� �� 52   
    �@J�SnapsToDevicePixels$
 True��60   �� 54   
    � �� �	#FFF3F3F36'   �� 55   
    �@ BorderBrush8   6(   �� 56   
    � �� �	#FF0000006'   �� 57   
    �@ TitleForeground �#ffffff6,   �� 58   
    � ��$ 1q�6,   �� 5:   
    � ��$ 12(�6%   �� 5;   
    �@ TextFormattingMode$ Display=�6;   �� 5<   
    �@ TextRenderingMode$ 	ClearType=�6:   �� 5=   
    �@�UseLayoutRounding$
 True��6.   �� 5N   
    �@ WindowChrome 5O        5P      $ 27Q�6%   $ 5��68   $ -1q�6I   $ 5q�6b   $ False��6|   $
 None=�6�   5R      �� 5S   
    � �� 5T      �� 5U      "  6"   .R�5V      �� $ border��6   #��z��6-   #��z 6W   #��z��6�    5W        5X      . 5Y   "     Enabled��. 5Z   &   �� .��5[   *   W� $	 disableRectangle��6:   $
 (UIElement.Opacity)�6c    0.56�   $ 0:0:0.1D�6�   5\   '   5]   #     5^   "   Disable��. 5_   &   �� .��5`   *   W� $	 disableRectangle��6:   $
 (UIElement.Opacity)�6c    06�   $ 0:0:0.1D�6�   5a   '   5b   #   5c      ._�5e      � ���#ffffff.+�5f      �� ���#000000$��-1q�6z   $
 0.15Q�6�   ��6;   �� *BorderThickness+$ border��6�   � 5g      $ 
windowGrid��6#   #��z 67    5h   "   �� 5i   &   $��32 �64   �� 5j   &    5l   "   �� 5m   &   $ iconSize��67   $��32 �6I   �� 5n   &   $
��Auto �67   �� 5o   &   �� 5p   &   $
��Auto �67   .+�5r   "   � $��2��6'   .+�5s   &   �� #��z 67   $��0,32,-120,0q�6X   5t   #   � 5u   "   $��1��6'   $��4��64   #��z��6H   .+�5v   &   �� .u�5w   *   �� 5x   '   5y   #   � 5z   "   $��0��6'   .+�5{   &     # z 67   �� 5|   &   #��z 60   $
 0.15Q�6Y   5}   #   � 5~   "   $��1��6'   .+�5   &     #��z  6;   #��z 6[   $��Center=�6�   $
��Left=�6�   $
��10,0q�6�   5�   #   � 5�   "   $��3��6'   $
! True��67   .+�5�   &   �� $" minimizedButton��6-   -   5        #��z 5�   F   $��Right=�6u   $��0,0,80,0q�6�   8�� ��5�   *   � 5�   .   $��Center=�63   $��Center=�6N   .+�5�   2   �� $��14��6<   $��1��6G   #��z 6R   $��0,6,0,0q�6{   5�   /   5�   '   �� 5�   &   $" maximizedButton��6-   -   5        #��z 5�   F   $��Right=�6u   $��0,0,40,0q�6�   8�� ��5�   *   � 5�   .   $��Center=�63   $��Center=�6N   .+�5�   2   �� $��12��6<   $��12��6G   #��z 6S   5�   /   5�   '   �� 5�   &   $" normalButton��6-   -   5        #��z 5�   C   $��Right=�6r   $��0,0,40,0q�6�   8�� ��5�   *   � 5�   .   $��Center=�63   $��Center=�6N   $��0,2,3,0q�6k   .+�5�   2   �� $��10��6<   $��10��6G   #��z 6S   �� 5�   2   $��10��6<   $��1��6G   #��z 6R   $	��Top=�6{   $��Right=�6�   $��	0,-4,-4,0q�6�   �� 5�   2   $��3��6<   $��1��6F   #��z 6Q   $��Right=�6z   $��0,5,-3,0q�6�   $	��Top=�6�   �� 5�   2   $��1��6<   $��9��6F   #��z 6Q   $��Right=�6z   $	��Top=�6�   $��	0,-3,-4,0q�6�   �� 5�   2   $��1��6<   $��3��6F   #��z 6Q   $	��Top=�6z   $��Right=�6�   $��0,-3,5,0q�6�   5�   /   5�   '   �� 5�   &   $" closeButton��6-   -   5        #��z 5�   B   $��Right=�6q   8�� ��5�   *   � 5�   .   $��Center=�63   $��Center=�6N   .+�5�   2   �� $��16��6<   $	��1.2��6G   #��z 6T   $# 0.5,0.5&�6}   z�5�   6   V� 5�   :   .~�5�   >   �� $$ 45Q�6N   5�   ;   5�   3   �� 5�   2   $��16��6<   $	��1.2��6G   #��z 6T   $# 0.5,0.5&�6}   z�5�   6   V� 5�   :   .~�5�   >   �� $	$ -45Q�6N   5�   ;   5�   3   5�   /   5�   '   5�   #   �� 5�   "   $ disableRectangle��6,   $��2��6F   $��4��6W   ���	#FF000000$ 0Q�6|   $% False��6�   5�      5�      5�      & 5�      P� 5�      ' �@�
ResizeMode$( NoResize=�68   . �5�      �� $) minimizedButton��6;    � y�$ Hidden=�6X   �� 5�      $) maximizedButton��6;    � y�$ Hidden=�6X   �� 5�      $) normalButton��6;    � y�$ Hidden=�6U   5�      P� 5�      ' �@�
ResizeMode$( CanMinimize=�68   . �5�      �� $) maximizedButton��6;    � y�$ Hidden=�6X   �� 5�      $) normalButton��6;    � y�$ Hidden=�6U   �� 5�      $) minimizedButton��67    � ��$ 0,0,40,0q�6T   5�      P� 5�      ' �@�WindowState$( 	Maximized=�69   . �5�      �� $) maximizedButton��6;    � y�$ Hidden=�6X   �� 5�      $) 
windowGrid��67    � ��$ 8q�6O   �� 5�      $) 
windowGrid��6%    6O   �� * �� *TemplatedParent+$=+ 7(Shell:WindowChrome.WindowChrome).ResizeBorderThickness� � ���� 5�      $) border��6@    � ��$ 0q�6T   5�      P� 5�      ' �@�WindowState$( Normal=�69   . �5�      �� $) normalButton��6;    � y�$ Hidden=�6U   5�      P� 5�      ( 62   Z� ' �@�Icon. �5�      �� $) iconSize��66    � ��$ 0 �6L   �� 5�       � ��$	 120��69   5�      5�      5�      5�      5�      