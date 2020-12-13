using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D12
    {

        public int ReturnResult()
        {
            int xcor=0;
            int ycor=0;
            int wxcor=10;
            int wycor=1;

            string[] Initialize()
            {
                
            string[] text = File.ReadAllLines(@"C:\Users\yilma\Documents\AOC2020\Day12/input12.txt");
            return text;
            }


            string[] input = Initialize();


            void TurnL()
        {   
                int m=wxcor;
                int n=wycor;
                wycor=m;
                wxcor=n*-1;
        }
            void TurnR()
        {   
                int m=wxcor;
                int n=wycor;
                wycor=m*-1;
                wxcor=n;
        }
            void MoveW(char d, int x)
            {
                if(d=='N')
                {
                    wycor=wycor+x;
                }
                if(d=='S')
                {
                    wycor=wycor-x;
                }
                if(d=='E')
                {
                    wxcor=wxcor+x;
                }
                if(d=='W')
                {
                    wxcor=wxcor-x;
                }
            }
            void Move(int x)
            {
                xcor=xcor+wxcor*x;
                ycor=ycor+wycor*x;
            }
            
            void Action(char co, int no)
            {
                if (co=='L')
                {

                    while(no>0)
                    {
                        TurnL();
                        no=no-90;
                    }
                    return;
                }
                else if (co=='R')
                {

                    while(no>0)
                    {
                        TurnR();
                        no=no-90;
                    }
                    return;
                }
                else if (co=='F')
                {
                    Move(no);
                }
                else if (co=='B')
                {
                    Move((-1*no));
                }
                else if (co=='N')
                {
                    MoveW('N', no);
                }
                else if (co=='S')
                {
                    MoveW('S', no);
                }
                else if (co=='E')
                {
                    MoveW('E', no);
                }
                else if (co=='W')
                {
                    MoveW('W', no);
                }
            
            
            
            }
            
            foreach (string w in input)
            {
                char code=w[0];
                int mag=Convert.ToInt32(w.Substring(1));
                Action(code, mag);
            }
        Console.WriteLine("The Manhattan Code is ... " + (Math.Abs(xcor)+Math.Abs(ycor)));
        return 0;
        }
        
    }
}
