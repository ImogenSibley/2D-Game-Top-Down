using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array2D : MonoBehaviour
{

    int[,] array = { 
        {1,0,1},
        {0,1,0},
        {1,0,1},
};
    // Start is called before the first frame update
    void Start()
    {


        for (int i = 0; i < array.GetLength(0); i++)
        {

            for (int j = 0; j<array.GetLength(1); j++)
            {
                MeshRenderer cube = GameObject.CreatePrimitive(PrimitiveType.Cube).GetComponent<MeshRenderer>();
                cube.transform.position = new Vector3(j, i, 0);

                if (array[i, j] == 1)
                {
                    cube.GetComponent<Renderer>().material.color = Color.green;
                }

                else
                {
                    cube.GetComponent<Renderer>().material.color = Color.red;
                }

            }

        }

        //if value is 1, set colour to green 
        //else if value is 0, set colour to red
    }

    // Update is called once per frame
    void Update()
    {

    }
}