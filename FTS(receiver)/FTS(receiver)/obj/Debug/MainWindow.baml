   M S B A M L   `   `   `  ����H  DFTS(receiver), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:FTS_receiver_FTS_receiver_  5   	       FTS_receiver_.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:FTS_receiver_     5   	     � 
ResizeMode$  CanMinimize=�5   	    � Title$ 
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      � -   5         �Name$ Receiver��5
       � ColumnDefinitions 5   
   �� 5      $
��136* �6   �� 5      $	��87* �6   �� 5      $
��177* �6   .+�5   
   �� -   5         ��Name$ emailBox��5      $
��Left=�6$   $��27��6?   $��220,160,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��330��6�   $��16(�6�   $��3��6�   �� 5   
   -   5         ��Name$ label1��5      $��Enter Your Institute ID��6    $
��Left=�6B   $��38��6]   $��	12,91,0,0q�6i   $	��Top=�6|   $	��202��6�   $��Arial)�6�   $��16(�6�   $
��Bold"�6�   $��1��6�   $��2��6�   �� 5   
   -   5         ��Name$ login��5      $��LOGIN��6    $
��Left=�60   $��32��6K   $��
51,238,0,0q�6W   $	��Top=�6k   $	��121��6�   $
��Bold"�6�   $��1��6�   �� 5   
   -   5        $ select_folder��5      $��SELECT FOLDER��6(   $
��Left=�6@   $��38��6[   $��
73,112,0,0q�6g   $	��Top=�6{   $	��194��6�   $��2��6�   � 5   
   -   5         �Name$ ProgressBar��5      $
��Left=�6+   $��17��6F   $��
44,287,0,0q�6R   $	��Top=�6f   $	��669��6~   $��3��6�   �� 5   
   -   5        $
 path��5      $
��Left=�6    $��38��6;   $��
44,112,0,0q�6G   $
 Wrap=�6[   $	��Top=�6o   $	��432��6�   $��3��6�   �� 5   
   -   5        $ ip��5      $
��Left=�6   $��26��69   $��	87,36,0,0q�6E   $
 Wrap=�6X   $	��Top=�6l   $	��389��6�   $��16(�6�   $��Arial)�6�   $��
YOUR IP:  ��6�   $��3��6�   �� 5   
   -	   5        	 ��Name$	 ProgressTextBlock��5      $
��Left=�6/   $��26��6J   $��
44,256,0,0q�6V   $
��Wrap=�6j   $	��Top=�6~   $	��238��6�   $��2��6�   5      5      