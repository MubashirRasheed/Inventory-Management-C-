   M S B A M L   `   `   `  ????M  IInventoryManagment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:InventoryManagmentInventoryManagment  5   	   %    InventoryManagment.CstmRegister   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:InventoryManagment     5   	     ? Title$  Customer??5   	   $	??700??6   $
??1300??6'   $??14(?64    ? IsSharedSizeScope .  ? 
ResizeMode$ CanResizeWithGrip=?6`    ? WindowStartupLocation$ CenterScreen=?6    ? 	Resources 5	         FocusVisual ?? Property ?? Value J? SnapsToDevicePixels ?? StrokeDashArray  Button.Static.Background	 ?? Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1
 ?? 
TargetType ?? 
TargetType ??Name ?? CornerRadius ??Name ?? Triggers P? Property P? Value ?? 
TargetName??%J  &	        &	 ?     &	 ?     &	 ?     &	     &	 6    &	 Y    &	 |    &	 ?    &		 ?    &	
 ?    7   7  7  7  7  7 	 ?? 5
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
 ??6%   .?5      ??  ?@?FocusVisualStyle8   61   ?? 5       ? ??8  6+   ?? 5       ? ??8  6,   ?? 5        ? ??# ? ??6+   ?? 5!       ? ??$ 1q?60   ?? 5"       ? ??$ Center=?6;   ?? 5#       ? ??$ Center=?69   ?? 5$       ? ??$ 1q?6(   ?? 5%       ? ?? 5&      ?? 5'      " ??6&   .R?5(      ?? $ border??6!   $ 20??61   #??z??6C   #??z??6o   #??z??6?    . ._?5)      ?? $ contentPresenter??6/   |?.  #??z??6[   #??z??6?   ??. # z 6?   #??z??6  5*       5+      P? 5,       ?@??IsDefaulted . . ?5-   "   ?? $ border??6@   # ? ??6T    ? ??5.      P? 5/       ?@J?IsMouseOver . . ?50   "   ?? $ border??6?    ? ?? ?	#0000ffff6S   ?? 51   "   $ border??6@    ? ?? ?#15041B6T   ?? 52   "   $ contentPresenter??6K    ? ?? ?#1212116k   ?? 53   "    ?@?Cursor$
 Hand??6;   54      P? 55       ? ?? . . ?56   "   ?? $ border??6?    ? ?? ?#f5a0176S   ?? 57   "   $ border??6@    ? ?? ?#15041B6T   ?? 58   "   $ contentPresenter??6K    ? ?? ?#1212116k   ?? 59   "    ?@?Cursor$
 Hand??6;   5:      P? 5;       ? {? .  . ?5<   "   ?? $ border??6?   8   ? ??6S   ?? 5=   "   $ border??6@   8   ? ??6T   ?? 5>   "   $ contentPresenter??6K   8   ? ??6i   5?      5A      5C      5D      5E      ??5F      ?? 5G   
    ?? ImageSource$&  abstract-room-sun-card-blank.jpg??6   .??5J      ? $??20q?6   .+?5K   
   ?? $??CUSTOMER REGISTER??6   $
??Left=?6,   $??	376,0,0,0q?6G   $	??Top=?6Z   $??85??6r   $	??525??6~   
???????$??48(?6?   $??Segoe UI Black)?6?   ?? 5M   
   $??Username??6   
???????$??100,112,0,0q?66   $??20(?6K   $??51??6Y   $	??Top=?6e   $
??Left=?6}   $	??187??6?   $??Segoe UI Black)?6?   ?? 5N   
   -   5        $??txtUsername??5N      ???	#FF844300
???????$??18(?6O   $??100,164,679,0q?6]   $??41??6t   $	??Top=?6?   $??Center=?6?   $	??473??6?   ??6?   Z? ?? 5O   
   $??Password??6   
???????$??687,112,0,0q?66   $??20(?6K   $??46??6Y   $	??Top=?6e   $
??Left=?6}   $	??179??6?   $??Segoe UI Black)?6?   G? 5P   
   -   5        $??txtPassword??5P      ???	#FF844300
???????$??18(?6S   $??687,164,92,0q?6a   $??41??6w   $	??Top=?6?   $??Center=?6?   $	??473??6?   ??6?   Z? ?? 5Q   
   $??Email??6   
???????$??100,229,0,0q?63   $??20(?6H   $??45??6V   $	??Top=?6b   $
??Left=?6z   $	??131??6?   $??Segoe UI Black)?6?   ?? 5R   
   -   5         ??Name$ txtUserEmail??5R      ???	#FF844300
???????$??18(?6R   $??104,284,0,0q?6`   $??42??6u   $	??Top=?6?   $
??Left=?6?   $	??473??6?   ??6?   Z? ?? 5S   
   -   5         ??Name$ 	btnSubmit??5S      $??Submit??6$   $??409,415,0,0q?65   
???   ?
???????$??18(?6p    J? RenderTransformOrigin$ 0.481,0.516&?6?   $
??Left=?6?   $	??417??6?   $??40??6?   $	??Top=?6?   $??Segoe UI Black)?6  #??? 
 6!  ?? 5T   
   -   5        $ btnBack??5T      $
??BACK??6"   $??
39,555,0,0q?61   ???	#FF844300
???????$??18(?6o   $??45??6?   $	??Top=?6?   $
??Left=?6?   $	??111??6?   #??? 
 6?   $??Segoe UI Black)?6  ?? 5U   
   -   5        $ Phonetxt??5U      ???	#FF844300
???????$??18(?6N   $??691,284,0,0q?6\   $??41??6q   $	??Top=?6}   $
??Left=?6?   $	??473??6?   ??6?   Z? ?? 5V   
   $??Phone??6   
???????$??695,229,0,0q?63   $??20(?6H   $??45??6V   $	??Top=?6b   $
??Left=?6z   $	??131??6?   $??Segoe UI Black)?6?   5X      5Z      