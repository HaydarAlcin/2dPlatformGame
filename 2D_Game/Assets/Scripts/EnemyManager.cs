using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;

    public bool colliderBusy = false;

    //D��man�n can bar� i�in olu�turdu�umuz public bir de�i�ken
    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Collider a de�di�inde �al��an methotdur.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player"&& !colliderBusy)
        {
            colliderBusy = true;
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }

        else if (other.tag=="Bullet")
        {
            GetDamage(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
    }

    
    
    
    /* Collider �n i�inde bulundu�u s�re boyunca �al��an methotdur.
    private void OnTriggerStay2D(Collider2D other)
    {
        
    }*/

        //Collider la ba�lant�s�n� kesti�inde �al��an methotdur.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            colliderBusy = false;
        }
    }

    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }

    public void AmIDead()
    {
        if (health <= 0)
        {
            //DataManager.Instance.EnemyKilled++;
            Destroy(gameObject);
        }
    }
}
