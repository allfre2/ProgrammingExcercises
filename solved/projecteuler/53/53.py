#!/usr/bin/python


from time import *

time = clock()

def f(n):
	if n > 1:
		return n * f(n-1)
	else: return 1 

def C(n,r):
	return f(n)/(f(r)*(f(n-r)))

print C(23,10)

R = []

for n in range(23,101):
	for r in range(1,n):
		if C(n,r) > 1000000: R.append([n,r])

print "=> ", R , "\n\t", len(R) , " numbers.\n\t time:", clock()-time
