   M S B A M L   `   `   `  ����F  BWpfAppDemos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppDemosWpfAppDemos  5   	   "    WpfAppDemos.DataTemplateDemo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfAppDemos     5   	   -   5          � Title$  DataTemplateDemo��5   	   $	��450��6"   $	��800��6/    � 	Resources 5
         lblStyle �� 
TargetType �� Property �� Value  lblExtStyle �� BasedOn  empTmplt �� Orientation �� Path��%u  &	        &	 �     7   &	 �     �� 5   
   " ��6!   .�5      ��  � ��
 ��  �6+   �� 5       � ��
 � ���6+   �� 5       � ��$ 30(�6)   5      �� 5   
   " ��6$   8   .�5      ��  � ��
 �  ��6+   5      �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� ��6    �� $ Ecode��� 5      $��       ��6    �� 5#      ��6    �� $ Ename��� 5$      $��       ��6    �� 5(      ��6    �� $ Salary��� 5)      $��       ��6    �� 5-      ��6    �� $ Deptid��� 5.      $��       ��6    50      52      53      .��55      ��  57   
   ��%�   &	        �� 58      " ��6%   .�59      ��  � ��
 �  ��6/   �� 5:       � ��
 � ���6/   �� 5;       � ��$ 30(�6-   5<      5=      .+�5A   
   �� .+�5B      �� $��DataGrid Demo��6   ��6,   ��  �� Source# [  �� 5C      $��DataGrid Demo 2��6   ��6.   �� # [ 5D      &   System.Windows.Controls.DataGrid  5F   
   -   5        $��dgEmp��5F      	   CanUserAddRows	 .  
   CanUserDeleteRows
 .     CanUserSortColumns . 6Q   �� 5G   
   $��DataGrid Demo��6   ��6(   �� # [  5J      5K      