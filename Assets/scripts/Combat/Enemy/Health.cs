using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth=100;
    int currentHealth;
    public Animator animator;
    public Slider slider;

    void Start()
    {
        currentHealth=maxHealth;
    }

    public void TakeDamage(int damage){
        currentHealth-=damage;
        slider.value-=damage/100.0f;
        //Hurt anim
        animator.SetTrigger("Hurt");
        if(currentHealth<=0){
            Die();
            Object.Destroy(this.gameObject);
        }
    }   
    void Die(){
        //Die anim
        animator.SetBool("isDead",true);
        Debug.Log("Enemy died");
    }
    void dest(){
        Object.Destroy(this.gameObject);
    }
}
