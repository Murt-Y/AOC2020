using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace aoc2020
{
    public class D2
    {
        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string text = File.ReadAllText(@"/home/murat/Documents/aoc2020/Day2/input2.txt");
            string[] words = text.Split("\n");
            return words;
            }
            string[] input = Initialize();
            input= input.Take(input.Count() - 1).ToArray();


            bool Checker(string w)
            {
                string[] pass = w.Split(": ");
                int min=0;
                int max=0;
                int i=0;
                char code='0';

                if(Char.IsDigit(pass[0][i+1]))
                {
                    min=Convert.ToInt32(pass[0].Substring(i,2));
                    i=i+3;
                }
                else
                {
                    min=Convert.ToInt32(pass[0][i])-'0';
                    i=i+2;
                }

                if(Char.IsDigit(pass[0][i+1]))
                {
                    max=Convert.ToInt32(pass[0].Substring(i,2));
                    i=i+3;
                }
                else
                {
                    max=Convert.ToInt32(pass[0][i])-'0';
                    i=i+2;
                }

                code=pass[0][i];
                if(pass[1][min-1]==code)
                {
                    if(pass[1][max-1]==code)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if(pass[1][max-1]==code)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            int totalcorrect=0;

            foreach(string s in input)
            {
            
            if(Checker(s)==true)
            {
                totalcorrect=totalcorrect+1;
            }
            }
            
            return totalcorrect;
        }
            
        
    }
}
