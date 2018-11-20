using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.NoPositive
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = { { { 1, 2 , 3 }, {-1, -2, -3 }, { - 1, 1, -3} },
                            { { 1 , 3, - 4 }, { -5, -5, -5}, { -1, 2, 3 } },
                            { { 1, 1 , -1}, {-1, -2, -3 }, { -3, 1, 2} } };

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int q = 0; q < array.GetLength(2); q++)
                    {
                        if (array[i, j, q] > 0)
                        {
                            array[i, j, q] = 0;
                        }
                        Console.Write(array[i, j, q] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
