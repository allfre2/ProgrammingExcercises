#include<stdio.h>
#include<stdlib.h>

#define BITCOUNT(v,c) \
 for((c) = 0; (v); ++(c)) \
  v &= (v -1);

#define LG(v,l) \
 {int _ = 1;\
 for((l) = 1; (v) > _; _ |= _ << 1){\
  (l)++;\
 }}

struct SubNet{
 unsigned int SubNetMask;
 unsigned int Min;
 unsigned int Max;
 int subnetBits;
 int hostBits;
 int bar;
 int startbar;
};

const struct SubNet A = {0xff000000,0x0a000000,0x0affffff,8,24,8,8};
const struct SubNet B = {0xfff00000,0xac100000,0xac1fffff,12,20,12,12};
const struct SubNet C = {0xffff0000,0xc0a80000,0xc0a8ffff,16,16,16,16};

// Globals of Death
struct SubNet * Force = 0;
int maximizeHosts = 0;

void printIp(unsigned int ip){
 printf("%d.%d.%d.%d",(ip >> 24),(ip >> 16) & 0xff,(ip >> 8) & 0xff, ip & 0xff);
}

void CalcSubNet(int subnets, int hosts, struct SubNet * subnet){
 int bits4subnets, bits4hosts;
 hosts *= subnets;
 LG(subnets,bits4subnets);
 LG(hosts,bits4hosts);
 unsigned int bits = 0x1 << (bits4hosts + bits4subnets -1);
 #define hasEnoughBits(SubNetMask, bits)\
  (!((SubNetMask) & (bits)))
 struct SubNet const * subNetClass;
 if(Force && hasEnoughBits(Force -> SubNetMask,bits))
  subNetClass = Force;
 else
  subNetClass = (hasEnoughBits(C.SubNetMask,bits) ? &C :
                 hasEnoughBits(B.SubNetMask,bits) ? &B :
                 &A);
 subnet -> SubNetMask = subNetClass -> SubNetMask;
 if(maximizeHosts)
  bits4hosts = 32 - (subNetClass -> bar + bits4subnets);
 else
  bits4subnets = 32 - (subNetClass -> bar + bits4hosts);
  unsigned int t = bits4subnets;
  while(t--){
   subnet -> SubNetMask |= subnet -> SubNetMask >> 1;
  }
 subnet -> Min= subNetClass -> Min;
 subnet -> Max= subNetClass -> Max;
 subnet -> subnetBits = bits4subnets;
 subnet -> hostBits = bits4hosts;
 unsigned int tmp = subnet -> SubNetMask;
 BITCOUNT(tmp, subnet -> bar);
 subnet -> startbar = subNetClass -> startbar;
}

void printNet(int n, struct SubNet * net){
 printf("net #%d) [",n);
 n--;
 unsigned int startIp = net -> Min
                               | (n << (32 - (net -> bar)));
 unsigned int endIp  =  startIp | ( (~net -> SubNetMask) ^ 0x1);
 printIp(startIp+1);
 printf("/%d .. ",net -> bar);
 printIp(endIp);
 printf("],  BroadCast: ");
 printIp(endIp | 0x1);
 printf(" , SubnetMask: ");
 printIp(net -> SubNetMask);
}

int main(int argc, char ** argv){
  int hosts, subnets;
  if(argc < 3) printUsage(), exit(1);
  else{
   subnets = atoi(argv[1]);
   hosts = atoi(argv[2]);
   if(argc > 3){
    char class = argv[3][0];
    if(class == 'A' || class == 'a')
     Force = &A;
    else
    if(class == 'B' || class == 'b')
     Force = &B;
    else
    if(class == 'C' || class == 'c')
     Force = &C;
    else Force = 0;

    if(argc > 4){
     maximizeHosts = 1;
    }
   }
  }
  #define SAMPLE 3
  struct SubNet subnet;
   CalcSubNet(subnets,hosts,&subnet);

  int i =0;

  while(++i <= SAMPLE){
    printf("\n");
     printNet(i,&subnet);
    printf("\n");
  }
  printf("\n ... \n\n");
  printNet(subnets,&subnet);
 printf("\n\n");
 unsigned int tmp = 0;

   printf(" Subnet bits: %d, Hosts bits: %d\n\n",subnet.bar - subnet.startbar, 32-subnet.bar);
}

void printUsage(){
 printf("\n\t Debe especificar el numero de subredes y de hosts.\n\n");
}
