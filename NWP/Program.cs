using System;

public class Program
{
    public static void Main(string[] args)
    {
        string s2 = " abaabbaaa";
        string s1 = " babab";
        int[,] tab = new int[s1.Length, s2.Length];

        for (int i = 0; i < s1.Length; i++)
        {
            for (int j = 0; j < s2.Length; j++)
            {
                if (i == 0 || j == 0)
                {
                    tab[i, j] = 0;
                }
            }
        }

        for (int i = 1; i < s1.Length; i++)
        {
            for (int j = 1; j < s2.Length; j++)
            {
                if (s1[i] == s2[j])
                {
                    tab[i, j] = tab[i - 1, j - 1] + 1;
                }
                else
                {
                    tab[i, j] = Math.Max(tab[i, j - 1], tab[i - 1, j]);
                }
            }
        }

        string tablica = "";
        for (int i = 0; i < s1.Length; i++)
        {
            for (int j = 0; j < s2.Length; j++)
            {
                tablica += tab[i, j] + " ";
            }
            tablica += "\n";
        }

        Console.WriteLine("Tablica:");
        Console.WriteLine(tablica);

        int x = s1.Length - 1;
        int y = s2.Length - 1;
        string nwp = "";

        while (x > 0 && y > 0)
        {
            if (s1[x] == s2[y])
            {
                nwp = s1[x] + nwp;
                x--;
                y--;
            }
            else if (tab[x - 1, y] > tab[x, y - 1])
            {
                x--;
            }
            else
            {
                y--;
            }
        }
        Console.WriteLine("NWP: " + nwp);
    }
}
