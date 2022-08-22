using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    public int points;


    public Transform pointsPlayer;
    public GameObject coin;
    

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }

    public void crash()
    {
        
            points++;
            Debug.Log(points);
        
    }
    
}
