using System;
using System.IO;

namespace anagram
{
    class Program
    {
        static string abc(string szo)
        {
            string abc = "";
            char[] betuk = szo.ToCharArray();
            Array.Sort(betuk);
            abc = new string(betuk);
            return abc;
        }

        static void Main()
        {
            #region 1. feladat
            Console.Write("1. feladat: Írja be a szöveget: ");
            string szoveg = Console.ReadLine();
            szoveg = szoveg.ToLower();
            int kdb = 0;
            char[] karakterek = new char[25];
            for (char i = 'a'; i <= 'z'; i++)
            {
                bool van = false;
                for (int i1 = 0; i1 < szoveg.Length; i1++)
                {
                    if(szoveg[i1] == i)
                    {
                        van = true;
                    }
                }
                if (van) 
                {
                    karakterek[kdb] = i;
                    kdb++; 
                }
            }
            Console.Write(kdb + " db\t");
            for (int i = 0; i < kdb; i++)
            {
                Console.Write("  {0}",karakterek[i]);
            }
            Console.WriteLine();
            #endregion

            #region 2. feladat
            FileStream fs = new FileStream("szotar.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int db = 0;
            while(!sr.EndOfStream)
            {
                sr.ReadLine();
                db++;
            }
            sr.Close();
            fs.Close();
            fs = new FileStream("szotar.txt", FileMode.Open);
            sr = new StreamReader(fs);
            string[] szavak = new string[db];
            for (int i = 0; i < db; i++)
            {
                szavak[i] = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
            #endregion

            #region 3. feladat
            FileStream fs1 = new FileStream("abc.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs1);
            for (int i = 0; i < db; i++)
            {
                if (i < db - 1)     { sw.WriteLine(abc(szavak[i]));}
                else                { sw.Write(abc(szavak[i])); }
            }
            sw.Close();
            fs1.Close();
            #endregion

            #region 4. feladat
            Console.Write("4. feladat: Írja be az első szót: ");
            string szo1 = Console.ReadLine();
            Console.Write("Írja be a második szót: ");
            string szo2 = Console.ReadLine();
            if (abc(szo1) == abc(szo2)) { Console.WriteLine("Anagramma."); }
            else                        { Console.WriteLine("Nem anagramma."); }
            #endregion 

            #region 5. feladat
            Console.Write("5. feladat: Írjon be egy szót: ");
            string szo = Console.ReadLine();
            int andb = 0;
            for (int i = 0; i < db; i++)
            {
                if(abc(abc(szavak[i])) == abc(szo))
                {
                    andb++;
                    if (andb == 1) { Console.WriteLine("A szó anagrammái:"); }
                    if (szo != szavak[i])
                    {
                        Console.WriteLine(szavak[i]);
                    }
                }
            }
            if (andb == 0) { Console.WriteLine("A szótárban nincs anagramma."); }
            #endregion

            #region 6. feladat
            int maxhossz = 0;
            for (int i = 0; i < db; i++)
            {
                if(szavak[i].Length > maxhossz)
                {
                    maxhossz =  szavak[i].Length;
                }
            }
            for (int i = 0; i < db; i++)
			{
                if(szavak[i].Length == maxhossz)
                    {
			        int i1 = 0;
                    while (i1 < i && abc(szavak[i1]) != abc(szavak[i]))
                    {
                        i1++;
                    }
                    if(i1 == i) 
                    {
                        Console.WriteLine(szavak[i]);
                    }
                    for (int i2 = i+1; i2 < db; i2++)
                    {
                        if(abc(szavak[i]) == abc(szavak[i2]))
                        {
                            Console.WriteLine(szavak[i2]);
                        }
                    }
                }
			}
            #endregion

            Console.ReadKey();
        }
    }
}
