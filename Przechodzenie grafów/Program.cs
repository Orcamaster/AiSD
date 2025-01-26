using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>
        {
            {0, new List<int>{1, 2}},
            {1, new List<int>{0, 3, 4}},
            {2, new List<int>{0, 5}},
            {3, new List<int>{1}},
            {4, new List<int>{1, 5}},
            {5, new List<int>{2, 4}}
        };

        Console.WriteLine("DFS:");
        DFS(graph, 0);

        Console.WriteLine("\n\nBFS");
        BFS(graph, 0);
    }

    public static void DFS(Dictionary<int, List<int>> graph, int start)
    {
        HashSet<int> visited = new HashSet<int>();
        Wzdluz(graph, start, visited);
    }

    private static void Wzdluz(Dictionary<int, List<int>> graph, int node, HashSet<int> visited)
    {
        visited.Add(node);
        Console.Write(node + " ");

        foreach (int neighbor in graph[node])
        {
            if (!visited.Contains(neighbor))
            {
                Wzdluz(graph, neighbor, visited);
            }
        }
    }

    public static void BFS(Dictionary<int, List<int>> graph, int start)
    {
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            Console.Write(node + " ");

            foreach (int neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}
