#include<iostream>

int d(int n,int l=21){
    while(--l) if(n % l) return 0;  
    return 1;
    }

main(){
int i=2520;

while(!d(++i));
       printf("%d",i);
       getchar();
}
