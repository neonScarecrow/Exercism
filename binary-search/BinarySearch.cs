using System;

public class BinarySearch
{
    private readonly int[] array;
    public BinarySearch(int[] input)
    {
        array = input;
    }

    public int Find(int value)
    {
        return FindTheEasyWay(value);
    }

    private int FindTheEasyWay(int value)
    {
        int index = Array.BinarySearch(array, 0, array.Length, value);
        return index < 0 ? -1 : index;
    }

    private int FindTheHardWay(int value)
    {
        int min = 0;
        int max = array.Length - 1;
        while (min <= max)
        {
            int mid = (max + min) / 2;
            int item = array[mid];
            if (value == item) return mid;
            if (value > item) min = mid + 1;
            else max = mid - 1;
        }

        return -1;
    }

}