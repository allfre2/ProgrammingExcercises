


sub p{
       
     
 for(my $i = 11;$i<$_[0];++$i){ 
   if(!($_[0]%$i)){ return 0; }  }
 return 1;   
}
sub circularp{
    my($n) = @_;
                # "$n" !~ /[^9713]/ || return 0;
     @t = split // ,"$n"; 
     for(my $i = 0; $i < @t; ++$i){
        if(not p $n){         return 0;
        }# print $n."\n"; 
     @t = ($t[$#t],@t[0..$#t-1]);
     $n = int join '', @t;
     }
 return 1;
}
  $ count = 4; # numbers 2, 3, 5, 7
  $i = 11;
while($i < 1e6){
 if (circularp $i){

  $ count++;
  print $i . "\n";  
 }
   $i += 2;
  while("$i" =~ /[^9371]/){ $i += 2;}      
}
print "\n\n\n -> $count";