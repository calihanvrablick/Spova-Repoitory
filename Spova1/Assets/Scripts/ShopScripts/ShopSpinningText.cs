using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Author: [Nguyen, Kanyon] & [Vrablick, Calihan]
 * Last Updated: [12/01/2023]
 * [Spins the text of the shop. Referenced from https://www.youtube.com/shorts/4AJ9_H8nqx4?feature=share.]
 */
public class ShopSpinningText : MonoBehaviour
{
    private Vector3 rotateAmount = new Vector3(0, 100, 0);

    // Update is called once per frame
    void Update()
    {
        //print("spinning");
        transform.Rotate(rotateAmount * Time.deltaTime);
    }
}
