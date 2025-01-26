using System;

public class Program
{
    public static void Main(string[] args)
    {
        BST tree = new BST();

        tree.Add(5);
        tree.Add(3);
        tree.Add(7);
        tree.Add(2);
        tree.Add(4);
        tree.Add(6);

        tree.InOrder();
        tree.PreOrder();
        tree.PostOrder();

        tree.Remove(2);
        tree.InOrder();
    }
}

public class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BST
{
    private Node Root;

    public void Add(int value)
    {
        Root = Add2(Root, value);
    }

    private Node Add2(Node node, int value)
    {
        if (node == null)
        {
            return new Node(value);
        }
        if (value < node.Value)
        {
            node.Left = Add2(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = Add2(node.Right, value);
        }
        return node;
    }

    public void Remove(int value)
    {
        Root = Remove2(Root, value);
    }

    private Node Remove2(Node node, int value)
    {
        if (node == null)
        {
            return null;
        }
        if (value < node.Value)
        {
            node.Left = Remove2(node.Left, value);
        }
        else if (value > node.Value)
        {
            node.Right = Remove2(node.Right, value);
        }
        else
        {
            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;
            node.Value = Minimum(node.Right);
            node.Right = Remove2(node.Right, node.Value);
        }
        return node;
    }

    private int Minimum(Node node)
    {
        int minValue = node.Value;
        while (node.Left != null)
        {
            node = node.Left;
            minValue = node.Value;
        }
        return minValue;
    }

    public void InOrder()
    {
        InOrderT(Root);
        Console.WriteLine();
    }

    private void InOrderT(Node node)
    {
        if (node != null)
        {
            InOrderT(node.Left);
            Console.Write(node.Value + " ");
            InOrderT(node.Right);
        }
    }

    public void PreOrder()
    {
        PreOrderT(Root);
        Console.WriteLine();
    }

    private void PreOrderT(Node node)
    {
        if (node != null)
        {
            Console.Write(node.Value + " ");
            PreOrderT(node.Left);
            PreOrderT(node.Right);
        }
    }

    public void PostOrder()
    {
        PostOrderT(Root);
        Console.WriteLine();
    }

    private void PostOrderT(Node node)
    {
        if (node != null)
        {
            PostOrderT(node.Left);
            PostOrderT(node.Right);
            Console.Write(node.Value + " ");
        }
    }
}
