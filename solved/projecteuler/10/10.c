int main(){
 int i = 2,n = 2000000,j;
long long unsigned int sum = 0;
 char buffer[2000000] = {1};
  memset(buffer,1,n*sizeof(char));
  while(i < n){
   sum += i;
   for(j = i*2; j < n; j += i){
    buffer[j] = 0;
   }
   while(++i < n && buffer[i] == 0);
  }
  printf("\n%llu\n",sum);
}
