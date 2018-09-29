use bigint;

my $r = 2;

for( $i = 1;$i< 1000;++$i){
  
     $r *= 2;
}

  @r = split //,$r;

     $r = 0;
   foreach $x (@r){

	$r += $x;

   }

     print $r;