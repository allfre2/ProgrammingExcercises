/*
The length of the side of the square follows this sequence:

1, 3, 5, 7, 9, ...

a[n] = a[0] + 2n

n = (a[n] - a[0]) / 2

with a[0] = 1 and a[n] = 1001 => n = 500

The sum of the 4 corner numbers of the square at any given n is:

 ( S + 2n(1) + S + 2n(2) + S + 2n(3) + S + 2n(4) )
 ( 4S + 2n( 1 + 2 + 3 + 4 ) )
 ( 4S + 20n )

where S is a starting number to which we sum a multiple of 2

The first starting number S1 is 1.
The next starting numbers obey this rule:

Sn+1 = Sn + 2(n)4

That is "the next starting number is the previous
starting number + 4 times the `step` needed to be taken
to get the corner numbers.
With this we can get this formula:

Sn+2 = S(n+1) + 2(n+1)4
	   Sn + 2(n)4 + 2(n+1)4

Sn+3 = S(n+2) + 2(n+2)4
       Sn + 2(n)4 + 2(n+1)4 + 2(n+2)4

           k-1
Sn+k = Sn + ∑  2(n+i-1)4
           i=1

Simplyfing this we get:

==================
Sn = 1 + 4(n^2-n)|
==================

for the nth starting number in the square.
And so our formula becomes:

 ( 4(1 + 4(n^2 - n)) + 20n )

for the sum of the four corners of the nth iteration of the square.
If we sum all of this up and add 1 we get the sum of all the numbers
in the diagonals:

     k
1 +  ∑  4 * (1 + 4*(n^2 - n)) + 20n
    n=1

     k
1 +  ∑  4 + 16(n^2 - n) + 20n
    n=1

     k
1 +  ∑  4 + 16n^2 - 16n + 20n
    n=1

     k
1 +  ∑  4 + 16n^2 + 4n
    n=1

if we evaluate this at k = 500 ( where the square
has side of length 1001 ) we get the solution to the problem.

*/

#include <iostream>
#include <cmath>
class NspiralDiagonal{
 public:
 NspiralDiagonal(){}
 // TODO: Esto no funciona!. Encontrar formula 
 // para no tener que hacerlo de manera iterativa
 double NthSum(int n = 500){
  double Sum = 1;
  Sum += 4*n;
  Sum += 2 * ((n*(n-1)));
  Sum += /*8/3 */ n*(n+1)*(2*n+1);
  Sum = (Sum*16) / 6;
  return Sum;
 }

 int RecursiveNthSum(int n = 500){
  if(n == 0)
   return 1;
  else return OuterRingSum(n) + RecursiveNthSum(n-1);
 }

 int OuterRingSum(int n = 1){
  int Sum;
  Sum = (4 + 16*(n*n) + 4*n);
 }
};

int main()
{
 NspiralDiagonal n;
 std::cout << std::endl << n.NthSum()
           << std::endl << n.RecursiveNthSum()
		   << std::endl;
}
