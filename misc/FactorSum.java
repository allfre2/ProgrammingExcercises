
class FactorSum {

	int s;

	FactorSum(int a, int b, int limite){
	 int ma,mb,ms;
	 this.s = a * b;
	 ma = (limite - (limite % a))/a;
	 mb = (limite - (limite % b))/b;
	 ms = (limite - (limite % s))/s;
	 System.out.println((a*ma*(ma+1)/2)+(b*mb*(mb+1)/2)-(s*ms*(ms+1)/2));
	}

	public static void main (String [] args)
	{
		new FactorSum(3,5,1000);
	}
}
