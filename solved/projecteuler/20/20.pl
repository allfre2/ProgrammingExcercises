
my $n = 1;
use bigint;

my $s = 0;

for($i=1;$i<101;++$i){

   $n *= $i;


}

@a = split //,"$n";

foreach $x (@a){

$s += $x;

}

print $n ."\n >" . $s;

#$r = <STDIN>;
