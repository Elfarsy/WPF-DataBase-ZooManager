   M S B A M L   `   `   `  ????J  FWPF ZooManagers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WPF_ZooManagersWPF_ZooManagers  5   	        WPF_ZooManagers.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WPF_ZooManagers     5   	     ? Title$  
MainWindow??5   	   $	??512??6   $
??1000??6)   .??5	      ? $??	0,0,96,10q?6    ? ColumnDefinitions 5
   
   ?? 5      $
??261* ?6   ?? 5      $	??66* ?6   ?? 5      $	??24* ?6   ?? 5      $
??277* ?6   ?? 5      $
??277* ?6   .+?5   
   ?? $??Zoo List??6   $
??Left=?6#   $??	28,17,0,0q?6>   $	??Top=?6Q   ?? 5   
   -   5        $??ListZoos??5      $??28,38,100,212q?6M   6d   ?? 5   
   $??Associated Animals List??6   $
??Left=?62   $??	43,10,0,0q?6M   $	??Top=?6`   $	??167??6x   $??3??6?   ?? 5   
   -   5         ??Name$ ListZAssociatedAnimals??5      $??23,35,66,212q?6]   $??2??6?   $??2??6?   ?? 5   
   -   5        $ listAllAnimals??5      $??39,57,33,212q?6U   $??4??6?   ?? 5   
   -   5        $??Delete Animal??5      $??2??6)   $??14,272,57,166q?69   $??2??6P   6d   ?? 5   
   -   5        $??Remove animal??5      $??43,279,0,166q?6)   $??4??6?   6O   ?? 5   
   -   5        $??
Delete Zoo??5      $??28,277,63,174q?6&   6=   ?? 5   
   -   5        $??Add Zoo??5      $??21,375,47,59q?6#   69   ?? 5   
   -   5        $??
Update Zoo??5      $??21,432,47,10q?6&   6<   ?? 5   
   -	   5        $??Update Animal??5      $??10,427,31,10q?6)   $??3??6?   6O   ?? 5   
   -
   5        $??	MyTextBox??5       ?? TextWrapping$
 Wrap=?6$   $??TextBox??68   $??21,325,44,121q?6G   $??4??6^   ?? 5   
   -   5        $??Add Animals to zoo??5      $??4??6.   $??23,10,-6,434q?6>   6T   ?? 5   
   -   5        $??
Add Animal??5      $??2??6&   $??2??66   $??14,364,23,69q?6J    J? RenderTransformOrigin$ 0.5,0.5&?6`   z?5      V? 5       .~?5!      ?? ?? 5"       ?? AngleX$ -2.493Q?6$   ?? 5#      T? 5$       T? X$ 4.063Q?6)   5%      5'      5)      5*      