using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
//using LibNoise; 
//using LibNoise.Generator;

public class ColorNoise : MonoBehaviour

{  
    public GameObject[][] grid; //declared an array of GameObjects

    private Renderer cube;

    private float offset = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        cube = GetComponent<Renderer>();
        
        grid = new GameObject[50][]; //init array with 5 columns

//        grid[0] = Instantiate(Resources.Load<GameObject>("Prefabs/Cube"));

        //for loops have 3 parts:
        // part 1: var to track: x = 0
        // part 2: when to exit the loop: x < grid.Length
        // part 3: how to change every time we loop: x++
        for (int x = 0; x < grid.Length; x++) //for loop to go through all the columns 
        {
            grid[x] = new GameObject[50]; //init this column to have 6 rows
            

            for (int y = 0; y < grid[x].Length; y++) //for loop to go through all the rows
            {

                grid[x][y] = Instantiate(Resources.Load<GameObject>("Prefabs/Cube")); //put a cube in the slot at this column, row

                grid[x][y].transform.position = new Vector3(x, y, 0); //use the column, row to position the cube

                //print(x + "   " + y);
                //print(Mathf.PerlinNoise(x * 0.1f,y * 0.1f));
                grid[x][y].GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(Mathf.PerlinNoise(x * 0.1f,y * 0.1f),1,1);
            }
        }
        
    }

    private void Update()
    {
        offset += .01f;
        
        for (int x = 0; x < grid.Length; x++) //for loop to go through all the columns 
        {

            for (int y = 0; y < grid[x].Length; y++) //for loop to go through all the rows
            {
                //print(x + "   " + y);
                //print(Mathf.PerlinNoise(x * 0.1f,y * 0.1f));
                grid[x][y].GetComponent<MeshRenderer>().material.color = Color.HSVToRGB(Mathf.PerlinNoise(x * 0.1f + offset,y * 0.1f),1,1);
            }
        }
    }
}

