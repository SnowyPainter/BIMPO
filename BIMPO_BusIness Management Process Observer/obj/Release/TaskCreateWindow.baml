   M S B A M L   `   `   `  ���� e  aBIMPO_BusIness Management Process Observer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:BIMPO_BusIness_Management_Process_Observer*BIMPO_BusIness_Management_Process_Observer  A    ;BIMPO_BusIness_Management_Process_Observer.TaskCreateWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Jlocal8clr-namespace:BIMPO_BusIness_Management_Process_Observer     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  
Create New��$	��495��$	��364�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=� � WindowStyle$
 None=�.��� ���	#FFD9B589.+�� -   $��
0,0,-1,455q����	#FF010E26.+���  �� Orientation$ 
Horizontal=�$��Right=�.+��� -    ��Name$ MinimizeBtn��$��0,3,5,5q�$
��Auto��$��49��
����������	#FF735D36.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowMinimize=��� -   $ CloseBtn��$��51��$
��Auto��$��0,3,5,5q����	#FF8C0E03
�������.��  $��20��$��20��$ Power=� J� RenderTransformOrigin$ -0.339,0.385&��� $
��Left=�$��29��$��5,5,0,0q�$	��Top=�$��28��$��Resource/PO.ico���� $��새 업무 생성��$
��Left=�$	��Top=�$��40,0,0,0q�
����������	#DDFFFFFF$��22(�$��38����Z� �� -    ��Name$ TitleTextbox��$
��Left=�$��51��$��	20,79,0,0q�	 �� TextWrapping$
	 Wrap=�$	��Top=�$	��325��
 �� 	MaxLength$
 30��$��20(� �� 	IsEnabled . ���	#FF735D36 �� 
CaretBrush �	#FF735D36 �� SelectionBrush �	#FF735D36
��������� -   $ DescribeTextbox��$
��Left=�$	��186��$��
20,174,0,0q�$
	 Wrap=�$	��Top=�$	��325�� �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=� �� MaxLines$ 10000�� . $��16(��� $��제목��$
��Left=�$	��Top=�$��	15,45,0,0q�$ 0.588,0.769&�$��22(�$��35��$��58��$
��Bold"����	#DDFFFFFF�� $��설명��$
��Left=�$	��Top=�$��
15,135,0,0q�$ 0.412,1&�$��20(�$��37��$��53��$
��Bold"����	#FF010E26�� -   $ TaskPriorityTextbox��$
��Left=�$��35��$��120,375,0,0q�$
	 Wrap=�$	��Top=�$��35��$��20(�$��1��
 ��������	#FF010E26$ 1��$
 1�� � Cursor$ IBeam�����	#FF735D36�� $��우선순위��$
��Left=�$	��Top=�$��
15,375,0,0q�$ 0.345,1&�$��38��$��95��$��22(�$
��Bold"����	#DDFFFFFF�� -   $��저장��$
��Left=�$	��Top=�$	��125��$��220,380,0,0q�$��45��
����������	#FF735D36