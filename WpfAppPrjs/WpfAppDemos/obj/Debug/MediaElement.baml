   M S B A M L   `   `   `  ����F  BWpfAppDemos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfAppDemosWpfAppDemos  5   	       WpfAppDemos.MediaElement   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfAppDemos     5   	     � Title$  MediaElement��5   	   $	��450��6   $	��800��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��68* �6   �� 5      $
��267* �6   �� 5      $	��84* �6   .+�5   
   �� -   5        $��	btnSelect��5      $��20(�6"   $��SELECT��60   $
��Left=�6A   $��48��6\   $��
616,10,0,0q�6h   $	��Top=�6|   $	��166��6�   6�   �� 5   
   -   5        $��lblMovie��5      $��Select Movie��6    $��20(�67   $
��Left=�6E   $��48��6`   $��	10,10,0,0q�6l   $	��Top=�6   $	��124��6�   �� 5   
   -   5        $��btnStart��5      $��20(�6!   $��START��6/   $
��Left=�6?   $��	10,10,0,0q�6Z   $��2��6m   $	��Top=�6z   $	��154��6�   $��64��6�    J� RenderTransformOrigin$ 0.775,0.532&�6�   6�   �� 5   
   -   5        $��btnPause��5      $��20(�6!   $��PAUSE��6/   $
��Left=�6?   $��
195,10,0,0q�6Z   $��2��6n   $	��Top=�6{   $	��148��6�   $��64��6�   6�   �� 5   
   -   5        $��	btnResume��5      $��20(�6"   $��RESUME��60   $
��Left=�6A   $��
447,10,0,0q�6\   $��2��6p   $	��Top=�6}   $	��152��6�   $��64��6�   6�   �� 5   
   -   5        $��btnStop��5      $��20(�6    $
��STOP��6.   $
��Left=�6=   $��
630,10,0,0q�6X   $��2��6l   $	��Top=�6y   $	��152��6�   $��64��6�   6�   r� 5   
   -   5        $��media1��5   /    r� LoadedBehavior$ Manual=�6   $
��Left=�6=   $	��247��6X   $��	10,10,0,0q�6e   $��1��6x   $	��Top=�6�   $	��772��6�   �� 5   
   -   5        $��txtFileName��5      $��20(�6'   $
��Left=�65   $��34��6P   $��
164,15,0,0q�6\   $
��Wrap=�6p   $��	TextBlock��6�   $	��Top=�6�   $	��435��6�   5      5      