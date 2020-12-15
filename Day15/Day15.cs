using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Collections; 

namespace aoc2020
{
    class D15
    {

        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string text = File.ReadAllText(@"C:\Users\yilma\Documents\AOC2020\Day15/input15.txt");
            string[] words = text.Split(",");
            return words;
            }

            string[] input = Initialize();
            int i=1;
            int[] Memx= new int [30000000];
            foreach(string w in input)
            {
                    Memx[Convert.ToInt32(w)]=i;
                    i++;
            }

            int next=0;
            while (i<30000001)
            {
                
                if(i==30000000)
                {
                    Console.WriteLine(next);
                }
                if(Memx[next]==0)
                {
                    Memx[next]=i;
                    next=0;
                }
                else{
                    int temp=next;
                    next=i-Memx[next];
                    Memx[temp]=i;  
                }
                i++;
            }
        return 0;
        }
        
    }
}
