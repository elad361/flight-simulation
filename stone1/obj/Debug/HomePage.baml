   M S B A M L   `   `   `  ����A  =stone1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:stone1stone1  5   	       stone1.HomePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:stone1     5   	     N� Title$  HomePage��5   	   $	��600��6   $	��900��6'    N� 
Background 5	      �� 5
   
    �� Color$
 Gray��6   5      .��5      �  � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��2* �6   .+�5    
   �� $��0��6   $��1��6    $
��Left=�6-   $��10,10q�6O   .��6^   !Please enter path to a CSV file6   �� 5!   
   -   5         ��Name$ CSVPath��5!      $��2��6#   $��0��60   
�������$	��400��6S   $
��Left=�6_   $��10,10q�6z   �� 5"   
   $��3��6   $��10,10q�6   .��6,   +)Please enter port to the FlightSimulation6W   �� 5#   
   -   5        $ portToFS��5#      $��4��6$   $	��400��61   $
��Left=�6=   $��10,10q�6X   6i   �� 5$   
   -   5        $��Show Simulation��5$      $��5��6+   $
��Left=�68   $	��100��6S   $��10,10q�6_   {�6�   ��  �� ElementName$ allSet�� �� Path$ 	IsChecked��� 5%   
   -   5         ��Name$ allSet��5%      $;��5FlightGear is open and XML settings file has uploaded��6#   $
��Left=�6c   $��6��6   $��10,10q�6�   $	��Top=�6�   5&      5'      