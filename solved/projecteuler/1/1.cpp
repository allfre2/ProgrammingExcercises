#include<iostream>


main(){
       int s = 0;
    for(int i = 1;i <1000;++i)   
    {
      (i%3 && i % 5) ? : s+= i;
    }
    printf("%d",s);
    getchar();       
}
