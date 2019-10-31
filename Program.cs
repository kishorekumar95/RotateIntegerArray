using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string flag = "";
            while (flag != "N")
            {
                Console.WriteLine("Enter the Array Size");

                int arraySize = Convert.ToInt32(Console.ReadLine());
                int[] tempArray = new int[arraySize];

                Console.WriteLine("Enter the Array");

                for (int i = 0; i <= tempArray.Length - 1; i++)
                {
                    tempArray[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Enter the Times You Want To Rotate");
                int times = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Which Direction You Want To Rotate: R/L");
                var direction = Console.ReadLine().ToUpper() == "R" ? 0 : 1;

                Rotator.Rotate(tempArray, direction, times);

                foreach (var item in tempArray)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Do You Want to Continue: Y/N");
                flag = Console.ReadLine().ToUpper();
            }

        }
    }

    public static class Rotator
    {
        public static T Rotate<T>(T arrayToRotate, int direction, int times)
        {

            arrayToRotate = Enum.GetName(typeof(Direction), direction) == "Right" ? Rotator.rotateRight(arrayToRotate, times) : Rotator.rotateleft(arrayToRotate, times);

            return arrayToRotate;
        }

        public static int[] rotateRight(int[] array, int times)
        {
            int[] temp = new int[array.Length];

            for (int i = 0; i < times; i++)
            {
                int last = array[array.Length - 1];
                for (int j = array.Length - 1; j >= 1; j--)
                {
                    temp[j] = array[j - 1];
                }
                temp[0] = last;
                temp.CopyTo(array, 0);

            }
            return temp;
        }

        public static int[] rotateleft(int[] array, int times)
        {
            int[] temp = new int[array.Length];

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

        public enum Direction
        {
            Right = 0,
            Left = 1
        }

    }
}
