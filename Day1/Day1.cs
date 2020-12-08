using System;
using System.IO;
using System.Collections.Generic;

namespace aoc2020
{
    class D1
    {
        public int ReturnResult()
        {
            int[] Initialize()
            {
                
            string text = File.ReadAllText(@"/home/murat/Documents/aoc2020/Day1/input11.txt");
            string[] words = text.Split("\n");
            int i= words.Length;
            int[] numeros = new int[i-1];
            int c=0;
            while(c<i-1)
            {
                numeros[c]= Convert.ToInt32(words[c]);
                c++;
            }
            return numeros;
            }
            int[] input = Initialize();
            void CheckSum(int k)
            {
                int c= input.Length-1;
                int r=c;
                while(c>k && r>0)
                {
                if((input[k]+input[c]+input[r])==2020)
                {
                    Console.WriteLine("The correct Numbers are ="+input[k] + "   " + input[c]+ "    " + input[r]);
                    Console.WriteLine("Result is "+ (input[k]*input[c]*input[r]));
                    return;
                }


                c--;
                if(c==k)
                {
                    r--;
                    c=input.Length-1;
                }
                }
                return;
            }


            Array.Sort(input);
            int t=0;
            while(t<input.Length)
            {
                CheckSum(t);
                t++;
            }
            
            
        return 0;
        }
    }
}
