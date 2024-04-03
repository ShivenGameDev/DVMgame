using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMeleeAttack : MonoBehaviour
{
    public Transform playerTransform;
    public float attackInterval = 1f;
    private float attackTimer = 0f;
    Vector3 direction;
    public Animator animator;
    RaycastHit2D hit;
    public bool isInRange=false;
    public float attackRange=10f;
    public Transform attackPoint;
    public GameObject zombie;
    void Start()
    {
        // Find the player GameObject
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if it's time to attack
        attackTimer += Time.deltaTime;

        // Calculate direction towards the player
        direction = (playerTransform.position - transform.position).normalized;
        Vector3 newScale = zombie.transform.localScale;

        if(direction.x>0)
            newScale.x = 0.9f;
        else
            newScale.x = -0.9f;
        zombie.transform.localScale = newScale;
        
        if (attackTimer >= attackInterval)
        {
            attackTimer=0f;
            if(isInRange){
                Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position,attackRange);
                foreach(Collider2D enemy in hitObjects)
                {
                    if(enemy.tag=="Player")
                    {
                        animator.SetTrigger("Attack");
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.GetComponent<Collider2D>().gameObject.tag=="Player"){
            isInRange=true;
            Debug.Log("Player entered");
        }
    }
    private void OnTriggerExit2D(Collider2D col){
        if(col.GetComponent<Collider2D>().gameObject.tag=="Player"){
            isInRange=false;
            Debug.Log("Player left");
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
    
}
