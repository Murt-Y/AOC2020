using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D8
    {

        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string[] text = File.ReadAllLines(@"/home/murat/Documents/aoc2020/Day8/input8.txt");
            return text;
            }

            string[] input = Initialize();
            int c=0;
            int t=0;
            int accumulator=0;
            List<int> counterl = new List<int>();
            void Oper(string w, int y)
            {
                if(w=="acc")
                {
                    accumulator=accumulator+y;
                    c++;
                    return;
                }
                if(w=="jmp")
                {
                    c=c+y;
                    return;
                }
                if(w=="nop")
                {
                    c++;
                    return;
                }
            }

            bool Run(int x, int r)
            {
                string code=input[x];
                string func=code.Substring(0,3);
                int value=Convert.ToInt32(code.Substring(3, code.Length-3));
                if(c==t && func=="jmp")
                {
                    func="nop";
                }
                Oper(func, value);

                if(counterl.Exists(x=> x==c))
                {
                    return false;
                }
                if(c>= input.Length)
                {
                    Console.WriteLine("Program is Complete");
                    Console.WriteLine("Accumulator Value is .... " +accumulator); 
                    return true;
                }
                counterl.Add(c);
                Run(c,t);
                return false;
            }

            while(t<input.Length)
            {
            counterl.Add(c);
            Run(c,t);
            c=0;
            t++;
            accumulator=0;
            counterl.Clear();
            }
        return 0;
        }
        
    }
}
