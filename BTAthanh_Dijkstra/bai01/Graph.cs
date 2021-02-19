using System;

class Graph
{
    public int[,] a;
    public int n { get; private set; }

    public Graph(int n)
    {
        this.n = n;
        a = new int[n, n];
    }

    public int this[int u, int v]
    {
        get { return a[u, v]; }
        set { a[u, v] = value; }
    }

    public void display(string separator)
    {
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
                Console.Write(a[i, j] + separator);

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}