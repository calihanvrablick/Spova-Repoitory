using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Vrablick, Calihan] & [Nguyen, Kanyon]
 * Last Updated: [12/06/2023]
 * [provides contact rule to bullet(s)]
 */

public class Bullet : MonoBehaviour
{
    public int damage;

    [SerializeField] public int contactDamage = 0;
}
