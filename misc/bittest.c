#include<stdio.h>
#include<stdlib.h>

int main(int argc, char ** argv){
 if(argc < 2) exit(1);
 int i = atoi(argv[1]);
 while( i != 0 ){
  printf("\n%.4x & %.4x = %.4x\n",i,i-1,i & i-1);
  i &= i-1;
  getchar();
 }
}
