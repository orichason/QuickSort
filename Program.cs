using System;
using System.Collections;
using System.Collections.Generic;

namespace QuickSort
{
    class Program
    {
        static void QuickSort<T>(T[] userList, int start, int end, IComparer<T> comparer)
        {
            int wall = start - 1;
            int pivot = end - 1;

            if (start + 1 >= end) return;

            bool fail = false;

            for (; wall < end - 1 && fail == false; wall++)
            {
                
                if (comparer.Compare(userList[wall + 1], userList[pivot]) > 0)
                {
                    fail = true;
                    
                    for (int probe = wall + 2; probe < pivot; probe++)
                    {
                        if (comparer.Compare(userList[probe], userList[pivot]) <= 0)
                        {
                            T temp = userList[wall + 1];
                            userList[wall + 1] = userList[probe];
                            userList[probe] = temp;
                            fail = false;
                            break;
                        }
                    }
                }

                //move pivot to middle.
            }
            {
                T temp = userList[wall];
                userList[wall] = userList[pivot];
                userList[pivot] = temp;

                QuickSort(userList, start, wall, comparer);
                QuickSort(userList, wall + 1, end, comparer);
            }
        }

        static void QuickSort<T>(T[] userList, IComparer<T> comparer)
        {
            QuickSort(userList, 0, userList.Length, comparer);
        }

        class IntComparer : IComparer<int>
        {
            public int Compare (int number1, int number2)
            {
                if (number1 < number2)
                {
                    return -1;
                }

                else if(number1 == number2)
                {
                    return 0;
                }

                else
                {
                    return 1;
                }
            }
        }

        static void Main(string[] args)
        {
            Random random = new Random(1);

            int[] numberList = new int[15];

            for (int i = 0; i < numberList.Length; i++)
            {
                numberList[i] = random.Next(1, 50);
                Console.Write($"{numberList[i]} , ");
            }

            IntComparer comparer = new IntComparer();
            IComparer<string> stringComparer = Comparer<string>.Default;
            Console.WriteLine();

            QuickSort(numberList, comparer);

            for (int i = 0; i < numberList.Length; i++)
            {
                Console.Write($" {numberList[i]} , ");
            }
        }
    }
}
