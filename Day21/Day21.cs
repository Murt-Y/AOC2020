using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc2020
{
    class D21
    {

        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string[] text = File.ReadAllLines(@"/home/murat/Documents/aoc2020/Day21/input21.txt");
            return text;
            }
            List<string> Ing = new List<string>();
            List<string> All = new List<string>();  

            string[] input = Initialize();

            foreach(string s in input)
            {
                string [] io= s.Split("contains");
                io[0]=io[0].Substring(0, io[0].Length-1);
                io[0]=io[0].Trim();
                io[1]=io[1].Trim();
                io[1]=io[1].Substring(0, io[1].Length-1);
                string[] xxx = io[0].Split(" ");
                string[] al = io[1].Split(",");
                foreach (string w in al)
                {

                    if(All.Contains(w.Trim()) == false)
                    {
                        All.Add(w.Trim());
                    }
                }
                foreach (string w in xxx)
                {
                    if(Ing.Contains(w) == false)
                    {
                        Ing.Add(w);
                    }
                }
            
            }
            int i=Ing.Count;
            int k=All.Count;
            int[,] list = new int[i,k];
                        void Runc(){
                                    int r=0;
                    while(r<All.Count)
                    {
                    int fcount=0;
                    int j=0;
                    int cnum=0;
                    while(j<Ing.Count)
                    {

                        if(list[j,r]==3)
                        {
                            fcount++;
                        }
                        if(list[j,r]==1)
                        {
                            cnum=j;
                        }
                        j++;
                    }
                    if(fcount==Ing.Count-1)
                    {
                        list[cnum,r]=2;
                        int z=0;
                        while(z<All.Count)
                        {
                            if(z!=r)
                            {
                                list[cnum,z]=3;
                            }
                            z++;
                        }
                        Console.WriteLine("A Match ... " + Ing[cnum] + " is    " + All[r]);
                    }
                    r++;
                    }
            }
           foreach(string s in input)
            {
                string [] io= s.Split("contains");
                io[0]=io[0].Substring(0, io[0].Length-1);
                io[0]=io[0].Trim();
                io[1]=io[1].Trim();
                io[1]=io[1].Substring(0, io[1].Length-1);
                string[] xxx = io[0].Split(" ");
                string[] al = io[1].Split(",");
                foreach (string w in al)
                {
                    int t=All.IndexOf(w.Trim());
                    int j=0;
                    // 0 daha belli değil 1 olabilir 2 kesin o 3 kesin yok, listeyi tara olmayanlar 3, 0lar 1, tek 1 varsa 2
                    while(j<Ing.Count)
                    {
                        bool check=false;
                        foreach(string o in xxx)
                        {
                            if(Ing[j]==o && list[j,t]!=3)
                            {
                                check=true;
                            }
                        }
                        if(check==true)
                        {
                            list[j,t]=1;
                        }
                        if(check==false)
                        {
                            list[j,t]=3;
                        }
                        j++;
                    }

                    Runc();
                }
            
            }






            
        int icount=0;
        int m=0;
        while(m<Ing.Count)
        {
            bool checka=true;
            int q=0;
            while(q<All.Count)
            {
                if(q==7)
                {
                    Console.WriteLine(list[m,q]);
                }
                else
                           
                {
                    Console.Write(list[m,q]);
                }
                if(list[m,q]!=3)
                {
                    checka=false;
                }
                q++;
            }
            if (checka==true)
            {
                foreach(string s in input)
                {

                    string pattern=String.Format(@"\b{0}\b", Ing[m]);
                    if(Regex.IsMatch(s, pattern))
                    {
                        icount++;
                    }
                }
            }
        m++;
        }

        //Console.WriteLine("Result is    " + icount);

        Console.WriteLine(Ing[109]+","+Ing[7]+","+Ing[37]+","+Ing[71]+","+Ing[14]+","+Ing[26]+","+Ing[82]+","+Ing[76]);

        return 0;
        }
        
    }
}
