   M S B A M L   `   `   `  ����S  OBdd_Fleur_Demare_Delgado, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Bdd_Fleur_Demare_DelgadoBdd_Fleur_Demare_Delgado  5   	   -    'Bdd_Fleur_Demare_Delgado.StoreDashboard   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Bdd_Fleur_Demare_Delgado     5   	     � Title$  StoreDashboard��5   	   $
��1000��6    $
��1900��60   ���#1C1358 � WindowState$ 	Maximized=�5	   	   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��259 �6   �� 5      $	��316 �6   �� 5      $	��341 �6   �� 5      $	��276 �6   �� 5      $	��654 �6   .+�5   
   � $��0��6   .+�5      �� -   5         ��Name$ StockButton��5      $	��230��6*   $	��306��67   $��Center=�6k   $��Center=�6�    J� RenderTransformOrigin$ -0.286,0.237&�6�   ��6T   Z� ��5      �� 5       �� ImageSource$ images/LogoStock.png��6!    j� Stretch$ Uniform=�6D   5      �� 5      $��Stock��6   $��
96,646,0,0q�6%   
�������$��36(�6L   $	��Top=�6Z   $��Fonts/#Simply Rounded)�6r   $
��Left=�6�   $	��169��6�   $	��277��6�   6�   5      � 5   
   $��1��6   .+�5      �� -   5        $ OrderButton��5      $	��230��6*   $	��306��67   $��Center=�6k   $��Center=�6�   $ -0.286,0.237&�6�   ��6T   Z� ��5      �� 5       $ images/LogoCommande.png��6!   $ Uniform=�6G   5"      �� 5$      $��Order��6   $��129,648,0,0q�6%   
�������$��36(�6M   $	��Top=�6[   $��Fonts/#Simply Rounded)�6s   $
��Left=�6�   $	��169��6�   $	��277��6�   6�   5%      � 5&   
   $��2��6   .+�5'      �� -   5        $ 
StatButton��5'      $	��230��6)   $	��306��66   $��Center=�6i   $��Center=�6�   $ -0.286,0.237&�6�   ��6R   Z� ��5(      �� 5)      $ images/LogoStats.png��6!   $ Uniform=�6D   5+      �� 5-      $��Stats��6   $��131,651,0,0q�6%   
�������$��36(�6M   $	��Top=�6[   $��Fonts/#Simply Rounded)�6s   $
��Left=�6�   $	��169��6�   $	��277��6�   6�   5.      � 5/   
   $��3��6   .+�50      �� -   5        $ CustomerButton��50      $	��230��6-   $	��306��6:   $��Center=�6q   $��Center=�6�   $ -0.286,0.237&�6�   ��6Z   Z� ��51      �� 52      $ images/LogoClient.png��6!   $ Uniform=�6E   54      �� 56      $��	Customers��6   $��
59,660,0,0q�6)   
�������$��36(�6P   $	��Top=�6^   $��Fonts/#Simply Rounded)�6v   $
��Left=�6�   $	��169��6�   $	��277��6�   6�   57      � 59   
   $��4��6   $��0,0,10,0q�6   .+�5;      �� -   5        $��
ButtonMenu��5;      $
��Menu��6'   $��0,0,372,345q�67   $	��247��6L   $	��178��6X   ���#3159C9$��24(�6z    �� 	ClickMode$ Release=�6�   ���#65A1F1$��Fonts/#Simply Rounded)�6�   ���#5B50B9$��Right=�6  $��Bottom=�6  6<  5=      5>      5?      