   M S B A M L   `   `   `  ����D  @CSToolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CSToolkit.ViewModelCSToolkit.ViewModel  5   	        CSToolkit.View.StartWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   3local!clr-namespace:CSToolkit.ViewModel     5   	   -   5        $��
MainWindow��5   *     � Title$  CWS Diagnostic Tool v1.2��6	    � Icon$ ../Resources/cws_icon.ico��6   � 
ResizeMode$ NoResize=�6"   � AllowsTransparency .  � WindowStyle$
 None=�6R  ��6<   �� *Height+ �� Mode$ TwoWay=���6c   �� *Width+$ TwoWay=� � Left 6�   �� *Left+$ TwoWay=�
 � Top 6�   �� *Top+$ TwoWay=�y�6�   �� *WindowVisibility+$ TwoWay=� � 	Resources 5      	 �� MergedDictionaries
 �� Source�� 5   
   	 5	      �� 5
      $+
 %../Resources/ResourcesDictionary.xaml?�6%   %    5      .��5      �� ���#3399FF$��5,0,5,5q�6#   ._�5   
   �  � RowDefinitions 5      �� 5      $��30 �6    6.   �� 5      $
��Auto �6    60   �� 5      $	��180 �6    6/   �� 5      $��60 �6    6.   .+�5      � $��0��6   ���#3399FF.+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� 6   �� 5      $��5,0,0,0q�6   $��14(�6-   
�������$��1��6N   .��6^   CWS Diagnostic Tool v1.26x   5      �� 5          HideButtonStyle#��[  69   ��6   �� *HideCommand+6d   �� 5!        CrossButtonStyle#��[ 6:   ��6   �� *CloseCommand+6f   5#      �� 5'        PrerequisitesAreaStyle#��[ 6   $��1��6E   ._�5(      �� .+�5)      �� $ 
Horizontal=�6!   .+�5*      �� -   5        $��ExpandInfoAreaBtton��5*   !     ExpandAreaButtonStyle#��[ 6f   ��6<   �� *ExpandInfoAreaCommand+��6�   �� *ExpandInfoAreaButtonText+$ TwoWay=�6�   5+      �� 5-      $��20��6   $��Bottom=�6(   $��0,0,0,0q�6J   $��40,0,0,0q�6\   .��6n   Prerequisites:6~   �� 5.      $��25��6   $	��Top=�6(   $��0,0,0,0q�6G   $��40,0,0,0q�6Y   .��6k   zxBefore you begin, please open the following ports on your Firewall to ensure that all tests are completed successfully :6�   �� 50      $ 
Horizontal=�6!   .+�51      �� $��40,0,0,0q�6$   '%1. Open these ports on your firewall:6]   52      �� 53      $ 
Horizontal=�6!   .+�54      A� $��5��6"   $��5��6-   
���   �$��Center=�6D   $��50,0,0,0q�6_   �� 55      $��20,0,0,0q�6$   Port 80 (TCP) Outbound6N   56      �� 57      $ 
Horizontal=�6!   .+�58      A� $��5��6"   $��5��6-   
���   �$��Center=�6D   $��50,0,0,0q�6_   �� 59      $��20,0,0,0q�6$   Port 443 (TCP) Outbound6O   5:      �� 5;      $ 
Horizontal=�6!   .+�5<      A� $��5��6"   $��5��6-   
���   �$��Center=�6D   $��50,0,0,0q�6_   �� 5=      $��20,0,0,0q�6$   Port 8080 (TCP) Outbound6P   5>      �� 5?      $ 
Horizontal=�6!   .+�5@      A� $��5��6"   $��5��6-   
���   �$��Center=�6D   $��50,0,0,0q�6_   �� 5A      $��20,0,0,0q�6$   ICMP (Type 30)6F   5B      �� 5C      $ 
Horizontal=�6!   .+�5D      A� $��5��6"   $��5��6-   
���   �$��Center=�6D   $��50,0,0,0q�6_   �� 5E      $��20,0,0,0q�6$   Port 53 (TCP/UDP) Outbound6R   5F      5H      5I      �� 5K      $��1��6     PrerequisiteTextStyle#��[ 6%   6V   � 5M      $��2��6    5O      �� 5P      $��* �6$   61   �� 5Q      $��3* �6$   62   .+�5T      �� $��0��6   $��Center=�6%   $��35��6B   $	��480��6N   $��Center=�6Z   .��6~   31Please enter your information in the fields below6�   � 5V      $��1��6    5W      �� 5X      6*   �� 5Y      6*   �� 5Z      6*   .+�5]      �� $��0��6   .��6)   Customer Name68   �� 5^      -   5        $��CustomerNameTextBox��5^      $��
145,0,20,0q�69   $��0��6M   ��6Z   ��  �� Path$ UserName�$ TwoWay=�6�   �� 5`      $��1��6   .��6)   	SR Number64   �� 5a      -   5        $��SerialNumberTextBox��5a      $��
145,0,20,0q�69   $��1��6M   ��6Z   �� $ SerialNumber�$ TwoWay=�6�   �� 5c      $��2��6   .��6)   CEC ID(Optional)6;   �� 5d      $��2��6   $��
145,0,20,0q�6+   ��6?   �� $ EmailAdress�$ TwoWay=�6p   5f      5h      �� 5j      $��3��6   $ 
Horizontal=�6&   $��Center=�6?   $��Bottom=�6\   $��0,0,0,12q�6w   .+�5k      �� -   5        $��ContinueButton��5k        GeneralButtonStyle#��[ 6/   $��0,0,20,0q�6[   ��6m   �� *ContinueCommand+.��6�   
Continue6�   �� 5l      #��[ 6   $��20,0,0,0q�6F   ��6X   �� *ExitCommand+.��6x   Exit6~   5m      5n      5o      5p      