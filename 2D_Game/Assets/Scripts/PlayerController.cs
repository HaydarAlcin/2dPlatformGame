using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    Animator PlayerAnim;
    public float movespeed = 1f;

    bool FacingRight = true;
    void Awake()
    {
    }


    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = this.GetComponent<Rigidbody2D>();
        PlayerAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();

        if (rbPlayer.velocity.x<0 && FacingRight)
        {
            FlipFace();
            
        }

        else if (rbPlayer.velocity.x>0 && !FacingRight)
        {
            FlipFace();
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
}
