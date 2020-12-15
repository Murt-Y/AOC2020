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
            SortedList<int,int> Memory = new SortedList<int,int>();
            int i=0;

            foreach(string w in input)
            {
                    Memory.Add(Convert.ToInt32(w), i);
                    i++;
            }

            int next=0;
            while (i<30000000)
            {
                
                if(i==30000000-1)
                {
                    Console.WriteLine(next);
                }
                if(Memory.ContainsKey(next)==false)
                {
                    Memory.Add(next, i);
                    next=0;
                }
                else{
                    int temp=next;
                    next=i-Memory[next];
                    Memory[temp]=i;  
                }
                i++;
            }
        return 0;
        }
        
    }
}
