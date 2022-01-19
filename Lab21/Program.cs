using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


//1.Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать.
//Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
//Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
//Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево.
//Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно.
//Создать многопоточное приложение, моделирующее работу садовников

namespace Lab21
{
    internal class Program
    {

        static string[,] garden = new string[20, 30];



        static void GardenerH()
        {
            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    if (garden[i, j] == "o")
                    {
                        garden[i, j] = "H";
                        Thread.Sleep(2);
                    }

                }
            }
        }

        static void GardenerV()
        {
            for (int j = garden.GetLength(1)-1; j >=0; j--)
            {
                for (int i = garden.GetLength(0)-1; i >=0; i--)
                {
                    if (garden[i, j] == "o")
                    {
                        garden[i, j] = "V";
                        Thread.Sleep(50);
                    }
                }
            }
        }

        static void Print()
        {
            

            while (true)
            {
               for (int i = 0; i < garden.GetLength(0); i++)
                {
                    for (int j = 0; j < garden.GetLength(1); j++)
                    {

                        Console.Write("{0,2}", garden[i, j]);
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(100);

                Console.Clear();

            }
        }



        static void Main(string[] args)
        {

            for (int i = 0; i < garden.GetLength(0); i++)
            {
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    garden[i, j] = "o";
                    
                }
            }

            ThreadStart threadStartP = new ThreadStart(Print);
            Thread threadP = new Thread(threadStartP);
            threadP.Start();

            ThreadStart threadStart = new ThreadStart(GardenerH);
            Thread thread = new Thread(threadStart);
            thread.Start();

            GardenerV();

            Console.ReadKey();
        }
    }
}
