using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Vrablick, Calihan] & [Nguyen, Kanyon]
 * Last Updated: [12/06/2023]
 * [Controls the movement of the easy enemy]
 */

public class MediumEnemy : MonoBehaviour
{
    private GameObject player;

    [SerializeField] public int contactDamage = 0;

    [SerializeField] private float timer = 5;
    public float bulletTime;

    public GameObject enemyBullet;
    public Transform SpawnPoint;

    public float bulletSpeed;

    public int health;

    // Update is called once per frame
    void Update()
    {
        GameObject[] allGameObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject thisObject in allGameObjects)
        {
            if (thisObject.name == "Player")
            {
                player = thisObject;
            }
        }

        this.gameObject.transform.LookAt(player.transform);
        shootAtPlayer();

        if (health <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// allows medium enemy to shoot at player x amount of times in x seconds
    /// </summary>
    void shootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(bulletObj, 5f);
    }
}
