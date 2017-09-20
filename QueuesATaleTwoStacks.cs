using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        MyQueue<int> queue = new MyQueue<int>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] line = Console.ReadLine().Split(' ');
            int operation = int.Parse(line[0]);

            if (operation == 1)
            { // enqueue
                queue.Enqueue(int.Parse(line[1]));
            }
            else if (operation == 2)
            { // dequeue
                queue.Dequeue();
            }
            else if (operation == 3)
            { // print/peek
                Console.WriteLine(queue.Peek());
            }
        }
    }
    public class MyQueue<T>
    {
        Stack<T> stackNewestOnTop = new Stack<T>();
        Stack<T> stackOldestOnTop = new Stack<T>();

        public void Enqueue(T value)
        { // Push onto newest stack
            stackNewestOnTop.Push(value);
        }

        public T Peek()
        {
            if (stackOldestOnTop.Count < 0)
            {
                while (!(stackNewestOnTop.Count < 0))
                {
                    stackOldestOnTop.Push(stackNewestOnTop.Pop());
                }
            }
            return stackOldestOnTop.Peek();
        }

        public T Dequeue()
        {
            if (stackOldestOnTop.Count < 0)
            {
                while (!(stackNewestOnTop.Count < 0))
                {
                    stackOldestOnTop.Push(stackNewestOnTop.Pop());
                }
            }
            return stackOldestOnTop.Pop();

        }
        public void PrepareOldStack()
        {
            if (stackNewestOnTop.Count > 0)
            {
                while (stackNewestOnTop.Count > 0)
                    stackOldestOnTop.Push(stackNewestOnTop.Pop());
            }
        }

    }
}