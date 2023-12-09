using System;
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
    private float laserCooldown = 10f;

    public GameObject enemyBullet;
    public float bulletSpeed;


    private Boolean laserAttackDebounce = false;


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
        if (laserAttackDebounce == false)
        {
            StartCoroutine(LaserCooldown());
        }
        transform.localPosition = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (health <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            //player.GetComponent<PlayerHandler>()
        }
    }


    /*
    public void LaserAttack()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(bulletObj, 5f);
    }
    */
    public void LaserSpin()
    {

    }



    /// <summary>
    /// handles the cooldown of the laser attack so it doesnt get spammed
    /// </summary>
    /// <returns></returns>
    IEnumerator LaserCooldown()
    {
        laserAttackDebounce = true;
        yield return new WaitForSeconds(laserCooldown);
        laserAttackDebounce = false;
    }
}
