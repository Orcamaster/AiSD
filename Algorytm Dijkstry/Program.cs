using System;
using System.Collections.Generic;

public class Program
{
    public static void Dijkstra(List<(int sasiad, int odleglosc)>[] graf, int poczatek)
    {
        int wierzcholki = graf.Length;
        int[] odleglosci = new int[wierzcholki];
        bool[] odwiedzone = new bool[wierzcholki];

        for (int i = 0; i < wierzcholki; i++)
        {
            odleglosci[i] = int.MaxValue;
        }
        odleglosci[poczatek] = 0;

        for (int i = 0; i < wierzcholki - 1; i++)
        {
            int u = MinOdleglosc(odleglosci, odwiedzone);
            if (u == -1) break;
            odwiedzone[u] = true;

            foreach (var (sasiad, waga) in graf[u])
            {
                if (!odwiedzone[sasiad] && odleglosci[u] != int.MaxValue
                    && odleglosci[u] + waga < odleglosci[sasiad])
                {
                    odleglosci[sasiad] = odleglosci[u] + waga;
                }
            }
        }
        Wypisz(odleglosci, poczatek);
    }

    private static int MinOdleglosc(int[] odleglosci, bool[] odwiedzone)
    {
        int minOdleglosc = int.MaxValue;
        int minIndex = -1;

        for (int i = 0; i < odleglosci.Length; i++)
        {
            if (!odwiedzone[i] && odleglosci[i] < minOdleglosc)
            {
                minOdleglosc = odleglosci[i];
                minIndex = i;
            }
        }
        return minIndex;
    }

    private static void Wypisz(int[] odleglosci, int poczatek)
    {
        Console.WriteLine("Wierzchołek - Odległość od " + poczatek);
        for (int i = 0; i < odleglosci.Length; i++)
        {
            Console.WriteLine(i + " : " + odleglosci[i]);
        }
    }

    public static void Main(string[] args)
    {
        var graf = new List<(int sasiad, int odleglosc)>[]
        {
            new List<(int, int)> {(1, 4), (7, 8)},
            new List<(int, int)> {(0, 4), (2, 8), (7, 11)},
            new List<(int, int)> {(1, 8), (3, 7), (5, 4), (8, 2)},
            new List<(int, int)> {(2, 7), (4, 9), (5, 14)},
            new List<(int, int)> {(3, 9), (5, 10)},
            new List<(int, int)> {(2, 4), (3, 14), (4, 10), (6, 2)},
            new List<(int, int)> {(5, 2), (7, 1), (8, 6)},
            new List<(int, int)> {(0, 8), (1, 11), (6, 1), (8, 7)},
            new List<(int, int)> {(2, 2), (6, 6), (7, 7)}
        };

        int poczatek = 0;
        Dijkstra(graf, poczatek);
    }
}
