   M S B A M L   `   `   `  ����e  aBIMPO_BusIness Management Process Observer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:BIMPO_BusIness_Management_Process_Observer*BIMPO_BusIness_Management_Process_Observer  5   	   B    <BIMPO_BusIness_Management_Process_Observer.DiagramShowWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   Dlocal8clr-namespace:BIMPO_BusIness_Management_Process_Observer  5   	   -   5          � Title$  MemoChartWindow��5	   	   $	��844��6!   $
��1489��6.    � WindowStartupLocation$ CenterScreen=�6;    � WindowStyle$
 None=�6`   $	��300��6s   $	��200��6�   .��5
      � .+�5   
   � -   5        $	��Top=�5      $��Stretch=�6'   $��40��6E   $��0,0,0,10q�6v   ���	#FF191726.+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5        $��33��5      ���	#DDFFFFFF���	#FF5C57F2
�������$	��Top=�6�   $��0,3,5,4q�6�   $
��Left=�6�   $��51��6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ InformationCircle=�6.   $��20��6G   $��20��6R   5      �� 5      -   5         ��Name$ DownloadDiagramBtn��5      $��33��65   ���	#DDFFFFFF���	#FF0ABF04
�������$	��Top=�6�   $��0,3,5,0q�6�   $
��Left=�6�   $��51��6�   .��5        $ Download=�6.   $��20��6>   $��20��6I   5      �� 5      -   5        $��33��5      ���	#DDFFFFFF���	#FFD9B504
�������$	��Top=�6~   $��0,3,5,4q�6�   $
��Left=�6�   $��51��6�   .��5        $ Share=�6.   $��20��6;   $��20��6F   5      �� 5      -   5        $ MaximizeBtn��5      $��0,3,5,4q�6.   $
��Auto��6?   $��51��6M   
����������	#FFF28705.��5        $ WindowMaximize=�6.   5      �� 5      -   5        $ MinimizeBtn��5      $��0,3,5,4q�6.   $
��Auto��6?   $��51��6M   
����������	#FFF28705.��5        $ WindowMinimize=�6.   5      �� 5      -   5        $ CloseBtn��5      $��66��6+   $
��Auto��66   $��0,3,5,4q�6D   ���	#FFD10026
�������.��5        $��20��6.   $��20��6:   $ Power=�6E    J� RenderTransformOrigin$ -0.339,0.385&�6R   5      5      �� 5       $
��Left=�6   $��29��6/   $��5,5,0,0q�6;   $	��Top=�6L   $��28��6d   $��Resource/PO.ico��6o   �� 5!      $��BIMPO��6   $
��Left=�6$   $	��Top=�6?   $��35,2,0,0q�6W   
����������	#DDFFFFFF$��18(�6�   $��30��6�   ��6i   Z� 6�   5#      �� 5$   
   -	   5         ��Name$ DiagramCanvas��5$      $��Stretch=�6(   $��
270,40,0,1q�6D   ���	#FFC2DCF26�   ]� 5%   
   $��Stretch=�6   ��.  $	��268��6F   $
��Left=�6R   ���	#FFF0F0F0$��
0,40,0,101q�6�   .+�5&      �� -
   5         ��Name$ WorkItemListview��5&      $��Disabled=�61   $��Stretch=�6g   $	��270��6�   ���	#89FFFFFF���	#DD000000$��0,0,0,1q�6  ���	#FFC2DCF2��5'      �� 5(      	 �� 
TargetType"	 ��6   
 �� Triggers
 5)      P� 5*       P� Property �@J�IsMouseOver P� Value . . �5+   "   ��  �� Property � �� �� Value
 ���� 6?   �� 5,   "    � ��$ 0q�6D   5-      P� 5.       �@��
IsSelected . . �5/   "   ��  � ��
 ���� 6?   �� 50   "    � ��$ 0q�6D   51      53      ��55      �� 56      .R�57      �� $ Vertical=�6%   $	��Top=�6<   58      ��5:      �� 5<      .R�5=      �  �Name$ BackgroundGrid��6X   $
��Left=�6   $��0,10,0,0q�6:   $	��247��6L   ��6p   �� *BackgroundColor+"  System.Windows.Media.Brushes   Black �� TargetNullValue# Z .+�5>      �� $��5,10,0,0q�6(   $��WrapWithOverflow=�6:   $
��Left=�6q   $	��Top=�6�   $��15(�6�   
���������6Z   �� *Title+6�   �� 5?      $
��Left=�6$   $��0,40,0,0q�6A   .��5@   "   �� 
�������$��11(�6?   $��WrapWithOverflow=�6M   ��6o   �� *	Content+5A      5B      5C      5F      5G      �� 5H   
   -   5        $��메모��5H      $
��Left=�6   $	��Top=�69   $��75��6Q   $��92,780,0,-14q�6\   ���	#FF5C57F2
�������$��70��6�   �� 5I   
   -   5        $��업무��5I      $
��Left=�6   $	��Top=�69   $��75��6Q   $��10,780,0,-14q�6\   
����������	#FF5C57F2$��70��6�   �� 5J   
   -   5        $��저장��5J      $
��Left=�6   $��75��69   $��189,780,0,-14q�6D   
����������	#FF3C8927$
��Auto��6�   �� 5K   
   $
��Left=�6   $
��Wrap=�6/   $��리스트 보기��6C   $	��Top=�6Q   $��
15,749,0,0q�6i   $��30��6}   $	��245��6�   $��18(�6�   5L      5M      