using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Düþmanýmýza Eriþmek için bir Rigidbody2D nesnesi tanýmlýyoruz
    Rigidbody2D rbEnemy;
    
    //Karakterimiz görünmez wall a çarptýðýnda sýkýþýp bug da kalmamasý için AddForce da kullanacaðýmýz kuvvetin gücünü giriyoruz.
    public float force;
    
    //Hýzýný tanýmlýyoruz.
    public float enemySpeed;
   
    //En önemli noktalarýmýzdan birisi crash durumu
    //ontriggerenter methodu çalýþtýðýnda içerisinde crash bool unu deðiþtirip sonrasýnda dýþarda bu durumu kontrol edebiliyoruz.
    public bool crash = false;


    
    void Start()
    {
        rbEnemy = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        EnemyMove();
    }

    //Yürüme Fonksiyonumuz
    void EnemyMove()
    {

        if (crash==true)
        {
            
            
            //Speedimizi ters yöne çeviriyoruz
            enemySpeed = -enemySpeed;

            //Force kuvvetimizi uyguluyoruz.
            force = -force;

            rbEnemy.AddForce(new Vector2(force, rbEnemy.velocity.y));
            
        }
        rbEnemy.velocity = new Vector2(enemySpeed, rbEnemy.velocity.y);
        
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Wall")
        {
           
            
                
                crash = true;
            
            
            
        }
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.tag == "Wall")
    //    {
    //        crash = true;
    //    }
    //}
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag=="Wall")
        {
           
            crash = false;
        } 
    }
    
}
