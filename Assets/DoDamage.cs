using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public float damage;
    // Update is called once per frame
    public void Damage()
    {
        Debug.Log("ATTACK");
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position,attackRange);
                foreach(Collider2D enemy in hitObjects)
                {
                    if(enemy.tag=="Player")
                    {
                        Debug.Log("attacking");
                        enemy.GetComponent<PlayerHealth>().TakeDamageFromZombie(damage);
                    }
                }
    }
}
