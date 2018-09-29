#include<stdio.h>
#define l 1000000
int o[] = {2,3,5,7,11,13,17};
int p(double n){ for(int i = 0;i<7;++i){if(!((int)n)%o[i]) return 0; }  return 1;}
int main(){
    
   double sum = 2+3+5+7+11+13+17;
   double n=17;    
while(n+=2<l)if( p(n)) sum += n;
       
       
       printf("suma de los primos hasta %g es %g", l, sum);
}
