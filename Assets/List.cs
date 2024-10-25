using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    List<string> itemsName = new List<string>(); //string list

    GameObject[] items = new GameObject[10]; //game object array

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < itemsName.Count; i++)
        {
            //set item in string list = item in object array
            itemsName.Add(items[i].name);

            //print each gameobject name to console
            Console.WriteLine(items[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
