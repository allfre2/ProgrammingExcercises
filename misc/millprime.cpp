#include <iostream>
#include "tools/primes.h"

using namespace std;
int main(){
 Sieve primes;
 primes.allowGrowth();
 int test[] = {0, 1e6, 3e6, 5e6, 6e6, 15e6, 20e6, 0};
  for( int i = 0; test[i]; ++i){
   cout << endl <<"#"<< test[i] << ": " << primes[test[i]] << " memory: ";
   cout <<  primes.memoryUsed()  << endl;
   if( cin.get() == 'q' ) break;
 }
 cout << primes[10e6];
 cout << primes;
}
