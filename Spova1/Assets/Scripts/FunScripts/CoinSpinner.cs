using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Author: [Nguyen, Kanyon] & [Vrablick, Calihan]
 * Last Updated: [12/01/2023]
 * [Spins the coin. Referenced from https://www.youtube.com/shorts/4AJ9_H8nqx4?feature=share.]
 */
public class CoinSpinner : MonoBehaviour
{
    private Vector3 rotateAmount = new Vector3(0,0,100);

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateAmount * Time.deltaTime);
    }
}
