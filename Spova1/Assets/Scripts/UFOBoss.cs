using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 * Author: [Nguyen, Kanyon] & [Vrablick, Calihan]
 * Last Updated: [12/08/2023]
 * [Handles the collisions and attacks of the UFO.]
 */
public class UFOBoss : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public int health;

    public int contactDamage;
    public int damage;

    private float speed = 2.25f;



    // Start is called before the first frame update
    void Start()
    {
        GameObject[] allGameObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject thisObject in allGameObjects)
        {
            if (thisObject.name == "Player")
            {
                player = thisObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (health <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
