   M S B A M L   `   `   `  ����G  CmultiTexLabs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:multiTexLabsmultiTexLabs  5   	       multiTexLabs.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:multiTexLabs     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3b+http://schemas.microsoft.com/xaml/behaviors  5   	     � Title$  
MainWindow��5	   	   $	��500��6   $	��920��6)    � 	Resources 5
         
TitleStyle �� 
TargetType  StoryboardChaneImages g� RepeatBehavior �� 
TargetName �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value   EasingFunction0  *System.Windows.Media.Animation.QuinticEase7  1System.Windows.Media.Animation.EasingFunctionBase	   
EasingMode  StoryboardChangetext 	 Zone1
 �� Rect  StoryboardTextSwipe ! StoryboardTextAnimationFinish��%�  &	        &	      &	 �    &	 �    &	 �    &	 �    �� 5   
   " ��6#   �� 5   
   $ Forever��63   .��5      U� $ image��6,   $ (UIElement.Opacity)�6J   .\�5        $ 00:00:00��6'   $ 1Q�6:    5        5      $	 EaseIn=�6&   5        5      $ 00:00:03��6'   $ 0Q�6:    5        5      $	 EaseIn=�6&   5        5      $ 00:00:06��6'   $ 1Q�6:    5        5      $	 EaseIn=�6&   5      5      U� 5      $ image1��6,   $ (UIElement.Opacity)�6K   .\�5        $ 00:00:00��6'   $ 0Q�6:    5         5!      $	 EaseIn=�6&   5#        5$      $ 00:00:03��6'   $ 1Q�6:    5%        5&      $	 EaseIn=�6&   5(        5)      $ 00:00:06��6'   $ 0Q�6:    5*        5+      $	 EaseIn=�6&   5-      5.      U� 5/      $ image2��6,   $ (UIElement.Opacity)�6K   .\�50        $ 00:00:00��6'   $ 0Q�6:    51        52      $	 EaseIn=�6&   54        55      $ 00:00:06��6'   $ 1Q�6:    56        57      $	 EaseIn=�6&   59        5:      $ 00:00:09��6'   $ 0Q�6:    5;        5<      $	 EaseIn=�6&   5>      5?      5@      �� 5A   
   -   5        .��5B      U� $
 grid��6,   $ (UIElement.Opacity)�6I   .\�5C        $ 00:00:00��6'   $ 0Q�6:     5D      $ 00:00:02��6'   $ 1Q�6:   5E      5F      �� 5G   
   $
 0,0,335,288�6+   �� 5H   
   -   5        .��5I      U� $
 Text��6,   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6I   .\�5J        $ 00:00:00��6'   $ 0Q�6:     5K      $ 00:00:04��6'   $	 1.5Q�6:   5L      U� 5M      $
 Text��6,   $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6I   .\�5N        $ 00:00:00��6'   $ 0Q�6:     5O      $ 00:00:04��6'   $
 -280Q�6:   5P      5Q      �� 5R   
   -   5        .��5S      U� $
 grid��6,   $ (UIElement.Opacity)�6I   .\�5T        $ 00:00:00��6'   $ 1Q�6:     5U      $ 00:00:02��6'   $ 0Q�6:   5V      5W      5X      *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5Y      +  %Microsoft.Xaml.Behaviors.EventTrigger  5Z   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5[      <  6Microsoft.Xaml.Behaviors.Media.ControlStoryboardAction     ControlStoryboardOption$
 Play=�6(   5  /Microsoft.Xaml.Behaviors.Media.StoryboardAction   
Storyboard# [ 6G   5\      .��5^      � 
�������$��	0,0,0,-16q�6   $	��900��61   $	��470��6=    � ColumnDefinitions 5_   
   �� 5`      $��0* �6   �� 5a      .+�5c   
   �� -   5         ��Name$ Title��5c   7     Maintext#���  6   $
��Wrap=�6F   $��Буквоед��6Z   $��	0,0,0,331q�6i   $��Center=�6|   $��1��6�   $��50(�6�   $	��800��6�    �� TextAlignment$ Center=�6�   �� 5d   
   -   5        $��607,378,20,24q�5d      $��1��6(   ��5e      �� 5f      .R�5g      � .+�5h      ��  ��Name$
 btn1��6$   
���  ��$��2��6?    �� RadiusX$ 8��6S    �� RadiusY$ 10��6_   �� 5i       ��Name$ buttonCaption��6    $��Center=�67   $��Center=�5j       $(��"Открыть в браузере��6=   $��20(�6Z   
�������
���  ��6�   5k       �� Triggers 5l      P� 5m       P� Property �@J�IsMouseOver P� Value . . �5n      ��  �� 
TargetName$
 btn1��6%    �� Property � �� �� Value
 �  ��6G   �� 5o      $ buttonCaption��6%    � ��
 �  ��6V   �� 5p      $ buttonCaption��6%    � ��
 �����6V   5q      5s      5u      �� 5v   
   -   5         ��Name$ image��5v      $��361,108,19,108q�6   $��/Image1.png��67   $
��Fill=�6L   $��1��6[   �� 5w   
   -   5        $ image1��5w      $��2��6    $��361,108,19,108q�64   $��/Image3.png��6L   $
��Fill=�6a    J� Opacity$ 0Q�6p   �� 5x   
   -   5        $ image2��5x      $��2��6    $��361,108,20,108q�64   $��/Image4.png��6L   $
��Fill=�6a   $ 0Q�6p   $	��254��6|   $	��520��6�   � 5y   
   -	   5         �Name$
 grid��5y      $��2��6   $��26,108,539,0q�61   $	��561��6G   $	��Top=�6T     J� Clip#  �  6l    5z        5{      $ Loaded��6!   . 5|        $
 Play=�60   # [ 6O   5}      .+�5      �� -
   5        $
 Text��5   ;   #���  6   $
��Wrap=�6I   $����«Буквоед» – крупнейшая сеть книжных магазинов в Санкт-Петербурге и Северо-Западном регионе России. Магазины сети входят в одно из самых крупных книготорговых объединений нашей страны — розничную сеть «Читай-город — Буквоед».��6]   $��30(�6E  $��Center=�6S  $	��562��6n  ! J� RenderTransformOrigin$! 0.5,0.5&�6{  z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      5�      5�      5�      