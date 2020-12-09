using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D9
    {

        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string[] text = File.ReadAllLines(@"C:\Users\yilma\Documents\AOC2020\Day9/input9.txt");
            return text;
            }
            string[] input = Initialize();
            long[] inputn = new long[input.Length];
            int i=0;
            foreach (string w in input)
            {
                inputn[i]=Convert.ToInt64(w);
                i++;
            }
            

 /*           bool CheckSum(int z){
            
                long sum=inputn[z];
                int pres=z-25;
                int c=0;
                int r=1;
                while(c<25)
                {
                    while(r<25)
                    {
                        if(c==r)
                        {

                        }
                        else if(inputn[pres+c]+inputn[pres+r]==sum)
                        {
                            return true;
                        }
                        r++;
                    }
                    c++;
                    r=c+1;
                }
                Console.WriteLine("This number fails the test .... "+sum);
                return false;
            
            }
            int s=25;
            while(s<inputn.Length)
            {
            CheckSum(s);
            s++;
            }
*/          
        long ntofind=22477624;
        long s=Int64.MaxValue;
        long l=0;
        bool FindSet(int x, long y)
        {
            if(inputn[x]<s)
            {
                s=inputn[x];
            }
            if(inputn[x]>l)
            {
                l=inputn[x];
            }
            
            if (inputn[x]==ntofind)
            {
                return false;
            }
            y=inputn[x]+y;
            if(y==ntofind)
            {
                Console.WriteLine("Last number is " +inputn[x]);
                return true;
            }
            if(y>ntofind)
            {
                return false;
            }
            else 
            {
                if(FindSet(x+1, y))
                {
                    return true;
                }
            }
            return false;
        }

        int t=0;
        while (t<inputn.Length)
        {
            if(FindSet(t, 0))
            {
                Console.WriteLine("The smallest number is "+ s);
                Console.WriteLine("The largest number is "+ l);
                Console.WriteLine("The total is "+ (s+l));
            }
            s=Int64.MaxValue;
            l=0;
            t++;
        }

           
        return 0;
        }
        
    }
}
