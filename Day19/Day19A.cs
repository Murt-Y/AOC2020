using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace aoc2020
{
    class D19A
    {

public class Rule
{ 
    public int no { get; set; }
    public string condition1 { get; set; }
    public string condition2 { get; set; }
}


        public int ReturnResult()
        {

            var watch = new System.Diagnostics.Stopwatch();
            
watch.Start();
            string[] Initialize()
            {
                
            string[] text = File.ReadAllLines(@"C:\Users\yilma\Documents\AOC2020\Day19/input19.txt");
            return text;
            }
            string[] input = Initialize();
            bool go =true;
            int i=0;
            List<Rule> rules=new List<Rule>();
            while(go)
            {
                string s=input[i];
                if (s=="")
                {
                    go=false;
                }
                else{
                    string[] p= s.Split(':');
                    string[] c=p[1].Split('|');
                    string c1=c[0];
                    string c2=string.Empty;
                    if(c.Length==2)
                    {
                        c2=c[1];
                        rules.Add(new Rule(){no=Convert.ToInt32(p[0]), condition1=c1, condition2=c2});
                    }


                        

                    else
                    {
                        rules.Add(new Rule(){no=Convert.ToInt32(p[0]), condition1=c1});
                    }

                }


                i++;
            }
            
            input = input.Skip(i).ToArray();
            List<string> results= new List<string>();
            List<string> final= new List<string>();
            int[] index =new int[150];
            foreach(Rule r in rules)
            {
                index[r.no]=rules.IndexOf(r);
            }

            string ReplaceWholeWord(string text, string word, string bywhat)
{
            static bool IsWordChar(char c) => char.IsLetterOrDigit(c) || c == '_';
            StringBuilder sb = null;
            int p = 0, j = 0;
            while (j < text.Length && (j = text.IndexOf(word, j, StringComparison.Ordinal)) >= 0)
            if ((j == 0 || !IsWordChar(text[j - 1])) &&
            (j + word.Length == text.Length || !IsWordChar(text[j + word.Length])))
        {
            sb ??= new StringBuilder();
            sb.Append(text, p, j - p);
            sb.Append(bywhat);
            j += word.Length;
            p = j;
            sb.Append(text, p, text.Length - p);
            return sb.ToString();
        }
            else j++;
            if (sb == null) return text;
            sb.Append(text, p, text.Length - p);
            return sb.ToString();
}
            

            bool CheckMe(string i, string a)
            {
                while(true)
                {
                    i=i.Trim();
                    if(a=="" && i=="")
                    {
                        return true;
                    }
                    if(a=="" && i!="")
                    {
                        return false;
                    }
                    if(a!="" && i=="")
                    {
                        return false;
                    }
                string [] s = i.Trim().Split();
                int l=Convert.ToInt32(s[0]);
                int n=index[l];

                if(rules[n].condition1.Contains("a") || rules[n].condition1.Contains("b"))
                {
                if (rules[n].condition1.Contains("a") && a[0]!='a')
                {
                    return false;
                }    
                else if (rules[n].condition1.Contains("b") && a[0]!='b')
                {
                    return false;
                }
                else if (rules[n].condition1.Contains("a") && a[0]=='a')
                {
                    a=a.Substring(1, a.Length-1);
                    i=ReplaceWholeWord(i, s[0], "");
                }
                    
                else if (rules[n].condition1.Contains("b") && a[0]=='b')
                {
                    a=a.Substring(1, a.Length-1);
                    i=ReplaceWholeWord(i, s[0], "");
                }
                }
                
                else
                {

                    string opt1=rules[n].condition1.Trim();
                    string opt2=null;
                    string i1=ReplaceWholeWord(i, s[0], opt1);
                    string i2=null;
                    
                    if(CheckMe(i1, a)==false)
                    {
                    if(rules[n].condition2!=null)
                {
                 opt2=rules[n].condition2.Trim();
                 i2=ReplaceWholeWord(i, s[0], opt2);
                 if(CheckMe(i2, a)==false)  
                 {
                     return false;
                 }
                 else
                 {
                     return true;
                 }
                }
                return false;
                }
                else{
                    return true;
                }
                }
                }
                return false;
                }
                
                
            List<string> list= new List<string>();
            List<Rule> ruleo=new List<Rule>();

            int t=0;
            foreach(Rule r in rules)
            {
                ruleo.Add(new Rule(){no=rules[t].no, condition1=rules[t].condition1, condition2=rules[t].condition2});
                t++;
            }

            void ResetR()
            {
                t=0;
            while(t<3)
            {
                rules[t].condition1=ruleo[t].condition1;
                t++;
            }
            
            }
            int trueno=0;
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }

            rules[0].condition1="42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[0].condition1="42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[0].condition1="42 42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[0].condition1="42 42 42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[0].condition1="42 42 42 42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[0].condition1="42 42 42 42 42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[0].condition1="42 42 42 42 42 42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
                        rules[0].condition1="42 42 42 42 42 42 42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
                        rules[0].condition1="42 42 42 42 42 42 42 42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
ResetR();
            

            rules[1].condition1="42 42 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[1].condition1="42 42 42 31 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[1].condition1="42 42 42 42 31 31 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
                        rules[1].condition1="42 42 42 42 42 31 31 31 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
// YENI
                                    rules[1].condition1="42 42 42 42 42 42 31 31 31 31 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
ResetR();
            

            rules[0].condition1="42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[1].condition1="42 42 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }

ResetR();
            

            rules[0].condition1="42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[1].condition1="42 42 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
ResetR();
            

            rules[0].condition1="42 42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[1].condition1="42 42 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }

ResetR();
            

            rules[0].condition1="42 42 42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[1].condition1="42 42 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
ResetR();
            rules[0].condition1="42 42 42 42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[1].condition1="42 42 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }

ResetR();
            
            rules[0].condition1="42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
                        rules[1].condition1="42 42 42 31 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
ResetR();
            
            rules[0].condition1="42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
                        rules[1].condition1="42 42 42 31 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
ResetR();
            rules[0].condition1="42 42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
                        rules[1].condition1="42 42 42 31 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }

ResetR();
            rules[0].condition1="42 42 42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[1].condition1="42 42 42 31 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
ResetR();
            
            rules[0].condition1="42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[1].condition1="42 42 42 42 31 31 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
ResetR();
            rules[0].condition1="42 42 42";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }
            rules[1].condition1="42 42 42 42 31 31 31 31";
            foreach (string w in input)
            {

                if(CheckMe("0", w))

                {

                    trueno++;
                    list.Add(w);
                }
            }

        list=list.Distinct().ToList();
        Console.WriteLine("Total number of true patterns is     "+list.Count());
        Console.WriteLine("Total number of true patterns is     "+trueno);
        watch.Stop();

Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        return 0;
        }
        
    }
}