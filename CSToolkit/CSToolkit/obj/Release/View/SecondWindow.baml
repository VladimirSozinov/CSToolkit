   M S B A M L   `   `   `  ���� D  @CSToolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:CSToolkit.ValidatorsCSToolkit.Validators  !    CSToolkit.View.SecondWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     9
validators"clr-namespace:CSToolkit.Validators     -     � Title$  CWS Diagnostic Tool v1.2�� � Icon$ ../Resources/cws_icon.ico�� � 
ResizeMode$ NoResize=� � AllowsTransparency .  � WindowStyle$
 None=����� *Height+ �� Mode$ TwoWay=����� *Width+$ TwoWay=� � Left �� *Left+$ TwoWay=�
 � Top �� *Top+$ TwoWay=�y��� *WindowVisibility+$ TwoWay=� � 	Resources 	 �� MergedDictionaries
 �� Source�� 	 �� $+
 %../Resources/ResourcesDictionary.xaml?�%    .���� ���#3399FF$��5,0,5,5q�._��  � RowDefinitions �� $��30 ��� $	��240 ��� $��* �$��60��.+�� $��0�����#3399FF.+���  �� Orientation$ 
Horizontal=�.+��� �� $��5,0,0,0q�$��14(�
�������$��1��.��CWS Diagnostic Tool v1.2��    HideButtonStyle#��[  ���� *HideCommand+��   CrossButtonStyle#��[ ���� *CloseCommand+� $��1�� � ColumnDefinitions �� $
��153* ��� $
��613* � �� $��* ��� $��3* �.+��� $��0��$��Center=�$��14(�$��35��$	��480��$��Center=�$��2��$��146,12,140,12q�.��31Please enter your information in the fields below� $��1��$��2�� �� �� �� �� .+��� $��0��.��Primary Proxy�� -   $��Proxy1TextBox��$��
145,0,35,0q�$��0������  �� Path$ Proxy1�$ TwoWay=��� $��1��.��Secondary Proxy�� -   $��Proxy2TextBox��$��
145,0,35,0q�$��1������ $ Proxy2�$ TwoWay=��� $��2��.��	Ping Host�� -   $��PingHostTextBox��$��
145,0,35,0q�$��2�����	#FFABADB3���� $ PingHostText�$ TwoWay=��� $��2��$ 
Horizontal=�$��Center=�$��Bottom=�$��0,0,0,12q�.+��� -   $��ContinueButton��  GeneralButtonStyle#��[ $��0,0,20,0q����� *ContinueCommand+.��
Continue�� -   $��
ExitButton��#��[ $��20,0,0,0q����� *ExitCommand+.��Exit