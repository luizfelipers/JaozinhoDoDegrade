using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerScript : MonoBehaviour
{
    public Animator bandidoAnimator;//declaração do Animator do bandido, para que seja possivel controlar as animações dele patrulhando


    

    public Transform leftPoint; //variável do tipo Transform, pois só precisamos saber a posição do gameObject, para servir de limite para o patroller 
    public Transform rightPoint; //variável do tipo Transform, pois só precisamos saber a posição do gameObject, para servir de limite para o patroller 

    public float moveSpeed; //velocidade  atual do inimigo

    private Rigidbody2D myRigidBody;//variável que controlará o componente RigidBody2D do gameObject anexado
    private SpriteRenderer myRenderer;//variável utilizada para controlar o Sprite Renderer da aranha, para poder Flipar o sprite dela, dependendo da direção que estiver andando

    

    public bool movingRight;//booleana que dita se o inimigo está se movendo para a direita

    public float stopedSpeed;//variável que contém a velocidade do inimigo parado (zero)
    public float normalSpeed;//variável que contem a velocidade do bandido


    public bool canMove;

    

    public EnemyHealth enemyHealthscript;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        canMove = true;

        
        
    }

    // Update is called once per frame
    void Update()
    {


        

        if (enemyHealthscript.dead == false)// SE O INIMIGO ESTIVER VIVO
        {
           


            if (canMove == true)
            { //caso o inimigo puder andar



                if (movingRight == true && transform.position.x > rightPoint.position.x)//caso o inimigo esteja andando pra direita e tenha passado pelo rightPoint no eixoX
                {

                    movingRight = false;//vira pra esquerda
                }
                if (movingRight == false && transform.position.x < leftPoint.position.x)//caso o inimigo esteja andando pra esquerda e tenha passado pelo lefttPoint no eixoX
                {

                    movingRight = true;//vira pra direita

                }




                if (movingRight == true)//Caso o bandido esteja virado pra direita
                {

                    transform.localRotation = Quaternion.Euler(0, 180, 0); //Reflete a imagem do inimigo 
                    myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);//adiciona uma força para a direita


                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0); //mantem a rotação normal do inimigo, pois está virado para a esquerda
                    myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);//força negativa (para a esquerda no eixo X)
                }

                
                

            }
            


        }



        else
        {
            canMove = false;

        }
    }


   

}