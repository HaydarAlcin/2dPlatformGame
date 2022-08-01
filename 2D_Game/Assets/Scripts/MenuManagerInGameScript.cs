using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGameScript : MonoBehaviour
{

    //ÝngameScreen ve Pause Screen için baþta game objeleri oluþturmamýz gerekiyor.
    public GameObject inGameScreen, pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Sonrasýnda Her Butonumuz Ýçin Bir Fonksiyon Tanýmlýyoruz Play, Pause, Home, RePlay
    
    public void PauseButton()
    {
        //Zamaný Durduruyoruz.
        Time.timeScale = 0;
        
        //ingame nesnesini setActive ini false yapýyoruz tabi bu nesneye InGameScreen i eklememiz gerek.
        inGameScreen.SetActive(false);
        
        //pauseScreen nesnesini setActive ini true yapýyoruz tabi bu nesneye PauseScreen i eklememiz gerek.
        pauseScreen.SetActive(true);
    }
    
    
    public void PlayButton()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }

    public void RePlayButton()
    {
        Time.timeScale = 1;
        //Oyunu Tekrardan Baþlatmak istediðimizde Sahneyþ tekrardan yüklememiz yeterli olacaktýr.
        //Eðer oyunumuz durgun bir þekilde tekrardan baþlýyor ise demek ki öncesinde timeScale ý 0 yapmýþýz. 
        SceneManager.LoadScene(1);
    }

    public void HomeButton()
    {
        //Home Sahnemizi Yüklüyoruz
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
