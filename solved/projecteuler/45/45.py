#!/usr/bin/python

from time import *

T = lambda n: (n * (n + 1)) / 2
P = lambda n: (n * ((3 * n) - 1)) / 2 
H = lambda n: (n * ((2 * n) - 1))

t = 285
p = 165
h = 143

print T(t) == P(p) == H(h)


def nextTPH(t,p,h):
	t = t+1
	while 1:
		if T(t) == P(p):
			if P(p) == H(h):
				return [t,p,h,T(t)]
			if P(p) < H(h):
				p = p+1
			else: h = h+1
		elif T(t) < P(p):
			t =  t+1
		else: p = p+1
tmp = [1,1,1,1]
while 1:
	time = clock()
	tmp = nextTPH(*tmp[:-1])
	print "\n" , tmp, 
	print " => time: ", time - clock()


