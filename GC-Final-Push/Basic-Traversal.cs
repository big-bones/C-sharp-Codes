using System;
using System.Collections.Generic;


class Program
{
    public static Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

    public static void Dfs(int node,int parent)
    {
        Console.WriteLine(node);
        foreach(var x in adj[node])
        {
            if(x == parent)
            {
                continue;
            }
            Dfs(x,node);
        }
    }

    public static void Bfs(int node)
    {
        Queue<int> queue = new Queue<int>();
        HashSet<int> visited = new HashSet<int> ();
        queue.Enqueue(node);
        while (queue.Count > 0)
        {
            int first = queue.Peek();
            visited.Add(first);
            Console.WriteLine(first);
            foreach (var x in adj[first])
            {
                if (visited.Contains(x))
                {
                    continue;
                }
                queue.Enqueue(x);  
            }
            queue.Dequeue();    
        }
    }
    
    public static void Main()
    {
        int n,m;
        n = int.Parse(Console.ReadLine());
        m = int.Parse(Console.ReadLine());  
        for(int i = 1; i <= m; i++)
        {
            int a, b;
            string input = Console.ReadLine();
            string[] arr = input.Split(" ");
            a = int.Parse(arr[0]);
            b = int.Parse(arr[1]);
            if (adj.ContainsKey(a) )
            {
                adj[a].Add(b);
            }
            else
            {
                adj[a] = new List<int>();
                adj[a].Add(b);
            }
            if (adj.ContainsKey(b))
            {
                adj[b].Add(a);
            }
            else
            {
                adj[b] = new List<int>();
                adj[b].Add(a);
            }
        }

        Dfs(1,-1);
        Bfs(1);
    }
}