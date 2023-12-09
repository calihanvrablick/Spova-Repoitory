using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Vrablick, Calihan] & [Nguyen, Kanyon]
 * Last Updated: [12/08/2023]
 * [Controls the damage of the lightsaber]
 */

public class Lightsaber : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EasyEnemy" )
        {
            other.gameObject.GetComponent<EasyEnemy>().health -= damage;
        }
    }
}
