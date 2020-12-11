using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D11
    {
public class Plan
{ 
    public int No { get; set; }
    public char State { get; set; }
    public char NextState { get; set; }
}
        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string[] text = File.ReadAllLines(@"C:\Users\yilma\Documents\AOC2020\Day11/input11.txt");
            return text;
            }

            string[] input = Initialize();
            int col=input[0].Length;
            int row=input.Length;
            bool change =true;
            int changecount=0;

            List<Plan> seats = new List<Plan>();
            int i=0;
            foreach(string w in input)
            {   
                foreach(char a in w)
                {
                seats.Add(new Plan(){No=i, State=a});
                i++;
                }
            }
            
            void CheckA(int z)
            {


                int rowr=z/col;
                int colr=z%col;
            
            bool CheckUp(int r)
            {
                
                
                int t=r-col;
                int rowt=t/col;
                int colt=t%col;
                if (t<0)
                {
                    return false;
                }
                if(seats[t].State=='.')
                {
                    return CheckUp(t);
                }
                if(seats[t].State=='#')
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            bool CheckRight(int r)
            {
                int t=r+1;
                int rowt=t/col;
                int colt=t%col;
                if (colt<colr)
                {
                    return false;
                }
                if(seats[t].State=='.')
                {
                    return CheckRight(t);
                }
                if(seats[t].State=='#')
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            bool CheckLeft(int r)
            {
                int t=r-1;
                int rowt=t/col;
                int colt=t%col;
                if (t<0 ||colt>colr)
                {
                    return false;
                }
                if(seats[t].State=='.')
                {
                    return CheckLeft(t);
                }
                if(seats[t].State=='#')
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            bool CheckDown(int r)
            {
                int t=r+col;
                if (t>seats.Count-1)
                {
                    return false;
                }
                if(seats[t].State=='.')
                {
                    return CheckDown(t);
                }
                if(seats[t].State=='#')
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            bool CheckUpL(int r)
            {
                int t=r-col-1;
                int rowt=t/col;
                int colt=t%col;
                if (t<0 || colt>colr)
                {
                    return false;
                }
                if(seats[t].State=='.')
                {
                    return CheckUpL(t);
                }
                if(seats[t].State=='#')
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            bool CheckUpR(int r)
            {
                int t=r-col+1;
                int rowt=t/col;
                int colt=t%col;
                if (t<0 || colt<colr)
                {
                    return false;
                }
                if(seats[t].State=='.')
                {
                    return CheckUpR(t);
                }
                if(seats[t].State=='#')
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            bool CheckDownL(int r)
            {
                int t=r+col-1;
                int rowt=t/col;
                int colt=t%col;
                if (t>seats.Count-1 || colt>colr)
                {
                    return false;
                }
                                if(seats[t].State=='.')
                {
                    return CheckDownL(t);
                }
                if(seats[t].State=='#')
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            bool CheckDownR(int r)
            {
                int t=r+col+1;
                int rowt=t/col;
                int colt=t%col;
                if (t>seats.Count-1 || colt<colr)
                {
                    return false;
                }
                                if(seats[t].State=='.')
                {
                    return CheckDownR(t);
                }
                if(seats[t].State=='#')
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }

            int adj=0;

            if(CheckUp(z))
            {
                adj++;
            }
                        if(CheckRight(z))
            {
                adj++;
            }
                        if(CheckLeft(z))
            {
                adj++;
            }
                        if(CheckDown(z))
            {
                adj++;
            }
                        if(CheckUpL(z))
            {
                adj++;
            }
                        if(CheckUpR(z))
            {
                adj++;
            }
                        if(CheckDownL(z))
            {
                adj++;
            }
                        if(CheckDownR(z))
            {
                adj++;
            }

            if(adj>=5)
            {
                seats[z].NextState='L';
            }
            if(adj==0)
            {
                seats[z].NextState='#';
            }

}
void RunIter(){
foreach(Plan s in seats)
{
                if (s.State!='.')
                {
                    CheckA(s.No);
                }
}
foreach(Plan s in seats)
{
                if (s.State!='.')
                {
                    if(s.State!=s.NextState){
                    changecount++;    
                    s.State=s.NextState;
                    }
                }
}
foreach(Plan s in seats)
{
Console.Write(s.State);
if (s.No%col==col-1)
{
    Console.Write("\n");
}
}
if (changecount==0)
{
    change=false;
    int full=0;
    foreach(Plan s in seats)
    {
        if(s.State=='#')
        {
            full++;
        }
    }
    Console.WriteLine("The Number of Occupied Seats is .. " +full);
}
changecount=0;
}

while(change==true)
{
    RunIter();

}
        return 0;
        }
        
    }
}
