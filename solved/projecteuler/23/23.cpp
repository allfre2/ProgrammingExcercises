#include<iostream>
#include <stdio.h>
int d(int n){
    int r = 0;
        for(int i = 1;i<n/2;++i) n % i ? : r += i;
    return r;
    }
    
    int len(int *a, int i = 0){
        return a[i]?len(a,i+1):i;
        }
    
int in(int n,int *a){
    int i = 0;
    while(a[i] && a[i]<= n ) 
     if(n == a[i++]) return i; 
    return -1;
    }
    
    int A(int n,int a[]){
        for (int i = 0;a[i]; ++i)
            if(in(n - a[i],a) > -1) return 1;
        return 0;
        }

main(){ 
       int a[28000] = {0};
       int s = 0;
       for(int i = 0,j = 0;i < 28123; ++i) if(d(i) > i) a[j++] = i;
       printf("len(a) = %d\n",len(a));
       for(int i = 1;i < 28123; ++i)
        if(!A(i,a)) s += i;
       printf("%d",s);
       getchar();
}
/* resultado: 4179871 */
