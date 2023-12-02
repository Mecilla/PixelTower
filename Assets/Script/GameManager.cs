using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }    // Singleton instance

    public AudioClip coinCollectSound; // Alt�n toplama sesi

    public GameObject playerDead;
    public GameObject GameOver;
    public GameObject PousePanel;
    public GameObject winPanel; // Kazand�n�z paneli objesi

    public string NEXT;



    public string GoSahne; // Ana men� sahnesinin ad�n� buraya atay�n.

    public HP _playerHealth = new HP(3, 3); // can ayar�

    public Text scoreHPText; // Can Tablosu
    

    public Text scoreText; //score tablosu
    public Text scorGameOver; //game over tablosu
    public int score = 0; // Oyuncunun skoru

    // ... Di�er de�i�kenleriniz ve metotlar�n�z ...

    public void Start()
    {
        winPanel.SetActive(false); // Kazand�n�z panelini ba�lang��ta kapal� yap
    }

    public void WinGame()
    {
        Time.timeScale = 0; // Oyunu duraklat
        winPanel.SetActive(true); // Kazand�n�z panelini a�
    }


    // "Tekrar Oyna" butonuna t�klan�nca �a�r�lacak metod
    public void RestartLevel()
    {
        Time.timeScale = 1; // Oyunu tekrar ba�lat
        winPanel.SetActive(false); // Kazand�n�z panelini kapat
        // Burada gerekli di�er i�lemleri de ekleyebilirsiniz
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // "Sonraki B�l�me Ge�" butonuna t�klan�nca �a�r�lacak metod
    public void NextLevel()
    {
        SceneManager.LoadScene(NEXT); // Burada sonraki b�l�me ge�i� yapabilirsiniz, "level2" sahnenin ad�n� temsil ediyor
        Time.timeScale = 1; // Oyun h�z�n� s�f�rla
        winPanel.SetActive(false); // Kazand�n�z panelini kapat
                                   // Gerekirse di�er i�lemleri burada ekleyebilirsiniz
    }

    // "Ana Men�ye D�n" butonuna t�klan�nca �a�r�lacak metod
    public void MainMenu()
    {
        // Burada ana men�ye d�n veya di�er i�lemleri ekleyebilirsiniz
    }


    private void Awake()
    {
        // Singleton �rne�ini kontrol etmek i�in Awake metodu
        if (Instance != null && Instance != this)
        {
            // Mevcut bir Instance �rne�i varsa ve bu �rnek kendisi de�ilse, kendisini yok et
            Destroy(this);
        }
        else
        {
            // Instance �rne�i hen�z atanmam��sa veya bu �rnekse, Instance'a kendini ata
            Instance = this;
        }
    }


    private void Update()
    {
        // ... Update metodu i�eri�i ...
    }

    // Para al�nd���nda yap�lacak i�lemler
    public void CollectCoin()
    {
        score += 10;
        scoreText.text = "= " + score.ToString();
        scorGameOver.text = "= " + score.ToString();

        // Skorun g�ncellendi�i di�er i�lemleri buraya ekleyebilirsiniz.

        // Ses �alma kodu
        AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
    }

    //can bari
    public void CollectHP()
    {
        
        scoreHPText.text ="= " + _playerHealth.Health.ToString();

    }


    // Oyuncu �ld���nde �a�r�lacak metot
    public void PlayerDied()
    {
        // ... PlayerDied metodu i�eri�i ...
        GameOver.SetActive(true);
        playerDead.SetActive(false);
        Time.timeScale = 0; // Zaman �l�e�ini 0 yaparak oyunu duraklat
    }

    public void Pause()
    {
        PousePanel.SetActive(true); // Durdurma panelini aktifle�tir
        Time.timeScale = 0; // Zaman �l�e�ini 0 yaparak oyunu duraklat
    }

    // Oyunu devam ettirme i�lemleri
    public void Continue()
    {
        PousePanel.SetActive(false); // Durdurma panelini pasifle�tir
        Time.timeScale = 1; // Zaman �l�e�ini 1 yaparak oyunu devam ettir
    }

    public void AnaMenuyeDonButton()
    {
        SceneManager.LoadScene(GoSahne); // Ana men� sahnesine ge�i� yap.
        Time.timeScale = 1; // Zaman �l�e�ini 1 yaparak oyunu devam ettir
    }

    // ... Di�er metotlar�n�z ...

    // ... Yeni metodunuzu ekleyin ...
}