   M S B A M L   `   `   `  ����e  aBIMPO_BusIness Management Process Observer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:BIMPO_BusIness_Management_Process_Observer*BIMPO_BusIness_Management_Process_Observer  5   	   A    ;BIMPO_BusIness_Management_Process_Observer.TaskCreateWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Jlocal8clr-namespace:BIMPO_BusIness_Management_Process_Observer     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
Create New��5	   	   $	��495��6   $	��364��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterOwner=�6K    � WindowStyle$
 None=�6o   .��5
      � ���	#FFD9B589.+�5   
   � -   5        $��
0,0,-1,455q�5   5   ���	#FF010E26.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5         ��Name$ MinimizeBtn��5      $��0,3,5,5q�6.   $
��Auto��6?   $��49��6M   
����������	#FF735D36.��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowMinimize=�6.   5      �� 5      -   5        $ CloseBtn��5      $��51��6+   $
��Auto��66   $��0,3,5,5q�6D   ���	#FF8C0E03
�������.��5        $��20��6.   $��20��6:   $ Power=�6E    J� RenderTransformOrigin$ -0.339,0.385&�6R   5      5      �� 5      $
��Left=�6   $��29��6/   $��5,5,0,0q�6;   $	��Top=�6L   $��28��6d   $��Resource/PO.ico��6o   �� 5      $��새 업무 생성��6   $
��Left=�6&   $	��Top=�6A   $��40,0,0,0q�6Y   
����������	#DDFFFFFF$��22(�6�   $��38��6�   ��6k   Z� 6�   5      �� 5   
   -   5         ��Name$ TitleTextbox��5      $
��Left=�6(   $��51��6C   $��	20,79,0,0q�6O   	 �� TextWrapping$
	 Wrap=�6b   $	��Top=�6v   $	��325��6�   
 �� 	MaxLength$
 30��6�   $��20(�6�    �� 	IsEnabled . ���	#FF735D36 �� 
CaretBrush �	#FF735D36 �� SelectionBrush �	#FF735D36
�������6  �� 5   
   -   5        $ DescribeTextbox��5      $
��Left=�6+   $	��186��6F   $��
20,174,0,0q�6S   $
	 Wrap=�6g   $	��Top=�6{   $	��325��6�    �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�6�    �� MaxLines$ 10000��6�    . $��16(�6  �� 5   
   $��제목��6   $
��Left=�6   $	��Top=�68   $��	15,45,0,0q�6P   $ 0.588,0.769&�6c   $��22(�6�   $��35��6�   $��58��6�   $
��Bold"�6�   ���	#DDFFFFFF6�   �� 5   
   $��설명��6   $
��Left=�6   $	��Top=�68   $��
15,135,0,0q�6P   $ 0.412,1&�6d   $��20(�6�   $��37��6�   $��53��6�   $
��Bold"�6�   ���	#FF010E266�   �� 5   
   -   5        $ TaskPriorityTextbox��5      $
��Left=�6/   $��35��6J   $��120,375,0,0q�6V   $
	 Wrap=�6k   $	��Top=�6   $��35��6�   $��20(�6�   $��1��6�   
 ��������	#FF010E26$ 1��6  $
 1��6(   � Cursor$ IBeam��66  ���	#FF735D366E  �� 5   
   $��우선순위��6   $
��Left=�6   $	��Top=�6:   $��
15,375,0,0q�6R   $ 0.345,1&�6f   $��38��6�   $��95��6�   $��22(�6�   $
��Bold"�6�   ���	#DDFFFFFF6�   �� 5   
   -   5        $��저장��5      $
��Left=�6   $	��Top=�69   $	��125��6Q   $��220,380,0,0q�6]   $��45��6r   
����������	#FF735D366�   5       5!      