using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultidimensionalArrayUndirectedGraphFloydWarshall.Interfaces;

namespace MultidimensionalArrayUndirectedGraphFloydWarshall.Utils
{
    class Analyser : IAnalyser
    {
        public int[,] FloydWarshall(int[,] graph)
        {
            int[,] distance = (int[,])graph.Clone();

            int n = graph.GetLength(0);
            for (int k = 0; k < n; ++k)
            {
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j <= i; ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                        {
                            distance[i, j] = distance[i, k] + distance[k, j];
                            distance[j, i] = distance[i, j];
                        }
                    }
                }
            }
            return distance;
        }

        public int[] Excentricity(int[,] array)
        {
            int[] e = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i > j)
                    {
                        e[i] = Math.Max(e[i], array[j, i]);
                    }
                    else
                    {
                        e[i] = Math.Max(e[i], array[i, j]);
                    }
                }
            }
            return e;
        }

        public IList<int> GetCenters(int[] array)
        {
            IList<int> centerList = new List<int>();
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                if (array[i] == array.Min())
                {
                    centerList.Add(i + 1);
                }
            }
            return centerList;
        }
    }
}
