   M S B A M L   `   `   `  ????M  IInventoryManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:InventoryManagmentInventoryManagment  5   	   $    InventoryManagment.CheckOrders   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:InventoryManagment     5   	     ? Title$
  Cart??5      $	??700??6   $
??1300??6"   $??14(?6/    ? IsSharedSizeScope .  ? 
ResizeMode$ CanResizeWithGrip=?6[    ? WindowStartupLocation$ CenterScreen=?6z    ? 	Resources 5	         FocusVisual ?? Property ?? Value J? SnapsToDevicePixels ?? StrokeDashArray  Button.Static.Background	 ?? Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1
 ?? 
TargetType ?? 
TargetType ??Name ?? CornerRadius ??Name ?? Triggers P? Property P? Value ?? 
TargetName??%J  &	        &	 ?     &	 ?     &	 ?     &	     &	 6    &	 Y    &	 |    &	 ?    &		 ?    &	
 ?    7   7  7  7  7  7  7  7  7  7 	 ?? 5
   
   .?5      ??  ? ?? 5      ?? 5      .R?5      ?? $??2q?6$    . #??? ??6J   $??1??6?   $	 1 2R?6?   5      5      5      ?? 5   
   $	 	#FFDDDDDD??6;   ?? 5   
   $	 	#FF707070??67   ?? 5   
   $	 	#FFBEE6FD??6>   ?? 5   
   $	 	#FF3C7FB1??6:   ?? 5   
   $	 	#FFC4E5F6??6<   ?? 5   
   $	 	#FF2C628B??68   ?? 5   
   $	 	#FFF4F4F4??6=   ?? 5   
   $	 	#FFADB2B5??69   ?? 5   
   $	 	#FF838383??6=   ?? 5   
   "
 ??6%   .?5      ??  ?@?FocusVisualStyle8   61   ?? 5       ? ??8  6+   ?? 5       ? ??8  6,   ?? 5        ? ??# ? ??6+   ?? 5!       ? ??$ 1q?60   ?? 5"       ? ??$ Center=?6;   ?? 5#       ? ??$ Center=?69   ?? 5$       ? ??$ 1q?6(   ?? 5%       ? ?? 5&      ?? 5'      " ??6&   .R?5(      ?? $ border??6!   $ 20??61   #??z??6C   #??z??6o   #??z??6?    . ._?5)      ?? $ contentPresenter??6/   |?.  #??z??6[   #??z??6?   ??. # z 6?   #??z??6  5*       5+      P? 5,       ?@??IsDefaulted . . ?5-   "   ?? $ border??6@   # ? ??6T    ? ??5.      P? 5/       ?@J?IsMouseOver . . ?50   "   ?? $ border??6?   8   ? ??6S   ?? 51   "   $ border??6@   8   ? ??6T   52      P? 53       ? ?? . . ?54   "   ?? $ border??6?   8   ? ??6S   ?? 55   "   $ border??6@   8   ? ??6T   56      P? 57       ? {? .  . ?58   "   ?? $ border??6?   8   ? ??6S   ?? 59   "   $ border??6@   8   ? ??6T   ?? 5:   "   $ contentPresenter??6K   8 	  ? ??6i   5;      5=      5?      5@      5A      ??5B      ?? 5C   
    ?? ImageSource$&  abstract-room-sun-card-blank.jpg??6   .??5E      ? $??20,20,20,10q?6   .+?5F   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ProductsDataGrid??5F   Q   $	??460??6   $??Center=?6    $??
10,10,10,0q?6=   $	??Top=?6k   $
??1232??6?   
???????
???   ?   
IsReadOnly . ??6?   Z? 6?   ?? 5G   
   -   5         ??Name$
 back??5G      $
??BACK??6   $??
41,568,0,0q?6.   ???	#FF844300
???????$??18(?6l   $
??Left=?6?   $	??124??6?   $??39??6?   $	??Top=?6?   #??? 
 6?   $??Segoe UI Black)?6?   5I      5J      