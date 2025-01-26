using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD2
{
    internal class List
    {
        public Node head;
        public Node tail;
        public int count;

        public Node AddFirst(int data)
        {
            Node newNode = new Node();
            newNode.data = data;

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }

            count++;
            return head;
        }

        public Node AddLast (int data)
        {
            Node newNode = new Node();
            newNode.data = data;

            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
            }

            count++;
            return tail;
        }

        public Node RemoveFirst (int data)
        {
            if (head == null)
            {
                return null;
            }

            Node temp = head;

            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.next;
                head.prev = null;
            }

            count--;
            return temp;
        }

        public Node RemoveLast (int data)
        {
            if (tail == null)
            {
                return null;
            }

            Node temp = tail;

            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
            }

            count--;
            return temp;
        }

        public Node Get(int n)
        {
            if (n < 0 || n >= count)
            {
                return null;
            }

            Node current = head;
            int index = 0;

            while (current != null)
            {
                if (index == n)
                {
                    return current;
                }
                current = current.next;
                index++;
            }

            return null;
        }

        public void Display()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}
