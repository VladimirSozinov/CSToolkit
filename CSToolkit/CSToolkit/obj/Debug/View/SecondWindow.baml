   M S B A M L   `   `   `  ����D  @CSToolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CSToolkit.ValidatorsCSToolkit.Validators  5   	   !    CSToolkit.View.SecondWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9
validators"clr-namespace:CSToolkit.Validators     5   	   -   5          � Title$  CWS Diagnostic Tool v1.2��5   	    � Icon$ ../Resources/cws_icon.ico��6v    � 
ResizeMode$ NoResize=�6<   � AllowsTransparency .  � WindowStyle$
 None=�6l  ��6*   �� *Height+ �� Mode$ TwoWay=���6Q   �� *Width+$ TwoWay=� � Left 6�   �� *Left+$ TwoWay=�
 � Top 6�   �� *Top+$ TwoWay=�y�6�   �� *WindowVisibility+$ TwoWay=� � 	Resources 5      	 �� MergedDictionaries
 �� Source�� 5   
   	 5	      �� 5
      $+
 %../Resources/ResourcesDictionary.xaml?�6%   %    5      .��5      �� ���#3399FF$��5,0,5,5q�6#   ._�5   
   �  � RowDefinitions 5      �� 5      $��30 �6    6.   �� 5      $	��240 �6    6/   �� 5      $��* �6    $��60��6+   6<   .+�5      � $��0��6   ���#3399FF.+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� 6   �� 5      $��5,0,0,0q�6   $��14(�6-   
�������$��1��6N   .��6^   CWS Diagnostic Tool v1.26x   5      �� 5         HideButtonStyle#��[  69   ��6   �� *HideCommand+6d   �� 5        CrossButtonStyle#��[ 6:   ��6   �� *CloseCommand+6f   5      � 5!      $��1��6    � ColumnDefinitions 5"      �� 5#      $
��153* �6'   �� 5$      $
��613* �6'    5&      �� 5'      $��* �6$   61   �� 5(      $��3* �6$   62   .+�5+      �� $��0��6   $��Center=�6%   $��14(�6B   $��35��6P   $	��480��6\   $��Center=�6h   $��2��6�   $��146,12,140,12q�6�   .��6�   31Please enter your information in the fields below6�   � 5-      $��1��6   $��2��6$    5.      �� 5/      6*   �� 50      6*   �� 51      6*   �� 52      6*   .+�55      �� $��0��6    .��6-   Primary Proxy6<   �� 56      -   5        $��Proxy1TextBox��56   "   $��
145,0,35,0q�67   $��0��6K   ��6X   ��  �� Path$ Proxy1�$ TwoWay=�6�   �� 58      $��1��6    .��6-   Secondary Proxy6>   �� 59      -   5        $��Proxy2TextBox��59   "   $��
145,0,35,0q�67   $��1��6K   ��6X   �� $ Proxy2�$ TwoWay=�6�   �� 5;      $��2��6    .��6-   	Ping Host68   �� 5<      -   5        $��PingHostTextBox��5<   "   $��
145,0,35,0q�69   $��2��6M   ���	#FFABADB3��6Z   �� $ PingHostText�$ TwoWay=�6   5>      5?      �� 5A      $��2��6   $ 
Horizontal=�6&   $��Center=�6?   $��Bottom=�6\   $��0,0,0,20q�6w   .+�5B      �� -   5        $��ContinueButton��5B   W     GeneralButtonStyle#��[ 6   $��0,0,20,0q�6E   ��6m   �� *ContinueCommand+.��6�   
Continue6�   �� 5C      -   5        $��
ExitButton��5C   W   #��[ 6   $��20,0,0,0q�6E   ��6i   �� *ExitCommand+.��6�   Exit6�   5D      5E      5F      5G      