#include<iostream>
#include<math.h>
int Ss(int n){
    int s = 0;
    for(int i = 0;i<n+1;++i) s+=i;
    return s*s;
    }

int sS(int n){
    int s = 0;
    for(int i = 0;i<n+1;++i) s+= (i*i);   
    return s; 
    }

main(){
       
       printf("%d",Ss(100)-sS(100));
       getchar();

}
