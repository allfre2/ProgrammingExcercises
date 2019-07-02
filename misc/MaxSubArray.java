import java.util.Random;
import java.util.Arrays;

class MaxSubArray{

 MaxSubArray(){}
class Result implements Comparable<Result>{
 int from;
 int to;
 int sum;

 Result(int sum, int from, int to){
  this.from = from;
  this.to = to;
  this.sum = sum;
 }

 @Override
 public int compareTo( Result R ){
  if(this.sum == R.sum)
   return 0;
  if(this.sum > R.sum) return 1;
   else return -1;
 }
}

 Result FindMaxSubArray(int[] A){
  return FindMaxSubArray(A, 0, A.length-1);
 }

 Result FindMaxSubArray(int[]A, int from, int to){
  int mid = from + ((to - from) / 2);
  Result left, right, cross;

  if(from >= to){ return new Result(A[from],from,to);}
  //if(A.length <139) return BruteForce(A);
  // 139 seems to be the case where n^2 beats nlogn algorithm

  left = FindMaxSubArray(A,from,mid);
  right = FindMaxSubArray(A,mid+1,to);
  cross = FindMaxCrossingSubArray(A,from,mid,to);

  // Implement comparable in Result class
  Result[] ans = {left, right, cross};
  Arrays.sort(ans);
  return ans[ans.length-1];
 }

 Result FindMaxCrossingSubArray(int[] A, int from, int mid, int to){

  int leftsum,rightsum,sum = 0,
   leftindex = mid, rightindex = mid+1;
  leftsum = rightsum = Integer.MIN_VALUE;

  for( int i = mid; i >= from; --i){
   sum += A[i];
   if(sum > leftsum){
    leftsum = sum;
    leftindex = i;
   }
  }

  sum = 0;
  for( int i = mid +1; i <= to; ++i){
   sum += A[i];
   if(sum > rightsum){
    rightsum = sum;
    rightindex = i;
   }
  }
  return new Result(leftsum+rightsum,leftindex,rightindex);
 }

 Result BruteForce(int[] A){
  int MaxSum = Integer.MIN_VALUE;
  int MaxI = 0;
  int MaxJ = 0;

  for( int i =0; i < A.length; ++i ){
   int sum = 0;
   for ( int j = i; j < A.length; ++j ){
    sum += A[j];
    if( sum > MaxSum ){
     MaxSum = sum;
     MaxI = i;
     MaxJ = j;
    }
   }
  }
  return new Result(MaxSum, MaxI, MaxJ);
 }

 Result Kadane(int[] A){
  int MaxSoFar = A[0];
  int MaxSum = A[0];
  int MaxI = 0, MaxJ = 0;

  for(int i = 1; i < A.length; ++i){
   if(MaxSum+A[i] > A[i]){
    MaxSum += A[i];
   }else{
    MaxSum = A[i];
    MaxI = i;
    MaxJ = i;
   }
   if(MaxSoFar < MaxSum){
    MaxSoFar = MaxSum;
    MaxJ = i;
   }
  }
  return new Result(MaxSoFar,MaxI,MaxJ);
 }

 int[] GenRandomIntArray(int n, int min, int max){
  int[] arr = new int[n];

  for(int i = 0; i < arr.length; ++i){
   Random ran = new Random();
   arr[i] = ran.nextInt(max - min + 1) + min;
  }
  return arr;
 }

 void TestRandom(int n, int len){
  System.out.println("Generating: " + n + " random arrays of length " +
                                          len + ".\n");
   Result r;
  int[][] arrays = new int[n][len];
  for( int i = 0; i < n; ++i){
   arrays[i] = GenRandomIntArray(len, -100, 100);
   r = BruteForce(arrays[i]);
   System.out.println(i + ") " + Arrays.toString(arrays[i]) + "\n");
   System.out.println( "maxSubArray from: " + r.from + " to: " + r.to  + " = " +r.sum + " \n ");
   r = FindMaxSubArray(arrays[i]);
   System.out.println( "maxSubArray* from: " + r.from + " to: " + r.to  +" = " + r.sum + " \n ");
   r = Kadane(arrays[i]);
   System.out.println( "maxSubArray! from: " + r.from + " to: " + r.to  + " = " + r.sum + " \n ");
  }
 }

 void Say(Object o){
  System.out.println(o);
 }

 void Test(int[] cases){
  long startTime, endTime;
  int[] arr;
  Result r;

  for(int i = 0; i < cases.length; ++i){
   arr = GenRandomIntArray(cases[i],-100,100);
   Say("\nTesting with array of size: " + cases[i] + "\n");
   startTime = System.nanoTime();
    r = Kadane(arr);
   endTime = System.nanoTime();
   Say("n time: " + (endTime - startTime)/1000000000.0 + "s");
   startTime = System.nanoTime();
    r = FindMaxSubArray(arr);
   endTime = System.nanoTime();
   Say("nlogn time: " + (endTime - startTime)/1000000000.0 + "s");
   //startTime = System.nanoTime();
   // r = BruteForce(arr);
   //endTime = System.nanoTime();
   //Say("n^2 time: " + (endTime - startTime)/1000000000.0 + "s");
  }

 }

 void FindWhereSameTime(){
  long startTime, endTime;
  long delta = 100;
  int sameforn;
  long diff = Long.MAX_VALUE;
  long nlogntime, n2time,ntime;
  Result r;
  int[] A;

  int size = 10000;

  while(size > 0 && Math.abs(delta) > 50){
   Say("\n * Testing with array of size: " + size+ "\n");
   A = GenRandomIntArray(size,-100,100);
   startTime = System.nanoTime();
    r = FindMaxSubArray(A);
   endTime = System.nanoTime();
   nlogntime = (endTime - startTime);
   Say("\tnlogn time: " + nlogntime );
//   startTime = System.nanoTime();
//    r = BruteForce(A);
//   endTime = System.nanoTime();
//   n2time = (endTime - startTime);
//   Say("\tn^2 time: " + n2time );
//   delta = n2time - nlogntime;
   startTime = System.nanoTime();
    r = Kadane(A);
   endTime = System.nanoTime();
   ntime = (endTime - startTime);
   delta = nlogntime - ntime;
   Say("\tn time: " + ntime );
   Say("\tdiff: " + delta);

     if(delta > 0){
      size -= size/2;
     }
     else{
      size += size/2;
     }
  }
 }

 public static void main(String[] args){
  (new MaxSubArray()).TestRandom(4, 10);
  System.out.println("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n\n");
  (new MaxSubArray()).Test(new int[]{100, 10000, 100000,1000000,10000000,100000000});
  (new MaxSubArray()).FindWhereSameTime();
  new java.util.Scanner(System.in).nextLine();
 }
}
