   M S B A M L   `   `   `  ���� e  aBIMPO_BusIness Management Process Observer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:BIMPO_BusIness_Management_Process_Observer*BIMPO_BusIness_Management_Process_Observer  ?    9BIMPO_BusIness_Management_Process_Observer.BusinessWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Jlocal8clr-namespace:BIMPO_BusIness_Management_Process_Observer     U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -   $	��790��$
��1430��  � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�.���  � RowDefinitions �� $��4* ��� $	��75* �.+�� -   ���	#FF3E3740.+���  �� Orientation$ 
Horizontal=�$��Right=�.+��� -   $��32�����	#DDFFFFFF���	#FF38592F
�������$	��Top=�$��0,3,5,0q�$
��Left=�$��51��.��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ InformationCircle=�$��20��$��20���� -    ��Name$ MinimizeBtn��$��0,3,5,5q�$
��Auto��$��51��
����������	#FF50B4F2.��  $ WindowMinimize=��� -   $ CloseBtn��$��66��$
��Auto��$��0,3,5,5q����	#FFD10026
�������.��  $��20��$��20��$ Power=� J� RenderTransformOrigin$ -0.339,0.385&��� $
��Left=�$��29��$��5,5,0,0q�$	��Top=�$��28��$��Resource/PO.ico���� $��BIMPO��$
��Left=�$	��Top=�$��35,2,0,0q�
����������	#DDFFFFFF$��18(�$��30����Z� �� -    ��Name$ WindowTitle��$��제목��$
��Left=�$	��Top=�$��	120,2,0,0q�$��35��$
��1095��$��18(����	#DDFFFFFF��Z� � -   	 �Name$	 MemoGrid��$
��Left=�$	��750��$��
1133,0,0,0q�$	��Top=�$	��297�����	#FFD9CCC5$��1��.+�� $
��Left=�$	��Top=�$��	10,10,0,0q��� $�� IDEA MEMOS��$
��Left=�$	��Top=�$��	99,23,0,0q�$
��Bold"�$��24(�
�������$	��196���� -   $ CreateNewMemoBtn��$��
새 메모��$
��Left=�$	��Top=�$	��100��$��
182,85,0,0q�$��42�����	#FFCBD966���	#DDFFFFFF
�������$��18(��� -	   $ SeeAllMemosBtn��$��다이어그램��$
��Left=�$	��Top=�$	��152��$��	15,84,0,0q����	#FFD9AB82
����������	#DDFFFFFF$��42��$��18(�$��Right=��� $
��Left=�$��	15,85,0,0q�$	��Top=����	#DDFFFFFF$��50��$��50��.��  $��40��$��40��$ MagnifyPlusOutline=��� $
��Auto=�$��Disabled=�$	��290��$��Right=�$��
0,155,0,10q�.���� -
   
 ��Name$
 	MemoStack��$
��Left=�$��0,0,0,0q�$	��Top=�$	��275��  $ 	Newspaper=�$��65��$��65��
�������$��	17,10,0,0q�� -   $	 DeadlineGrid��$
��Left=�$��45��$	��Top=�$	��835�����	#FFF2955E$��1��$��	298,0,0,0q�.+��� $��데드라인��$
��Left=�$��15,3,0,0q�$	��Top=�$ 	0.385,0.4&�$��20(�$��91�����	#DDFFFFFF��Z� (  "System.Windows.Controls.DatePicker  -     Name$ StartDate_DatePicker��$
��Left=�$��	120,9,0,0q�$	��Top=�$	��160��{�.     IsTodayHighlighted . ���	#99000000
�������  -   $ EndDate_DatePicker��$
��Left=�$��	340,9,0,0q�$	��Top=�$	��155�� . {�.  
����������	#99000000�� $
��Left=�$	��Top=�$��
325,45,0,0q�$��2��  $ Bridge=�$��	285,5,0,0q�$ 0.688,-0.25&�$��40��$��45��
��������� -   $ SaveDeadlineDateBn��$��데드라인 설정��$
��Left=�$	��Top=�$	��120��$��	705,8,0,0q����	#FF91A646
�������$ 0.917,0.531&��� -   $ LeftDatesLabel��$��N일 남음��$
��Left=�$	��Top=�$��
505,10,0,0q�$ 0.125,0.517&�
����������	#DDFFFFFF$��14(�4  .System.Windows.Automation.AutomationProperties   Name$ LeftDaysLabel����Z� � $
��Left=�$	��703��$��
318,47,0,0q�$��1��$	��Top=�$	��805��
�������.+��� -    ��Name$ TaskListView��$	��330��$	��Top=�$��
10,10,10,0q� �� SelectionMode$ Single=�$��Hidden=� �� View �� .P��� $��업무�� �� Width$	 300�� �� DisplayMemberBinding �� *Title+�� $��요약 설명��$	 300�� �� CellTemplate �� .R��� $��NoWrap=�$��20������ *
Describe+�� $ 60�� �� *
Priority+���� -   
 � Tag$ Priority��$��60��.��  -     Name$ SortPriorityIcon��$ ArrowUp=�$��25��$��20���� $��완수�� �� .R��� {�.  
��� � � d� 	IsChecked �� *Accomplished+�� $��우선순위��$
��Left=�$	��Top=�$��
572,26,0,0q��� $��	콘텐츠��$��60,349,-10,460q����	#FFFFA82B���	#DDFFFFFF$��16(��� $
��Left=�$��	0,337,0,0q�$	��Top=�
����������	#DD252525.��  $��50��$��50��$ Paper=����	#FF639CBF�� -    ��Name$ TitleTextbox��$
��Left=�$��40��$��
60,428,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��360�� �� 	MaxLength$ 30��$��20(� �� 	IsEnabled . {�.  �� -   $ DescribeTextbox��$
��Left=�$	��184��$��
60,488,0,0q�$
 Wrap=�$	��Top=�$	��470�� �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=� �� MaxLines$ 10000�� . {�.  $��16(��� $��제목��$
��Left=�$	��Top=�$��
10,428,0,0q�$ 0.588,0.769&�$��14(��� $��설명��$
��Left=�$	��Top=�$��
10,483,0,0q�$ 0.412,1&�$��14(��� -   $ EditTaskBtn��$��수정��$
��Left=�$	��Top=�$	��125��$��550,598,0,0q����	#FF999999���	#FF575757$ 0.524,0.375&�$��16(��� -   $ DeleteTaskBtn��$
��Left=�$	��Top=�$��60��$��745,391,0,0q����	#FFBF1F1F���	#FF252525$��16(�.��  $ TrashCan=�$��23��$��23�����	#DDFFFFFF�� -   $ TaskPriorityTextbox��$
��Left=�$��35��$��425,433,0,0q�$
 Wrap=�$	��Top=�$��45��$��16(�$��1�� �� 
CaretBrush
 �����
���   �$ 1��$ 1�� � Cursor$ IBeam��{�.  �� $��우선순위��$
��Left=�$	��Top=�$��405,407,0,0q�$ 0.345,1&�$��63���� $��세부 내용 및 수정��$
��Left=�$	��Top=�$��60,348,-12,0q�$��35��$	��757�����	#FFFFBF50$��18(����	#DDFFFFFF�� -   $ OpenCreateTaskWindowBtn��$��
새 업무��$
��Left=�$	��Top=�$	��255��$��550,638,0,0q�
����������	#FF91A646$��35��$��16(��� $��완료 여부��$
��Left=�$	��Top=�$��473,407,0,0q�$ 0.387,0.538&��� 
���   ����	#FFF3F3F3$��475,437,275,226q�._��� -     ��Name$  AccomplishCheckBox��$��14(�{�.  .��  $ Check=�$��25��$��25�����	#FF008919�� -   ! ��Name$! FileListbox��$
��Left=�$	��155��$	��Top=�$	��255��$��550,433,0,0q�
����������	#FFD9CCC5�� -   $ 
AddFileBtn��$��파일 추가��$	��Top=�$��700,596,0,0q����	#FFEAE23D���	#FF938502{�.  ���	#DD000000�� $
��Wrap=�$��파일 목록��$��550,412,170,265q�� -   " �Name$" BusinessProgressBar��$
��Left=�$��19��$	��Top=�$	��708��# � Orientation$# Vertical=����	#FFCBD966���	#FF85BB65���	#FF78E031$ 0.5,0.5&�$��1��$��
298,45,0,0q�z�V� .~��� �� �� $ �� Angle$$ -0.002Q�T� � $
��Left=�$	��750��$��1��$	��Top=�$	��300�����	#FF85BB65.+�  $ MoneyUsd=�
�������$��65��$��65��$��
211,10,0,0q��� $��회계 ��$��Right=�$
��Left=�$	��Top=�$��24(�
�������$	��196��$��	-1,23,0,0q�$��42��$��Microsoft YaHei UI)��� -   $��회계 파일 추가��$
��Left=�$��
20,135,0,0q�$	��Top=�$	��265��$��52��$��18(��� -   $ AccountingListview��$
��Left=�$	��345��$	��Top=�$	��260��$��
25,200,0,0q� �� .P��� $��	회계서�� �� *
FileName+�� -   % ��Name$% BusinessScale_TextBlock��$
��Left=�$
��Wrap=�$��0��$	��Top=�$��110,104,-1,0q�$	��191���� $
��Left=�$
��Wrap=�$��목표 사업 규모��$	��Top=�$��
20,104,0,0q��� -    $% MonthlySales_TextBlock��$
��Left=�$
��Wrap=�$��0��$	��Top=�$��
110,79,0,0q�$ -0.078,0.313&�$	��190���� $
��Left=�$
��Wrap=�$��목표 한달 매출��$	��Top=�$��	20,80,0,0q�