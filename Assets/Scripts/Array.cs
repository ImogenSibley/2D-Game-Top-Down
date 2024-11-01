using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array : MonoBehaviour
{
    string[] itemsName = new string[10]; //string array

    GameObject[] items = new GameObject[10]; //game object array

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<itemsName.Length; i++)
        { 
            //set item name to item
            //item in string array = item in object array
            itemsName[i] = items[i].name; 
            Console.WriteLine(itemsName); //print
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
