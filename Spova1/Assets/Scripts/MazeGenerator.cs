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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int RandomNumber()
    {
        int number = Random.Range(1, 3);
        //print(number);
        return number;
    }

    public void makeRoom()
    {
        RandomNumber();
    }
}
