using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void lightsaberAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = lightsaber.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(resetAttackCooldown());
    }

    IEnumerator resetAttackCooldown()
    {
        StartCoroutine(resetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator resetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }

}
