   M S B A M L   `   `   `  ����G  CMelgoza4Ever, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Melgoza4Ever.VistasMelgoza4Ever.Vistas  5      .    (Melgoza4Ever.Vistas.MenuPrincipalCliente   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Melgoza4Ever.Vistas     5        N� Title$  MenuPrincipalCliente��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � 	Resources 5   
      MenuItemStyle �� 
TargetType �� Property �� Value �� ScaleX �� ScaleY	 �� 
TargetType
 �� Padding � HorizontalOffset m� IsSubmenuOpen � VerticalOffset K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers P� Property P� Value N� EnterActions �� TargetProperty	 W� To g� Duration N� ExitActions  MenuSeparatorStyle��%�  &	        &	     �� 5      " m�6*   .�5      ��  � ��
 �����6/   �� 5       � ��$ 20,15q�6,   �� 5       � ��$ Center=�66   �� 5       � ��$ Center=�68   �� 5       � z� 5      �� 5      $ 1Q�6)   $ 1Q�64   5      �� 5       � �� 5      �� 5      "	 m�6*   .R�5       � $��Center=�6#   
������ .+�5!   "   �� $

 10,5q�6)   
������ ._�5"   &   �� $
��10,0q�67   $��Header��6E   5#   #   � 5$   "   $ -1��5%   %   #��z 5&   %   $��Bottom=�5'   %   $ 1��5(   %   .��5)   &   �� $
 10q�6-   ���#2E2E2E._�5*   *   �� $
 True��65   $ Cycle=�6H   5+   '   5,   #   5-      5.      50       51      P� 52       �@J�IsMouseOver$
 True��65   . �53      ��  � ��
 � ���67   54      P� 55       �@m�IsSubmenuOpen$
 True��67   . �56      ��  � ��
 � ���67   57      P� 58       �@J�IsMouseOver$
 True��65    59      �� 5:      .��5;   "   �� .��5<   &   W� $/ )(RenderTransform).(ScaleTransform.ScaleX)�5=   )    1.15>   )   $ 0:0:0.1D�5?   )   W� 5@   &   $/ )(RenderTransform).(ScaleTransform.ScaleY)�5A   )    1.15B   )   $ 0:0:0.1D�5C   )   5D   #   5E       5G      �� 5H      .��5I   "   �� .��5J   &   W� $/ )(RenderTransform).(ScaleTransform.ScaleX)�5K   )    15L   )   $ 0:0:0.1D�5M   )   W� 5N   &   $/ )(RenderTransform).(ScaleTransform.ScaleY)�5O   )    15P   )   $ 0:0:0.1D�5Q   )   5R   #   5S      5U      5W      �� 5Y      " ��6/   .�5Z      ��  � ��
 �����6/   �� 5[       � ��$ 1��6+   �� 5\       � ��$	 5,5q�6+   5]      5^      .+�5_   
   � $��0��6   ���#323D8F.+�5`      �� $	��500��5a      $	��100��5b      $��Center=�5c      � 5e      $	��416��6   $��Center=�6   .+�5f      �� $��Center=�6    �� Orientation$ 
Horizontal=�6:   .+�5g      �� -   5         ��Name$ text_Titulo��5h      $��40��5i      $	��300��5j      $��0,10,0,0q�5k      $��30(�5l      $
��Bold"�5m      
�������$��Zapateria 3 Hermanos��5o      5p      5q      5r      �� 5u   
   $��1��5v      $��50��5w      $	��Top=�5x      ���#2E2E2E$ 
Horizontal=�5z      .+�5}      o� $��1��5~      $	��Top=�5      ���#2E2E2E.@�5�      m� -   5         m�Name$ itemProductos��5�      #��[  5�      ��5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��Center=�5�   !   $��20(�5�   !   $
��Bold"�5�   !   $��	Productos��5�   !   5�      5�      m� 5�      -   5        $ itemCarrito��5�      #��[  5�      ��5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��Center=�5�   !   $��20(�5�   !   $
��Bold"�5�   !   $��Carrito��5�   !   5�      5�      m� 5�      -   5        $ itemOpciones��5�      #��[  61   ��5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��Center=�5�   !   $��20(�5�   !   $
��Bold"�5�   !   $��Opciones��5�   !   5�      .@�5�      m� -   5        $ itemAgregarBilletera��5�      $��Agregar Billetera��5�      #��[  5�      m� 5�      -   5        $ itemConsultarBilletera��5�      $��Consultar billeteras��5�      #��[  5�      5�      m� 5�      -   5        $ itemExit��5�      #��[  5�      ��5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��Center=�5�   !   $��20(�5�   !   $
��Bold"�5�   !   $��Salir��5�   !   5�      5�      5�      5�      � 5�   
   $��1��6   $��0,50,0,0q�6    � ColumnDefinitions 5�      �� 5�      $��* �6#   �� 5�      $
��Auto �6#   .+�5�       � -   5          �Name$ 	Container��5�       J� IsHitTestVisible$
 True��5�        � NavigationUIVisibility$ Hidden=�5�      5�      5�      5�      