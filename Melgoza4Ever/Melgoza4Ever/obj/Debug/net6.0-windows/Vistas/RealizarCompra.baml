   M S B A M L   `   `   `  ����G  CMelgoza4Ever, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Melgoza4Ever.VistasMelgoza4Ever.Vistas  5      (    "Melgoza4Ever.Vistas.RealizarCompra   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Melgoza4Ever.Vistas     5        � Title$  RealizarCompra��5	      
�������.��5      � .+�5   
   �� $��Información de compra��6   $
��Left=�60   $��	48,46,0,0q�6K   $	��Top=�6^   $��36(�6v   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ tableProductos��5      $	��846��5      $	��149��5      $
��Left=�5      $	��Top=�5         AlternatingRowBackground �#E0E0E0   AutoGenerateColumns$ False��5      ���#F5F5F5���#2E2E2E$��2,2,2,2q�5         CanUserAddRows$ False��5         CanUserDeleteRows$ False��5         CanUserResizeRows$ False��5         HeadersVisibility$ Column=�5         RowHeaderWidth$ 0Q�5      $��
48,210,0,0q�6    ��5      �� *Items+	 � 	Resources	 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader
 �� 
TargetType �� Property �� Value*  $System.Windows.Controls.DataGridCell��%�  '        '      �� 5       "
  6   .�5!      ��  � �� �#FFFFFF63   �� 5"       � �� �#2E2E2E63   �� 5#       � ��$ 14(�61   �� 5$       � ��$
 Bold"�63   �� 5%       � ��$ 40��6/   �� 5&       � ��$ Center=�6C   5'      �� 5(      "
  6   .�5)      ��  � �� �#00000063   �� 5*       � ��$ 12(�61   �� 5+       � ��$ 30��6/   �� 5,       � ��$ 10,0,0,0q�60   5-      5.         Columns 50      0  *System.Windows.Controls.DataGridTextColumn  52         FontSize$ 15Q�6&   ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��64      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� *name+  53      $ 15Q�6&   $ 	Categoria��64   $	 200 6G    6S   �� *
category+  54      $ 15Q�6&   $ Descripción��64   $	 200 6I    6U   �� *description+  55      $ 15Q�6&   $ Precio��64   $	 200 6D    6P   �� *price+58      �� 59   
   -   5        $��btn_RealizarCompra��59      $��Realizar compra��6+   $
��Left=�6E   $��695,392,0,0q�6`   $	��Top=�6u   $��24(�6�   $	��199��6�   6�   �� 5:   
   -   5        $��label_precioTotal��5:      $��Precio a pagar: $��6)   $
��Left=�6E   $��
48,386,0,0q�6`   $	��Top=�6t   $��24(�6�   �� 5;   
   -   5        $��label_nombreCliente��5;      $��Nombre del comprador:��6+   $
��Left=�6K   $��
48,109,0,0q�6f   $	��Top=�6z   $��22(�6�   �� 5<   
   -   5        $��label_Direccion��5<      $��Dirección:��6'   $
��Left=�6<   $��
48,171,0,0q�6W   $	��Top=�6k   $��22(�6�   5=      5>      