   M S B A M L   `   `   `  ����   	CSToolkit!    CSToolkit.View.ResultWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  -     � Title$  CWS Diagnostic Tool v1.2�� � Icon$ ../Resources/cws_icon.ico�� � AllowsTransparency .  � WindowStyle$
 None=� � Left �� *Left+ �� Mode$ TwoWay=�
 � Top �� *Top+$ TwoWay=����� *Height+$ TwoWay=����� *Width+$ TwoWay=� � 	Resources  �� MergedDictionaries	 �� Source��  �� $+	 %../Resources/ResourcesDictionary.xaml?�%    .���� ���#3399FF$��5,0,5,5q�._�� 
 � RowDefinitions
 �� $��30 ��� $��50 ��� $��* ��� $��30 ��� $��50 �.+�� $��0�����#3399FF.+���  �� Orientation$ 
Horizontal=�.+��� �� $��5,0,0,0q�$��14(�
�������$��1��.��CWS Diagnostic Tool v1.2��    HideButtonStyle#��[  $��1������ *HideCommand+��   CrossButtonStyle#��[ $��1������ *CloseCommand+�� $��1��$��1,1,1,0q�
�������._��� -   $��
TitleLabel��$��0��$��14(�$��20,0,0,0q�$
��Left=�$��Center=�$
��Left=����� *WindowHeaderText+$ TwoWay=�����  �� Path$ Width� �� ElementName$ My���� $��2��$��1q�
�������._�� .+��� -   $��CommandList��$��Disabled=�$��Disabled=����� *
Operations+ �� View �� .P��� $��Action�� �� Width �� *HalfOfWindowWidth+ �� CellTemplate �� .R�]� .+��� $��12(�$��20��$��1q�$��Center=�$��0,0,0,0q����� *CommandName+�� $��16��$��16��$��10,0,0,0q� J� RenderTransformOrigin$ 0.5, 0.5&�"  WpfAnimatedGif.ImageBehavior   AnimatedSource$ ../Resources/Circle.gif��y��� *CircleImageVisibility+�� $��Status�� �� *HalfOfWindowWidth+ �� .R��� $��12(�$��20��$��Center=�$��Center=�$��0,0,0,0q����� *CurrentState+�� $��3��$��1,0,1,1q�
�������._��� $ 
Horizontal=�.+��� -   $��FinishedCommandsLabel��$��14(�$
��Auto��$
��Left=�$
��Left=�$��20,0,0,0q����� *
ResultText+�� -   $��
LinkButton��$��3��$��Center=�  Link#��[ ���� *LinkCommand+���� *LinkButtonText+�� $��4��$ 
Horizontal=�$��Center=�.+��� -   $��ContinueButton��  GeneralButtonStyle#��[ $��0,0,20,0q�{�.  ���� *ContinueCommand+.��Generate report�� -   $��
ExitButton��#��[ {�.  $��20,0,0,0q����� *ExitCommand+.��Finish