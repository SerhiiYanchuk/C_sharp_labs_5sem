   M S B A M L   `   `   `  ����F  BHotelAppWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:HotelAppWPFHotelAppWPF  5   	       HotelAppWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:HotelAppWPF     5   	     � Title$  HotelService��5   	   $	��450��6   $	��400��6+    � 	Resources 5
         TextFamilyWeight �� Property �� Value  InputDataText �� BasedOn �� Triggers P� Property P� Value �� RelativeSource	 �� Path
 �� 
TargetType  ButtonTemplate ��Name �� CornerRadius �� Triggers �� 
TargetName��%�  &	        &	 v     7   &	 �    �� 5   
   .�5      ��  � ��$ Century Schoolbook)�63   �� 5       � ��$ Medium"�63   5      �� 5   
   8   .�5      ��  � ��$ 15(�61    5      P� 5       �@=�HasError$
 True��69   . �5      ��  �@�ToolTip 5      ��  �� *Self+$)	 #(Validation.Errors)[0].ErrorContent��� 5       � ��
 �  ��6;   5      5      �� 5    
   "
 ��6   .R�5!      �� $ GenerateButtonBorder��6   $	��100��63   $ 3��6?   
���   �$��1q�5"   )   
�������._�5#      �� $��15(�6!   $��Century Schoolbook)�6/   $��Center=�5$   !   $��Center=�6>   $��Magic��6Y   5%       5'      P� 5(       �@J�IsMouseOver$
 true��61   . �5)      �� $ GenerateButtonBorder��6    � ��
 ��  �6V   5*      P� 5+       � ��$
 true��6/   . �5,      �� $ GenerateButtonBorder��6    � ��
 �����6U   5-      5/      53      .��55      � .+�56   
   �� -   5         ��Name$ HotelService��56      .@�58      �� -   5         ��Name$ 	hotelsTab��58      ��59      �� 5:       �� Orientation$ 
Horizontal=�6!   .+�5;      A� $��10��6"   $��10��6.   
���   �69   �� 5<      $��3q�6$   Hotels67   5=      ��5?      �� 5@      $��5,0,0,0q�6!   $
��Left=�63   .+�5A      &   System.Windows.Controls.DataGrid  -   5          Name$ 
hotelsGrid��5A   #      AutoGenerateColumns$ False��67      HorizontalGridLinesBrush
 �����   
IsReadOnly$
 True��6w      RowBackground
 �����   AlternatingRowBackground
 �������5B   Z   �� *Hotels+ �� SelectedItem 6y   �� *SelectedHotel+   Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D   "   ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��65      Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *Name+6\     5E   "   $ Address��65   $ 80 6b    6F   �� *	Address+6b   5G      �� 5I      $ 
Horizontal=�6%   $��20 20q�6>   .+�5J      �� -   5         ��Name$ DeleteHotelButton��5J   %   $��26��5K   o   $��0 0 20 0q�6{   $��Delete��6�   $��53��6�   ��6   �� *SelectedHotel+��6H   �� *DeleteHotelCommand+6�   5N      (  "System.Windows.Controls.DatePicker  5P      $��20 10q�6%      SelectedDate 64   �� *RoomFilter.CheckInDate+  5Q      $��20 10q�6%    64   �� *RoomFilter.CheckOutDate+�� 5R      -   5         ��Name$ sizeBox��5R   #   $	��120��64   $��20 10q�6@   ��6O   ��   �� Source  ,   &HotelAppWPF.EnumBindingSourceExtension  *M� *local:TypeSizeEnumModel++! �� SelectedValue! 6�   �� *RoomFilter.TypeSize+�� 5S      -   5        $ 
comfortBox��5S   #   $	��120��67   $��20 10q�6C   ��6R   ��     *M� *local:TypeComfortEnumModel++! 6�   �� *RoomFilter.TypeComfort+�� 5U      -   5        $ FindRoomsButton��5U   !   $��26��5V   p   $
��Find��6|   $��53��6�   $��20 10q�6�   ��6   �� *
RoomFilter+��6E   �� *SearchFreeRoomsCommand+6�     5X      -   5        $ 	roomsGrid��5X   #   $ False��66   
 �����$
 True��6v   
 �����
 �������5Y   Z   �� *Rooms+ 5Z        5[   "   $ Number��65   $ 90 6`    6E   �� *Number+6`     5\   "   $ Price per day��65   $ 80 6l    6L   �� *PricePerDay+6l     5]   "   $ Type comfort��65   $ 90 6k    6K   �� *TypeComfort+6k     5^   "   $ 	Type size��65   $ 80 6e    6H   �� *
TypeSize+6e     5_   "   $ Check-in date��65   $ 90 6l    6L   �� *CheckInDate+6l     5`   "   $ Check-out date��65   $ 80 6q    6M   �� *MaxCheckOutDate+6q   5b      5c      5e      �� 5g      -	   5        $ 
ClientsTab��5g      ��5h      �� 5i      $ 
Horizontal=�6!   .+�5j      �� $��10��6$   $��10��60   
���   �6;   �� 5k      $��3q�6$   Client base6<   5l      ��5n      �� 5p      .+�5q        -
   5        $ clientsGrid��5q   #   $ False��68   
 �����$
 True��6x   
 �����
 �������5r   Z   �� *	Clients+ 6z   �� *SelectedClient+ 5s        5t   "   $ 
First name��65   $ 90 6g    6I   �� *	FirstName+6g     5u   "   $ 	Last name��65   $ 80 6e    6H   �� *
LastName+6e   5w      �� 5x      -   5        $ OrderButton��5x   !   $
��0 10q�66   $��26��5y   q   $��Show orders��6}   $��88��6�   ��6   �� *SelectedClient+��6I   �� *SearchOrdersCommand+6�     5z      -   5        $ 
ordersGrid��5z   #   $ False��67   
 �����$
 True��6w   
 �����
 �������5{   Z   �� *Orders+ 6y   �� *SelectedOrder+ 5|        5}   "   $ 
Hotel name��65   $ 90 6r    6I   �� *HotelRoom.Hotel.Name+6r     5~   "   $ Number��65   $ 80 6j    6E   �� *HotelRoom.Number+6j     5   "   $ Price per day��65   $ 90 6v    6L   �� *HotelRoom.PricePerDay+6v     5�   "   $ Check-in��65   $ 80 6g    6G   �� *CheckInDate+6g     5�   "   $ 	Check-out��65   $ 90 6i    6H   �� *CheckOutDate+6i     5�   "   $ Payment state��65   $ 90 6m    6L   �� *PaymentState+6m   5�      �� 5�      $ 
Horizontal=�6%   $��20 20q�6>   $��Center=�6M   .+�5�      �� -   5        $ DeleteOrderButton��5�   %   $��26��5�   o   $��0 0 20 0q�6{   $��Delete��6�   $��53��6�   ��6   �� *SelectedOrder+��6H   �� *DeleteOrderCommand+6�   �� 5�      -   5        $ ConfirmPayButton��5�   %   $��26��5�   r   $	��Pay��6~   $��53��6�   ��6   �� *SelectedOrder+��6H   �� *ConfirmPaymentCommand+6�   5�      5�      5�      �� 5�      -   5        $ AddHotelTab��5�      ��5�      �� 5�      $ 
Horizontal=�6!   .+�5�      A� $��10��6"   $��10��6.   
���   �69   �� 5�      $��3q�6$   	Add hotel6:   5�      ��5�      �� 5�      $
��Left=�6"   .+�5�      �� $ 
Horizontal=�6%   $��10 10q�6>   .+�5�      �� $��0 0 5 0q�6(   #��[ 69   Name:6g   �� 5�      $��89��6&   #��[ 61   ��5�   "   �� *NewHotel.Name+" �� Mode$" TwoWay=�# �� UpdateSourceTrigger$# PropertyChanged=�$ �� ValidatesOnDataErrors$
$ True��.��6�   5�      5�      �� 5�      $ 
Horizontal=�6%   $��10 10q�6>   .+�5�      �� $��0 0 5 0q�6(   #��[ 69   
Address:6j   �� 5�      $��80��6'   #��[ 62   ��5�   "   �� *NewHotel.Address+$" TwoWay=�$# PropertyChanged=�$
$ True��5�      �� 5�      -   5        $ AddHotelButton��5�   !   #��[ 69   $��30��5�   g   ��6   �� *
NewHotel+��6C   �� *AddHotelCommand+6g   5�      5�      �� 5�      -   5        $ AddClientTab��5�      ��5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��10��6$   $��10��60   
���   �6;   �� 5�      $��3q�6$   
Add client6;   5�      ��5�      �� 5�      $
��Left=�6!   .+�5�      �� $ 
Horizontal=�6%   $��10 10q�6>   .+�5�      �� $��0 0 5 0q�6(   #��[ 69   $��78��6`   First name:6x   �� 5�      $��89��6&   #��[ 61   ��5�   "   �� *NewClient.FirstName+$" TwoWay=�$# PropertyChanged=�$
$ True��.��6�   5�      5�      �� 5�      $ 
Horizontal=�6%   $��10 10q�6>   .+�5�      �� $��0 0 5 0q�6(   #��[ 69   
Last name:6l   �� 5�      $��80��6'   #��[ 62   ��5�   "   �� *NewClient.LastName+$" TwoWay=�$# PropertyChanged=�$
$ True��5�      �� 5�      $ 
Horizontal=�6%   $��10 10q�6>   .+�5�      �� $��0 0 5 0q�6(   #��[ 69   Phone number:6o   �� 5�      $��80��6'   #��[ 62   ��5�   "   �� *NewClient.PhoneNumber+$" TwoWay=�$# PropertyChanged=�$
$ True��5�      �� 5�      -   5        $ AddClientButton��5�   !   #��[ 6:   $��30��5�   i   $	��150��6u   ��6   �� *	NewClient+��6D   �� *AddClientCommand+6u   5�      5�      5�      5�      5�      