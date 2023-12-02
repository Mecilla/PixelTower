using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }    // Singleton instance

    public AudioClip coinCollectSound; // Altýn toplama sesi

    public GameObject playerDead;
    public GameObject GameOver;
    public GameObject PousePanel;
    public GameObject winPanel; // Kazandýnýz paneli objesi

    public string NEXT;



    public string GoSahne; // Ana menü sahnesinin adýný buraya atayýn.

    public HP _playerHealth = new HP(3, 3); // can ayarý

    public Text scoreHPText; // Can Tablosu
    

    public Text scoreText; //score tablosu
    public Text scorGameOver; //game over tablosu
    public int score = 0; // Oyuncunun skoru

    // ... Diðer deðiþkenleriniz ve metotlarýnýz ...

    public void Start()
    {
        winPanel.SetActive(false); // Kazandýnýz panelini baþlangýçta kapalý yap
    }

    public void WinGame()
    {
        Time.timeScale = 0; // Oyunu duraklat
        winPanel.SetActive(true); // Kazandýnýz panelini aç
    }


    // "Tekrar Oyna" butonuna týklanýnca çaðrýlacak metod
    public void RestartLevel()
    {
        Time.timeScale = 1; // Oyunu tekrar baþlat
        winPanel.SetActive(false); // Kazandýnýz panelini kapat
        // Burada gerekli diðer iþlemleri de ekleyebilirsiniz
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // "Sonraki Bölüme Geç" butonuna týklanýnca çaðrýlacak metod
    public void NextLevel()
    {
        SceneManager.LoadScene(NEXT); // Burada sonraki bölüme geçiþ yapabilirsiniz, "level2" sahnenin adýný temsil ediyor
        Time.timeScale = 1; // Oyun hýzýný sýfýrla
        winPanel.SetActive(false); // Kazandýnýz panelini kapat
                                   // Gerekirse diðer iþlemleri burada ekleyebilirsiniz
    }

    // "Ana Menüye Dön" butonuna týklanýnca çaðrýlacak metod
    public void MainMenu()
    {
        // Burada ana menüye dön veya diðer iþlemleri ekleyebilirsiniz
    }


    private void Awake()
    {
        // Singleton örneðini kontrol etmek için Awake metodu
        if (Instance != null && Instance != this)
        {
            // Mevcut bir Instance örneði varsa ve bu örnek kendisi deðilse, kendisini yok et
            Destroy(this);
        }
        else
        {
            // Instance örneði henüz atanmamýþsa veya bu örnekse, Instance'a kendini ata
            Instance = this;
        }
    }


    private void Update()
    {
        // ... Update metodu içeriði ...
    }

    // Para alýndýðýnda yapýlacak iþlemler
    public void CollectCoin()
    {
        score += 10;
        scoreText.text = "= " + score.ToString();
        scorGameOver.text = "= " + score.ToString();

        // Skorun güncellendiði diðer iþlemleri buraya ekleyebilirsiniz.

        // Ses çalma kodu
        AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
    }

    //can bari
    public void CollectHP()
    {
        
        scoreHPText.text ="= " + _playerHealth.Health.ToString();

    }


    // Oyuncu öldüðünde çaðrýlacak metot
    public void PlayerDied()
    {
        // ... PlayerDied metodu içeriði ...
        GameOver.SetActive(true);
        playerDead.SetActive(false);
        Time.timeScale = 0; // Zaman ölçeðini 0 yaparak oyunu duraklat
    }

    public void Pause()
    {
        PousePanel.SetActive(true); // Durdurma panelini aktifleþtir
        Time.timeScale = 0; // Zaman ölçeðini 0 yaparak oyunu duraklat
    }

    // Oyunu devam ettirme iþlemleri
    public void Continue()
    {
        PousePanel.SetActive(false); // Durdurma panelini pasifleþtir
        Time.timeScale = 1; // Zaman ölçeðini 1 yaparak oyunu devam ettir
    }

    public void AnaMenuyeDonButton()
    {
        SceneManager.LoadScene(GoSahne); // Ana menü sahnesine geçiþ yap.
        Time.timeScale = 1; // Zaman ölçeðini 1 yaparak oyunu devam ettir
    }

    // ... Diðer metotlarýnýz ...

    // ... Yeni metodunuzu ekleyin ...
}