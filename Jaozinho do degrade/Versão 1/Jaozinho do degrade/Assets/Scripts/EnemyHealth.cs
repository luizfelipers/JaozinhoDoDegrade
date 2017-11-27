using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {


    public float enemyMaxHealth;

    float currentHealth;

    public bool dead;

    public Animator bandidoAnimator;

    public PatrollerScript patrollerScript;


	// Use this for initialization
	void Start () {

        currentHealth = enemyMaxHealth;
        dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void AddDamage(float damage)
    {
        currentHealth = currentHealth - damage;

            if(currentHealth <= 0)
        {
            MakeDead();
        }



    }


     void MakeDead()
    {

        dead = true;
        bandidoAnimator.SetBool("Dead", true);
     patrollerScript.canMove = false;

    }


}
