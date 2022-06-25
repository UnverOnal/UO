using System;
using System.Collections;
using System.Collections.Generic;

public static class RandomUtility
{
    public static T[] Shuffle<T> (this Random random, T[] array)
    {
        int length = array.Length;
        while (length > 1) 
        {
            int k = random.Next(length--);
            T temp = array[length];
            array[length] = array[k];
            array[k] = temp;
        }

        return array;
    }
}
