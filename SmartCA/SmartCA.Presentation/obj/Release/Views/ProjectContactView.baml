   M S B A M L   `   `   `  ���� O  KSmartCA.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SmartCA.Presentation.ViewsSmartCA.Presentation.Views  3    -SmartCA.Presentation.Views.ProjectContactView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Apresentation(clr-namespace:SmartCA.Presentation.Views     -     �Name$  projectContactWindow�� � Title$ Project Contacts��$	��600��$	��800��   FormBackgroundBrush#��[  .���  � RowDefinitions �� $
��Auto ��� �� $
��Auto � � ColumnDefinitions �� $��1* ��� $��2* �.+���   headerLabelStyle#��[ $��10q�$��0��$��0��.��Project Contacts�� #��[ $��
0,10,10,10q�$��0��$��1��.��Selected Contact�� $��
10,0,10,10q�$��1��$��0��$ �� IsSynchronizedWithCurrentItem$
 TrueY� �� DisplayMemberPath$
 Name�� �� SelectedItem ��  �� Path$ CurrentContact����� $ Contacts��� 
���   �$��1q�$��	0,0,10,10q�$��1��$��1��._��� .���  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto �.+��� $��First Name:��$��0��$��0��  baseLabelStyle#��[ �� $��0��$��1������ $ CurrentContact.FirstName��� $��
Last Name:��$��1��$��0��#��[ �� $��1��$��1������ $ CurrentContact.LastName��� $��	Initials:��$��2��$��0��#��[ �� $��2��$��1������ $ CurrentContact.Initials��� $��
Job Title:��$��3��$��0��#��[ �� $��3��$��1������ $ CurrentContact.JobTitle��� $��Address Info:��$��4��$��0��#��[ *   $SmartCA.Presentation.Views.Addresses  $��4��$��1�� � DataContext �� $ 	Addresses��� $��Company:��$��5��$��0��#��[ �� $��5��$��1��$
 Name�� �� $+ %CurrentContact.Contact.CurrentCompany����� $ 	Companies��� $��Email:��$��6��$��0��#��[ �� $��6��$��1������ $ CurrentEntity.PhoneNumber��� $��Phone Number:��$��6��$��0��#��[ �� $��6��$��1������ $ CurrentEntity.PhoneNumber��� $��Fax Number:��$��7��$��0��#��[ �� $��7��$��1������ $ CurrentEntity.FaxNumber��� $
��URL:��$��8��$��0��#��[ �� $��8��$��1������ $ CurrentEntity.URL��� $��Remarks:��$��9��$��0��#��[ �� $��9��$��1��	 �� TextWrapping$
	 Wrap=����� $ CurrentEntity.Remarks��� $��Right=�$��
10,0,10,10q�$��2��$��0������ $ 
NewCommand�.��New�� $��Right=�
 �� Orientation$
 
Horizontal=�$��2��$��1��.+��� $��2��$��0��$��10, 0,10,10q����� $ SaveCommand�.��Save�� $��2��$��0��$��	0,0,10,10q����� $ CancelCommand�.��Cancel