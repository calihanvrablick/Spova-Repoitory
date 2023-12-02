using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Nguyen, Kanyon] & [Vrablick, Calihan]
 * Last Updated: [11/29/2023]
 * [Holds player variables and handles the collisions for the player.]
 */
public class PlayerHandler : MonoBehaviour
{

    public int health;
    public int Coins;

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
        if (other.gameObject.tag == "Coin")
        {
            Coins += 1;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}
