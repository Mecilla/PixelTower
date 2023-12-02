using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;

    // K�p�n sol tarafta olup olmad���n� belirleyen de�i�ken.
    private bool solTaraf = true;

    // Sol ve sa� duvarlar�n bile�enleri.
    private GameObject solDuvar, sagDuvar;
    public AudioClip DamageSound; // hasar toplama sesi
    public AudioClip HealSound; // can toplama sesi
    public AudioClip jumpSound; // z�plama sesi

    public GameObject hasarResmi; // Resmi bu alana s�r�kleyin veya script i�inde atay�n
    private bool hasarAlindi = false;

    // GameManager bile�enini bul ve atama yap
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();// Bulunan GameManager bile�enini gameManager de�i�kenine atar
    }

    private void Start()
    {
        // Sol ve sa� duvarlar�n oyun nesnelerini al.
        solDuvar = GameObject.FindWithTag("SolDuvar");
        sagDuvar = GameObject.FindWithTag("SagDuvar");
    }

    // Her frame i�in �a�r�l�r.
    private void Update()
    {
        // Kullan�c� sol t�klama yapt�ysa
        if (Input.GetMouseButtonDown(0))
        {
            transform.Rotate(0f, 0f, 180f); // Z ekseni etraf�nda 180 derece d�n��
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);

            // E�er k�p sol taraftaysa,
            if (solTaraf)
            {
                // k�p� sa� tarafa ta��yan animasyonu ba�lat.
                transform.DOMove(sagDuvar.transform.position + new Vector3(-0.96f, 0f, 0f), 0.15f).SetEase(Ease.Linear);

                solTaraf = false;
            }
            // E�er k�p sa� taraftaysa,
            else
            {
                // k�p� sol tarafa ta��yan animasyonu ba�lat.
                transform.DOMove(solDuvar.transform.position + new Vector3(0.96f, 0f, 0f), 0.15f).SetEase(Ease.Linear);

                solTaraf = true;
            }
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Coin"))
        {
            gameManager.CollectCoin();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            // Kazand�n�z tag'ine sahip objeyle temas ger�ekle�ti
            gameManager.WinGame(); // Kazand�n�z panelini a�
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Enemy tag�na sahip objeyle �arp��ma ger�ekle�ti

            // Oyuncunun can�n� azalt
            PlayerTakeDmg(1);
            AudioSource.PlayClipAtPoint(DamageSound, transform.position);

            Debug.Log("Player Health: " + GameManager.Instance._playerHealth.Health);
            
        }
        if (collision.gameObject.CompareTag("Heal"))
        {
            // �arp��an objeyi yok et
            Destroy(collision.gameObject);
            PlayerHeal(1);
            Debug.Log("Player Health: " + GameManager.Instance._playerHealth.Health);
            AudioSource.PlayClipAtPoint(HealSound, transform.position);
        }


        
        //can degeri 0 yada alt�ysa 
        else if(GameManager.Instance._playerHealth.Health <= 0) 
        {
            gameManager.PlayerDied();
        }
        gameManager.CollectHP(); // can degeri
    }


    // Oyuncunun hasar almas�n� sa�lar
    private void PlayerTakeDmg(int dmg)
    {
        GameManager.Instance._playerHealth.DmgUnit(dmg);
        StartCoroutine(GosterVeGizle());
    }

    // Oyuncunun iyile�mesini sa�lar
    private void PlayerHeal(int healing)
    {
        GameManager.Instance._playerHealth.HealUnit(healing);
    }

    IEnumerator GosterVeGizle()
    {
        hasarAlindi = true;
        hasarResmi.SetActive(true);

        yield return new WaitForSeconds(0.4f); // Resmin 1 saniye boyunca g�r�nmesini sa�lar

        hasarResmi.SetActive(false);
        hasarAlindi = false;
    }
}
