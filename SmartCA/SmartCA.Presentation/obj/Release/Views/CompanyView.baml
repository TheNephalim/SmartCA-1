   M S B A M L   `   `   `  ���� O  KSmartCA.Presentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SmartCA.Presentation.ViewsSmartCA.Presentation.Views  ,    &SmartCA.Presentation.Views.CompanyView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Apresentation(clr-namespace:SmartCA.Presentation.Views     -     �Name$  companiesWindow�� � Title$ 	Companies��$	��600��$	��800��   FormBackgroundBrush#��[  .���  � RowDefinitions �� $
��Auto ��� �� $
��Auto � � ColumnDefinitions �� $��1* ��� $��2* �.+���   headerLabelStyle#��[ $��10q�$��0��$��0��.��	Companies�� #��[ $��
0,10,10,10q�$��0��$��1��.��Selected Company�� $��
10,0,10,10q�$��1��$��0��$ �� IsSynchronizedWithCurrentItem$
 TrueY� �� DisplayMemberPath$
 Name�� �� SelectedItem ��  �� Path$ CurrentCompany����� $ EntitiesView��� 
���   �$��1q�$��	0,0,10,10q�$��1��$��1��._��� .���  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto �.+��� $��Name:��$��0��$��0��  baseLabelStyle#��[ �� $��0��$��1������ $ CurrentEntity.Name��� $��Abbreviation:��$��1��$��0��#��[ �� $��1��$��1������ $  CurrentEntity.Abbreviation��� $��Address Info:��$��2��$��0��#��[ *   $SmartCA.Presentation.Views.Addresses  $��2��$��1�� � DataContext �� $ 	Addresses��� $��Headquarter Address:��$��3��$��0��#��[ �� $��3��$��1�� �� $ HeadquartersAddress����� $ Address��� $��Phone Number:��$��4��$��0��#��[ �� $��4��$��1������ $ CurrentEntity.PhoneNumber��� $��Fax Number:��$��5��$��0��#��[ �� $��5��$��1������ $ CurrentEntity.FaxNumber��� $
��URL:��$��6��$��0��#��[ �� $��6��$��1������ $ CurrentEntity.URL��� $��Remarks:��$��7��$��0��#��[ �� $��7��$��1��	 �� TextWrapping$
	 Wrap=����� $ CurrentEntity.Remarks��� $��Right=�$��
10,0,10,10q�$��2��$��0������ $ 
NewCommand�.��New�� $��Right=�
 �� Orientation$
 
Horizontal=�$��2��$��1��.+��� $��2��$��0��$��10, 0,10,10q����� $ SaveCommand�.��Save�� $��2��$��0��$��	0,0,10,10q����� $ CancelCommand�.��Cancel