using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D13
    {
public class Bus
{ 
    public long Id { get; set; }
    public long Time { get; set; }
}
        public int ReturnResult()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            string[] Initialize()
            {
                
            string[] text = File.ReadAllLines(@"C:\Users\yilma\Documents\AOC2020\Day13/input13.txt");
            return text;
            }

            string[] input = Initialize();
            string[] bustime =input[1].Split(',');
            
            List<Bus> bust= new List<Bus>();
            int i=0;

            foreach(string w in bustime)
            {
                if(w=="x")
                {
                    i++;
                }
                else
                {
                    bust.Add(new Bus(){Id=Convert.ToInt64(w), Time=i});
                    i++;
            }
            }
                long CheckV(long x, long y, long z, long t)
                {
                    bool check=false;
                    int j=1;
                    while(check==false)
                    {
                        if(((x+y*j)+t)%z==0)
                        {
                            return (x+y*j);
                        }
                        j++;
                    }
                    return 0;
                }
                int p=2;
                long val=CheckV(bust[0].Time, bust[0].Id, bust[1].Id, bust[1].Time);
                long repeat=bust[0].Id*bust[1].Id;
                while(p<bust.Count)
                {
                    val=CheckV(val, repeat, bust[p].Id, bust[p].Time);
                    Console.WriteLine("The answer is " + val);
                    repeat=repeat*bust[p].Id;
                    p++;
                }

                watch.Stop();
                Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        return 0;
        }
        
    }
}
