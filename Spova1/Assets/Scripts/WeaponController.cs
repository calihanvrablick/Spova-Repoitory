using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Vrablick, Calihan] & [Nguyen, Kanyon]
 * Last Updated: [12/06/2023]
 * [handles all objects and animations in the WeaponcController folder]
 */

public class WeaponController : MonoBehaviour
{
    public GameObject lightsaber;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;

    public bool isAttacking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {
                lightsaberAttack();
            }
        }
    }

    /// <summary>
    /// handles lightsaber attack with animation
    /// </summary>
    public void lightsaberAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = lightsaber.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(resetAttackCooldown());
    }

    //resetting the attack cooldown back to normal
    IEnumerator resetAttackCooldown()
    {
        StartCoroutine(resetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    //resetting the isAttacking status to normal
    IEnumerator resetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }

}
