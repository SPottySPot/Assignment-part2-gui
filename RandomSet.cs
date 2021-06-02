using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace Assignment_part2_gui
{
    public class RandomSet
    {
        public int[] arr = new int[] { };
        public int[] sortedArr = new int[] { };
        Random randomGenerator = new Random();
        public int bubblePasses = 0;
        public int oddEvenPasses = 0;


        public RandomSet(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Array.Resize(ref arr, arr.Length + 1);
                arr[arr.Length - 1] = randomGenerator.Next(99) + 1;
            }
        }

        public void Seed(int seed)
        {
            
            //get 20% of the array size
            int random = randomGenerator.Next(arr.Length);
            int offset = (random) / 5+1;
            int location = arr.Length - offset;
            
            //add the seed
            arr[location] = seed;
        }

        public int search(int num)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (num == arr[i])
                {
                    //returns place in array
                    return i;
                }
            }
            return -1;
        }
        public int[] bubbleSort(int[] data)
        {
            int lenD = data.Length;
            int passes = 0;

            int tmp = 0;
            for (int i = 0; i < lenD; i++)
            {
                for (int j = (lenD - 1); j >= (i + 1); j--)
                {
                    if (data[j] < data[j - 1])
                    {
                        tmp = data[j];
                        data[j] = data[j - 1];
                        data[j - 1] = tmp;
                    }
                }
                passes++;
            }
            bubblePasses = passes;
            return data;
        }

        public void sortBubble()
        {
            Array.Resize(ref sortedArr, arr.Length);
            arr.CopyTo(sortedArr, 0);
            sortedArr = bubbleSort(sortedArr);
        }

        public int[] oddEvenSort(int[] list)
        {
            int passes = 0;
            void swap(int[] swaplist, int i, int j)
            {
                var temp = swaplist[i];
                swaplist[i] = swaplist[j];
                swaplist[j] = temp;
            }
            var sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (var i = 1; i < list.Length - 1; i += 2)
                {
                    if (list[i] > list[i + 1])
                    {
                        swap(list, i, i + 1);
                        sorted = false;
                    }
                }
                for (var i = 0; i < list.Length - 1; i += 2)
                {
                    if (list[i] > list[i + 1])
                    {
                        swap(list, i, i + 1);
                        sorted = false;
                    }
                }
                passes++;
            }
            oddEvenPasses = passes;
            return list;
        }

        public void sortOddEven()
        {
            sortedArr = arr;
            sortedArr = oddEvenSort(sortedArr);
        }

        public void printArray()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine();
        }

        public void printSortedArray()
        {
            for (int i = 0; i < sortedArr.Length; i++)
            {
                Console.Write(sortedArr[i] + ", ");
            }
            Console.WriteLine();
        }

        public void writeFile(string filename)
        {
            try
            {
                StreamWriter streamwriter = new StreamWriter(filename);
                for (int i = 0; i < arr.Length; i++)
                {
                    streamwriter.WriteLine(arr[i]);
                }
                streamwriter.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine("error saving to file: " + err.Message);
            }
        }


    }
}
