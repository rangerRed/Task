   M S B A M L   `   `   `  ����@  <Task2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Task2.ModelTask2.Model  5   	   clr-namespace:Task2Task2  5   	       Task2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +modelclr-namespace:Task2.Model     5   	   %localclr-namespace:Task2     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$
 Task��5	   	   $	��600��6   $
��1200��6#   .��5
      � .+�5   
   R� -   5         R�Name$	 trv��5   v    %� IsVirtualizing .  %� VirtualizationMode$ 	Recycling=�6@   $
��Left=�6�   $��
10,10,0,70q�6�   $	��280��6  ��6�   �� *
Children+��5      �� 5       �� DataType$ x:Type model:BaseItem��6+    �� ItemsSource 6L   �� *
Children+.R�5      �  � ColumnDefinitions 5      �� 5      $	��190 �6/   �� 5      $��18 �6/   .+�5      �� $��0��6    ��60   �� *Name+�� 5      $��1��6#   $��Center=�63   y�6N   �� *	Visible+ d� 	IsChecked 6m   �� *TreeViewChecked+5      5      5      �� 5   
   $��300,10,10,10q�6   	 �� CornerRadius$	 3��6'   ���#f3f3f3._�5      �� !
 �� IsDeferredScrollingEnabled
 . $
��auto=�6J   .��5      �� -   5         ��Name$
 txBl��5      $��Consolas)�6*   $��18(�6@   $��Center=�6N   $��30q�6i   $V��PДля просмотра содержимого
выберите элемент��6u   5      5      �� 5   
   -   5        $��10q�5      $��Bottom=�6   $
��Left=�68   $��50��6S   $	��280��6_   $%��Сохранить заново��6k   $��14(�6�   6�   5      5       