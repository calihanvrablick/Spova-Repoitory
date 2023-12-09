using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public GameObject mazeNodePrefab;



    private float wallHeight = 10;
    private float wallThickness = 1;
    private static int rowSize = 10;
    private static int colSize = 10;



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
                    gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    floorArray[row, col] = transform.gameObject;
                    transform.name = "(" + row + ", " + col + ")";
                    transform.SetParent(floorFolder.transform);
                    continue;
                }

                floorArray[row, col] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                floorArray[row, col].transform.localScale = new Vector3(xSize, 1, zSize);
                floorArray[row, col].name = "(" + row + ", " + col + ")";
                floorArray[row, col].transform.localPosition = new Vector3(xSize*row, 0, zSize*col);

                floorArray[row, col].transform.SetParent(floorFolder.transform);


                Renderer thisRenderer = floorArray[row, col].GetComponent<Renderer>();

                // before randomly generating the floor, check to see if the node is the last of the grid
                // this will be the end grid that the player needs to get to.
                if (row == rowSize-1 && col == colSize-1)
                {
                    thisRenderer.material.SetColor("_Color", Color.green);
                    continue;
                }

                // roll number to see what floor plan the room gets
                int number = UnityEngine.Random.Range(1, 4);

                if (number >= 3)
                {
                    // shop
                    GameObject shopClone = Instantiate(shopPrefab, new Vector3(xSize * row, 1, zSize * col), Quaternion.identity);
                    thisRenderer.material.SetColor("_Color", Color.yellow);

                    shopClone.transform.SetParent(floorArray[row, col].transform);
                }
            }
        }

        GenerateMaze();
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



    /// <summary>
    /// sets up the walls for the maze. randomly generates the maze path afterwards.
    /// </summary>
    private void GenerateMaze()
    {
        for (int row = 0; row < rowSize; row++)
        {
            for (int col = 0; col < colSize; col++)
            {

                GameObject thisFloor = floorArray[row, col];
                GameObject thisMazeNode = Instantiate(mazeNodePrefab, thisFloor.transform.localPosition, Quaternion.identity);
                thisMazeNode.name = "NodeValues";

                // making all 4 walls

                GameObject frontWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                frontWall.name = "Front";
                frontWall.transform.localScale = new Vector3(thisFloor.transform.localScale.x, wallHeight, wallThickness);
                // adjust wall position to floor position
                frontWall.transform.localPosition = new Vector3(0, wallHeight / 2, (thisFloor.transform.localScale.x / 2) - (wallThickness/2)) + thisFloor.transform.localPosition;
                frontWall.transform.SetParent(thisFloor.transform);
                

                GameObject backWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                backWall.name = "Back";
                backWall.transform.localScale = new Vector3(thisFloor.transform.localScale.x, wallHeight, wallThickness);
                // adjust wall position to floor position
                backWall.transform.localPosition = new Vector3(0, wallHeight / 2, -(thisFloor.transform.localScale.x / 2) + (wallThickness / 2)) + thisFloor.transform.localPosition;
                backWall.transform.SetParent(thisFloor.transform);


                GameObject leftWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                leftWall.name = "Left";
                leftWall.transform.localScale = new Vector3(wallThickness, wallHeight, thisFloor.transform.localScale.z);
                // adjust wall position to floor position
                leftWall.transform.localPosition = new Vector3(-(thisFloor.transform.localScale.z / 2) + (wallThickness / 2), wallHeight / 2, 0) + thisFloor.transform.localPosition;
                leftWall.transform.SetParent(thisFloor.transform);


                GameObject rightWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                rightWall.name = "Right";
                rightWall.transform.localScale = new Vector3(wallThickness, wallHeight, thisFloor.transform.localScale.z);
                // adjust wall position to floor position
                rightWall.transform.localPosition = new Vector3((thisFloor.transform.localScale.z / 2) - (wallThickness / 2), wallHeight / 2, 0) + thisFloor.transform.localPosition;
                rightWall.transform.SetParent(thisFloor.transform);



                thisMazeNode.GetComponent<MazeNode>().frontWall = frontWall;
                thisMazeNode.GetComponent<MazeNode>().backWall = backWall;
                thisMazeNode.GetComponent<MazeNode>().leftWall = leftWall;
                thisMazeNode.GetComponent<MazeNode>().rightWall = rightWall;
                thisMazeNode.GetComponent<MazeNode>().row = row;
                thisMazeNode.GetComponent<MazeNode>().col = col;


                thisMazeNode.transform.SetParent(thisFloor.transform);
            }
        }

        RecursiveMazeGeneration(null, floorArray[0, 0].transform.Find("NodeValues").GetComponent<MazeNode>());
    }



    /// <summary>
    /// randomly generates the maze path
    /// </summary>
    /// <param name="previousNode"></param>
    /// <param name="currentNode"></param>
    private void RecursiveMazeGeneration(MazeNode previousNode, MazeNode currentNode)
    {
        currentNode.Visit();
        OpenWallPath(previousNode, currentNode);

        MazeNode nextNode;

        do
        {
            nextNode = GetNextUnvisitedNode(currentNode);

            if (nextNode != null)
            {
                RecursiveMazeGeneration(currentNode, nextNode);
            }

        } while (nextNode != null);
    }



    /// <summary>
    /// randomly grabs the next unvisited cell to open up
    /// </summary>
    /// <param name="currentNode"></param>
    /// <returns></returns>
    private MazeNode GetNextUnvisitedNode(MazeNode currentNode)
    {
        var newNodes = GetUnvisitedNodes(currentNode);

        return newNodes.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }



    /// <summary>
    /// checks all sides of the current node to see if there are unvisited cells.
    /// </summary>
    /// <param name="currentNode"></param>
    /// <returns></returns>
    private IEnumerable<MazeNode> GetUnvisitedNodes(MazeNode currentNode)
    {
        int x = currentNode.row;
        int z = currentNode.col;

        // check right side
        if (x + 1 < rowSize)
        {
            var cellToRight = floorArray[x + 1, z].transform.Find("NodeValues").GetComponent<MazeNode>();

            if (cellToRight.isVisited == false)
            {
                yield return cellToRight;
            }
        }

        // check left side
        if (x - 1 >= 0)
        {
            var cellToLeft = floorArray[x - 1, z].transform.Find("NodeValues").GetComponent<MazeNode>();

            if (cellToLeft.isVisited == false)
            {
                yield return cellToLeft;
            }
        }

        // check top side
        if (z + 1 < colSize)
        {
            var cellToFront = floorArray[x, z + 1].transform.Find("NodeValues").GetComponent<MazeNode>();

            if (cellToFront.isVisited == false)
            {
                yield return cellToFront;
            }
        }

        // check bottom side
        if (z - 1 >= 0)
        {
            var cellToBack = floorArray[x, z - 1].transform.Find("NodeValues").GetComponent<MazeNode>();

            if (cellToBack.isVisited == false)
            {
                yield return cellToBack;
            }
        }
    }



    /// <summary>
    /// opens up the walls blocking the path between the given nodes
    /// </summary>
    /// <param name="previousNode"></param>
    /// <param name="currentNode"></param>
    private void OpenWallPath(MazeNode previousNode, MazeNode currentNode)
    {
        if (previousNode == null)
            return;

        if (previousNode.transform.position.x < currentNode.transform.position.x)
        {
            //going right
            previousNode.ClearRight();
            currentNode.ClearLeft();
            return;
        }
        if (previousNode.transform.position.x > currentNode.transform.position.x)
        {
            //going left
            previousNode.ClearLeft();
            currentNode.ClearRight();
            return;
        }
        if (previousNode.transform.position.z < currentNode.transform.position.z)
        {
            //going up
            previousNode.ClearFront();
            currentNode.ClearBack();
            return;
        }
        if (previousNode.transform.position.z > currentNode.transform.position.z)
        {
            //going down
            previousNode.ClearBack();
            currentNode.ClearFront();
            return;
        }
    }
}