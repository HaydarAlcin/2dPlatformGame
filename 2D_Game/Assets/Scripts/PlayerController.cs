using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    Animator PlayerAnim;
    public float movespeed = 1f;
    public float jumpForce = 1f, jumpFrequancy=1f /*ZýplamaSýklýðý*/,nextJumpTime;
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

        if (Input.GetAxis("Vertical")>0 && iGrounded && nextJumpTime<Time.timeSinceLevelLoad) //Dikey deðer 0 dan büyük giriliyorsa kullanýcý tuþa basýyor demektir.
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequancy; //Karakterin her tuþa bastýðýmýzda ayný yüksekliðe zýplamasýný saðlýyoruz.
            Jump();
        }


        if (transform.position.y<-12)
        {
            SceneManager.LoadScene("InGameScene");
        }
    }

    //Her 0.02 saniyede bir çalýþýr yani 1 saniyede 50 kere.
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
        //Eðer bir kuvvet ya da hýz uygulamak istersek bunu Vectorleri kullanýp oluþturabiliriz.
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
