using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace aoc2020
{
    public class D3
    {
        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string text = File.ReadAllText(@"/home/murat/Documents/aoc2020/Day3/input3.txt");
            string[] words = text.Split("\n");
            return words;
            }
            string[] input = Initialize();
            input= input.Take(input.Count() - 1).ToArray();
            int t=input[0].Length;
            int k=input.Length;
            int x=0;
            int y=0;

            bool CheckTree(string w, int xc)
            {
                if(w[xc]=='#')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            
            Int64 treem=1;

            void SlopeChecker(int xs, int ys)
            {
                x=0;
                y=0;
                int totaltrees=0;
            
            while(y<k)
            {
            bool at = CheckTree(input[y], x);
            if (at==true)
            {
                totaltrees+=1;
            }

            x=x+xs;
            y=y+ys;
            if(x>=t)
            {
                x=x-t;
            }

            }
            treem=treem*totaltrees;
            }
            SlopeChecker(1,1);
            SlopeChecker(3,1);
            SlopeChecker(5,1);
            SlopeChecker(7,1);
            SlopeChecker(1,2);


            Console.WriteLine("Multiplication of Trees is ... : " + treem);
            return  0;
        }


    }
}
