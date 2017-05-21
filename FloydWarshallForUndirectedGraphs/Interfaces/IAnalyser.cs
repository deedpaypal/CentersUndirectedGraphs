using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultidimensionalArrayUndirectedGraphFloydWarshall.Interfaces
{
    interface IAnalyser
    {
        int[,] FloydWarshall(int[,] graph);
        int[] Excentricity(int[,] array);
        IList<int> GetCenters(int[] array);
    }
}
