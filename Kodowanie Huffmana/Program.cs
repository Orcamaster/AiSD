using System;
using System.Collections.Generic;

public class Program
{
    public class Node
    {
        public char Character;
        public int Frequency;
        public Node Left;
        public Node Right;
    }

    public static void Main(string[] args)
    {
        string text = "ala ma kota a kot ma ale";

        Dictionary<char, int> frequencies = new Dictionary<char, int>();
        foreach (char c in text)
        {
            if (!frequencies.ContainsKey(c))
                frequencies[c] = 0;
            frequencies[c]++;
        }

        List<Node> nodes = new List<Node>();
        foreach (var f in frequencies)
        {
            nodes.Add(new Node { Character = f.Key, Frequency = f.Value });
        }

        while (nodes.Count > 1)
        {
            nodes.Sort((a, b) => a.Frequency - b.Frequency);

            Node left = nodes[0];
            Node right = nodes[1];

            Node parent = new Node
            {
                Character = '\0',
                Frequency = left.Frequency + right.Frequency,
                Left = left,
                Right = right
            };

            nodes.Remove(left);
            nodes.Remove(right);
            nodes.Add(parent);
        }

        Node root = nodes[0];

        Dictionary<char, string> huffman = new Dictionary<char, string>();
        GenerateCodes(root, "", huffman);

        foreach (var kvp in huffman)
        {
            Console.WriteLine($"'{kvp.Key}': {kvp.Value}");
        }

        string code = "";
        foreach (char c in text)
        {
            code += huffman[c];
        }

        Console.WriteLine($"\nKod: {code}");
    }

    public static void GenerateCodes(Node node, string code, Dictionary<char, string> huffman)
    {
        if (node == null)
            return;

        if (node.Left == null && node.Right == null)
        {
            huffman[node.Character] = code;
        }

        GenerateCodes(node.Left, code + "0", huffman);
        GenerateCodes(node.Right, code + "1", huffman);
    }
}
