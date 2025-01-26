using System;
using System.Collections.Generic;

public class Edge
{
    public int start;
    public int koniec;
    public int waga;
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Edge> krawedzie = new List<Edge>
        {
            new Edge {start = 0, koniec = 1, waga = 4},
            new Edge {start = 0, koniec = 2, waga = 4},
            new Edge {start = 1, koniec = 2, waga = 2},
            new Edge {start = 1, koniec = 3, waga = 5},
            new Edge {start = 2, koniec = 3, waga = 8},
            new Edge {start = 2, koniec = 4, waga = 10},
            new Edge {start = 3, koniec = 4, waga = 2}
        };

        int wierzcholki = 5;
        List<Edge> drzewo = Kruskal(krawedzie, wierzcholki);

        foreach (var krawedz in drzewo)
        {
            Console.WriteLine($"{krawedz.start}-{krawedz.koniec} : {krawedz.waga}");
        }
    }

    public static List<Edge> Kruskal(List<Edge> krawedzie, int wierzcholki)
    {
        krawedzie.Sort((a, b) => a.waga.CompareTo(b.waga));


        int[] rodzic = new int[wierzcholki];
        for (int i = 0; i < wierzcholki; i++)
        {
            rodzic[i] = i;
        }

        int Find(int v)
        {
            if (rodzic[v] != v)
            {
                rodzic[v] = Find(rodzic[v]);
            }
            return rodzic[v];
        }

        void Union(int v1, int v2)
        {
            int r1 = Find(v1);
            int r2 = Find(v2);
            if (r1 != r2)
            {
                rodzic[r2] = r1;
            }
        }

        List<Edge> drzewo = new List<Edge>();
        foreach (var krawedz in krawedzie)
        {
            int r1 = Find(krawedz.start);
            int r2 = Find(krawedz.koniec);

            if (r1 != r2)
            {
                drzewo.Add(krawedz);
                Union(krawedz.start, krawedz.koniec);
            }
        }

        return drzewo;
    }
}
