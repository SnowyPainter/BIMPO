   M S B A M L   `   `   `  ����e  aBIMPO_BusIness Management Process Observer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:BIMPO_BusIness_Management_Process_Observer*BIMPO_BusIness_Management_Process_Observer  5   	   J    DBIMPO_BusIness_Management_Process_Observer.NewBusinessCreationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Jlocal8clr-namespace:BIMPO_BusIness_Management_Process_Observer     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��500��5	   	   $	��500��6     � 
ResizeMode$  NoResize=�6"    � Icon$ Resource/PO.ico��68    � WindowStyle$
 None=�6O   .��5
      � -   5        ���	#FFD9B589.+�5   
   �� -   5         ��Name$ BusinessTitle��5      $
��Left=�6)   $��50��6D   $��113,155,0,0q�6P    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��247��6�   $��22(�6�    �� 
CaretBrush �	#FFF2B705
������� �� SelectionBrush �	#FFF2B705���	#FF735D366�   �� 5   
   $��사업 이름��6   $
��Left=�6    $	��Top=�6;   $��
30,120,0,0q�6S   $��22(�6g   
�������$
��Bold"�6�   �� 5   
   -   5         ��Name$ SubmitBtn_Clicked��5      $��확인��6,   $
��Left=�69   $	��Top=�6T   $	��250��6l   $��125,425,0,0q�6x   $��63��6�   $��24(�6�   ���	#FF735D36
�������6�   �� 5   
   -   5        $ CloseBtn��5      $
��Left=�6#   $	��Top=�6>   $��55��6V   $��435,462,0,0q�6a   $��28��6v   
����������	#FF8C0E03.��5      '  !MaterialDesignThemes.Wpf.PackIcon  $��0,0,0,0q�6&   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ CloseBox=�67   $��20��6G   $��20��6S   6`   5      � 5   
   $
��Left=�6   $	��100��6*   $	��Top=�67   $	��500��6O   ���	#FF010E26.+�5      �� $"��비지니스를 시작하기��6   $
��Left=�6)   $��	25,20,0,0q�6D   $	��Top=�6W   $��36(�6o   $
��Bold"�6}   
�������$��55��6�   $	��345��6�   ��6�   Z� 6�   5      �� 5   
   -   5        $ BusinessScale_Textbox��5      $
��Left=�61   $��50��6L   $��113,270,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $	��247��6�   $��22(�6�    �	#FFF2B705
������� �	#FFF2B705���	#FF735D366�   �� 5   
   $��목표 규모(1=1만원)��6   $
��Left=�6'   $	��Top=�6B   $��
28,221,0,0q�6Z   $��22(�6n   
�������$
��Bold"�6�   �� 5   
   -   5        $ MonthlySales_Textbox��5      $
��Left=�60   $��50��6K   $��113,365,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��247��6�   $��22(�6�    �	#FFF2B705
������� �	#FFF2B705���	#FF735D366�   �� 5   
   $%��목표 한달 매출(1=1만원)��6   $
��Left=�6*   $	��Top=�6E   $��
30,321,0,0q�6]   $��22(�6q   
�������$
��Bold"�6�   5      5      