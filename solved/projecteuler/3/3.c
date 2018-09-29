#include <stdio.h>
#include <string.h>
#include <stdlib.h>

long long int N = 600851475143;
int GenPrimes(int n, char * buffer){
 printf("\n\n");
 long long int i = 2,j;
 while(i < n && N){
  if(N % i == 0) printf("\nfactor: %lld",i),N /= i,i=2;
  for(j = i*2; j < n; j += i){
   buffer[j] = 0;
  }
  while(buffer[++i] == 0 && i < n);
 }
 printf("\n\n");
}

int main(int argc, char **argv){
 
 char * numbers;
 int n,i;
 n = 10000;
 if(argc > 1){
  n = atoi(argv[1]);
 }
 numbers = (char *) malloc(n*sizeof(char));
 if(numbers == (void *)0) 
  printf("\nCouldn't allocate %lld\n",(long long int)n*sizeof(long long int)),exit(1);
 memset(numbers,1,sizeof(char)*n);
 GenPrimes(n,numbers);
 free(numbers);
 return 0;
}
