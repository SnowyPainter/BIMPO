   M S B A M L   `   `   `  ����e  aBIMPO_BusIness Management Process Observer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:BIMPO_BusIness_Management_Process_Observer*BIMPO_BusIness_Management_Process_Observer  5   	   ;    5BIMPO_BusIness_Management_Process_Observer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Jlocal8clr-namespace:BIMPO_BusIness_Management_Process_Observer     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  StartupWindow��5   	    � Title$ Hello BIMPO!��5	   	   $	��600��6   $	��850��6+    � 
ResizeMode$ NoResize=�67    � WindowStartupLocation$ CenterScreen=�6M    � Icon$ /Resource/PO.ico��6r    � WindowStyle$
 None=�6�   .��5
      � -   5         �Name$ BackgroundGrid��5
       � Cursor$ Arrow��6#   ���	#FFE0E0E0 � RowDefinitions 5   
   �� 5      $	��31* �6   �� 5      $
��569* �6   .+�5   
   �� -   5        	 ��Name$	 GreetingLabel��5      $��안녕하세요 이름님��6'   $
��Left=�6;   $	��Top=�6V   
 J� RenderTransformOrigin$
 
0.909,1.53&�6n   $��	20,24,0,0q�6�   $��41��6�   $	��467��6�   $��24(�6�   $
��Bold"�6�   $��1��6�   
�������6�   �� 5   
   -   5         ��Name$ BusinessListView��5      $
��Left=�6-   $	��351��6H   $��	22,74,0,0q�6U   $	��Top=�6h   $	��816��6�   $��16(�6�   $��1��6�    �� SelectionMode$ Single=�6�    �� View 5      �� 5      .P�5      �� $��업무��6%    �� Width$	 500��61    �� DisplayMemberBinding 6=   �� *BusinessTitle+�� 5      $��	시작일��6%   $	 200��62    6>   �� *	Degdate+�� 5      $��	진척도��6%   $ 80��62    6=   �� *
Progress+5      5      �� 5   
   -   5         ��Name$ MakeNewBusinessBtn��5      
�������$
��Left=�6A   $	��Top=�6\   $	��180��6t   $��
20,449,0,0q�6�   $��1��6�   ���	#FF41A681$��57��6�   $��14(�6�   $��Normal"�6�   .��5      �� 
�������$#��새 비지니스 시작하기��6'   ��6=   Z� 6U   5      �� 5   
   -   5         ��Name$ BusinessTitle��5      $��Stretch=�6+   $��21,511,315,30q�6I   $��1��6`   $
��Wrap=�6m   $��Center=�6�   $��28��6�   $��20(�6�   
�������$ No��6�   �� 5   
   -   5        $ DeleteBusinessBtn��5      $��선택한 업무 삭제��6,   $
��Left=�6@   $	��Top=�6[   $	��149��6s   $��
688,22,0,0q�6   $��1��6�   ���	#FFE800006�   �� 5    
   $
��100%��6   $
��Left=�6   $	��Top=�6:   $��811,525,-1,0q�6R   $��1��6h   ���	#DDFFFFFF��6u   Z� 6�   � 5!   
   -   5         �Name$ BusinessProcessBar��5!      $
��Left=�62   $��23��6M   $	��Top=�6Y   $	��851��6q   $��0,548,-1,-2q�6}   $��1��6�   ���	#FF008957���	#FF3EC167���	#FF4BA4F25"      �� 5#   
   -	   5        $ OpenBusinessBtn��5#      $
��Left=�6*   $	��Top=�6E   $	��150��6]   $��685,447,0,0q�6i   $��1��6~   $��55��6�   ���	#FF4BA4F2$��16(�6�   
�������.��5$      �� $��업무 열기��6   $
��Left=�6$   $	��Top=�6?   ���	#DDFFFFFF��6W   Z� 6m   5%      � 5'   
   -
   5        ���	#FF3E3740$��	0,0,0,564q�5'   K   $��2��6^   .+�5(      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5)      �� -   5        $ 
RefreshBtn��5)      $��0,3,5,4q�6-   $
��Auto��6>   $��51��6L   ���	#FF41A681
�������.��5*      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Refresh=�6.   5+      �� 5,      -   5        $ MinimizeBtn��5,      $��0,3,5,4q�6.   $
��Auto��6?   $��51��6M   ���	#FF4BA4F2
�������.��5-        $ WindowMinimize=�6.   5.      �� 5/      -   5        $ CloseBtn��5/      $��66��6+   $
��Auto��66   $��0,3,5,4q�6D   ���	#FFC50024
�������.��50        $��20��6.   $��20��6:   $ Power=�6E   $
 -0.339,0.385&�6R   51      52      �� 53      $
��Left=�6   $��29��6/   $��5,5,0,0q�6;   $	��Top=�6L   $��28��6d   $��Resource/PO.ico��6o   �� 54      $��BIMPO��6   $
��Left=�6$   $	��Top=�6?   $��35,0,0,0q�6W   
����������	#DDFFFFFF$��18(�6�   $��30��6�   ��6i   Z� 6�   55      �� 56   
   -   5        $  AttainedBusinessPercentage��56      $
��Left=�68   $��	145,1,0,0q�6S   $
��Wrap=�6f   $��전체 100% 달성��6z   $	��Top=�6�   $��20��6�   $	��106��6�   
�������$��14(�6�   � 57   
   -   5        $ ProgressAverBar��57      $
��Left=�6/   $��10��6J   $��
145,20,0,0q�6V   $	��Top=�6j   $	��100��6�   ���	#FF00375D���	#FF4BA4F2���	#FF4BA4F26�   59      5:      