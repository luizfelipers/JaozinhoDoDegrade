using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {


    public float enemyMaxHealth;//Variável que controla a vida máxima do inimigo

    float currentHealth;//variável refente a vida atual do player, a cada frame

    public bool dead;//variável que controla se o inimigo está morto o unão

    public Animator bandidoAnimator;//controlar aas variaveis do animador

    public PatrollerScript patrollerScript;//poder controlar o movimento do inimigo


	// Use this for initialization
	void Start () {

        currentHealth = enemyMaxHealth;//inimigo inicia com a vida cheia
        dead = false;//começa vivo
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void AddDamage(float damage)//Função AddDamage recebe um valor Damage
    {
        currentHealth = currentHealth - damage;     //O dano é subtraído da vida atual do player

            if(currentHealth <= 0)  //caso a vida do player esteja zerada, ele morre
        {
            MakeDead();//chama função de morrer
        }



    }


     void MakeDead()
    {

        dead = true;//ativa a booleana referente ao estado do inimigo
        bandidoAnimator.SetBool("Dead", true);//ativa o booleano no animador
     patrollerScript.canMove = false;//trava o movimento do player

    }


}
