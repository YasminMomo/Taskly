   M S B A M L   `   `   `  ����D  @TasklyApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TasklyApp.ViewsTasklyApp.Views  5      ;"clr-namespace:TasklyApp.ViewModelsTasklyApp.ViewModels  5      "    TasklyApp.Views.TaskOverview   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:TasklyApp.Views     5      9
viewmodels"clr-namespace:TasklyApp.ViewModels     5        � DataContext  5      (   "TasklyApp.ViewModels.MainViewModel  5   
   .��5      � $��0 0 6 0q�6   .+�5   
   �� $	��170��6   ���#1A1C1E �� CornerRadius$ 6��63   $��0��6D   ._�5      �  � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $��* �6$   .+�5      � $��0��6   .+�5      �� $:��4pack://application:,,,/Resources/Images/Overview.png��6   $��24��6Z   $��24��6e   $
��Left=�6q   $��Center=�6�   $��
30 25 0 10q�6�   �� 5      $��Tasks Overview��6    $��13(�66   ���#1C8DFE$
��Left=�6Y   $��Center=�6t   $��
65 25 0 15q�6�   5      � 5      $��1��6   $��	0 0 10 20q�6$    � ColumnDefinitions 5      �� 5      $
��auto �6+   �� 5       $
��auto �6+   .+�5#      � $��0��6   $��0 0 20 0q�6+    5$      �� 5%      $
��auto �6/   �� 5&      $
��auto �6/   .+�5)      �� $��60(�6T   
�������$��Black"�6u   $��Center=�6�   $��Center=�6�   $��	40 5 40 5q�6�   $��0��6�   ��6%   �� *TaskOverviewModel.Tasks/Total+6�   �� 5*       �� Orientation$ Vertical=�6%   $��	100 0 0 0q�6<   $��Center=�6O   .+�5+      �� $��Active��6(   $��16(�66   ���#1C8DFE$
��Left=�6Y   $��Center=�6t   $��25 8 0 0q�6�   $��1��6�   �� 5,      $��Tasks��6(   $��16(�65   ���#1C8DFE$
��Left=�6X   $��Center=�6s   $��25 0 0 0q�6�   $��1��6�   5-      5.      � 50      $��1��6   $��	10 0 15 0q�6+   $��Right=�6>    51      �� 52      $��* �6,   �� 53      $��* �6,   �� 54      $��* �6,   .+�57      �� $	��160��6!   ���#1C8DFE$ 5��6B   $��0��6S   $��3q�6`   ._�58      �� $ 
Horizontal=�6)   .+�59   "   �� $��13(�6Z   $
��Bold"�6h   
�������$
��Left=�6�   $��Center=�6�   $��10 0 0 0q�6�   ��6,   �� *TaskOverviewModel.Tasks/Todo+6�   �� 5:   "   $��| To Do Tasks��6,   $��13(�6A   
�������$��Center=�6b   $��Center=�6   $��8 0 0 0q�6�   5;      5<      �� 5>      $	��160��6!   ���#FE761C$ 5��6B   $��1��6S   $��3q�6`   ._�5?      �� $ 
Horizontal=�6)   .+�5@   "   �� $��13(�6]   $
��Bold"�6k   
�������$
��Left=�6�   $��Center=�6�   $��10 0 0 0q�6�   ��6,   �� *!TaskOverviewModel.Tasks/OnGoing+6�   �� 5A   "   $��| On Going Tasks��6,   $��13(�6D   
�������$��Center=�6e   $��Center=�6�   $��8 0 0 0q�6�   5B      5C      �� 5E      $	��160��6!   ���#FE321C$ 5��6B   $��2��6S   $��3q�6`   ._�5F      �� $ 
Horizontal=�6)   .+�5G   "   �� $��13(�6Z   $
��Bold"�6h   
�������$
��Left=�6�   $��Center=�6�   $��10 0 0 0q�6�   ��6,   �� *TaskOverviewModel.Tasks/Done+6�   �� 5H   "   $��| Done Tasks��6,   $��13(�6@   
�������$��Center=�6a   $��Center=�6~   $��8 0 0 0q�6�   5I      5J      5K      5L      5N      5P      5Q      5R      