using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonRepetitiveRandomArray : MonoBehaviour {
    
    // Public Variables
    public int i_arraySize;
    public int i_randomRange;
   
    // Function generating non repetitive random arrays
    int[] RandomArray()
    {
        if (i_randomRange < i_arraySize)
        {
            throw new Exception("Random range needs to be bigger than array size!");
        }
        // Declare the array, its size and local variables
        int[] array_result = new int[i_arraySize];
        int i_random;
        int i_temp;      

        // Loop through each array item and set it to a random number
        for (int i = 0; i < array_result.Length; i++)
        {            
            i_random = UnityEngine.Random.Range(0, i_randomRange);
            i_temp = Array.Find(array_result, q => q == i_random);                    
            if (i == 0 && i_temp == 0 && i_random == 0){
                array_result[i] = 0;
            }
            else if (i_temp == 0)
            {
                array_result[i] = i_random;
            }
            else
            {
                i--;
            }           
        }       
        return array_result;
    }
}
