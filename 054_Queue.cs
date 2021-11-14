using System;
using System.Collections.Generic;

namespace _054_HW_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue instructQueue = new Queue();
            Queue dataQueue = new Queue();
            Queue cpuInstruct = new Queue();
            Queue cpuData = new Queue();
            
            char instruct = '0';
            char data;

            while(instruct != '?')
            {
                Console.Write("Instruct: ");
                instruct = char.Parse(Console.ReadLine());
                if(instruct == '?')
                {
                    break;
                }
                Node instructNode = new Node(instruct);
                instructQueue.Push(instructNode);

                Console.Write("Data: ");
                data = char.Parse(Console.ReadLine());
                Node dataNode = new Node(data);
                dataQueue.Push(dataNode);
            }          

            int cpuCounter = 0;
            int instructCounter = 0;
            int dataCounter = 0;

            while (instructQueue != null && dataQueue != null)
            {
                while(instructCounter < 4)
                {

                    cpuInstruct.Push(instructQueue.GetNode(instructCounter));
                    cpuData.Push(dataQueue.GetNode(dataCounter));

                }

                while (cpuInstruct != null)
                {
                    cpuInstruct.Pop();
                }

                while (cpuData != null)
                {
                    cpuData.Pop();
                }

                cpuCounter++;
            }

            Console.Clear();
            Console.WriteLine("CPU cycles needed: {0}", cpuCounter);

        }
    }

    class Node
    {
        public char Value;
        public Node Next;

        public Node(char value)
        {
            this.Value = value;
        }
    }

    class Queue
    {
        private Node Root;

        public void Push(Node node)
        {
            if(Root == null)
            {
                Root = node;
            }
            else
            {
                Node ptr = Root;
                while(ptr.Next != null)
                {
                    ptr = ptr.Next;
                }
                ptr.Next = node;
            }
        }

        public Node Pop()
        {
            if(Root == null)
            {
                return null;
            }
            Node node = Root;
            Root = Root.Next;
            node.Next = null;
            return node;
        }

        public Node GetNode(int index)
        {
            Node ptr = Root;
            while(index > 0)
            {
                if(ptr == null)
                {
                    throw new IndexOutOfRangeException();
                }
                ptr = ptr.Next;
                index--;
            }
            return ptr;
        }
    }
}
