   M S B A M L   `   `   `  ����O  KSmartCA.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SmartCA.Presentation.ViewsSmartCA.Presentation.Views  5   	   3    -SmartCA.Presentation.Views.ProjectContactView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Apresentation(clr-namespace:SmartCA.Presentation.Views     5   	   -   5          �Name$  projectContactWindow��5   	    � Title$ Project Contacts��5   	   $	��600��6"   $	��800��6/      FormBackgroundBrush#��[  5   	   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��2* �6   .+�5   
   ��   headerLabelStyle#��[ 6   $��10q�6:   $��0��6F   $��0��6S   .��6c   Project Contacts6u   �� 5   
   #��[ 6   $��
0,10,10,10q�6:   $��0��6N   $��1��6[   .��6k   Selected Contact6}   �� 5   
   $��
10,0,10,10q�6   $��1��6&   $��0��63   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5       �� DisplayMemberPath$
 Name��5       �� SelectedItem 5      ��  �� Path$ CurrentContact���5      �� $ Contacts�5      �� 5   
   
���   �$��1q�6%   $��	0,0,10,10q�69   $��1��6L   $��1��6Y   ._�5      �� .��5      �  5!      �� 5"      $
��Auto �6(   �� 5#      $
��Auto �6(   �� 5$      $
��Auto �6(   �� 5%      $
��Auto �6(   �� 5&      $
��Auto �6(   �� 5'      $
��Auto �6(   �� 5(      $
��Auto �6(   �� 5)      $
��Auto �6(   �� 5*      $
��Auto �6(   �� 5+      $
��Auto �6(    5.      �� 5/      $
��Auto �6+   �� 50      $
��Auto �6+   .+�53      �� $��First Name:��6   $��0��62   $��0��6?     baseLabelStyle#��[ 6O   �� 54      $��0��6   $��1��6+   ��6;   �� $ CurrentContact.FirstName��� 56      $��
Last Name:��6   $��1��61   $��0��6>   #��[ 6N   �� 57      $��1��6   $��1��6+   ��6;   �� $ CurrentContact.LastName��� 59      $��	Initials:��6   $��2��60   $��0��6=   #��[ 6M   �� 5:      $��2��6   $��1��6+   ��6;   �� $ CurrentContact.Initials��� 5<      $��
Job Title:��6   $��3��61   $��0��6>   #��[ 6N   �� 5=      $��3��6   $��1��6+   ��6;   �� $ CurrentContact.JobTitle��� 5?      $��Address Info:��6   $��4��64   $��0��6A   #��[ 6Q   *   $SmartCA.Presentation.Views.Addresses  5@      $��4��6-   $��1��6:    � DataContext 6J   �� $ 	Addresses��� 5B      $��Company:��6   $��5��6/   $��0��6<   #��[ 6L   �� 5C      $��5��6   $��1��6,   $
 Name��5E       5D      �� $+ %CurrentContact.Contact.CurrentCompany���5F      �� $ 	Companies�5G      �� 5I      $��Email:��6   $��6��6-   $��0��6:   #��[ 6J   �� 5J      $��6��6   $��1��6+   ��6;   �� $ CurrentEntity.PhoneNumber��� 5K      $��Phone Number:��6   $��6��64   $��0��6A   #��[ 6Q   �� 5L      $��6��6   $��1��6+   ��6;   �� $ CurrentEntity.PhoneNumber��� 5M      $��Fax Number:��6   $��7��62   $��0��6?   #��[ 6O   �� 5N      $��7��6   $��1��6+   ��6;   �� $ CurrentEntity.FaxNumber��� 5O      $
��URL:��6   $��8��6+   $��0��68   #��[ 6H   �� 5P      $��8��6   $��1��6+   ��6;   �� $ CurrentEntity.URL��� 5Q      $��Remarks:��6   $��9��6/   $��0��6<   #��[ 6L   �� 5R      $��9��6   $��1��6+   	 �� TextWrapping$
	 Wrap=�6g   ��6;   �� $ CurrentEntity.Remarks�6g   5U      5V      5W      �� 5Y   
   $��Right=�6   $��
10,0,10,10q�6-   $��2��6A   $��0��6N   ��6^   �� $ 
NewCommand�.��6�   New6�   �� 5Z   
   $��Right=�6   
 �� Orientation$
 
Horizontal=�61   $��2��6J   $��1��6W   .+�5[      �� $��2��6   $��0��6"   $��10, 0,10,10q�62   ��6G   �� $ SaveCommand�.��6l   Save6r   �� 5\      $��2��6   $��0��6"   $��	0,0,10,10q�62   ��6E   �� $ CancelCommand�.��6l   Cancel6t   5]      5^      5_      