using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace aoc2020
{
    public class D4
    {
        public int ReturnResult()
        {
            string[] Initialize()
            {
                
            string text = File.ReadAllText(@"/home/murat/Documents/aoc2020/Day4/input4.txt");
            string[] words = text.Split("\n\n");
            return words;
            }
            string[] input = Initialize();
            
            bool CheckValid(string w)
            {
                if (w.Contains("byr") && w.Contains("iyr") && w.Contains("eyr") && w.Contains("hgt") && w.Contains("hcl") && w.Contains("ecl") && w.Contains("pid"))
                {
                    
                    int[] CheckIndex(string code)
                    {
                    int[] indexes = {0,0};
                    int sti=w.IndexOf(code);
                    int fni=0;
                    int i=0;
                    bool run=true;

                    while(run==true)
                    {
                        if((sti+4+i)>=w.Length || w[sti+4+i]==' ' || w[sti+4+i]== 10)
                        {
                            fni=sti+4+i;
                            run=false;
                        }
                        i++;
                    }
                    indexes[0]=sti;
                    indexes[1]=fni;
                    return indexes;
                    }
                    
                    string CheckValue(int i1, int i2)
                    {
                        string value = w.Substring(i1+4, i2-i1-4);

                    return value;
                    }

                    bool CheckBYR()
                    {
                    int[] indexbyr= CheckIndex("byr");
                    if(indexbyr[1]-indexbyr[0]-4!=4)
                    {
                        return false;
                    }
                    else
                    {
                    int byr=Convert.ToInt32(CheckValue(indexbyr[0], indexbyr[1]));

                    if(byr<1920 || byr>2002)
                    {
                        return false;
                    }
                    }
                        return true;
                    }

                    bool CheckIYR()
                    {
                    int[] indexiyr= CheckIndex("iyr");
                    if(indexiyr[1]-indexiyr[0]-4!=4)
                    {
                        return false;
                    }
                    else
                    {
                    int iyr=Convert.ToInt32(CheckValue(indexiyr[0], indexiyr[1]));
                    if(iyr<2010 || iyr>2020)
                    {
                        return false;
                    }
                    }
                    return true;
                    }                

                    bool CheckEYR()
                    {
                    int[] indexeyr= CheckIndex("eyr");
                    if(indexeyr[1]-indexeyr[0]-4!=4)
                    {
                        return false;
                    }
                    else
                    {
                    int eyr=Convert.ToInt32(CheckValue(indexeyr[0], indexeyr[1]));
                    if(eyr<2020 || eyr>2030)
                    {
                        return false;
                    }
                    }
                    return true;
                    }
                    
                    bool CheckHGT()
                    {
                   int[] indexhgt= CheckIndex("hgt");
                    string hgt=CheckValue(indexhgt[0], indexhgt[1]);
                    if(hgt[(hgt.Length-2)]=='c' && hgt[(hgt.Length-1)]=='m')
                    {
                        if(hgt.Length!=5)
                        {
                            return false;
                        }
                        int h=Convert.ToInt32(hgt.Substring(0,3));
                        if(h>193 || h<150)
                        {
                            return false;
                        }
                    }
                    else if(hgt[(hgt.Length-2)]=='i' && hgt[(hgt.Length-1)]=='n')
                    {
                        if(hgt.Length!=4)
                        {
                            return false;
                        }
                        int h=Convert.ToInt32(hgt.Substring(0,2));
                        if(h>76 || h<59)
                        {
                            return false;
                        }
                    }
                    else
                    {
                            return false;
                    }
                    return true;
                    }
                   
                    bool CheckHCL()
                    {
                    int[] indexhcl= CheckIndex("hcl");
                    if(indexhcl[1]-indexhcl[0]-4!=7)
                    {
                        return false;
                    }
                    else
                    {
                    string hcl=CheckValue(indexhcl[0], indexhcl[1]);
                    if(hcl[0]!='#')
                    {
                        return false;
                    }
                    string colorrange="0123456789abcdef";
                    char[] toc=colorrange.ToCharArray();
                    if(hcl.Substring(1,6).IndexOfAny(toc)==-1)
                    {
                        return false;
                    }
                    }
                    return true;
                    }

                    bool CheckECL()
                    {
                    int[] indexecl= CheckIndex("ecl");
                    if(indexecl[1]-indexecl[0]-4!=3)
                    {
                        return false;
                    }
                    else
                    {
                    string ecl=CheckValue(indexecl[0], indexecl[1]);
                    if(ecl=="amb" ||ecl=="blu" || ecl=="brn" || ecl=="gry" || ecl=="grn" || ecl=="hzl" || ecl=="oth")
                    {
                        return true;
                    }
                    }
                    return false;
                    }
                   
                    bool CheckPID()
                    {
                    int[] indexpid= CheckIndex("pid");
                    if(indexpid[1]-indexpid[0]-4!=9)
                    {
                        return false;
                    }

                    return true;
                    }
                    

                    if (CheckBYR()==false)
                    {
                        return false;
                    }
                    if (CheckPID()==false)
                    {
                        return false;
                    }
                    if (CheckECL()==false)
                    {
                        return false;
                    }
                    if (CheckHGT()==false)
                    {
                        return false;
                    }                    
                    if (CheckIYR()==false)
                    {
                        return false;
                    }
                    if (CheckEYR()==false)
                    {
                        return false;
                    }
                    if (CheckHCL()==false)
                    {
                        return false;
                    }

                    return true;
                }
                else 
                {
                    return false;
                }
            }
            int totalvp=0;
            foreach(string s in input)
            {
            if(CheckValid(s)==true)
            {
                totalvp++;
            }
            }
            Console.WriteLine("Total valid passport number is .. " + totalvp);
            return 0;
        }
    }
}
