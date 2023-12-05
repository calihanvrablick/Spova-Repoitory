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

    // editable variables
    public int health;
    public int Coins;
    public float invicibilityTime;


    // object variables
    private Renderer playerRenderer;


    // placeholder variables
    private bool isInvincible = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
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

        if (other.gameObject.tag == "HardEnemy")
        {
            TakeDamage(other.gameObject.GetComponent<HardEnemy>().contactDamage);
        }
    }





    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // CUSTOM FUNCTIONS GO DOWN HERE
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!





    /// <summary>
    /// checks to see if the player is alive. If not, switch to the game over screen
    /// </summary>
    public void CheckIfDead()
    {
        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(1);
        }
    }





    /// <summary>
    /// subtracts health from the player character and calls for the player to become invincible
    /// 
    /// if player is invincible, dont take damage
    /// </summary>
    /// <param name="damageToTake"></param>
    public void TakeDamage(int damageToTake)
    {

        if (isInvincible == false)
        {
            health -= damageToTake;
            StartCoroutine(TurnInvincible());
        }
    }





    /// <summary>
    /// prevents the player from taking damage for 5 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator TurnInvincible()
    {
        if (isInvincible == false)
        {
            isInvincible = true;
            InvokeRepeating("toggleBlink", 0f, 0.25f);
            yield return new WaitForSeconds(invicibilityTime);
            isInvincible = false;
            CancelInvoke();
            playerRenderer.enabled = true;
        }
    }





    /// <summary>
    /// makes the player capsule invisible or visible based on its current visibility
    /// </summary>
    private void toggleBlink()
    {
        //print(gameObject.name);
        if (playerRenderer.enabled == true)
        {
            playerRenderer.enabled = false;
        }
        else
        {
            playerRenderer.enabled = true;
        }
    }
}