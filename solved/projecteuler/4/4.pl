my $n = 0, $t = 0, $r = "";

for($i = 1000;$i > 99; --$i){

 for($j = 1000;$j > 99; --$j){
  
    $t = $i*$j;

     
    if($n < $t && $t eq reverse $t ){
               $n = $t; 
               $r = "$i * $j"; 
               print "\n $i*$j = " . $t;
    }

 }
}
      print "\n\n-> $r = " . $n;
