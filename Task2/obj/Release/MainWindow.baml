   M S B A M L   `   `   `  ���� @  <Task2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Task2.ModelTask2.Model  clr-namespace:Task2Task2      Task2.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +modelclr-namespace:Task2.Model     %localclr-namespace:Task2       � WindowStartupLocation$  CenterScreen=� � Title$
 Task��$	��600��$
��1200��.��� .+�R� -    R�Name$	 trv�� %� IsVirtualizing . $
��Left=�$��
10,10,0,70q�$	��280������ *
Children+����  �� DataType$ x:Type model:BaseItem�� �� ItemsSource �� *
Children+.R��  � ColumnDefinitions �� $��15 ��� .+��� $��1������ *Name+�� $��0��$��Center=� d� 	IsChecked �� *TreeViewChecked+�� $��300,10,10,10q� �� CornerRadius$ 3�����#f3f3f3._��� !	 �� IsDeferredScrollingEnabled	 . $
��auto=�.���� -   
 ��Name$

 txBl��$��18(�$��Center=�$��30q�$W��QДля просмотра содержимого
 выберите элемент���� -   $��10q�$��Bottom=�$
��Left=�$��50��$	��280��$%��Сохранить заново��$��14(�