using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public bool dead = false;

    public float bulletSpeed;
    public Transform bullet; //Mermi
    Transform muzzle; //Namlu

    //Ald���m�z hasar� ekranda g�stermek i�in kullanaca��m�z de�i�ken
    public Transform floatingText;

    //CAN BARIMIZ ���N de�i�ken tan�ml�yoruz
    public Slider slider;

    
    // Start is called before the first frame update
    void Start()
    {
        //Mermimiz Player in child i oldu�undan dolay� transformumuzun 1 indexli childi olarak yapabiliyoruz.
        muzzle = transform.GetChild(1);

        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootBullet();
        }
    }

    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text=damage.ToString();
        slider.value = health;
        
        if ((health-damage)>=0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        AmIDead();
    }

    public void AmIDead()
    {
        if (health<=0)
        {
            dead = true;
        }
    }

    void shootBullet()
    {
        //Ge�ici de�i�ken
        Transform tempBullet;

        //Kur�unu olu�turmak i�in kulland���m�z method kur�unu �ncesinde Prefab olarak ayarlam��t�k.
        tempBullet = Instantiate(bullet,muzzle.position,Quaternion.identity);
        //1.Parametre ne olu�turulaca��, 2. Parametre nerede olu�turulaca�� yani konumu
        //3.Parametre ise nas�l bir davran�� sergileyece�i kendi davran���n� yapmas�n� istersek Quaternion.indentity kullan�r�z.

        /*KEND� KODLAMAM
        if (this.GetComponent<Transform>().localScale.x>0)
        {
            tempBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, 0));
        }
        else
        {
            tempBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletSpeed, 0));
        }*/

        //DAHA KOLAY YOLU e�er bu y�ntemi kullanacaksak forward z eksenini g�steriyor onu de�i�tirmek gerek UNUTULMAMALI
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);

    }
}
