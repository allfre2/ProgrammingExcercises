#!/usr/bin/perl 
use bigint;

my @d;

  for($a = 1,$n = 2, $b = 1,$t=0;;$t=$b,$b+=$a,$a=$t,++$n){
     
    @d = split //,$b;

    if(@d >= 1000){ 
   
     print "\n".$b."\n\n${n}th"; die;

    }

   }
