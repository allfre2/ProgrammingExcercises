#include<iostream>
#include<stdio.h>
/* 10001st prime*/

inline int p(register int n){
   register int t = n;
    n /= 2;
    while(--n > 1 && t > 2) if( t%n == 0 ) return 0; 
    
    return 1;
}


main(){
       register int c = 1,s = 2;
       for(register int i = 3;i < 2e6;i += 2)
           if(p(i)){ s += i; if( ++c == 10001) printf("10001st prime %d",i);}
printf("\n\n sum below 2E6 -> %d",s);

getchar();
}
