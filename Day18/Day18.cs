using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D18
    {

        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string[] text = File.ReadAllLines(@"/home/murat/Documents/aoc2020/Day18/input18.txt");
            return text;
            }

            string[] input = Initialize();

    long Operation(string t)

    {
        t=t.Replace(" " , "");
        int i=0;
        long result=0;
        string op="plus";

           while(i<t.Length)
            {
                if(t[i]=='+')
                {
                    op="plus";
                }
                else if(t[i]=='*')
                {
                        result=result*Operation(t.Substring(i+1, t.Length-i-1));
                        return result;
                }
                else if(Char.IsDigit(t[i]))
                {
                    if(op=="plus")
                    {
                        result=result+(t[i]-48);
                    }

                }
                else if(t[i]=='(')
                {

                    long rest=Operation(t.Substring(i+1, t.Length-i-1));
                    if(op=="plus")
                    {
                        result=result+rest;
                    }
                    if(op=="multi")
                    {
                        result=result*rest;
                    }
                    
                    bool inp=true;
                    int tcount=0;
                    while (inp==true)
                    {
                        

                        if(t[i]==')')
                        {
                            tcount--;
                        }
                        if(t[i]=='(')
                        {
                            tcount++;
                        }
                        if(tcount==0)
                        {
                            inp=false;
                            i--;
                        }
                        i++;
                    }
                }
                else if(t[i]==')')
                {
                    return result;
                }

                i++;
            }
    return result;
    }
long totres=0;
foreach (string w in input)
{
    totres=totres+Operation(w);
    
}


Console.WriteLine("Final Result is " +totres);

        return 0;
        }
        
    }
}