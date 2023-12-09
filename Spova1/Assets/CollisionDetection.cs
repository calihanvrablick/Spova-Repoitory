using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Vrablick, Calihan] & [Nguyen, Kanyon]
 * Last Updated: [12/06/2023]
 * [handles lightsaber collision with enemie(s)]
 */

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MediumEnemy" && wc.isAttacking)
        {
            Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("Hit");
        }
    }
}