using System;
using System.Collections.Generic;
using System.Linq;

namespace BefungeInterpreterKataCodeWars
{
class BefungeInterpreter{void  f(string R)
{o="";m=new int [z];p=0;u=0;t=-1;q=0;g=1;d
=0;x=l=false;j=R;w=0;h=1;int _t=0;for (int
i=0;i<j.Length;++i){++ _t;if(j[i]=='\n'){w
=_t>w?_t:w;_t=0;++h;}}w=_t>w?_t:w;j=string
.Concat(j.Split("\n").Select(s=>(s.Length<
w?s+new string(' ',w-s.Length):s)+"\n"));}
public string Interpret(string _i){ f(_i);
while(true){_g(_u());if(l)break;}return o;
}void _g(char op){if (op == '"') { x = !x;
return; }if(x){m[p++]=op;return; }if(char.
IsDigit(op)){m[p++]=op-'0';}else switch(op
){case '+':if(p>1){m[p-2]=m[p-1]+m[p-2];--
p;}break;case '-':if(p>1){m[p-2]=m[p-2]-m[
p-1];--p;}break;case '*':if(p>1){m[p-2]=m[
p-1]*m[p-2];--p;}break;case '/':if(p>1){m[
p-2]=m[p-1]!=0?m[p-2]/m[p-1]:0;--p;}break;
case '%':if(p>1){m[p-2]=m[p-1]!=0?m[p-2]%m
[p-1]:0;--p;}break;case '!':if(p>0)m[p-1]=
m[p-1]==0?1:0;break;case '`':if(p>1){m[p-2
]=m[p-2]>m[p-1]?1:0;--p;}break;case '>':g=
1;d=0;break; case '<':g=-1;d=0;break; case 
'v':g=0;d=1;break;case '^':g=0;d=-1;break;
case '?':switch (new Random().Next (0, 4))
{case 0:g=1;d=0;break;case 1: g = 0; d = 1
; break;case 2:g=-1;d=0;break;case 3:g=0;d
=-1; break;} break; case '_':d = 0;if(p <=
0||m[--p]==0)g=1;else g=-1;break;case '|':
g=0;if(p<=0||m[--p]==0)d=1;else d=-1;break
;case ':':m[p]=p<1?0:m[p-1];++p;break;case
 '\\':if (p>0){if (p>1){int tmp=m[p-1];m[p
 -1]=m[p-2];m[p-2]=tmp;}else m[p-1]= 0 ; }
 break;case '$':if(p>0)--p;break;case '.':
if(p>0)o+=m[--p].ToString();break;case ','
:if (p>0)o+=(char)m[--p]; break; case '#':
_u();break;case 'p':if (p>=3){_y=m[p-1];_x
=m[p-2];V=m[p-3];p-=3;_y(_x, _y, (char)V);
}break;case 'g':if (p>=2){_y=m[p-1];_x=m[p
-2];m[p-2]=j[index(_x, _y)];p-=1 ; }break;
case '@':l=true;break;default:break;}}char 
_u(){t+=g;q+=d;if(g!=0){if(t<0)t=w-1;if( t
>=w)t=0;}if(d!=0){if(q<0)q=h;if(q>=h)q=0;}
u=k ();if (u<j.Length) return j[u];else l=
true;return ' '; }bool _o(int x,int y,char
V){if (x>-1&&x<w&&y>-1&&y<h){var _b =  j .
ToCharArray();_b[_a(x,y)]=V; j =new string
(_b);return true;}else return false;} char 
r(int x, int y) => j[_a(x, y)];int k()  =>
_a(t, q);int _a(int x, int y) => ((y * (w+
1))+x);string j, o;static int z = 1 << 24;
int[] m;int p,u,w, h,t, q,g, d, _y, _x, V;
bool x,l;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;} }
