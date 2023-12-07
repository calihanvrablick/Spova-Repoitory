using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject lightsaber;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {

            }
        }
    }

    public void lightsaberAttack()
    {
        canAttack = false;
        Animator anim = lightsaber.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(resetAttackCooldown());
    }

    IEnumerator resetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

}
