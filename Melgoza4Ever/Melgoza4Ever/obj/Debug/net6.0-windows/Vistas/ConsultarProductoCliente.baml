   M S B A M L   `   `   `  ����G  CMelgoza4Ever, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Melgoza4Ever.VistasMelgoza4Ever.Vistas  5      2    ,Melgoza4Ever.Vistas.ConsultarProductoCliente   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Melgoza4Ever.Vistas     5        N� Title$  ConsultarProductoCliente��5	       N� 
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
 Bold"�63   �� 5=       � ��$ 40��6/   �� 5>       � ��$ Center=�6C   5?      �� 5@      "  6   .�5A      ��  � �� �#00000063   �� 5B       � ��$ 12(�61   �� 5C       � ��$ 30��6/   �� 5D       � ��$ 10,0,0,0q�60   5E      5F         Columns 5H      0  *System.Windows.Controls.DataGridTextColumn  5I         FontSize$ 15Q�6&   ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��64      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� *name+  5J      $ 15Q�6&   $ 	Categoria��64   $	 200 6G    6S   �� *
category+  5K      $ 15Q�6&   $ Descripción��64   $	 200 6I    6U   �� *description+  5L      $ 15Q�6&   $ Precio��64   $	 200 6D    6P   �� *price+  5M      $ 15Q�6&   $ Disponibilidad��64   $	 100 6L    6X   �� *	available+4  .System.Windows.Controls.DataGridTemplateColumn  5N      $ Consultar Producto��6)      MinWidth$	 200Q�6E      CellTemplate 5O      �� 5P      .R�5Q      �� -   5        $��	Consultar��5Q   L   5R      5U        5V      $ Agregar al carrito��6)   $	 200Q�6E    5W      �� 5X      .R�5Y      �� -   5        $��Agregar��5Y   I   5Z      5]      5_      �� 5`   
   -   5        $��btn_Restore��5a      $��0��5b      $	��110��5c      $��
812,78,0,0q�5d      $
��Left=�5e      $	��Top=�5f      $��Restablecer��5h      $��16(�5i       J� RenderTransformOrigin$ 0.228,1.827&�5j      �� 5k   
   $��0��5l      $��	25,10,0,0q�5m      $
��Left=�5n      $	��Top=�5o      $O��ISeleccione e ingrese los campos solicitados para la busqueda del contrato��5p      $��16(�5q      �� 5r   
   -   5        $��comBox_TypeSearch��5s      $��0��5t      $	��196��5u      $��
361,76,0,0q�5v      $
��Left=�5w      $	��Top=�5x      $��18(�5y      �� 5z   
   $��Campo de busqueda:��6   $
��Left=�6-   $��
117,48,0,0q�6H   $	��Top=�6\   $��14(�6t   �� 5{   
   $��Filtro de busqueda:��6   $
��Left=�6.   $��
361,46,0,0q�6I   $	��Top=�6]   $��14(�6u   5|      5}      