using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGecisKontrol : MonoBehaviour
{
    public float gecisSuresi = 3.0f; // Geçiþ süresi saniye cinsinden
    public string HedefSahneAdi;

    private void Start()
    {
        // Butona basýldýðýnda GeçisSahnesi metodunu çaðýr
        // Örnek olarak, butonun týklama olayýna baðlý olarak çaðýrabilirsiniz.
        // Örneðin, bir UI butonunun "OnClick" olayýna bu kodu baðlayabilirsiniz.
    }

    public void GeçisSahnesi()
    {
        // Gecis süresi kadar bekle ve sonra diðer sahneye geç
        Invoke("SahneGecisi", gecisSuresi);
    }

    private void SahneGecisi()
    {
        // Diðer sahneye geçiþ kodu burada
        SceneManager.LoadScene(HedefSahneAdi); // "HedefSahneAdi", geçmek istediðiniz sahnenin adý olmalý
    }
}
