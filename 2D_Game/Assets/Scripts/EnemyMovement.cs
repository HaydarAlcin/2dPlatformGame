using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //D��man�m�za Eri�mek i�in bir Rigidbody2D nesnesi tan�ml�yoruz
    Rigidbody2D rbEnemy;
    
    //Karakterimiz g�r�nmez wall a �arpt���nda s�k���p bug da kalmamas� i�in AddForce da kullanaca��m�z kuvvetin g�c�n� giriyoruz.
    public float force;
    
    //H�z�n� tan�ml�yoruz.
    public float enemySpeed;
   
    //En �nemli noktalar�m�zdan birisi crash durumu
    //ontriggerenter methodu �al��t���nda i�erisinde crash bool unu de�i�tirip sonras�nda d��arda bu durumu kontrol edebiliyoruz.
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

    //Y�r�me Fonksiyonumuz
    void EnemyMove()
    {

        if (crash==true)
        {
            
            
            //Speedimizi ters y�ne �eviriyoruz
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
