   M S B A M L   `   `   `  ����G  CMelgoza4Ever, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Melgoza4Ever.VistasMelgoza4Ever.Vistas  5      (    "Melgoza4Ever.Vistas.EditarProducto   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Melgoza4Ever.Vistas     5        � Title$  EditarProducto��5	      
�������.��5      �  � RowDefinitions 5   
   �� 5      $	��28* �6   �� 5      $��3* �6   .+�5   
   �� $=��7Ingresa los datos necesarios para registrar el producto��6   $
��Left=�6R   $��	23,36,0,0q�6m   $	��Top=�6�   $��16(�6�   �� 5   
   $��Nombre del Producto:��6   $
��Left=�6/   $��	23,92,0,0q�6J   $	��Top=�6]   $��16(�6u   �� 5   
   -   5        $��text_Nombre��5      $
��Left=�6%   $��
219,96,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��165��6�   $��16(�6�   �� 5   
   $��
Categoria:��6   $
��Left=�6%   $��
25,139,0,0q�6@   $	��Top=�6T   $��16(�6l   �� 5   
   -   5        $��comBox_Categoria��5      $
��Left=�6+   $��219,144,0,0q�6F   $	��Top=�6[   $	��165��6s   �� 5   
   $��Disponibilidad:��6   $
��Left=�6*   $��
25,186,0,0q�6E   $	��Top=�6Y   $��16(�6q   �� 5   
   -   5        $��text_Disponibilidad��5      $
��Left=�6-   $��219,190,0,0q�6H   $
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��165��6�   $��16(�6�   �� 5   
   $��Precio:��6   $
��Left=�6"   $��
25,240,0,0q�6=   $	��Top=�6Q   $��16(�6i   �� 5   
   -   5        $��text_Precio��5      $
��Left=�6%   $��219,248,0,0q�6@   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��165��6�   $��16(�6�   �� 5   
   $��Descripción:��6   $
��Left=�6'   $��
26,291,0,0q�6B   $	��Top=�6V   $��16(�6n   �� 5   
   -   5        $��text_Descripcion��5      $
��Left=�6*   $��219,295,0,0q�6E   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��165��6�   $��16(�6�   �� 5   
   $��Talla:��6   $
��Left=�6!   $��
26,345,0,0q�6<   $	��Top=�6P   $��16(�6h   �� 5   
   -   5        $��
text_Talla��5      $
��Left=�6$   $��219,349,0,0q�6?   $
 Wrap=�6T   $�� ��6h   $	��Top=�6p   $	��165��6�   $��16(�6�   �� 5   
   -   5        $��imagenProducto��5      $
��Left=�6&   $	��127��6A   $��457,139,0,0q�6N   $	��Top=�6c   $	��155��6{   $��/Vistas/photo.png��6�   �� 5   
   -   5        $��btn_AddImage1��5      
������$��+��6?   $��650,175,0,0q�6K   $
��Left=�6`   $��0��6{   $	��Top=�6�   $��20(�6�   $��50��6�   $��50��6�   6�   �� 5    
   -	   5        $��	btn_Salir��5       $��Salir��6"   $
��Left=�62   $��66,6,0,0q�6M   $��1��6_   $	��Top=�6l    J� RenderTransformOrigin$ -5.805,0.752&�6�   $��14(�6�   $��64��6�   �� 5!   
   -
   5        $��
btn_Editar��5!      $��Editar��6$   $
��Left=�65   $��	685,6,0,0q�6P   $��1��6c   $	��Top=�6p   $��14(�6�   5"      5#      