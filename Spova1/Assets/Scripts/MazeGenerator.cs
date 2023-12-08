using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Author: [Nguyen, Kanyon] & [Vrablick, Calihan]
 * Last Updated: [11/29/2023]
 * [Handles the functionality of the maze.]
 */
public class MazeGenerator : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject shopPrefab;
    public GameObject enemyGrid;
    public GameObject parkourGrid;




    private static int rowSize = 4;
    private static int colSize = 4;

    // array for holding the floors
    private GameObject[,] floorArray = new GameObject[rowSize, colSize];

    // empty game object for holding the floors
    private GameObject floorFolder;


    void Start()
    {
        floorFolder = new GameObject("FloorFolder");

        //Test();



        // setup grid using 2-dimensional array

        float xSize = transform.localScale.x;
        float zSize = transform.localScale.z;

        for (int row = 0; row < rowSize; row++)
        {
            for (int col = 0; col < colSize; col++)
            {
                // dont need the first grid since the floor is already there
                if (row == 0 && col == 0)
                {
                    transform.name = "(" + row + ", " + col + ")";
                    transform.SetParent(floorFolder.transform);
                    continue;
                }

                floorArray[row, col] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                floorArray[row, col].transform.localScale = new Vector3(xSize, 1, zSize);
                floorArray[row, col].name = "(" + row + ", " + col + ")";
                floorArray[row, col].transform.localPosition = new Vector3(xSize*row, 0, zSize*col);

                floorArray[row, col].transform.SetParent(floorFolder.transform);


                // roll number to see what floor plan the room gets
                int number = UnityEngine.Random.Range(1, 4);

                if (number >= 3)
                {
                    // shop

                    Renderer renderer = floorArray[row, col].GetComponent<Renderer>();
                    GameObject shopClone = Instantiate(shopPrefab, new Vector3(xSize * row, 1, zSize * col), Quaternion.identity);
                    renderer.material.SetColor("_Color", Color.yellow);

                    shopClone.transform.SetParent(floorArray[row, col].transform);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int RandomNumber()
    {
        int number = Random.Range(1, 4);
        int result = Mathf.Clamp(number, 1, 3);
        //print(number);
        return result;
    }

    public void MakeRoom()
    {
        RandomNumber();
    }



    /// <summary>
    /// function used only to debug the functionality of the maze
    /// not normally called by the script
    /// </summary>
    private void Test()
    {
        /*
        int[] array = new int[10];
        for (int i = 0; i < 10; i++)
        {
            array[i] = RandomNumber();
        }
        string msg = "";
        foreach (int i in array)
        {
            msg += i + " ";
        }
        print(msg);
        */
    }
}