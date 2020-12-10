using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D10
    {
        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string[] text = File.ReadAllLines(@"C:\Users\yilma\Documents\AOC2020\Day10/input10.txt");
            return text;
            }
            string[] words = Initialize();
            List<int> input = new List<int>();
            List<long> result = new List<long>();




            foreach (string w in words)
            {
                input.Add(Convert.ToInt32(w));
            } 
           input.Sort();

            int i =0;
            while(i<input.Count)
            {
                result.Add(0);
                i++;
            }

           long CheckNode(int x)
           {
                if(x==input.Count-1 || input[x+1]>input[x]+3)
               {
                   result[x]=1;
                   return 1;
               }
               long n1=0;
               
                if(result[x+1]==0){
               n1=CheckNode(x+1);
                result[x+1]=n1;
                }
                else
                {
                    n1=result[x+1];
                }

               long n2=0;
                if(x<input.Count-2 && input[x+2]<=input[x]+3)
               {
                   if(result[x+2]==0){
                n2=CheckNode(x+2);
                result[x+2]=n2;
                }
                else
                {
                    n2=result[x+2];
                }
               }
                long n3=0;
                if(x<input.Count-3 &&input[x+3]<=input[x]+3)
               {
                    if(result[x+3]==0){
                n3=CheckNode(x+3);
                }
                else
                                {
                    n3=result[x+3];
                }

               }


            return n1+n2+n3;
            
           }

           long x1=0;
           long x2=0;
           long x0=0;
           x0=CheckNode(0);
            if (input[1]<4)
            {
                 x1= result[1];
            }
            if (input[2]<4)
            {
                 x2= result[2];
            }
            Console.WriteLine("The total number of paths is..."+ (x0+x1+x2));

        return 0;
        }
        
    }
}
