using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertScript : MonoBehaviour {

    public PatrollerScript patrollerScript;///declaração dessa variável para poder acessar variáveis e valores da classe PatrollerScript (script dos patrulhas)

    public EnemyHealth enemyHealthScript;//declaração dessa variável para poder acessar a booleana Dead de EnemyHealth, para checar se o inimigo esta vivo

    public bool alert;// é ativada quando o player entra em estado de alerta

    public Animator bandidoAnimator;//declarado para controlar as animações referentes ao estado de alerta

    public Collider2D eyeSight;//Collisor 2d (box Collider) que vai ser usado para perceber o player na sua frente

	// Use this for initialization
	void Start () {
        alert = false; // o Inimigo NãO tem como estado padrão o de alerta

	}

    // Update is called once per frame
    void Update()
    {
        if (alert)//caso o inimigo esteja em estado de alerta
        {

            bandidoAnimator.SetBool("Aware", true);//ativa a variável do estado de alerta no Animator
            bandidoAnimator.SetBool("CanWalk", false);//desativa a locomoção do inimigo no Animador
            patrollerScript.canMove = false;//desativa o movimento do inimigo
            patrollerScript.moveSpeed = patrollerScript.stopedSpeed;//a velocidade do inimigo passa a ser a sua velocidade parado ( zero)


        }
        else//caso o inimigo não esteja em estado de alerta
        {
            patrollerScript.canMove = true;//pode se mover

            bandidoAnimator.SetBool("Aware", false);//desativa o estado de alerta
            bandidoAnimator.SetBool("CanWalk", true);//volta a se mover

            patrollerScript.moveSpeed = patrollerScript.normalSpeed;//retoma sua velocidade normal

        }
    }

    //FUNÇÕES

       //-----ESTADO DE ALERTA-------------
    // VERIFICAÇÃO DO PLAYER ENTRANDO NA VISÃO DO INIMIGO


    void OnTriggerStay2D(Collider2D collision)//quando o trigger da visão do inimigo alcança o collisor do player
    {
        if (collision.tag == "Player")  //caso o trigger detecte um objeto colisor com tag Player, ativa a variável Alert
        {
            alert = true;
           

            
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")//Quando o player sai do trigger do inimigo, o inimigo sai do estado de alerta
        {
            alert = false;
          
           

        }
    }
}
