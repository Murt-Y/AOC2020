using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020
{
    class D24
    {
public class Hex
{ 
    public int x { get; set; }
    public int y { get; set; }
    public bool black { get; set; }
    public bool create { get; set; }
    public int n1 { get; set; } =-1;
    public int n2 { get; set; }=-1;
    public int n3 { get; set; }=-1;
    public int n4 { get; set; }=-1;
    public int n5 { get; set; }=-1;
    public int n6 { get; set; }=-1;
    public bool change { get; set; }
}
        public int ReturnResult()
        {
            int xcor=0;
            int ycor=0;

            string[] Initialize()
            {   
            string[] text = File.ReadAllLines(@"/home/murat/Documents/aoc2020/Day24/input24.txt");
            return text;
            }

            List<Hex> map= new List<Hex>();

            string[] input = Initialize();

            void Action(string c)
            {
                if(c=="e")
                {
                    xcor+=2;
                }
                else if(c=="w")
                {
                    xcor-=2;
                }
                else if(c=="ne")
                {
                    xcor+=1;
                    ycor+=2;
                }
                else if(c=="nw")
                {
                    xcor-=1;
                    ycor+=2;
                }
                else if(c=="se")
                {
                    xcor+=1;
                    ycor-=2;
                }
                else if(c=="sw")
                {
                    xcor-=1;
                    ycor-=2;
                }
                
            }
            
            void Create(int mapindex, int xcor, int ycor)
            {
                    int n1i=map.FindIndex(h => h.x==xcor+2 && h.y==ycor);

                    if(n1i==-1)
                    {
                        map.Add(new Hex() {x=xcor+2, y=ycor, black=false});
                        map[mapindex].n1=map.Count-1;
                    }
                    else
                    {
                        map[mapindex].n1=n1i;
                    }

                    int n2i=map.FindIndex(h => h.x==xcor-2 && h.y==ycor);
                    if(n2i==-1)
                    {
                        map.Add(new Hex() {x=xcor-2, y=ycor, black=false});
                        map[mapindex].n2=map.Count-1;
                    }
                    else
                    {
                        map[mapindex].n2=n2i;
                    }

                    int n3i=map.FindIndex(h => h.x==xcor+1 && h.y==ycor+2);
                    if(n3i==-1)
                    {
                        map.Add(new Hex() {x=xcor+1, y=ycor+2, black=false});
                        map[mapindex].n3=map.Count-1;
                    }
                    else
                    {
                        map[mapindex].n3=n3i;
                    }

                    int n4i=map.FindIndex(h => h.x==xcor-1 && h.y==ycor+2);
                    if(n4i==-1)
                    {
                        map.Add(new Hex() {x=xcor-1, y=ycor+2, black=false});
                        map[mapindex].n4=map.Count-1;
                    }
                    else
                    {
                        map[mapindex].n4=n4i;
                    }

                    int n5i=map.FindIndex(h => h.x==xcor+1 && h.y==ycor-2);
                    if(n5i==-1)
                    {
                        map.Add(new Hex() {x=xcor+1, y=ycor-2, black=false});
                        map[mapindex].n5=map.Count-1;
                    }
                    else
                    {
                        map[mapindex].n5=n5i;
                    }

                    int n6i=map.FindIndex(h => h.x==xcor-1 && h.y==ycor-2);
                    if(n6i==-1)
                    {
                        map.Add(new Hex() {x=xcor-1, y=ycor-2, black=false});
                        map[mapindex].n6=map.Count-1;
                    }
                    else
                    {
                        map[mapindex].n6=n6i;
                    }
            }
            
            
            
            foreach (string w in input)
            {
                int i=0;
                xcor=0;
                ycor=0;
                while(i<w.Length)
                {
                string code=string.Empty;
                code=code+w[i];
                if(code=="s" || code=="n")
                {
                code=code+w[i+1];
                i=i+2;
                }

                else
                {
                    i=i+1;
                }
                Action(code);
                }
                int mapindex=map.FindIndex(h => h.x==xcor && h.y==ycor);
                if(mapindex==-1)
                {
                    map.Add(new Hex() {x=xcor, y=ycor, black=true, n1=-1, n2=-1, n3=-1, n4=-1, n5=-1, n6=-1, create=true});
                    mapindex=map.Count-1;
                    Create(mapindex, xcor, ycor);

                }
                else
                {   
                    if(map[mapindex].create==false)
                    {
                        Create(mapindex, xcor, ycor);
                        map[mapindex].create=true;
                    }
                    if(map[mapindex].black==true)
                    {
                        map[mapindex].black=false;
                    }
                    else
                    {
                        map[mapindex].black=true;
                    }
                }
            }
            void BlackCount()
            {
            int blackcount=0;
            foreach(Hex h in map)
            {
                if(h.black==true)
                {
                blackcount++;
                }
            }
            Console.WriteLine("Number of Black Tiles   " + blackcount);
            }
            
            BlackCount();


            void CheckN(int index)
            {
                if(map[index].n1==-1)
                {
                    int x= map.FindIndex(h => h.x==map[index].x+2 && h.y==map[index].y);
                    if(x!=-1)
                    {
                        map[index].n1=x;
                        map[x].n2=index;
                    }
                }
                if(map[index].n2==-1)
                {
                    int x= map.FindIndex(h => h.x==map[index].x-2 && h.y==map[index].y);
                    if(x!=-1)
                    {
                        map[index].n2=x;
                        map[x].n1=index;
                    }
                }
                if(map[index].n3==-1)
                {
                    int x= map.FindIndex(h => h.x==map[index].x+1 && h.y==map[index].y+2);
                    if(x!=-1)
                    {
                        map[index].n3=x;
                        map[x].n6=index;
                    }
                }
                if(map[index].n4==-1)
                {
                    int x= map.FindIndex(h => h.x==map[index].x-1 && h.y==map[index].y+2);
                    if(x!=-1)
                    {
                        map[index].n4=x;
                        map[x].n5=index;
                    }
                }
                if(map[index].n5==-1)
                {
                    int x= map.FindIndex(h => h.x==map[index].x+1 && h.y==map[index].y-2);
                    if(x!=-1)
                    {
                        map[index].n5=x;
                        map[x].n4=index;
                    }
                }
                if(map[index].n6==-1)
                {
                    int x= map.FindIndex(h => h.x==map[index].x-1 && h.y==map[index].y-2);
                    if(x!=-1)
                    {
                        map[index].n6=x;
                        map[x].n3=index;
                    }
                }
            }

            void Change()
            {

                int t=map.Count;
                int z=0;
                while(z<t)
                {
                    if(map[z].change==true)
                    {
                        if(map[z].black==true)
                        {
                            map[z].black=false;
                        }
                        else 
                    {
                    map[z].black=true;
                    Create(z, map[z].x, map[z].y);




                    /*
                    if(map[z].n1==-1)
                    {
                        map.Add(new Hex() {x=xcor+2, y=ycor, black=false});
                        map[z].n1=map.Count-1;
                    }
                    if(map[z].n2==-1)
                    {
                        map.Add(new Hex() {x=xcor-2, y=ycor, black=false});
                        map[z].n2=map.Count-1;
                    }
                    if(map[z].n3==-1)
                    {
                        map.Add(new Hex() {x=xcor+1, y=ycor+2, black=false});
                        map[z].n3=map.Count-1;
                    }
                    if(map[z].n4==-1)
                    {
                        map.Add(new Hex() {x=xcor-1, y=ycor+2, black=false});
                        map[z].n4=map.Count-1;
                    }
                    if(map[z].n5==-1)
                    {
                        map.Add(new Hex() {x=xcor+1, y=ycor-2, black=false});
                        map[z].n5=map.Count-1;
                    }
                    if(map[z].n6==-1)
                    {
                        map.Add(new Hex() {x=xcor-1, y=ycor-2, black=false});
                        map[z].n6=map.Count-1;
                    }
                    */
                        }

                    map[z].change=false;    
                    }
                    z++;
                }
            }
            void Day()
            {
            foreach(Hex h in map)
            {
                if(h.black==false)
                {
                    int bn=0;
                    if(h.n1!=-1 && map[h.n1].black==true)
                    {
                        bn++;
                    }
                                       if(h.n2!=-1 && map[h.n2].black==true)
                    {
                        bn++;
                    }
                                       if(h.n3!=-1 && map[h.n3].black==true)
                    {
                        bn++;
                    }
                                       if(h.n4!=-1 && map[h.n4].black==true)
                    {
                        bn++;
                    }
                                       if(h.n5!=-1 && map[h.n5].black==true)
                    {
                        bn++;
                    }
                                       if(h.n6!=-1 && map[h.n6].black==true)
                    {
                        bn++;
                    }

                    if(bn==2)
                    {
                        h.change=true;
                
                    }


                }

                else
                {
                    int bn=0;
                                        if(map[h.n1].black==true)
                    {
                        bn++;
                    }
                                       if(map[h.n2].black==true)
                    {
                        bn++;
                    }
                                       if(map[h.n3].black==true)
                    {
                        bn++;
                    }
                                       if(map[h.n4].black==true)
                    {
                        bn++;
                    }
                                       if(map[h.n5].black==true)
                    {
                        bn++;
                    }
                                       if(map[h.n6].black==true)
                    {
                        bn++;
                    }

                    if(bn==0 || bn>2)
                    {
                        h.change=true;
                    }
                }
            }
            }

            int lastncheck=0;
            int run=100;
            int k=0;
            while(k<run)
            {
                while(lastncheck<map.Count)
                {
                    CheckN(lastncheck);
                    lastncheck++;
                }
                Day();
                Change();
                BlackCount();
                k++;
            }


        return 0;
        }
        
    }
}
