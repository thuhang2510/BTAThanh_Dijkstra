using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai01
{
    class Program
    {
        static void Main(string[] args)
        {
            FileIO fileIO = new FileIO();

            Input input = fileIO.docFile("input.txt");
            Dijkstra dijkstra = new Dijkstra(input.g);

            (List<int> ketqua, int trongSo) = dijkstra.findPath(input.uBD, input.uKT);

            Console.WriteLine("Trong so: " + trongSo);

            if (ketqua != null)
                Console.WriteLine(string.Join(" --> ", ketqua));
            else
                Console.WriteLine("Khong co duong di");
        }
    }
}
