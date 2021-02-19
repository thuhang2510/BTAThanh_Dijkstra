using System.Collections.Generic;
using System.Linq;

class Dijkstra
{
    private Graph g;

    public Dijkstra(Graph g)
    {
        this.g = g;
    }

    private int timKCMin(int[] dist, bool[] visited)
    {
        int min = int.MaxValue;
        int dinh = 0;

        for (int i = 0; i < dist.Length; ++i)
            if (min > dist[i] && visited[i] == false)
            {
                min = dist[i];
                dinh = i;
            }

        return dinh;
    }

    private (int[] dist, int[] pre) dijkstra(int uBD)
    {
        int[] dist = Enumerable.Repeat(int.MaxValue, g.n).ToArray();
        int[] pre = Enumerable.Repeat(-1, g.n).ToArray();
        bool[] visited = new bool[g.n];

        dist[uBD] = 0;

        for (int i = 0; i < g.n; ++i)
        {
            int u = timKCMin(dist, visited);
            visited[u] = true;

            for (int v = 0; v < g.n; ++v)
            {
                if (visited[v] == false && g[u, v] != 0)
                {
                    int alt = dist[u] + g[u, v];

                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        pre[v] = u;
                    }
                }
            }
        }

        return (dist, pre);
    }

    public (List<int> path, int trongSo) findPath(int startVertex, int endVertex)
    {
        (int[] dist, int[] pre) = dijkstra(startVertex);

        List<int> path = new List<int>();
        int u = endVertex;

        if (pre[u] == -1)
            return (null, 0);

        path.Add(u);

        while (pre[u] != -1)
        {
            path.Add(pre[u]);
            u = pre[u];
        }

        path.Reverse();

        return (path, dist[endVertex]);
    }
}