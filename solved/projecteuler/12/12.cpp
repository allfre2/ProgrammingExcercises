#include<iostream>

main(){
       for(int i = 7, t = 0, d=0, tmp = 0;d<500;++i, d = 0, t = 0){
             for(int j = 0; j<i+1;) t += ++j; 
             
             for(int k = 1;k < t;++k) t % k ?  :  ++d;
             printf("\n%d\n",d);
             if(d >= 500) printf("%d",t),getchar(),exit(0);
             }
}
