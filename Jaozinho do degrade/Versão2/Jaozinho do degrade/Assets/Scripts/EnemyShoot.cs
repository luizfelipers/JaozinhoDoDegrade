using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {// SCRIPT PARA CONTROLAR O COMPORTAMENTO DO INIMIGO PARA ATIRAR



    public PatrollerScript patrollerScript;//declaração dessa variável para poder acessar variáveis e valores da classe PatrollerScript (script dos patrulhas)

    public AlertScript alertScript;//declaração dessa variável para poder acessar variáveis e valores do script de estado de alerta

    public float shotCounter;//contador que será decrementado pelo tempo

    public float waitBetweenShots;//intervalo de tempo entre um tiro e outro



    

    public Animator bandidoAnimator;///declaração dessa variável para poder acessar controlar variáveis do animador -- Mudar as variáveis para acionar a animação de atirar


    // Use this for initialization
    void Start () {
        shotCounter = waitBetweenShots;//o contador recebe o valor atribuido na variável refenrete ao intervalo
    }
	
	// Update is called once per frame
	void Update () {



        if (alertScript.alert == true)//caso o jogador esteja em estado de alerta (Estado de alerta definido e controlado em outro script)
        {
            shotCounter -= Time.deltaTime; //decrementa o contador
            AttackPlayer();//chama a função de ataque 

        }
	}




    public void AttackPlayer()
    {
       
        
            if (shotCounter <= 0)//caso o contador atinja 0
            {
                bandidoAnimator.SetBool("Shoot", true);//ativa a booleana que controla a animação de atirar
                shotCounter = waitBetweenShots;//reseta o valor do contador, para o valor do intervalo

                
            }
            else
            {
                bandidoAnimator.SetBool("Shoot", false);//caso o contador ainda não tenha atingido 0, a animação é falsa
            }



        
    }






}
