   M S B A M L   `   `   `  ����O  KSmartCA.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SmartCA.Presentation.ViewsSmartCA.Presentation.Views  5   	   ,    &SmartCA.Presentation.Views.CompanyView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Apresentation(clr-namespace:SmartCA.Presentation.Views     5   	   -   5          �Name$  companiesWindow��5   	    � Title$ 	Companies��5   	   $	��600��6   $	��800��6(      FormBackgroundBrush#��[  5   	   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   .+�5   
   ��   headerLabelStyle#��[ 6   $��10q�6:   $��0��6F   $��0��6S   .��6c   	Companies6n   �� 5   
   #��[ 6   $��
0,10,10,10q�6:   $��0��6N   $��1��6[   .��6k   Selected Company6}   �� 5   
   $��
10,0,10,10q�6   $��1��6&   $��0��63   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5       �� DisplayMemberPath$
 Name��5       �� SelectedItem 5      ��  �� Path$ CurrentCompany���5      �� $ 	Companies�5      �� 5   
   
���   �$��1q�6%   $��	0,0,10,10q�69   $��1��6L   $��1��6Y   ._�5      �� .��5      �  5!      �� 5"      $
��Auto �6(   �� 5#      $
��Auto �6(   �� 5$      $
��Auto �6(   �� 5%      $
��Auto �6(   �� 5&      $
��Auto �6(   �� 5'      $
��Auto �6(   �� 5(      $
��Auto �6(   �� 5)      $
��Auto �6(    5,      �� 5-      $
��Auto �6+   �� 5.      $
��Auto �6+   .+�51      �� $��Name:��6   $��0��6,   $��0��69     baseLabelStyle#��[ 6I   �� 52      $��0��6   $��1��6+   ��6;   �� $ CurrentCompany.Name��� 54      $��Abbreviation:��6   $��1��64   $��0��6A   #��[ 6Q   �� 55      $��1��6   $��1��6+   ��6;   �� $! CurrentCompany.Abbreviation��� 57      $��Address Info:��6   $��2��64   $��0��6A   #��[ 6Q   *   $SmartCA.Presentation.Views.Addresses  58      $��2��6-   $��1��6:    � DataContext 6J   �� $ 	Addresses��� 5:      $��Headquarter Address:��6   $��3��6;   $��0��6H   #��[ 6X   �� 5;      $��3��6   $��1��6,    5<   
   �� $ HeadquartersAddress���5=   
   �� $ 	Addresses�5>      �� 5@      $��Phone Number:��6   $��4��64   $��0��6A   #��[ 6Q   �� 5A      $��4��6   $��1��6+   ��6;   �� $  CurrentCompany.PhoneNumber��� 5B      $��Fax Number:��6   $��5��62   $��0��6?   #��[ 6O   �� 5C      $��5��6   $��1��6+   ��6;   �� $ CurrentCompany.FaxNumber��� 5D      $
��URL:��6   $��6��6+   $��0��68   #��[ 6H   �� 5E      $��6��6   $��1��6+   ��6;   �� $ CurrentCompany.URL��� 5F      $��Remarks:��6   $��7��6/   $��0��6<   #��[ 6L   �� 5G      $��7��6   $��1��6+   	 �� TextWrapping$
	 Wrap=�6h   ��6;   �� $ CurrentCompany.Remarks�6h   5J      5K      5L      �� 5N   
   $��Right=�6   $��
10,0,10,10q�6-   $��2��6A   $��0��6N   ��6^   �� $ 
NewCommand�.��6�   New6�   �� 5O   
   $��Right=�6   
 �� Orientation$
 
Horizontal=�61   $��2��6J   $��1��6W   .+�5P      �� $��2��6   $��0��6"   $��10, 0,10,10q�62   ��6G   �� $ SaveCommand�.��6l   Save6r   �� 5Q      $��2��6   $��0��6"   $��	0,0,10,10q�62   ��6E   �� $ CancelCommand�.��6l   Cancel6t   5R      5S      5T      