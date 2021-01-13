using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace aoc2020
{
    class D22
    {

        public int ReturnResult()
        {
  
            string[] text1 = File.ReadAllLines(@"/home/murat/Documents/aoc2020/Day22/p1.txt");
            string[] text2 = File.ReadAllLines(@"/home/murat/Documents/aoc2020/Day22/p2.txt");


            List<int> p1i = new List<int>();
            List<int> p2i = new List<int>();
            int gamecount=0;
            foreach(string s in text1)
            {
                p1i.Add(Convert.ToInt32(s));
            }
            foreach(string s in text2)
            {
                p2i.Add(Convert.ToInt32(s));
            }
        bool Game(List<int> p1, List<int> p2)
        {
            gamecount++;
            int mygamecount=gamecount;
        List<string> mem = new List<string>();
        string Save(List<int> d1, List<int> d2)
        {
            string save ="p1-";
            foreach(int z in d1)
            {
                save=save+Convert.ToString(z)+",";
            }
            save=save+"p2-";
            foreach(int z in d2)
            {
                save=save+Convert.ToString(z)+",";
            }
            return save;
        }
        void Round()
        {
            int x=p1[0];
            int y=p2[0];
            p1.RemoveAt(0);
            p2.RemoveAt(0);
            if(p1.Count>=x && p2.Count>=y)
        {
            List<int> r1 = new List<int>();
            List<int> r2 = new List<int>();
            int i=0;
            int r1max=0;
            int r2max=0;
            while(i<x)
            {
                if(p1[i]>r1max)
                {
                    r1max=p1[i];
                }
                r1.Add(p1[i]);
                i++;
            }
            i=0;
            while(i<y)
            {
                if(p2[i]>r2max)
                {
                    r2max=p2[i];
                }
                r2.Add(p2[i]);
                i++;
            }
            if(r1max>r2max)
            {
                p1.Add(x);
                p1.Add(y);
            }    
            else if(Game(r1,r2))
            {
                p1.Add(x);
                p1.Add(y);
            }
            else
            {
                p2.Add(y);
                p2.Add(x);
            }
        }

        else
        {


            if(x>y)
            {
                p1.Add(x);
                p1.Add(y);
            }
            if(x<y)
            {
                p2.Add(y);
                p2.Add(x);
            }

        }
        }
        
        bool gameover=false;
        int roundcount=0;
        string phase=string.Empty;
        while(gameover==false)
        {
        phase=Save(p1, p2);
        if(mem.Contains(phase))
            {
                return true;
            }
        else
        {
            mem.Add(phase);
        }
        Round();
        roundcount++;
        if(p1.Count==0 || p2.Count==0)
            {
            gameover=true;
            }
        }
        int score1=0;
        int score2=0;
        int i=0;
        while(i<p1.Count)
        {
            score1=score1+p1[i]*p1.Count-i;
            i++;
        }
        while(i<p2.Count)
        {
            score2=score2+p2[i]*(p2.Count-i);
            i++;
        }
        if(mygamecount==1)
        {
        Console.WriteLine("P1 Score is   " + score1);
        Console.WriteLine("P2 Score is   " + score2);
        }
        if(score1>score2)
        {
            return true;
        }
        else
        {
            return false;
        }

        }

        Game(p1i, p2i);






        return 0;
        }
        
    }
}
