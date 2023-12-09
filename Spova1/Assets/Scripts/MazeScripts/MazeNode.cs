using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Author: [Nguyen, Kanyon] & [Vrablick, Calihan]
 * Last Updated: [12/08/2023]
 * [Stores values for each wall node in the maze for future editing.]
 */
public class MazeNode : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject frontWall;
    public GameObject backWall;

    public int row, col;

    public Boolean isVisited;


    /// <summary>
    /// returns if the node has already been visited or not
    /// </summary>
    /// <returns></returns>
    public bool IsVisited()
    { 
        return isVisited;
    }


    /// <summary>
    /// sets the node's visit status to true
    /// </summary>
    public void Visit()
    {
        isVisited = true;
    }


    /// <summary>
    /// clears the left side of the node
    /// </summary>
    public void ClearLeft()
    {
        leftWall.SetActive(false);
    }


    /// <summary>
    /// clears the right wall of the node
    /// </summary>
    public void ClearRight()
    {
        rightWall.SetActive(false);
    }


    /// <summary>
    /// clears the front wall of the node
    /// </summary>
    public void ClearFront()
    {
        frontWall.SetActive(false);
    }


    /// <summary>
    /// clears the back wall of the node
    /// </summary>
    public void ClearBack()
    {
        backWall.SetActive(false);
    }

    internal object OrderBy(Func<object, int> value)
    {
        throw new NotImplementedException();
    }
}
