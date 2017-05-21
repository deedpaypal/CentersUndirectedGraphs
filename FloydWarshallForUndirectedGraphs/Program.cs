﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultidimensionalArrayUndirectedGraphFloydWarshall.MatrixGenerator;
using MultidimensionalArrayUndirectedGraphFloydWarshall.Utils;

namespace MultidimensionalArrayUndirectedGraphFloydWarshall
{
    class Program
    {
        public const int INF = 2000000;
        static void Main(string[] args)
        {
            Console.WriteLine("Input amount of vertexes");
            int sizeOfGraph = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input amount of graphs");
            int amountOfGraphs = Convert.ToInt32(Console.ReadLine());

            //среднее количество секунд на один граф
            double sWatch = 0.0;

            //проход по всем рандомным графам, количество которых amountOfGraphs
            for (int i = 0; i < amountOfGraphs; i++)
            {
                //объект для построения рандомного графа
                MatrixGeneratorMultidimensionalArray m = new MatrixGeneratorMultidimensionalArray(sizeOfGraph);

                //исследуемый рандомный граф
                /// <summary>
                /// Тут объект класса MatrixGeneratorArrayOfArrays содержит методы
                /// GetLowRarefactionMatrix, GetMediumRarefactionMatrix, GetHardRarefactionMatrix,
                /// то есть зависимость от разреженности. По умолчанию слаборазреженный граф
                /// изменяй их по своему усмотрению
                /// </summary>


                int[,] graph = m.GetHardRarefactionMatrix();

                //печатаем для наглядности
                MatrixPrinter.Print(graph);
                Stopwatch sw = new Stopwatch();

                //включаем счетчик
                sw.Start();

                //объект-анализатор, в котором есть методы построения матрицы Dn кратчайших путей, поиск эксцентриситетов и центров
                Analyser analyser = new Analyser();
                int[,] graphToFloydWarshall = analyser.FloydWarshall(graph);
                int[] excentricities = analyser.Excentricity(graphToFloydWarshall);
                IList<int> centers = analyser.GetCenters(excentricities);
                sw.Stop();

                //вывод вершин-центров
                Console.Write("Centers-vertexes: ");
                foreach (var center in centers)
                {
                    Console.Write(center + " ");
                }

                //прибвляем к общему времени время, затраченное на текущий граф
                sWatch = sWatch + sw.Elapsed.TotalSeconds;
                Console.WriteLine();
                Console.WriteLine("Time for a single graph: {0} seconds", sw.Elapsed.TotalSeconds);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            //среднее время
            Console.WriteLine("Average time for graph, which has a {0} vertexes: {1} seconds", amountOfGraphs, sWatch / amountOfGraphs);
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
