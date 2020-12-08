using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D7
    {
public class Colors
{ 
    public string Name { get; set; }
    public string Contains { get; set; }
    public string Shiny { get; set; }
}
        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string[] text = File.ReadAllLines(@"/home/murat/Documents/aoc2020/Day7/input7.txt");
            return text;
            }

            string[] input = Initialize();

            List<Colors> alist = new List<Colors>();
            char[] digits = {'0','1','2','3','4','5','6','7','8','9'};

            foreach(string w in input)
            {
                string[] temp=w.Split("bags contain");
                temp[1]=temp[1].Replace("bags", "");
                temp[1]=temp[1].Replace("bag", "");
                temp[1]=temp[1].Replace(" ,", "");
                temp[1]=temp[1].Replace(" .", "");
                alist.Add(new Colors(){Name=temp[0], Contains=temp[1]});
            }
            
            bool CheckIfGold(string x)
            {

                if(x==" no other")
                {
                return false;

                }

                if(x.Contains("shiny gold"))
                {
                return true;
                }
                else{
                x=x.Trim();   
                int k=x.Length;
                int i=1;
                int starti=0;
                int fini=0;
                while(i<k)
                {
                    if(Char.IsDigit(x[i]) || i==k-1)
                    {
                        fini=i;
                        string s;
                        if(i==k-1)
                        {
                        s=x.Substring(starti, fini-starti+1);
                        s+=" ";
                        }
                        else
                        {
                        s=x.Substring(starti, fini-starti);
                        }
                        s=s.Substring(2);
                        int pos=alist.FindIndex(x => x.Name==s);;

                        if(alist[pos].Shiny=="Y")
                        {
                            return true;
                        }
                        if(CheckIfGold(alist[pos].Contains))
                        {
                            return true;
                        }
                        alist[pos].Shiny="N";
                        starti=fini;
                    }
                    i++;
                }

                    }
                return false;
            }

            //int totalgoldbag=0;
            //foreach(Colors c in alist)
            //{
            //    if(CheckIfGold(c.Contains))
            //    {
            //        totalgoldbag++;
            //        c.Shiny="Y";
            //    }
            //    else{
            //        c.Shiny="N";
            //    }
            //}
            int pos=alist.FindIndex(x => x.Name=="shiny gold ");
            int CheckTotalBags(int z)
            {
                int tbag=0;
                if (alist[z].Contains==" no other")
                {
                    return 0;
                }
                else
                {
                    string con =alist[z].Contains;
                    
                    con=con.Trim();   
                int k=con.Length;
                int i=1;
                int starti=0;
                int fini=0;
                while(i<k)
                {
                    if(Char.IsDigit(con[i]) || i==k-1)
                    {
                        fini=i;
                        string s;
                        if(i==k-1)
                        {
                        s=con.Substring(starti, fini-starti+1);
                        s+=" ";
                        }
                        else
                        {
                        s=con.Substring(starti, fini-starti);
                        }
                        int multip=Convert.ToInt32(s.Substring(0,2));
                        s=s.Substring(2);
                        int poss=alist.FindIndex(x => x.Name==s);
                        tbag=tbag+(multip+multip*CheckTotalBags(poss));
                        starti=fini;
                    }
                    i++;
                }





                return tbag;
                }
            }

            Console.WriteLine(CheckTotalBags(pos));


            
        return 0;
        }
        
    }
}
