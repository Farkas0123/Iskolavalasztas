using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_11F_Iskolavalasztas
{
    class Program
    {
        static int[] a_kiválasztottak;

        static bool Van_negatív_elem(int[] kapacitások)
        {
            int i = 0;
            while (i < kapacitások.Length && 0 <= kapacitások[i])
                i++;
            return i < kapacitások.Length;
        }

        static bool Bekerult(int i, int j, List<int[]> t, int[] kapacitasok)
        {
            bool dontes = false;
            kapacitasok[t[i][j]]--;
            if (0 <= kapacitasok[t[i][j]])
            {
                dontes = true;
            }
            else
            {
                kapacitasok[t[i][j]]++;
            }

            return dontes;
        }

        //minden oszlop egy tanuló, iskolák a sorok, kapacitásokra figyelj, rossz ha betelik és még rakna
        static (bool, int) Oszlopban_keres(int i, List<int[]> t, int[] kapacitasok)
        {
            
            for (int j = 0; j < 2; j++)
            {
                if (Bekerult(i, j, t, kapacitasok))
                {
                    return (j < t[i][j], j);
                }
            }
            return (false, 0);
        }

        static bool Keres(List<int[]> tanulók, int[] kapacitások, int eleje)
        {
            //Jobbra-balra keresés
            int i = 0;
            while (0 <= i && i < tanulók.Count())
            {
                (bool van, int j) = Oszlopban_keres(i, tanulók, kapacitások);
                if (van)
                {
                    a_kiválasztottak[i++] = tanulók[i][j];
                }
                else
                {
                    i--;
                    kapacitások[i]++;
                }

            }
            return true;
            /*for (int i = 0; i < tanulók[eleje].Length; i++)
            {
                a_kiválasztottak[eleje] = tanulók[eleje][i];

                if (0 < kapacitások[tanulók[eleje][i]])
                {
                    kapacitások[tanulók[eleje][i]]--;

                    bool result = Keres(tanulók, kapacitások, eleje + 1);
                    if (result)
                    {
                        return true;
                    }
                    else
                    {
                        kapacitások[tanulók[eleje][i]]++;
                        a_kiválasztottak[eleje] = 0;
                    }
                }
            }
            return false;*/
        }


        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            // int[] tömb = input.Split(' ').Select(int.Parse).ToArray();

            string[] t2 = input.Split(' ');

            int N = int.Parse(t2[0]);
            int M = int.Parse(t2[1]);

            List<int[]> tanulók = new List<int[]>();
            for (int i = 0; i < N; i++)
            {
                input = Console.ReadLine();
                string[] sortömb = input.Split(' ');
                int[] akt_jelentkezo = new int[2] { int.Parse(sortömb[0]), int.Parse(sortömb[1]) };
                tanulók.Add(akt_jelentkezo);
            }

            a_kiválasztottak = new int[N];
            int[] kapacitások = new int[M + 1];
            for (int i = 1; i <= M; i++)
            {
                kapacitások[i] = int.Parse(Console.ReadLine());
            }

            //Beolvasás vége

            bool van_e = Keres(tanulók, kapacitások, 0);

            // Kiírás
            if (van_e)
            {
                Console.WriteLine(string.Join(" ", a_kiválasztottak));
            }
            else
            {
                Console.WriteLine(-1);
            }



        }


    }
}