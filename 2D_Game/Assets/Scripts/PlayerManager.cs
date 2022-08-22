using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public float points;
    public bool dead = false;

    //Karakter Ölünce Kan Yapýyoruz
    public Transform bloodParticle;


    public float bulletSpeed;
    public Transform bullet; //Mermi
    Transform muzzle; //Namlu

    //Aldýðýmýz hasarý ekranda göstermek için kullanacaðýmýz deðiþken
    public Transform floatingText;

    //CAN BARIMIZ ÝÇÝN deðiþken tanýmlýyoruz
    public Slider slider;

    //Mouse butonamý yoksa oyuna mý týklýyor bunu öðrenmek için bool deðiþkeni oluþturuyoruz.
    bool mouseIsNotOverUI;


    void Start()
    {
        //Mermimiz Player in child i olduðundan dolayý transformumuzun 1 indexli childi olarak yapabiliyoruz.
        muzzle = transform.GetChild(1);

        slider.maxValue = health;
        slider.value = health;
        
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Her mouse a týkladýðýmýzda ateþ etme çalýþtýðýndan dolayý buttonlara dahi týklasak karakterimiz ateþ ediyor bunun önüne geçmeliyiz.
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            shootBullet();
        }
    }

    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text=damage.ToString();
        
        
        if ((health-damage)>=0)
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
        if (health<=0)
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity),3f);
            dead = true;
            Destroy(gameObject);
        }
    }

    void shootBullet()
    {
        //Geçici deðiþken
        Transform tempBullet;

        //Kurþunu oluþturmak için kullandýðýmýz method kurþunu öncesinde Prefab olarak ayarlamýþtýk.
        tempBullet = Instantiate(bullet,muzzle.position,Quaternion.identity);
        //1.Parametre ne oluþturulacaðý, 2. Parametre nerede oluþturulacaðý yani konumu
        //3.Parametre ise nasýl bir davranýþ sergileyeceði kendi davranýþýný yapmasýný istersek Quaternion.indentity kullanýrýz.

        /*KENDÝ KODLAMAM
        if (this.GetComponent<Transform>().localScale.x>0)
        {
            tempBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, 0));
        }
        else
        {
            tempBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletSpeed, 0));
        }*/

        //DAHA KOLAY YOLU eðer bu yöntemi kullanacaksak forward z eksenini gösteriyor onu deðiþtirmek gerek UNUTULMAMALI
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        //DataManager.Instance.ShotBullet++;

    }
}
