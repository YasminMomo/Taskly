   M S B A M L   `   `   `  ����D  @TasklyApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TasklyApp.ViewsTasklyApp.Views  5      ;"clr-namespace:TasklyApp.ViewModelsTasklyApp.ViewModels  5      #    TasklyApp.Views.TasksDueToday   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:TasklyApp.Views     5      9
viewmodels"clr-namespace:TasklyApp.ViewModels     5      $
��auto��5	      $
��auto��6     � DataContext  5
      1   +TasklyApp.ViewModels.TasksDueTodayViewModel  5   
   .��5      �� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $7��1pack://application:,,,/Resources/Images/Today.png��6   $��24��6O   $��24��6Z   $��
30 25 0 10q�6f   �� 5      $��Tasks Today��6   $��13(�6+   ���#FE321C$��Center=�6N   $��Center=�6k   $��
10 30 0 15q�6�   5      �� 5   
   ���#1A1C1E �� Padding$ 8q�6&    �� CornerRadius$ 5��62   $��Stretch=�6C   $	��180��6a   $��0 0 25 0q�6n   ._�5      �� $��Disabled=�6   $
��Auto=�6B   .��5      �� -   5         ��Name$ TasksDueTodayStackPanel��5   6   $ 
Horizontal=�6   .+�5      �� ��6#   �� *TasksDueToday+��5      �� 5      .R�5   "   �� $ 
Horizontal=�6-   5      ��5      �� 5       .R�5!   "      TasklyApp.Views.TaskCard  ���#101213$��0,0,8,0q�6W      Task 61   �� 6W   5"      5$      5%      5&      5'      5(      5)      