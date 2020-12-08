using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D6
    {
        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string text = File.ReadAllText(@"/home/murat/Documents/aoc2020/Day6/input6.txt");
            string[] words = text.Split("\n\n");
            int totalcount=0;
            foreach(string w in words)
            {
                int[] questions = new int[26];
                string[] pep = w.Split("\n");
                foreach (string p in pep)
                {
                    foreach (char a in p)
                    {
                        questions[a-97]=questions[a-97]+1;
                    }
                }

            int county=0;
            foreach (int q in questions)  
            {
                if(q==pep.Length)
                {
                    county++;
                }
            }  
            totalcount=totalcount+county;
            }


            Console.WriteLine("Total Count is..." + totalcount);
            return words;
            }
            string[] input = Initialize();
 
            
        return 0;
        }
    }
}
