using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGecisKontrol : MonoBehaviour
{
    public float gecisSuresi = 3.0f; // Ge�i� s�resi saniye cinsinden
    public string HedefSahneAdi;

    private void Start()
    {
        // Butona bas�ld���nda Ge�isSahnesi metodunu �a��r
        // �rnek olarak, butonun t�klama olay�na ba�l� olarak �a��rabilirsiniz.
        // �rne�in, bir UI butonunun "OnClick" olay�na bu kodu ba�layabilirsiniz.
    }

    public void Ge�isSahnesi()
    {
        // Gecis s�resi kadar bekle ve sonra di�er sahneye ge�
        Invoke("SahneGecisi", gecisSuresi);
    }

    private void SahneGecisi()
    {
        // Di�er sahneye ge�i� kodu burada
        SceneManager.LoadScene(HedefSahneAdi); // "HedefSahneAdi", ge�mek istedi�iniz sahnenin ad� olmal�
    }
}
