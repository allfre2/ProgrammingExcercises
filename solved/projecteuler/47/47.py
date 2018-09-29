#!/usr/bin/python
from time import *
primes = [2] 

time = clock()

def p(x):
	for i in range(3,x,2):
		if x % i == 0: return 0
	return 1  
	

for i in range(3,777,2):
	if(p(i)): primes.append(i)

def primefactors(x):
	return [i for i in primes  if x % i == 0]

n = 647
f = 0
a = primefactors(647)
b = []
i = 648
while 1 :
	b = primefactors(i)
	if len(b) >= 4 and not set(a) & set(b):
		f = f + 1
	else: 
		f = 0	
	if f >= 4: 
		print i," => ",b, "\n", i - 1," => ",a, "\n", i - 2," => ",primefactors(i - 2), "\n",i - 3," => ",primefactors(i-3), "\n","\n\ttime:",clock() - time
		break
		
	i = i + 1 
	a = b
	

