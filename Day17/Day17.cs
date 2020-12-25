using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D17
    {
public class Plan
{ 
    public int Xcor { get; set; }
    public int Ycor { get; set; }
    public int Zcor { get; set; }
    public int Wcor { get; set; }
    public char State { get; set; }
    public char NextState { get; set; }
}
        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string[] text = File.ReadAllLines(@"/home/murat/Documents/aoc2020/Day17/input17.txt");
            return text;
            }

            string[] input = Initialize();


            List<Plan> coordinates = new List<Plan>();

            // UNTIL HERE; COORDINATES ADD; CHECK EACH NEIGHBOUR; IF NO ADD COORD, FOR THE EDGES AT LEAST? OR INCREASE GRID NECESSARY TIMEs;
            int row=8;
            int row_s=0;
            int col=8;
            int col_s=0;
            int dep=0;
            int dep_s=0;
            int wor=0;
            int wor_s=0;
            int y=0;
            int x=0;
            foreach(string w in input)
            {   

                foreach(char a in w)
                {
                coordinates.Add(new Plan(){Xcor=x, Ycor=y, Zcor=0, Wcor=0, State=a});
                x++;
                }
                x=0;
                y++;
            }
            
            void Expand()
            {
                row++;
                row_s--;
                col++;
                col_s--;
                dep++;
                dep_s--;
                wor++;
                wor_s--;

                int j=row_s;
                int k=col_s;
                int l=dep_s;
                int m=wor_s;

                while(j<row)
                {
                    while(k<col)
                    {
                        while(l<=dep)
                        {
                            while(m<=wor)
                            {
                            int x=coordinates.FindIndex(x=> x.Xcor==k && x.Ycor==j && x.Zcor==l && x.Wcor==m);
                            if(x==-1)
                            {
                                coordinates.Add(new Plan(){Xcor=k, Ycor=j, Zcor=l, Wcor=m, State='.'});
                            }
                                
                                m++;
                            }
                            m=wor_s;
                            l++;
                        }
                        l=dep_s;
                        k++;
                    }
                    k=col_s;
                    j++;
                }
                
            }
            void CheckN()
            {
                foreach (Plan c in coordinates)
                {
                    int activen=0;
                    foreach (Plan n in coordinates)
                    {
                            if(n.State=='.')
                            {
                                continue;
                            }
                        int difx=c.Xcor-n.Xcor;
                        if(Math.Abs(difx)>1)
                        {
                            continue;
                        }
                        int dify=c.Ycor-n.Ycor;
                        if(Math.Abs(dify)>1)
                        {
                            continue;
                        }
                        int difz=c.Zcor-n.Zcor;
                        if(Math.Abs(difz)>1)
                        {
                            continue;
                        }
                        int difw=c.Wcor-n.Wcor;
                        if(Math.Abs(difw)>1)
                        {
                            continue;
                        }

                        if(difx== 0 && dify== 0 && difz==0 && difw==0)
                        {
                            continue;
                        }
                        activen++;

                    }
                    if (c.State=='.' && activen==3)
                    {
                        c.NextState='#';
                    }
                    else if(c.State=='#' && (activen==2 || activen==3))
                    {
                        c.NextState='#';
                    }
                    else
                    {
                        c.NextState='.';
                    }

                }
            }

            void Update()
            {
                foreach(Plan u in coordinates)
                {
                        u.State=u.NextState;
                }
            }

            void Cycle()
            {
            Expand();
            CheckN();
            Update();
            }
            Cycle();
            Cycle();
            Cycle();
            Cycle();
            Cycle();
            Cycle();

            int activecubes=0;
            foreach(Plan a in coordinates)
            {
                if(a.State=='#')
                {
                    activecubes++;
                }
            }
        return 0;
        }
        
    }
}
