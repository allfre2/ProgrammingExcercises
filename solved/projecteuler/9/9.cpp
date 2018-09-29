#include<stdio.h>
#include <stdlib.h>

main(){

    for(int i = 1;;++i)
     for(int j = 1;j < i;++j)
      for(int k = 1;k < j;++k)
        if((k*k) + (j*j) == i*i && k+j+i==1000)  printf("%d",k*j*i), getchar(),exit(0);

}
