using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Vrablick, Calihan] & [Nguyen, Kanyon]
 * Last Updated: [12/06/2023]
 * [Controls the movement of the easy enemy]
 */

public class EasyEnemy : MonoBehaviour
{
    //game objects to determine how far left/right enemy goes
    public GameObject leftPoint;
    public GameObject rightPoint;

    public int contactDamage = 0;
    public int health = 1;

    //boundaries for left/right
    private Vector3 leftPosition;
    private Vector3 rightPosition;

    //how fast the enemy travels
    public float speed = 5;

    //the direction it is going
    public bool goingLeft;

    // Start is called before the first frame update
    void Start()
    {
        leftPosition = leftPoint.transform.position;
        rightPosition = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();

        if (health <=0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void EnemyMove()
    {
        if (goingLeft == true)
        {
            //once the enemy reaches the leftPos - goingLeft is false
            if (transform.position.x <= leftPosition.x)
            {
                goingLeft = false;
            }
            else
            {
                //translate the enemy left by speed using Time.deltaTime
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else
        {
            //once the enemy reaches the rightPos - goingLeft is false
            if (transform.position.x >= rightPosition.x)
            {
                goingLeft = true;
            }
            else
            {
                //translate the enemy by speed using Time.deltaTime
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
}
