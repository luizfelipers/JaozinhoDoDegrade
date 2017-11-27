using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed; //velocidade de locomoção do player

    private Rigidbody2D myRigidBody;// Declaração do RigidBody do player, para que as forças possam ser adionadas nele

    public float jumpForce;

    public Transform groundCheck;

    public float groundCheckRadius;

    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator myAnimator;


    public bool facingRight;//caso o player esteja virado pra direita, a variavel é verdadeira


    public float runSpeed;

    public float activeSpeed;


    public bool ligeiro;

	// Use this for initialization
	void Start () {

        myRigidBody = GetComponent<Rigidbody2D>(); //Inicialização do objeto myRigidBody, ao anexar o componente RigidBody do player ao objeto



        myAnimator = GetComponent<Animator>();

        facingRight = false;

        activeSpeed = moveSpeed;

        ligeiro = false;
	}
	
	// Update is called once per frame
	void Update () {





        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (Input.GetButton("Shift") ) //TOGGLE PARA MODO ÁGIL
        {
            ligeiro = true;
        
        }
        else
        {
            ligeiro = false;
            
        }

        if(ligeiro == true)
        {
            activeSpeed = runSpeed;
        }
        else
        {
            activeSpeed = moveSpeed;
        }


        if (Input.GetAxisRaw("Horizontal") > 0f) //Caso o Input horizontal (Eixo X) seja maior que zero, o player tende a ir para a direita
        {
            myRigidBody.velocity = new Vector3(activeSpeed, myRigidBody.velocity.y, 0f); //Adiciona uma velocidade nova ao Rigid Body do player. O player se move no eixo X com a sua moveSpeed, e no eixo Y permanece com a velocidade atual do objeto
            facingRight = true;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0f)//Caso o Input horizontal (Eixo X) seja menor que zero, o player tende a ir para a esquerda
        {
            myRigidBody.velocity = new Vector3(-activeSpeed, myRigidBody.velocity.y, 0f);// Adiciona uma velocidade moveSpeed negativa. Isso é, uma velocidade que tende a ir para o lado negativo (esquerda) no eixo X
            facingRight = false;
        }

        else
        {
            myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f); //Caso o Input Horizontal não for maior, nem menor que 0...Ele será 0! Sendo 0, o player não se move no eixo X, e apenas mantém sua velocidade no eixo Y.
        }

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {


            if(ligeiro == true)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, 20f, 0f);
            }
            else
            {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, 15f, 0f);
            }

            
        }


        if(facingRight == false)//caso esteja virado para a esquerda
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0); //mantém os valores padrão, uma vez que o player já é virado pra esquerda
        }
        else //caso esteja virado pra direita
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0); //Reflete a rotação do player no eixo Y
        }


        if (Input.GetButton("Fire1"))
        {

            Punch();
        }
        else {
            myAnimator.SetBool("Punching", false);
        }

        if (Input.GetButton("Fire2"))
        {

            myAnimator.SetBool("Kicking", true);
        }
        else
        {
            myAnimator.SetBool("Kicking", false);
        }


        myAnimator.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));
        myAnimator.SetBool("Grounded", isGrounded);
        myAnimator.SetFloat("vSpeed", myRigidBody.velocity.y );
	}

    public void Punch(){

        myAnimator.SetBool("Punching", true);

        
    }

}
