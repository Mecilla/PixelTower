using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;

    // Küpün sol tarafta olup olmadýðýný belirleyen deðiþken.
    private bool solTaraf = true;

    // Sol ve sað duvarlarýn bileþenleri.
    private GameObject solDuvar, sagDuvar;
    public AudioClip DamageSound; // hasar toplama sesi
    public AudioClip HealSound; // can toplama sesi
    public AudioClip jumpSound; // zýplama sesi

    public GameObject hasarResmi; // Resmi bu alana sürükleyin veya script içinde atayýn
    private bool hasarAlindi = false;

    // GameManager bileþenini bul ve atama yap
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();// Bulunan GameManager bileþenini gameManager deðiþkenine atar
    }

    private void Start()
    {
        // Sol ve sað duvarlarýn oyun nesnelerini al.
        solDuvar = GameObject.FindWithTag("SolDuvar");
        sagDuvar = GameObject.FindWithTag("SagDuvar");
    }

    // Her frame için çaðrýlýr.
    private void Update()
    {
        // Kullanýcý sol týklama yaptýysa
        if (Input.GetMouseButtonDown(0))
        {
            transform.Rotate(0f, 0f, 180f); // Z ekseni etrafýnda 180 derece dönüþ
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);

            // Eðer küp sol taraftaysa,
            if (solTaraf)
            {
                // küpü sað tarafa taþýyan animasyonu baþlat.
                transform.DOMove(sagDuvar.transform.position + new Vector3(-0.96f, 0f, 0f), 0.15f).SetEase(Ease.Linear);

                solTaraf = false;
            }
            // Eðer küp sað taraftaysa,
            else
            {
                // küpü sol tarafa taþýyan animasyonu baþlat.
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
            // Kazandýnýz tag'ine sahip objeyle temas gerçekleþti
            gameManager.WinGame(); // Kazandýnýz panelini aç
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Enemy tagýna sahip objeyle çarpýþma gerçekleþti

            // Oyuncunun canýný azalt
            PlayerTakeDmg(1);
            AudioSource.PlayClipAtPoint(DamageSound, transform.position);

            Debug.Log("Player Health: " + GameManager.Instance._playerHealth.Health);
            
        }
        if (collision.gameObject.CompareTag("Heal"))
        {
            // Çarpýþan objeyi yok et
            Destroy(collision.gameObject);
            PlayerHeal(1);
            Debug.Log("Player Health: " + GameManager.Instance._playerHealth.Health);
            AudioSource.PlayClipAtPoint(HealSound, transform.position);
        }


        
        //can degeri 0 yada altýysa 
        else if(GameManager.Instance._playerHealth.Health <= 0) 
        {
            gameManager.PlayerDied();
        }
        gameManager.CollectHP(); // can degeri
    }


    // Oyuncunun hasar almasýný saðlar
    private void PlayerTakeDmg(int dmg)
    {
        GameManager.Instance._playerHealth.DmgUnit(dmg);
        StartCoroutine(GosterVeGizle());
    }

    // Oyuncunun iyileþmesini saðlar
    private void PlayerHeal(int healing)
    {
        GameManager.Instance._playerHealth.HealUnit(healing);
    }

    IEnumerator GosterVeGizle()
    {
        hasarAlindi = true;
        hasarResmi.SetActive(true);

        yield return new WaitForSeconds(0.4f); // Resmin 1 saniye boyunca görünmesini saðlar

        hasarResmi.SetActive(false);
        hasarAlindi = false;
    }
}
