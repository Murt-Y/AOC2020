using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D23
    {

        public int ReturnResult()
        {
            List<int> cups=new List<int>();
            int[] index=new int[1000001];
            int[] cupsinput ={5,8,3,9,7,6,2,4,1};
            int z=0;
            
            int total=1000000;
            while(z<cupsinput.Length)
            {
                cups.Add(cupsinput[z]);
                index[cups[z]]=z;
                z++;
            }
            
            while(z<total)
            {
                cups.Add(z+1);
                index[z+1]=z;
                z++;
            }
            
            int[] pick=new int[3];


            void Pick(int c)
            {
                pick[0]=cups[(c+1)%total];
                pick[1]=cups[(c+2)%total];
                pick[2]=cups[(c+3)%total];
            }
            int counter=0;
            void Round()
            {
                int currentcup=cups[counter];
                Pick(counter);
                int dest=cups[counter%total]-1;
                bool destcheck=false;
                while(destcheck==false)
                {
                if(pick.Contains(dest))
                {
                    dest=dest-1;
                }
                else if(dest<=0)
                {
                    dest=total;
                }
                else
                {
                    destcheck=true;
                }
                }
                int j=0;
                int desti=index[dest];

                if(desti>counter)
                {
                    j=counter+4;
                    while(j<desti+1)
                    { 
                    index[cups[j]]-=3;
                    j++;
                    }
                }
                if(desti<counter)
                {
                    j=desti+1;
                    while(j<counter+1)
                    { 
                    index[cups[j]]+=3;
                    j++;
                    }
                }


                if(counter+1<cups.Count)
                {
                cups.RemoveAt((counter+1)%cups.Count);
                    if(counter+1<cups.Count)
                    {
                        cups.RemoveAt((counter+1)%cups.Count);
                                    if(counter+1<cups.Count)
                    {
                                        cups.RemoveAt((counter+1)%cups.Count);
                    }
                    else
                    {
                    cups.RemoveAt(0);
                    int m=0;
                    while(m<total+1)
                    {
                        index[m]-=1;
                        m++;
                    }
                    }
                    }
                    else
                    {
                    cups.RemoveAt(0);
                    cups.RemoveAt(0);
                    int m=0;
                    while(m<total+1)
                    {
                        index[m]-=2;
                        m++;
                    }   
                    }
                }
                else
                {
                    cups.RemoveAt(0);
                    cups.RemoveAt(0);
                    cups.RemoveAt(0);
                    int m=0;
                    while(m<total+1)
                    {
                        index[m]-=3;
                        m++;
                    }
                }
                desti=index[dest];
                cups.Insert(desti+1, pick[2]);
                cups.Insert(desti+1, pick[1]);
                cups.Insert(desti+1, pick[0]);
                index[pick[2]]=desti+3;
                index[pick[1]]=desti+2;
                index[pick[0]]=desti+1;

                counter=(index[currentcup]+1)%total;
            }
            int run=10000000;
            int k=0;
            while(k<run)
            {
            Round();
            k++;
            }
            int indexone=0;
            int i=0;
            foreach (int t in cups)
                {
                    if(t==1)
                    {
                        indexone=i;
                        break;
                    }
                    i++;
                }

            Console.WriteLine(cups[(indexone+1)%total]);
            Console.WriteLine(cups[(indexone+2)%total]);
        return 0;
        }
        
    }
}
