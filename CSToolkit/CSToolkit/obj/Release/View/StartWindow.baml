   M S B A M L   `   `   `  ���� D  @CSToolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CSToolkit.ViewModelCSToolkit.ViewModel       CSToolkit.View.StartWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     3local!clr-namespace:CSToolkit.ViewModel     -     � Title$  CWS Diagnostic Tool v1.2�� � Icon$ ../Resources/cws_icon.ico�� � 
ResizeMode$ NoResize=� � AllowsTransparency .  � WindowStyle$
 None=����� *Height+ �� Mode$ TwoWay=����� *Width+$ TwoWay=� � Left �� *Left+$ TwoWay=�
 � Top �� *Top+$ TwoWay=�y��� *WindowVisibility+$ TwoWay=� � 	Resources 	 �� MergedDictionaries
 �� Source�� 	 �� $+
 %../Resources/ResourcesDictionary.xaml?�%    .���� ���#3399FF$��5,0,5,5q�._��  � RowDefinitions �� $��30 ��� $	��160 ��� $	��240 ��� $��* �$��60��.+�� $��0�����#3399FF.+���  �� Orientation$ 
Horizontal=�.+��� �� $��5,0,0,0q�$��14(�
�������$��1��.��CWS Diagnostic Tool v1.2��    HideButtonStyle#��[  ���� *HideCommand+��   CrossButtonStyle#��[ ���� *CloseCommand+�� $��1�����#7999FF$��1q�$��20,20,20,20q�._��� .+��� .����Prerequisites - Before you begin, please ensure the below ports are opened on your firewall to ensure all tests work successful:�� $ 
Horizontal=�.+�A� $��5��$��5��
���   �$��Center=�$��10,0,0,0q��� $��50,0,0,0q�Port 80 (TCP) Outbound�� $ 
Horizontal=�.+�A� $��5��$��5��
���   �$��Center=�$��10,0,0,0q��� $��50,0,0,0q�Port 443 (TCP) Outbound�� $ 
Horizontal=�.+�A� $��5��$��5��
���   �$��Center=�$��10,0,0,0q��� $��50,0,0,0q�Port 8080 (TCP) Outbound�� $ 
Horizontal=�.+�A� $��5��$��5��
���   �$��Center=�$��10,0,0,0q��� $��50,0,0,0q�ICMP (Type 30)�� $ 
Horizontal=�.+�A� $��5��$��5��
���   �$��Center=�$��10,0,0,0q��� $��50,0,0,0q�Port 53 (TCP/UDP)� $��2�� �� $��* ��� $��3* �.+��� $��0��$��Center=�$��35��$	��480��$��Center=�.��31Please enter your information in the fields below� $��1�� �� �� �� �� .+��� $��0��.��Customer Name�� -   $��CustomerNameTextBox��$��
145,0,35,0q�$��0������  �� Path$ UserName�$ TwoWay=��� $��1��.��	SR Number�� -   $��SerialNumberTextBox��$��
145,0,35,0q�$��1������ $ SerialNumber�$ TwoWay=��� $��2��.��CEC ID(Optional)�� $��2��$��
145,0,35,0q����� $ EmailAdress�$ TwoWay=��� $��3��$	��210��.��Install WinPcap (if required)�� -   $��InstallWinPcapCheckBox��$��3��$
��Left=�$��	255,0,0,0q�$��Center=� d� 	IsChecked �� *NeedToInstallWinPcap+�� $��3��$ 
Horizontal=�$��Center=�$��Bottom=�$��0,0,0,12q�.+��� -   $��ContinueButton��  GeneralButtonStyle#��[ $��0,0,20,0q����� *ContinueCommand+.��
Continue�� #��[ $��20,0,0,0q����� *ExitCommand+.��Exit