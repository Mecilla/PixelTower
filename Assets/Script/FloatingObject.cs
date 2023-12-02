using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingObject : MonoBehaviour
{
    public float floatDistance = 5f; // Hareket edilecek mesafe
    public float floatDuration = 2f; // Toplam süre

    public GameObject Menu;

    private Vector3 originalPosition; // Orijinal pozisyon

    private void Start()
    {
        originalPosition = transform.position; // Baþlangýç pozisyonunu kaydet

        // Yavaþça yukarý gidip aþaðý inme animasyonunu baþlat
        StartFloating();
    }

    private void StartFloating()
    {
        // +y yönünde gidip gelme animasyonu
        transform.DOMoveY(originalPosition.y + floatDistance, floatDuration / 2)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // LoopType.Yoyo ile gidip gelme efekti saðlanýr
    }

    public void StopFloating()
    {
        // Animasyonu durdur
        DOTween.Kill(transform);

        // 3 saniye sonra objeyi aktifleþtirir
        StartCoroutine(MenuActive(1.5f));

        // 3 saniye sonra objeyi pasifleþtir
        //StartCoroutine(DeactivateAndDestroyAfterDelay(3f));


    }
    private IEnumerator DeactivateAndDestroyAfterDelay(float delay)  
    {
        yield return new WaitForSeconds(delay); // Belirtilen süre kadar bekle

        // Objeyi pasifleþtir
        gameObject.SetActive(false);

        // Objeyi 3 saniye sonra tamamen yok et
        Destroy(gameObject, 3f);
    }

    private IEnumerator MenuActive(float del)
    {
        yield return new WaitForSeconds(del); // Belirtilen süre kadar bekle

        Menu.SetActive(true); //menu aktif

    }

}
