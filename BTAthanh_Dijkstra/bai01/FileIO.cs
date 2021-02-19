using System;
using System.IO;

class FileIO
{
    public Input docFile(string fileName)
    {
        char[] sep = new char[] { ' ', '\t' };

        string[] lines = File.ReadAllLines(fileName);

        string[] linesDinh = lines[0].Trim().Split(sep);

        int n = int.Parse(lines[1]);
        Graph g = new Graph(n);

        int uBD = int.Parse(linesDinh[0]);
        int uKT = int.Parse(linesDinh[1]);

        for (int i = 2; i < lines.Length; ++i)
        {
            string[] content = lines[i].Trim().Split(sep, System.StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < content.Length; ++j)
                g[i - 2, j] = int.Parse(content[j]);
        }

        Input input = new Input(g, uBD, uKT);

        return input;
    }
}

class Input
{
    public int uBD;
    public int uKT;
    public Graph g;

    public Input(Graph g, int uBD, int uKT)
    {
        this.uBD = uBD;
        this.uKT = uKT;
        this.g = g;
    }
}