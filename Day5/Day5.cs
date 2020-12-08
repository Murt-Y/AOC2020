using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D5
    {
        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string text = File.ReadAllText(@"/home/murat/Documents/aoc2020/Day5/input5.txt");
            string[] words = text.Split("\n");
            return words;
            }
            string[] input = Initialize();
            input= input.Take(input.Count() - 1).ToArray();
            int highestid=0;
            int[] fulllist = new int[127*8+7];
            foreach(string w in input)
            {
                int i=0;
                int seatrow=0;
                int seatcolumn=0;

                while (i<7)
                {
                    
                    if (w[i]=='B')
                    {
                        seatrow=seatrow+Convert.ToInt32(Math.Pow(2, 6-i));
                    }
                    i++;

                }
                i=7;
                while (i<10)
                {
                    if(w[i]=='R')
                    {
                    seatcolumn=seatcolumn+Convert.ToInt32(Math.Pow(2, 9-i));
                    }
                    i++;
                }
                int seatid= seatrow*8+seatcolumn;
                Console.WriteLine(seatid);
                fulllist[seatid]=1;
                if (seatid>highestid)
                {
                    highestid=seatid;
                }
            }
        Console.WriteLine("Highest Seat Id is .... " +highestid);
        return 0;
        }
    }
}
