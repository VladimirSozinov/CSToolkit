   M S B A M L   `   `   `  ����  	CSToolkit!    CSToolkit.View.ResultWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	   -   5          � Title$  CWS Diagnostic Tool v1.2��5   	    � Icon$ ../Resources/cws_icon.ico��6�    � AllowsTransparency .  � WindowStyle$
 None=�6!   � Left 6*   �� *Left+ �� Mode$ TwoWay=�
 � Top 6M   �� *Top+$ TwoWay=���6n   �� *Height+$ TwoWay=���6�   �� *Width+$ TwoWay=� � 	Resources 5       �� MergedDictionaries	 �� Source�� 5   
    5	      �� 5
      $+	 %../Resources/ResourcesDictionary.xaml?�6%   %    5      .��5      �� ���#3399FF$��5,0,5,5q�6#   ._�5   
   � 
 � RowDefinitions
 5      �� 5      $��30 �6    6.   �� 5      $��50 �6    6.   �� 5      $��* �6    6-   �� 5      $��30 �6    6.   �� 5      $��50 �6    6.   .+�5      � $��0��6   ���#3399FF.+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� 6   �� 5      $��5,0,0,0q�6   $��14(�6-   
�������$��1��6N   .��6^   CWS Diagnostic Tool v1.26x   5      �� 5         HideButtonStyle#��[  69   $��1��6b   ��6   �� *HideCommand+6t   �� 5         CrossButtonStyle#��[ 6:   $��1��6d   ��6   �� *CloseCommand+6v   5!      �� 5#      $��1��6   $��1,1,1,0q�6"   
�������._�5$      �� -   5        $��
TitleLabel��5$      $��0��6\   $��14(�6i   $��20,0,0,0q�6�   $
��Left=�6�   $��Center=�6�   $
��Left=�6�   ��6*   �� *WindowHeaderText+$ TwoWay=���6w   ��  �� Path$ Width� �� ElementName$ My��6  5%      �� 5'      $��2��6   $��1q�6"   
�������._�5(      � .+�5)      �� -   5        $��CommandList��5)      $��Disabled=�6U   $��Disabled=�6�   ��62   �� *
Operations+ 5*       �� 
TargetType �� Property �� Value��%W   '��       �� 5+      " ��6$   .�5,   "   ��  � ��$ Stretch=�6O   5-      5.       �� View 5/      �� 50      .P�51   "   �� $��Action��61    �� Width 6A   �� *HalfOfWindowWidth+ �� CellTemplate 52   &   �� 53   *   .R�54   .   ]� .+�55   2   �� $��12(�6X   $��20��6f   $��1q�6r   $��Center=�6~   $��0,0,0,0q�6�   ��68   �� *CommandName+6�   �� 56   2   $��16��6e   $��16��6p   $��10,0,0,0q�6|   $
��Left=�6�    J� RenderTransformOrigin$ 0.5, 0.5&�6�   "  WpfAnimatedGif.ImageBehavior   AnimatedSource$ ../Resources/Circle.gif��6�   y�68   �� *CircleImageVisibility+6  57   /   58   +   5:   #   �� 5;   "   $��Status��61    6A   �� *HalfOfWindowWidth+ 5<   &   �� 5=   *   .R�5>   .   �� $��0q�6U   $��12(�6`   $��20��6n   $��1q�6z   $��Center=�6�   $��Center=�6�   ��64   �� *CurrentState+6�   5?   +   5A   #   5B      5D      5E      5F      �� 5H      $��3��6   $��1,0,1,1q�6"   
�������._�5I      �� $ 
Horizontal=�6   .+�5J      �� -   5        $��FinishedCommandsLabel��5J      $��14(�69   $
��Auto��6G   $
��Left=�6T   $
��Left=�6v   $��20,0,0,0q�6�   ��6�   �� *
ResultText+6�   �� 5K      -   5        $��
LinkButton��5K   *   $��3��6   $��Center=�6<     Link#��[ 6w   ��6W   �� *LinkCommand+��6�   �� *LinkButtonText+6�   5L      5M      �� 5O      $��4��6   $ 
Horizontal=�6&   $��Center=�6?   .+�5P      �� -   5        $��ContinueButton��5P        GeneralButtonStyle#��[ 6S   $��0,0,20,0q�6   {�.  ��6/   �� *ContinueCommand+.��6�   Generate report6�   �� 5Q      -   5        $��
ExitButton��5Q      #��[ 6K   {�.  $��20,0,0,0q�6�   ��6+   �� *ExitCommand+.��6�   Finish6�   5R      5T      5U      5V      