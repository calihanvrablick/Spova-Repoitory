using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        CheckIfDead();
    }


    /// <summary>
    /// handles collision events for the player object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Coins += 1;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }



    /// <summary>
    /// checks to see if the player is alive. If not, switch to the game over screen
    /// </summary>
    public void CheckIfDead()
    {
        if (health < 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(1);
        }
    }
}
