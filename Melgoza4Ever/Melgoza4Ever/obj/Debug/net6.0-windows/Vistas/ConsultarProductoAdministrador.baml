   M S B A M L   `   `   `  ����G  CMelgoza4Ever, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Melgoza4Ever.VistasMelgoza4Ever.Vistas  5      8    2Melgoza4Ever.Vistas.ConsultarProductoAdministrador   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Melgoza4Ever.Vistas     5        N� Title$$  ConsultarProductoAdministrador��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $	��130 �6   �� 5      $
��200* �6   �� 5      $��50 �6   .+�5   
   �� -   5        $��text_SearchBy��5      $��0��5      $	��200��5      $��
117,79,0,0q�5      $
��Left=�5      $	��Top=�5      $��16(�5       �� TextWrapping$
 Wrap=�5      �� 5   
   -   5        $��
btn_Search��5      $��0��5      $	��101��5      $��
688,78,0,0q�5      $
��Left=�5       $	��Top=�5!      $��Buscar��5#      $��16(�5$      &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ tableProductos��5&      $��1��5'      $
��1280��5(      $	��350��5)      $��Center=�5*      $��Center=�5+         AlternatingRowBackground �#E0E0E0   AutoGenerateColumns$ False��5-      ���#F5F5F5���#2E2E2E$��2,2,2,2q�50         CanUserAddRows$ False��51         CanUserDeleteRows$ False��52      	   CanUserResizeRows$	 False��53      
   HeadersVisibility$
 Column=�54         RowHeaderWidth$ 0Q�56      ��55      �� *Items+ � 	Resources 57      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell��%�  '        '      �� 58      "  6   .�59      ��  � �� �#FFFFFF63   �� 5:       � �� �#2E2E2E63   �� 5;       � ��$ 14(�61   �� 5<       � ��$
 Bold"�63   �� 5=       � ��$ 40��6/   �� 5>       � ��$ Center=�6C   5?      �� 5@      "  6   .�5A      ��  � �� �#00000063   �� 5B       � ��$ 12(�61   �� 5C       � ��$ 30��6/   �� 5D       � ��$ 10,0,0,0q�60   5E      5F         Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5I         FontSize$ 15Q�6&   ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��64      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� *name+  5J      $ 15Q�6&   $ 	Categoria��64   $	 200 6G    6S   �� *
category+  5K      $ 15Q�6&   $ Descripción��64   $	 200 6I    6U   �� *description+  5L      $ 15Q�6&   $ Precio��64   $	 200 6D    6P   �� *price+4  .System.Windows.Controls.DataGridTemplateColumn  5M      $ Editar Producto��6)      MinWidth$	 200Q�6B      CellTemplate 5N      �� 5O      .R�5P      �� -   5        $��Editar��5P   I   5Q      5T        5U      $ Eliminar Producto��6)   $	 200Q�6D    5V      �� 5W      .R�5X      �� -   5        $��Eliminar��5X   K   5Y      5\      5^      �� 5_   
   -   5        $��btn_Restore��5`      $��0��5a      $	��110��5b      $��
812,78,0,0q�5c      $
��Left=�5d      $	��Top=�5e      $��Restablecer��5g      $��16(�5h       J� RenderTransformOrigin$ 0.228,1.827&�5i      �� 5j   
   $��0��5k      $��	25,10,0,0q�5l      $
��Left=�5m      $	��Top=�5n      $O��ISeleccione e ingrese los campos solicitados para la busqueda del contrato��5o      $��16(�5p      �� 5q   
   -   5        $��comBox_TypeSearch��5r      $��0��5s      $	��196��5t      $��
361,76,0,0q�5u      $
��Left=�5v      $	��Top=�5w      $��18(�5x      �� 5y   
   $��Campo de busqueda:��6   $
��Left=�6-   $��
117,48,0,0q�6H   $	��Top=�6\   $��14(�6t   �� 5z   
   $��Filtro de busqueda:��6   $
��Left=�6.   $��
361,46,0,0q�6I   $	��Top=�6]   $��14(�6u   �� 5{   
   -   5        $��Agregar Producto��5{      $
��Left=�6,   $��
1128,0,0,0q�6G   $��2��6[   $��Center=�6h   $��18(�6�   6�   5|      5}      