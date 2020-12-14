using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D142
    {
        public class Mem
{ 
    public long Id { get; set; }
    public long Value { get; set; }
}
        public int ReturnResult()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            string[] Initialize()
            {
                
            string[] text = File.ReadAllLines(@"/home/murat/Documents/aoc2020/Day14/input14.txt");
            return text;
            }

            string[] input = Initialize();
            string mask=string.Empty;
            List<Mem> Memory= new List<Mem>();

            string Convert2(long x)
            {
                string a=String.Empty;
                
                while(x>0)
                {
                    a=a.Insert(0, Convert.ToString(x%2));
                    x=x/2;
                }
                return a;
            }
            
            string Mask(string p)
            {
                int i=0;
                int pl=p.Length;
                char[] togive= new char[36];

                foreach(char c in p)
                {
                        togive[36-pl+i]=c;
                
                i++;
                }
                i=0;
                foreach(char c in mask)
                {
                        if(c!='0')
                        {
                            togive[i]=c;
                        
                }
                else if(togive[i]=='\0')
                {
                    togive[i]='0';
                }
                i++;
                }
                string toreturn=new string (togive);
                return toreturn;
            }

            foreach(string w in input)
            {
                if(w.Substring(0,4)=="mask")
                {
                    mask=w.Substring(7,36);
                }
                if(w.Substring(0,3)=="mem")
                {
                    int i=3;
                    int memf=0;
                    while(i<w.Length)
                    {
                        if(w[i]==']')
                        {
                            memf=i;
                            i=w.Length;
                        }
                        i++;
                    }
                    long memadress=Convert.ToInt64(w.Substring(4,memf-4));
                    long value=Convert.ToInt64(w.Substring(memf+4));

                    string memadressbin=Convert2(memadress);
                    memadressbin=Mask(memadressbin);

                    void StoreF(string mes)
                    {
                    bool trim=false;
                    while(trim==false)
                    {
                        if(mes[0]==32 || mes[0]==48)
                        {
                            mes=mes.Substring(1);
                        }
                        else
                        {
                            trim=true;
                        }
                    }

                    memadress=Convert.ToInt64(mes, 2);
                    int indexmem =Memory.FindIndex(x=> x.Id==memadress);


                    if (indexmem==-1)
                    {
                        Memory.Add(new Mem(){Id=memadress, Value=value});
                    }
                    else
                    {
                        Memory[indexmem].Value=value;
                    }
                    }


                    void Store(string m, string n)
                    {
                                                            if(n=="")
                                {
                                    StoreF(m);
                                }

                                else {
                        foreach(char c in n)
                        {

                            n=n.Substring(1);
                            if(c != 'X')
                            {
                                m=m+c;

                                if(n=="")
                                {
                                    StoreF(m);
                                }
                                
                            }
                            else
                            {
                                string k=m+'1';
                                string l=m+'0';
                                Store(k,n);
                                Store(l,n);
                                return;
                            }
                                }
                        }

                    
                    }

                    Store(" ", memadressbin);



                }
            }
            
            long sum=0;
            foreach(Mem m in Memory)
            {
                sum=sum+m.Value;
            }
            Console.WriteLine("Total Sum is .. " + sum);

        return 0;
        }
        
    }
}
