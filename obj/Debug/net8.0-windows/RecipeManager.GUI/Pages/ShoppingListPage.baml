   M S B A M L   `   `   `  ����C  ?CookBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:CookBook.RecipeManager.GUI.Pages CookBook.RecipeManager.GUI.Pages  5      7    1CookBook.RecipeManager.GUI.Pages.ShoppingListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:CookBook.RecipeManager.GUI.Pages     5        N� Title$  ShoppingListPage��5      .��5
      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ]� $��0��6   $��0,0,0,20q�6!   .+�5      �� $��Shopping List��6   $��24(�5      $
��Bold"�5         TextPrimaryBrush#��[  5      �� 5      -   5        $��Add Item��5      $��Right=�5      $	��100��5      5      5      �� 5    
   $��1��6   $��1q�5!        BorderBrush#��[ 5"      
������� �� CornerRadius$ 4��5$      ._�5%      �� .��5&      �� -   5         ��Name$ shoppingList��5&      $��10q�65   ��5'      �� 5(      .R�5)      � $	��0,5q�6#    � ColumnDefinitions 5*   "   �� 5+   &   $
��Auto �67   �� 5,   &   $��* �67   �� 5-   &   $	��100 �67   �� 5.   &   $
��Auto �67   .+�52   "   �� $��0��6+   $��Center=�54   *   $��0,0,10,0q�55   *    d� 	IsChecked 53   *   �� *
IsSelected+55   *   �� 58   "   $��1��6,   $��Center=�5:   *   ��59   *   �� *Name+5:   *   �� 5=   "   -   5        $��2��5=   *   $	��5,0q�5?   *   $��Center=�5@   *   ��5>   *   �� *
Quantity+5B   *   �� 5E   "   -   5        $��3��5E   )   $	��✕��5F   )   $��30��5G   )   $��30��5H   )   $��5,0,0,0q�5I   )   
 � Tag 5K   )   �� 5L      5M      5O      5P      5Q      �� 5T   
   $��2��6    �� Orientation$ 
Horizontal=�5U      $��Right=�5V      $��0,20,0,0q�5W      .+�5X      �� -   5        $��Copy to Clipboard��5X      $	��150��5Y      $��0,0,10,0q�5Z      5[      �� 5]      -   5        $��Save as Text��5]      $	��150��5^      5_      5`      � 5c   
   -   5         �Name$ addItemPopup��5c      	 � 	StaysOpen$	 False��5e      
 � PlacementTarget
 5d      ��  �� ElementName$ MainGrid��.��5f      �� 
�������#��[ 5g      $��1q�5h      $ 4��5i       �� Padding$ 20q�5j      ._�5k      �� $	��300��6   .+�5l      �� $��Add New Item��6    $��18(�5m      $
��Bold"�5n      $��0,0,0,15q�5o      �� 5q      $��
Item Name:��6    $��0,0,0,5q�5r      �� 5s      -   5         ��Name$ txtNewItemName��5s      $��0,0,0,15q�5t      �� 5v      $��	Quantity:��6    $��0,0,0,5q�5w      �� 5x      -	   5        $ txtNewItemQuantity��5x      $��0,0,0,15q�5y      �� 5{      $ 
Horizontal=�6!   $��Right=�5|      .+�5}      �� -
   5        $��Cancel��5}   !   $	��100��5~   !   $��0,0,10,0q�5   !   5�   !   �� 5�      -   5        $	��Add��5�   !   $	��100��5�   !   5�   !   5�      5�      5�      5�      5�      5�      