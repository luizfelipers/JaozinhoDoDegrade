using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollerScript : MonoBehaviour
{
    public Animator bandidoAnimator;


    public PlayerController target;

    public Transform leftPoint; //variável do tipo Transform, pois só precisamos saber a posição do gameObject, para servir de limite para o patroller 
    public Transform rightPoint; //variável do tipo Transform, pois só precisamos saber a posição do gameObject, para servir de limite para o patroller 

    public float moveSpeed; //velocidade que o inimigo andará no seu intervalo de espaço

    private Rigidbody2D myRigidBody;//variável que controlará o componente RigidBody2D do gameObject anexado
    private SpriteRenderer myRenderer;//variável utilizada para controlar o Sprite Renderer da aranha, para poder Flipar o sprite dela, dependendo da direção que estiver andando

    public Transform awareRangeView;


    public bool movingRight;

    public float stopedSpeed;
    public float normalSpeed;


    public bool canMove;

    public float shotCounter;

    public float waitBetweenShots;

    public bool alert;

    public float shootingTimer;

    public EnemyHealth enemyHealthscript;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        target = FindObjectOfType<PlayerController>();//acha um objeto do tipo Player Controller, que no caso, só existe um (PLAYER), e linka esse objeto a variavel
        canMove = true;


        shotCounter = waitBetweenShots;
        awareRangeView.gameObject.SetActive(true);
        alert = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (enemyHealthscript.dead == false)
        {
            if (alert)
            {
                shotCounter -= Time.deltaTime;
                AttackPlayer();
            }




            if (movingRight == true && transform.position.x > rightPoint.position.x)//caso a aranha esteja andando pra direita e tenha passado pelo rightPoint no eixoX
            {

                movingRight = false;
            }
            if (movingRight == false && transform.position.x < leftPoint.position.x)
            {

                movingRight = true;

            }
            if (movingRight == true)//Caso o bandido esteja virado pra direita
            {
                if (canMove == true)
                {
                    myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);


                }
                else
                {

                    myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
                }


                //myRenderer.flipX = true;


                transform.localRotation = Quaternion.Euler(0, 180, 0); //Reflete a rotação do player no eixo Y




                if (target.gameObject.transform.position.x < awareRangeView.position.x && target.gameObject.transform.position.x > gameObject.transform.position.x)
                {
                    bandidoAnimator.SetBool("Aware", true);
                    bandidoAnimator.SetBool("CanWalk", false);
                    canMove = false;
                    moveSpeed = stopedSpeed;
                    alert = true;

                }
                else
                {
                    bandidoAnimator.SetBool("Aware", false);
                    bandidoAnimator.SetBool("CanWalk", true);
                    canMove = true;
                    moveSpeed = normalSpeed;
                    alert = false;
                }


            }



            else
            {



                if (canMove == true)
                {

                    myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);



                }
                else
                {

                    myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
                }
                {

                    // myRenderer.flipX = false;
                    transform.localRotation = Quaternion.Euler(0, 0, 0); //mantém os valores padrão, uma vez que o player já é virado pra esquerda

                    if (target.gameObject.transform.position.x > awareRangeView.position.x && target.gameObject.transform.position.x < gameObject.transform.position.x)
                    {
                        bandidoAnimator.SetBool("Aware", true);
                        bandidoAnimator.SetBool("CanWalk", false);
                        canMove = false;
                        moveSpeed = stopedSpeed;
                        alert = true;
                    }
                    else
                    {
                        bandidoAnimator.SetBool("Aware", false);
                        bandidoAnimator.SetBool("CanWalk", true);
                        canMove = true;
                        moveSpeed = -normalSpeed;
                        alert = false;

                    }

                }


            }
        }


       else 
        {

            awareRangeView.gameObject.SetActive(false);
            canMove = false;
            bandidoAnimator.SetBool("CanWalk", false);
        }

      //  if (alert)
        //{
          //  shotCounter -= Time.deltaTime;
            //AttackPlayer();
        //}

        


       // if (movingRight == true && transform.position.x > rightPoint.position.x)//caso a aranha esteja andando pra direita e tenha passado pelo rightPoint no eixoX
       // {

      //      movingRight = false;
      //  }
     //   if (movingRight == false && transform.position.x < leftPoint.position.x)
      //  {
//
      //      movingRight = true;
//
      //  }
      //  if (movingRight == true)//Caso o bandido esteja virado pra direita
      //  {
       //     if (canMove == true)
       //     {
         //       myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);

//
       //     }
      //      else
       //     {
      //         
       //         myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
       //     }


            //myRenderer.flipX = true;


         //   transform.localRotation = Quaternion.Euler(0, 180, 0); //Reflete a rotação do player no eixo Y




         //   if (target.gameObject.transform.position.x < awareRangeView.position.x && target.gameObject.transform.position.x > gameObject.transform.position.x)
           // {
            //    bandidoAnimator.SetBool("Aware", true);
            //    bandidoAnimator.SetBool("CanWalk", false);
            //    canMove = false;
            //    moveSpeed = stopedSpeed;
            //    alert = true;

           // }
         //   else
         //   {
          //      bandidoAnimator.SetBool("Aware", false);
         //       bandidoAnimator.SetBool("CanWalk", true);
         //       canMove = true;
         //       moveSpeed = normalSpeed;
             //   alert = false;
           // }


      //  }



      //  else
       // {



       //     if (canMove == true)
       //     {
                
        //        myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);



          //  }
           // else
          //  {
               
             //   myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
           // }
           // {

                // myRenderer.flipX = false;
              //  transform.localRotation = Quaternion.Euler(0, 0, 0); //mantém os valores padrão, uma vez que o player já é virado pra esquerda

              //  if (target.gameObject.transform.position.x > awareRangeView.position.x && target.gameObject.transform.position.x < gameObject.transform.position.x)
              //  {
              //      bandidoAnimator.SetBool("Aware", true);
             //       bandidoAnimator.SetBool("CanWalk", false);
               //     canMove = false;
                 //   moveSpeed = stopedSpeed;
                   // alert = true;
                //}
               // else
                //{
                  //  bandidoAnimator.SetBool("Aware", false);
                    //bandidoAnimator.SetBool("CanWalk", true);
                 //   canMove = true;
                 //   moveSpeed = -normalSpeed;
                   // alert = false;
        //
          //      }

          //  }


        //}
    }

    public void AttackPlayer()
    {
        if (target.isActiveAndEnabled)
        {
            if (shotCounter < 0)
            {
                bandidoAnimator.SetBool("Shoot", true);
                shotCounter = waitBetweenShots;

              //  if (shootingTimer <= 0)
                //{
                  //  shotCounter = waitBetweenShots;
                    //bandidoAnimator.SetBool("Shoot", false);
                //}
                
            }
            else
            {
                bandidoAnimator.SetBool("Shoot", false);
            }



        }
    }

}