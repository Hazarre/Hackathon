using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementCountroler : MonoBehaviour
{
    private CharacterController controller;
    private PlayerStats playerStats;
    private Vector2 playerVelocity;
    public float playerSpeed = 5.0f;
    public float timeMod = 0;
    public Animator animator;
    public bool facingRight;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerStats = gameObject.GetComponent<PlayerStats>();
        facingRight = false;
    }

    void Update()
    {


        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Animator anim = GetComponent<Animator>();
        if(move.x < 0 && !facingRight){
          Flip();
        }
        if(move.x > 0 && facingRight){
          Flip();
        }
        //-----
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) ){
          anim.SetBool("IsLeft",true);
        }else{
          anim.SetBool("IsLeft",false);
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) ){
          anim.SetBool("IsRight",true);
        }else{
          anim.SetBool("IsRight",false);
        }
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) ){
          anim.SetBool("IsUp",true);
        }else{
          anim.SetBool("IsUp",false);
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) ){
          anim.SetBool("IsDown",true);
        }else{
          anim.SetBool("IsDown",false);
        }
        //-----
        int el = playerStats.getEnegryLevel();
        if(el>0){
          controller.Move(move * (Time.deltaTime + timeMod) * playerSpeed);
        }

        // if(transform.position.x < -5){
        //   transform.position = new Vector3(21.5f, transform.position.y, 0);
        // } else if(transform.position.x > 21.5f){
        //   transform.position = new Vector3(-5, transform.position.y, 0);
        // }
        //
        // if(transform.position.y < -5){
        //   transform.position = new Vector3(transform.position.x, 21.5f, 0);
        // } else if(transform.position.y > 21.5f){
        //   transform.position = new Vector3(transform.position.x, -5, 0);
        // }




    }

    void Flip(){
      facingRight = !facingRight;
      Vector3 theScale = transform.localScale;
      theScale.x *= -1;
      transform.localScale = theScale;
    }
}
