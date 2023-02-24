using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    Animator PlayerAnim;
    public float movespeed = 1f;
    public float jumpForce = 1f, jumpFrequancy=1f /*Z�plamaS�kl���*/,nextJumpTime;
    bool FacingRight = true;
    bool iGrounded = false;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    


   
    void Start()
    {
        rbPlayer = this.GetComponent<Rigidbody2D>();
        PlayerAnim = this.GetComponent<Animator>();
    }

    
    void Update()
    {
        HorizontalMove();
        OnGroundedCheck();

        if (rbPlayer.velocity.x<0 && FacingRight)
        {
            FlipFace();
            
        }

        else if (rbPlayer.velocity.x>0 && !FacingRight)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical")>0 && iGrounded && nextJumpTime<Time.timeSinceLevelLoad) //Dikey de�er 0 dan b�y�k giriliyorsa kullan�c� tu�a bas�yor demektir.
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequancy; //Karakterin her tu�a bast���m�zda ayn� y�ksekli�e z�plamas�n� sa�l�yoruz.
            Jump();
        }


        if (transform.position.y<-12)
        {
            SceneManager.LoadScene("InGameScene");
        }
    }

    //Her 0.02 saniyede bir �al���r yani 1 saniyede 50 kere.
    void FixedUpdate()
    {
        
    }

    void HorizontalMove()
    {
        rbPlayer.velocity = new Vector2(Input.GetAxis("Horizontal")*movespeed,rbPlayer.velocity.y);
        PlayerAnim.SetFloat("PlayerSpeed", Mathf.Abs(rbPlayer.velocity.x));
    }

    void FlipFace()
    {
        FacingRight = !FacingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        //E�er bir kuvvet ya da h�z uygulamak istersek bunu Vectorleri kullan�p olu�turabiliriz.
        rbPlayer.AddForce(new Vector2(0f, jumpForce));
    }

    void OnGroundedCheck()
    {
        iGrounded = Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius,groundCheckLayer);
        PlayerAnim.SetBool("isGroundedAnim", iGrounded);
    }



    public void Antrenman()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            
        }
    }
}
