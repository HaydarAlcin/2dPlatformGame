using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGameScript : MonoBehaviour
{

    //�ngameScreen ve Pause Screen i�in ba�ta game objeleri olu�turmam�z gerekiyor.
    public GameObject inGameScreen, pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Sonras�nda Her Butonumuz ��in Bir Fonksiyon Tan�ml�yoruz Play, Pause, Home, RePlay
    
    public void PauseButton()
    {
        //Zaman� Durduruyoruz.
        Time.timeScale = 0;
        
        //ingame nesnesini setActive ini false yap�yoruz tabi bu nesneye InGameScreen i eklememiz gerek.
        inGameScreen.SetActive(false);
        
        //pauseScreen nesnesini setActive ini true yap�yoruz tabi bu nesneye PauseScreen i eklememiz gerek.
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
        //Oyunu Tekrardan Ba�latmak istedi�imizde Sahney� tekrardan y�klememiz yeterli olacakt�r.
        //E�er oyunumuz durgun bir �ekilde tekrardan ba�l�yor ise demek ki �ncesinde timeScale � 0 yapm���z. 
        SceneManager.LoadScene(1);
    }

    public void HomeButton()
    {
        //Home Sahnemizi Y�kl�yoruz
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
