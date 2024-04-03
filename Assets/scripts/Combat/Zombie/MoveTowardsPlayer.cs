using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float distance;
    public float moveSpeed=5f;
    Vector3 direction;
    public float triggerDistance=5f;
    public Animator animator;

    void Update()
    {
        direction = (playerTransform.position - transform.position).normalized;
        distance = Vector3.Distance(playerTransform.position,transform.position);
        if(distance<=triggerDistance){
            Vector3 targetPosition = transform.position + direction * moveSpeed * Time.deltaTime;
            animator.SetFloat("Speed",moveSpeed);
            // Move the enemy towards the player using Lerp for smooth movement
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
        }
        else{
            animator.SetFloat("Speed",0f);
        }
    }
}
