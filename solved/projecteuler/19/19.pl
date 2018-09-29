# Soluton to euler problem 19
 $year = 1900;
 $day = 1;
 @m = (31,28,31,30,31,30,31,31,30,31,30,31);
 $undays = 0;

 sub leapyr{ ! (($_[0] % 100 || $_[0] % 400) && $_[0] % 4);}

for(;$year <= 2000;++$year){
  if(leapyr $year){ $m[1] = 29; } else { $m[1] = 28; }
  print $year . "\n";
 for($i = 0;$i <= 11;++$i){
   
     $day = ($day += $m[$i] % 7) % 7;
     ++$undays if $year > 1900  && $day == 0; #####print $day . "\n";
  }
}

 print $undays;

<>;