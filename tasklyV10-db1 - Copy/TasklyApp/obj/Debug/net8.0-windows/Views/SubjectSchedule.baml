   M S B A M L   `   `   `  ����D  @TasklyApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TasklyApp.ConvertersTasklyApp.Converters  5      ;"clr-namespace:TasklyApp.ViewModelsTasklyApp.ViewModels  5      %    TasklyApp.Views.SubjectSchedule   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:TasklyApp.Converters     5      9
viewmodels"clr-namespace:TasklyApp.ViewModels     5      $	��300��5   3     � 	Resources  5      4   .TasklyApp.Converters.AlternatingColorConverter   AlternatingColorConverter��%   &	          5   
   6*   5       � DataContext 5      /   )TasklyApp.ViewModels.SubjectScheduleModel  5   
   .��5      � .+�5   
   �� ���	#00FFFFFF$��0q�6K   
������ $��0q�5   (   ��5      �� *	Schedules+��5      �� 5       �� 
TargetType" ��6"   .R�5      � .+�5      ��  ��Name$ ScrollViewer��6'   $
��Auto=�6=   $
��Auto=�6`   .��5      �� 5      5      5      ��5!      �� 5"      .R�5#      � $��5q�6    � ColumnDefinitions 5$      �� 5%      $
��Auto �6/   �� 5'      $��* �6/   .+�5,      �� $��80��6!   $��35��6,    �� CornerRadius$ 16��68   $��0��6J   $��5q�6Z   ��5-      `� 5.   "    `� 	Converter# [  6/   .1�5/   &   ��  �� Path$ ItemsSource�6e    �� RelativeSource 6.   �� 	 �� AncestorType	 ListBox6e   �� 50   &   51   #   ._�53      �� 
�������$��14(�6T   $
��Bold"�6b   $��Center=�54   $   $��Center=�6?   ��53   (   �� *	Subject+54   ?   55      �� 58      $	��450��6!   $��35��6-   ���#373A3D$ 16��6N   $��1��6`   $��	25,0,15,0q�59      
 �� Padding$
 10q�60   $��Right=�5:      ._�5;      �� 
�������$��12(�6Q   $��Center=�5<   $   $��Center=�6?   $
��Wrap=�6\   ��5;   (   �� *Time+5<   \   5=      5>      5?      ��5B      �� 5C       �� 
TargetType" ��6   .�5E      ��  �� Property � �� �� Value
 ���� 63   �� 5F       � ��
 �����63   �� 5G       � ��
 ���� 64   �� 5I       � ��$ 0q�68    �� Triggers 5L      �� 5N       �� Binding 6&   �� *
IsSelected+ �� *Self+ �� Value True6k   .a�5O      ��  � ��
 ���� 6;   5Q      P� 5T       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5U      ��  � ��
 ���� 6<   �� 5V       � ��$ 0q�6@   5W      5Y      5\      5]      5_      