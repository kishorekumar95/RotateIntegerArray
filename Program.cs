using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string flag = "";
            while (flag != "N" )
            {
                List<int> list = new List<int>();
                Console.WriteLine("Enter the Array Size");

                int arraySize = Convert.ToInt32(Console.ReadLine());
                //int?[] tempArray = new int?[arraySize];
                int[] tempArray = new int[arraySize];
                Console.WriteLine("Enter the Array");

                for (int i = 0; i <= tempArray.Length - 1; i++)
                {
                    tempArray[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Enter the Times You Want To Rotate");
                int times = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Which Direction You Want To Rotate: R/L");
                string direction = Console.ReadLine().ToUpper();

                tempArray = direction == "R" ? Program.rotateRight(tempArray, times, arraySize) : Program.rotateleft(tempArray, times, arraySize);
                foreach (var item in tempArray)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Do You Want to Continue: Y/N");
                flag = Console.ReadLine().ToUpper();
            }

        }

        /// <summary>
        /// Initially tried something like creating nullable integer array.
        /// it was working fine for rotating left but facing issue in rotating right.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="times"></param>
        /// <param name="arraySize"></param>
        /// <returns></returns>
        public static int?[] rotateLeft1(int?[] array, int times, int arraySize)
        {
            int?[] temp = new int?[arraySize];

            for (int i = 0; i < times; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    temp[j] = array[j + 1] ?? array[0];
                }
                temp.CopyTo(array, 0);

            }
            return temp;
        }

        public static int[] rotateRight(int[] array, int times, int arraySize)
        {
            int[] temp = new int[arraySize];

            for (int i = 0; i < times; i++)
            {
                int last = array[array.Length - 1];
                for (int j = array.Length - 1; j >= 1; j--)
                {
                    //temp[j] = array[j + 1] != -1 ? array[j + 1] : array[0];
                    temp[j] = array[j - 1];
                }
                temp[0] = last;
                temp.CopyTo(array, 0);

            }
            return temp;
        }

        public static int[] rotateleft(int[] array, int times, int arraySize)
        {
            int[] temp = new int[arraySize];

            for (int i = 0; i < times; i++)
            {
                int first = array[0];

                for (int j = 0; j < array.Length - 1; j++)
                {
                    temp[j] = array[j + 1];
                }
                temp[array.Length - 1] = first;
                temp.CopyTo(array, 0);

            }
            return temp;
        }
    }
}
