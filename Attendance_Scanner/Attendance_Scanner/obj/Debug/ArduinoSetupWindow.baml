   M S B A M L   `   `   `  ����M  IAttendance_Scanner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Attendance_ScannerAttendance_Scanner  5   	   +    %Attendance_Scanner.ArduinoSetupWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Attendance_Scanner     5   	     � Title$  ArduinoSetupWindow��5   	   $	��167��6$   $	��224��61   .��5	      � .+�5
   
   �� $��Arduino Setup��6   $
��Left=�6(   $��	10,10,0,0q�6C   $	��Top=�6V   $��18(�6n   $
��Bold"�6|   �� 5   
   -   5         ��Name$ COMBOX_Ports��5      $
��Left=�6)   $��	10,49,0,0q�6D   $	��Top=�6W   $	��120��6o   �� 5   
   -   5         ��Name$ BTN_Refresh��5      $��Refresh��6&   $
��Left=�68   $��
135,49,0,0q�6S   $	��Top=�6g   $��53��6   6�   �� 5   
   -   5        $ BTN_Connect��5      $��Connect��6&   $
��Left=�68   $��	10,77,0,0q�6S   $	��Top=�6f   $��75��6~   6�   �� 5   
   $��Last UID read:��6   $
��Left=�6)   $��10,102,0,-5.333q�6D   $	��Top=�6]    J� RenderTransformOrigin$ 0.5,0.5&�6u   �� 5   
   -   5         ��Name$ LBL_LastRead��5      $�� ��6&   $
��Left=�61   $��98,102,0,-5.333q�6L   $	��Top=�6e   5      5      