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

    // Collider a deðdiðinde çalýþan methotdur.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player"&& !colliderBusy)
        {
            colliderBusy = true;
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
    }

    
    
    
    /* Collider ýn içinde bulunduðu süre boyunca çalýþan methotdur.
    private void OnTriggerStay2D(Collider2D other)
    {
        
    }*/

        //Collider la baðlantýsýný kestiðinde çalýþan methotdur.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            colliderBusy = false;
        }
    }
}
