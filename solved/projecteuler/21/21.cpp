#include <iostream>

int d(int n){
    int r = 0;
        for(int i = 1;i<n;++i) n % i ? : r += i;
    return r;
    }

main(){
       int s = 0;
       int t = 0;
      for(int i = 0;i<10000;++i){
              (t = d(i));
          if(i == d(t) && t != i && t < 10000)  s += i/*,printf("\n%d\t%d - %d",i,d(i),d(d(i)))*/;
          }
        std::cout << "\n\n-> " << s;
        std::cin.get();
      
}
