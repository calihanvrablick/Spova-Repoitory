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

    public GameObject shopGrid;
    public GameObject enemyGrid;
    public GameObject parkourGrid;



    void Start()
    {
        RandomNumber();

        Test();
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