using System;

class Program
{
    static void Main()
    {
        int[] array = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] parts = input.Split();

            switch (parts[0])
            {
                case "exchange":
                    int index = int.Parse(parts[1]);
                    if (index < 0 || index >= array.Length)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        array = Exchange(array, index);
                    }
                    break;

                case "max":
                    Console.WriteLine(MaxIndex(array, parts[1]));
                    break;

                case "min":
                    Console.WriteLine(MinIndex(array, parts[1]));
                    break;

                case "first":
                    int count1 = int.Parse(parts[1]);
                    if (count1 > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        PrintArray(GetFirst(array, count1, parts[2]));
                    }
                    break;

                case "last":
                    int count2 = int.Parse(parts[1]);
                    if (count2 > array.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else
                    {
                        PrintArray(GetLast(array, count2, parts[2]));
                    }
                    break;
            }
        }

        PrintArray(array);
    }

    static int[] Exchange(int[] arr, int index)
    {
        int[] result = new int[arr.Length];
        int pos = 0;

        for (int i = index + 1; i < arr.Length; i++)
        {
            result[pos++] = arr[i];
        }
        for (int i = 0; i <= index; i++)
        {
            result[pos++] = arr[i];
        }

        return result;
    }

    static string MaxIndex(int[] arr, string type)
    {
        int max = int.MinValue;
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (IsType(arr[i], type))
            {
                if (arr[i] >= max)
                {
                    max = arr[i];
                    index = i;
                }
            }
        }

        return index == -1 ? "No matches" : index.ToString();
    }

    static string MinIndex(int[] arr, string type)
    {
        int min = int.MaxValue;
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (IsType(arr[i], type))
            {
                if (arr[i] <= min)
                {
                    min = arr[i];
                    index = i;
                }
            }
        }

        return index == -1 ? "No matches" : index.ToString();
    }

    static int[] GetFirst(int[] arr, int count, string type)
    {
        int[] temp = new int[count];
        int found = 0;

        for (int i = 0; i < arr.Length && found < count; i++)
        {
            if (IsType(arr[i], type))
            {
                temp[found++] = arr[i];
            }
        }

        return CopyResult(temp, found);
    }

    static int[] GetLast(int[] arr, int count, string type)
    {
        int[] temp = new int[count];
        int found = 0;

        for (int i = arr.Length - 1; i >= 0 && found < count; i--)
        {
            if (IsType(arr[i], type))
            {
                temp[found++] = arr[i];
            }
        }

        // reverse the collected results
        Array.Reverse(temp, 0, found);
        return CopyResult(temp, found);
    }

    static bool IsType(int number, string type)
    {
        return type == "even" ? number % 2 == 0 : number % 2 != 0;
    }

    static int[] CopyResult(int[] array, int length)
    {
        int[] result = new int[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = array[i];
        }
        return result;
    }

    static void PrintArray(int[] arr)
    {
        Console.Write("[");
        Console.Write(string.Join(", ", arr));
        Console.WriteLine("]");
    }
}