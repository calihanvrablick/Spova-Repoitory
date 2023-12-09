using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Vrablick, Calihan] & [Nguyen, Kanyon]
 * Last Updated: [12/08/2023]
 * [Controls the rotation of the spiral]
 */

public class Spiral : MonoBehaviour
{
    int directionNumber = Random.Range(1, 5);

// Start is called before the first frame update
void Start()
    {
        if (directionNumber == 4)
        {
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (directionNumber == 3)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (directionNumber == 2)
        {
            transform.localRotation = Quaternion.Euler(0, 270, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
