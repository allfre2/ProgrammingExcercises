#include<iostream>

main(){
     int s = 0;
  for(int a = 1, b = 2,t=0;b<4e+6;t=b,b+=a,a=t)
        
        b%2? : s+=b; 
        
        printf("%d",s);
    getchar();

       
}
