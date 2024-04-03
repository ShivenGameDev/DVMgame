using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100f;
    public float damageToFireball = 10f;
    public Animator animator;
    public Slider slider;

    private void OnTriggerEnter2D(Collider2D col)
    {
      
        if(col.tag == "Enemy")
        {
            playerHealth -= damageToFireball;
            slider.value-=damageToFireball/100.0f;
            animator.SetTrigger("Hurt");
        }
    }

    public void TakeDamageFromZombie(float damage){
        playerHealth-=damage;
        slider.value-=damage/100.0f;
        animator.SetTrigger("Hurt");
    }
}
