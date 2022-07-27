using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;

    public bool colliderBusy = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
