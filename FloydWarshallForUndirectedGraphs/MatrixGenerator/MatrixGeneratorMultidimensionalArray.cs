using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultidimensionalArrayUndirectedGraphFloydWarshall.MatrixGenerator
{
    class MatrixGeneratorMultidimensionalArray
    {

        static Random rn = new Random();
        private static int Rarefaction { get; set; }
        private static int Size { get; set; }

        public MatrixGeneratorMultidimensionalArray(int size)
        {
            Size = size;
        }

        public int[,] GetLowRarefactionMatrix()
        {
            int size = Size;
            int b = size * size;
            int lowRarefaction = rn.Next((int)(b * 0.25), (int)(b * 0.45));
            int rarefactionCount = lowRarefaction;
            Rarefaction = rarefactionCount;
            int[,] newMatrix = new int[size, size];

            while (rarefactionCount > 0)
            {
                int nl = rn.Next(0, size);
                int nh = rn.Next(0, size);

                if (newMatrix[nl, nh] == 0 && nh >= nl)
                {
                    if (nl == nh)
                    {
                        newMatrix[nl, nh] = 0;
                    }
                    else
                    {
                        newMatrix[nl, nh] = rn.Next(2, 25);
                    }
                    rarefactionCount--;
                }
            }

            for (int coordX = 0; coordX < size; coordX++)
            {
                for (int coordY = coordX; coordY < size; coordY++)
                {
                    if (coordX != coordY && newMatrix[coordX, coordY] == 0)
                    {
                        newMatrix[coordX, coordY] = 2000000;
                    }
                    newMatrix[coordY, coordX] = newMatrix[coordX, coordY];
                }
            }
            return newMatrix;
        }

        public int[,] GetMediumRarefactionMatrix()
        {
            int size = Size;
            int b = size * size;
            int mediumRarefaction = rn.Next((int)(b * 0.45), (int)(b * 0.9));
            int rarefactionCount = mediumRarefaction;
            Rarefaction = rarefactionCount;
            int[,] newMatrix = new int[size, size];

            while (rarefactionCount > 0)
            {
                int nl = rn.Next(0, size);
                int nh = rn.Next(0, size);

                if (newMatrix[nl, nh] == 0 && nh >= nl)
                {
                    if (nl == nh)
                    {
                        newMatrix[nl, nh] = 0;
                    }
                    else
                    {
                        newMatrix[nl, nh] = rn.Next(2, 25);
                    }
                    rarefactionCount--;
                }
            }

            for (int coordX = 0; coordX < size; coordX++)
            {
                for (int coordY = coordX; coordY < size; coordY++)
                {
                    if (coordX != coordY && newMatrix[coordX, coordY] == 0)
                    {
                        newMatrix[coordX, coordY] = 2000000;
                    }
                    newMatrix[coordY, coordX] = newMatrix[coordX, coordY];
                }
            }
            return newMatrix;
        }

        public int[,] GetHardRarefactionMatrix()
        {
            int size = Size;
            int[,] newMatrix = new int[size, size];

            for (int coordX = 0; coordX < size; coordX++)
            {
                for (int coordY = coordX; coordY < size; coordY++)
                {
                    if (coordX != coordY && newMatrix[coordX, coordY] == 0)
                    {
                        newMatrix[coordX, coordY] = rn.Next(2, 25);
                    }
                    newMatrix[coordY, coordX] = newMatrix[coordX, coordY];
                }
            }
            return newMatrix;
        }
    }
}
