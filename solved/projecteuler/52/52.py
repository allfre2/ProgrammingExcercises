#!/usr/bin/python

from time import *

time = clock()

i = 2


while True:
	TMP = [x*i for x in range(1,7)]
	L = [list(str(x)) for x in TMP]
	for j in range(len(L)): L[j].sort()  
	if False not in [L[0] == b for b in L]: 
		print "=> ", TMP, "\n\t", clock()-time
		break
	i = i + 1



