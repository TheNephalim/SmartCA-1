   M S B A M L   `   `   `  ����   SmartCA.Presentation7    1SmartCA.Presentation.Views.ProjectInformationView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Project Information��$	��700��$	��700�� � 	Resources    ProjectNameAndNumber � ColumnDefinitions � RowDefinitions  boldLabelStyle ��Name  baseLabelStyle �� Path ��Name  baseTextBoxStyle �� Triggers �� Value	 �� Binding
 �� 
TargetName �� Property �� Value  OwnerInformation  baseTextBoxStype$ �� IsSynchronizedWithCurrentItem �� 
IsEditable w� TextPath �� DisplayMemberPath  baseComboBoxStyle �� SelectedItem��%5  &	        7  7  7  7  7  &	 �    7  7  7  7  7  7  7  7  7  7  7  7  7  �� .R��  �� ��  �� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Project Number:��8��  �� $ ProjectNumber��$��1��$��0��8�� ���� $ CurrentEntity.Number��� $ NewProjectNumber��$��1��$��0��$y�Hidden=����� $ NewProjectNumber��� $��0��$��1��$��Project Name:��8�� �� $ ProjectName��$��1��$��1��8�� ���� $ CurrentEntity.Name��� $ NewProjectName��$��1��$��1��$y�Hidden=�8�� ���� $ NewProjectName� �� $	 New��	 �� $ CurrentObjectState�.a��� $
 NewProjectNumber�� � y�$ Visible=��� $
 NewProjectName�� � y�$ Visible=��� $
 ProjectNumber�� � y�$ Hidden=��� $
 ProjectName�� � y�$ Hidden=��� .R��  �� ��  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Owner Name:��8��  �� $��1��$��0��8�� ���� $ CurrentEntity.Owner.Name��� $��1��$��1��$
 TrueY�$	��200�� . $
 Name��$
 Name��8��  �� $ CurrentEntity.Owner����� $ Owners��� $��0��$��2��$��Owner Abbrev.:��8�� �� $��1��$��2��8�� ���� $&  CurrentEntity.Owner.Abbreviation��� $��0��$��3��$��Owner Address:��8�� �� $��1��$��3��8�� ���� $, &ProjectOwnerHeadquartersAddress.Street��� $��0��$��4��$��Owner City:��8�� �� $��1��$��4��8�� ���� $* $ProjectOwnerHeadquartersAddress.City��� $��0��$��5��$��Owner State:��8��	 �� $��1��$��5��8��
 ���� $+ %ProjectOwnerHeadquartersAddress.State��� $��0��$��6��$��
Owner Zip:��8�� �� $��1��$��6��8�� ���� $0 *ProjectOwnerHeadquartersAddress.PostalCode�.��� -    �Name$ 
LayoutRoot��.+��� $��80, 40, 64, 80q�$
 TrueY�.@��� $��Contact Info��.��� $��35, 12, 5, 5q� �� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��2��$��0��#��[  ���� �� $��0��$��1��$��Project Address:��#��[ �� $��1��$��1��#��[ ���� $ ProjectAddress.Street��� $��0��$��2��$��Project City:��#��[ �� $��1��$��2��#��[ ���� $ ProjectAddress.City��� $��0��$��3��$��Project State:��#��[ �� $��1��$��3��#��[ ���� $ ProjectAddress.State��� $��0��$��4��$��Project Zip:��#��[ �� $��1��$��4��#��[ ���� $ ProjectAddress.PostalCode��� $��2��$��5��#��[ ���� �� $��0��$��6��$��CA Name/Title:��#��[ �� $��1��$��6��$
 TrueY�$	��200�� . $ 	FirstName��#��[  �� $- 'CurrentEntity.ConstructionAdministrator����� $  ConstructionAdministrators����� .R��  �� �� �� �� �� .+��� $��0������ $ 	FirstName��� $��1��$�� ���� $��2������ $ LastName��� $��3��$��, ���� $��4������ $ JobTitle��� $��0��$��7��$��Principal-In-Charge:��#��[ �� $��1��$��7��$
 TrueY�$	��200��$
��Auto�� . $ 	FirstName��#��[  �� $% CurrentEntity.PrincipalInCharge����� $ 
Principals����� .R��  �� �� �� .+��� $��0������ $ 	FirstName��� $��1��$�� ���� $��2������ $ LastName��� $��Details��.��� $��35, 12, 5, 5q��� $��Marketing Info��.��� $��35, 12, 5, 5q��� $��
Allowances��.��� $��35, 12, 5, 5q�