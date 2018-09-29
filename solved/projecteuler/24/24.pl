#!/usr/bin/perl

use bigint;


sub d{
	my($n,$exp) = @_;
	my($sum) = 0;
	foreach(split //,$n) { $sum += $_ ** $exp; }
	return $sum;
}
for ($i = 2; $i < 500000; ++$i){
	$t = d($i,$ARGV[0]);
	if($t == $i) { $sum += $i; print $i . "\n"; }
}

 print "sum =>\t $sum \n";


