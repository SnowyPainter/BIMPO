   M S B A M L   `   `   `  ���� e  aBIMPO_BusIness Management Process Observer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:BIMPO_BusIness_Management_Process_Observer*BIMPO_BusIness_Management_Process_Observer  ;    5BIMPO_BusIness_Management_Process_Observer.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Jlocal8clr-namespace:BIMPO_BusIness_Management_Process_Observer     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     �Name$  StartupWindow�� � Title$ Hello BIMPO!��$	��600��$	��850�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � Icon$ /Resource/PO.ico�� � WindowStyle$
 None=�.��� -    �Name$ BackgroundGrid�� � Cursor$ Arrow�����	#FFE0E0E0 � RowDefinitions �� $	��31* ��� $
��569* �.+��� -   	 ��Name$	 GreetingLabel��$��안녕하세요 이름님��$
��Left=�$	��Top=�
 J� RenderTransformOrigin$
 
0.909,1.53&�$��	20,24,0,0q�$��41��$	��467��$��24(�$
��Bold"�$��1��
��������� -    ��Name$ BusinessListView��$
��Left=�$	��351��$��	22,74,0,0q�$	��Top=�$	��816��$��16(�$��1�� �� SelectionMode$ Single=� �� View �� .P��� $��업무�� �� Width$	 500�� �� DisplayMemberBinding �� *BusinessTitle+�� $��	시작일��$	 200�� �� *	Degdate+�� $��	진척도��$ 80�� �� *
Progress+�� -    ��Name$ MakeNewBusinessBtn��
�������$
��Left=�$	��Top=�$	��180��$��
20,449,0,0q�$��1�����	#FF41A681$��57��$��14(�$��Normal"�.���� 
�������$#��새 비지니스 시작하기����Z� �� -    ��Name$ BusinessTitle��$��Stretch=�$��21,511,315,30q�$��1��$
��Wrap=�$��Center=�$��28��$��20(�
�������$ No���� -   $ DeleteBusinessBtn��$��선택한 업무 삭제��$
��Left=�$	��Top=�$	��149��$��
688,22,0,0q�$��1�����	#FFE80000�� $
��100%��$
��Left=�$	��Top=�$��811,525,-1,0q�$��1�����	#DDFFFFFF��Z� � -    �Name$ BusinessProcessBar��$
��Left=�$��23��$	��Top=�$	��851��$��0,548,-1,-2q�$��1�����	#FF008957���	#FF3EC167���	#FF4BA4F2�� -	   $ OpenBusinessBtn��$
��Left=�$	��Top=�$	��150��$��685,447,0,0q�$��1��$��55�����	#FF4BA4F2$��16(�
�������.���� $��업무 열기��$
��Left=�$	��Top=����	#DDFFFFFF��Z� � -
   ���	#FF3E3740$��	0,0,0,564q�$��2��.+���  �� Orientation$ 
Horizontal=�$��Right=�.+��� -   $ 
RefreshBtn��$��0,3,5,4q�$
��Auto��$��51�����	#FF41A681
�������.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Refresh=��� -   $ MinimizeBtn��$��0,3,5,4q�$
��Auto��$��51�����	#FF4BA4F2
�������.��  $ WindowMinimize=��� -   $ CloseBtn��$��66��$
��Auto��$��0,3,5,4q����	#FFC50024
�������.��  $��20��$��20��$ Power=�$
 -0.339,0.385&��� $
��Left=�$��29��$��5,5,0,0q�$	��Top=�$��28��$��Resource/PO.ico���� $��BIMPO��$
��Left=�$	��Top=�$��35,0,0,0q�
����������	#DDFFFFFF$��18(�$��30����Z� �� -   $  AttainedBusinessPercentage��$
��Left=�$��	145,1,0,0q�$
��Wrap=�$��전체 100% 달성��$	��Top=�$��20��$	��106��
�������$��14(�� -   $ ProgressAverBar��$
��Left=�$��10��$��
145,20,0,0q�$	��Top=�$	��100�����	#FF00375D���	#FF4BA4F2���	#FF4BA4F2