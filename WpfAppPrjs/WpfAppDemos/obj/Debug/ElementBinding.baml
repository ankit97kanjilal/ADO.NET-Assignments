   M S B A M L   `   `   `  ����F  BWpfAppDemos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppDemosWpfAppDemos  5   	        WpfAppDemos.ElementBinding   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfAppDemos     5   	     � Title$  ElementBinding��5   	   $	��450��6    $	��800��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��110* �6   �� 5      $
��244* �6   �� 5      $	��65* �6   .+�5   
   �� $��30(�6   $��Enter Data :��6   $
��Left=�65   $��	37,43,0,0q�6P   $	��Top=�6c   $��56��6{   $	��187��6�   �� 5   
   -   5        $��txtData��5      $��30(�6!   $
��Left=�6n   $��56��6�   $��
214,43,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��475��6�   ��6/   ��  �� ElementName$ 
sliderData�� �� Path$ Value� �� Mode$ TwoWay=�6�   �� 5   
   -   5        $��lblData��5      $��30(�6   $
��Left=�6p   $��	37,10,0,0q�6�   $��1��6�   $	��Top=�6�   $��54��6�   $	��323��6�   ��6-   �� $ 
sliderData��$ Value�$ Default=�6�   �� 5   
   $
��Left=�6   $	��224��6+   $��
469,10,0,0q�68   $	��Top=�6L   $	��261��6d   $��pic1.jpg��6p   $��1��6�   $
��Fill=�6�    J� Opacity 6�   �� $ 
sliderData��$ Value�6�   �� 5   
   -   5        $��
sliderData��5       � Minimum$ 0Q�6#    � Maximum$ 1Q�6/   	 � Value$	 0Q�6;   $
��Left=�6E   $��	37,22,0,0q�6`   $��2��6s   $	��Top=�6�   $	��652��6�   $��18��6�   5      5      