using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D16
    {
        public class Rule
{ 
    public string Name { get; set; }
    public string[] Value { get; set; }
}
        public int ReturnResult()
        {
            string[] Rules()
            {
            string[] text = File.ReadAllLines(@"/home/murat/Documents/aoc2020/Day16/rules.txt");
            return text;
            }
            string[] Tickets()
            {
            string[] text = File.ReadAllLines(@"/home/murat/Documents/aoc2020/Day16/tickets.txt");
            return text;
            }
            int[] MyTicket()
            {
            string text = File.ReadAllText(@"/home/murat/Documents/aoc2020/Day16/myticket.txt");
            string[] words =text.Split(",");
            int im=0;
            int[] mtt=new int[20];
            foreach (string s in words)
            {
                mtt[im]=Convert.ToInt32(s);
                im++;
            }
            return mtt;
            }
            List<Rule> rules= new List<Rule>();
            string[] r = Rules();
            int[,] rulebook =new int[20,20];

           
            int[]myticket=MyTicket();

            

            foreach (string w in r)
            {   
                string[] t =w.Split(": "); 
                string[] p= t[1].Split(" or ");
                rules.Add(new Rule(){Name=t[0], Value=p});   
            }
            int invalid=0;

            bool CheckRule(int x, int k)
            {
                bool c=false;
                int i=0;
                int[] table=new int[20];
                foreach (Rule r in rules)
                {
                    
                    foreach (string w in r.Value)
                    {

                        string[] m=w.Split("-");
                        if(x>=Convert.ToInt32(m[0]) && x<=Convert.ToInt32(m[1]))
                        {
                            c=true;
                            table[i]=1;
                            break;
                        }

                    }
                    i++;
                }
                if (c==false)
                {
                invalid=invalid+x;
                return false;
                }
                else
                {
                    int j=0;
                    while (j<20)
                    {
                        if(table[j]==0)
                        rulebook[j,k]=rulebook[j,k]+1;
                        j++;
                    }
                    return true;
                }
            }


            
            bool CheckValid(string t)
            {
                string[] p=t.Split(",");
                int[]x= new int[p.Count()];
                int i=0;
                foreach (string pp in p)
                {
                    x[i]=Convert.ToInt32(pp);
                    i++;
                }
                bool c=true;
                int k=0;
                foreach(int o in x)
                {
                    if(CheckRule(o, k)==false)
                    {
                        c=false;
                        break;
                    }
                    k++;
                }
                if(c==false)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }


            string[] tickets = Tickets();
            int i=0;
            foreach (string ti in tickets)
            {
                if(CheckValid(ti)==false)
                {
                    tickets[i]=null;
                }
                i++;
            }

            int z=0;
        foreach(int p in rulebook)
        {
            
            Console.Write(p);
            z++;
            if(z%20==0)
            {
                Console.WriteLine();
            }
        }
        int ms=0;
        foreach(int s in myticket)
        {
                CheckRule(s, ms);
                ms++;
        }
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("-----------------------------------");
        foreach(int p in rulebook)
        {
            
            Console.Write(p);
            z++;
            if(z%20==0)
            {
                Console.WriteLine();
            }
        }
        long result=myticket[1]*myticket[3]*myticket[10]*myticket[6]*myticket[8]*myticket[19];
        Console.WriteLine("Result is .... " + result);
        return 0;
        }
        
    }
}