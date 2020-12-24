using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace aoc2020
{
    class D19
    {

public class Rule
{ 
    public int no { get; set; }
    public string condition1 { get; set; }
    public string condition2 { get; set; }
}


        public int ReturnResult()
        {
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


            results.Add("42 42 31");

            List<string> CheckR(){
                i=0;
            while(i<results.Count)
            {
                
                if(results[i].Any(char.IsDigit))
                {
                
                string[] tocheck=results[i].Trim().Split(" ");
                foreach (string c in tocheck)
                {
                    if(c=="a" || c=="b")
                    {

                    }
                    else
                    {
                
                        int n=index[Convert.ToInt32(c)];
                        if(rules[n].condition2!=null)
                        {
                            int k=i;
                            string m1=rules[n].condition1.Trim();
                            string m2=rules[n].condition2.Trim();
                            List<string> results2= new List<string>();

                    while(k<results.Count)
                    {
                                if(results[k].Contains(c))
{
                                            string temp1= results[k];
                                            results[k] = ReplaceWholeWord(results[k],c ,m1);
                                            temp1=ReplaceWholeWord(temp1,c ,m2);
                                            results2.Add(temp1);
                                            
}
k++;
}
results.AddRange(results2);

}
                        else
                        {
                            int k=i;
                            string m=rules[n].condition1.Trim();
                            if(m.Contains("a"))
                                            {
                                                m="a";
                                            }
                            if(m.Contains("b"))
                                            {
                                                m="b";
                                            }

                            while(k<results.Count)
                            {
                                if(results[k].Contains(c)){
                                            results[k] = ReplaceWholeWord(results[k],c ,m);
                                            }
                                            k++;
                                            
                            }
                        }

                    }
                }
                }
                
                else
                {
                    bool change=false;
                    i++;

   
                    while(change==false)
                    {
                                         if(i>=results.Count)
                                         {
                                             break;
                                         }
                        if(results[i].Any(char.IsDigit))
                        {
                            change=true;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    

                    results=results.Distinct().ToList();

                }
                

            }

            return results;
            }


        
            List<string> t=CheckR();

            
            final.AddRange(t);
            results.Clear();
            CheckValid();
            t.Clear();

            results.Add("42 42 42 31");
            results.Add("42 42 42 42 31");
            t=CheckR();
            final.AddRange(t);
            results.Clear();
            CheckValid();
            t.Clear();


            results.Add("42 42 42 31 31");
            results.Add("42 42 42 42 31 31 31");
            t=CheckR();
            final.AddRange(t);
            results.Clear();
            CheckValid();
            t.Clear();

            results.Add("42 42 42 42 42 31");
            results.Add("42 42 42 42 42 31 31 31 31");
            t=CheckR();
            final.AddRange(t);
            results.Clear();
            CheckValid();
            t.Clear();

            results.Add("42 42 42 42 42 42 31");
            results.Add("42 42 42 42 42 42 31 31 31 31 31");
            t=CheckR();
            final.AddRange(t);
            results.Clear();
            CheckValid();
            t.Clear();

            results.Add("42 42 42 42 42 42 42 31");
            results.Add("42 42 42 42 42 42 42 31 31 31 31 31 31");
            t=CheckR();
            final.AddRange(t);
            results.Clear();
            CheckValid();
            t.Clear();

            results.Add("42 42 42 42 42 42 42 42 31");
            results.Add("42 42 42 42 42 42 42 42 31 31 31 31 31 31 31");
            t=CheckR();
            final.AddRange(t);
            results.Clear();
            CheckValid();
            t.Clear();


            void CheckValid(){
            int k=0;
            while(k<final.Count)
            {
                final[k]=final[k].Replace(" ","");
                k++;
            }

            int totalcount=0;

            foreach(string f in input)
            {
                if(final.Contains(f))
                {
                    totalcount++;
                }
            }

            Console.WriteLine("total number is ... " +totalcount);

            }
        return 0;
        }
        
    }
}