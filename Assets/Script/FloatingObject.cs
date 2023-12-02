using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatingObject : MonoBehaviour
{
    public float floatDistance = 5f; // Hareket edilecek mesafe
    public float floatDuration = 2f; // Toplam s�re

    public GameObject Menu;

    private Vector3 originalPosition; // Orijinal pozisyon

    private void Start()
    {
        originalPosition = transform.position; // Ba�lang�� pozisyonunu kaydet

        // Yava��a yukar� gidip a�a�� inme animasyonunu ba�lat
        StartFloating();
    }

    private void StartFloating()
    {
        // +y y�n�nde gidip gelme animasyonu
        transform.DOMoveY(originalPosition.y + floatDistance, floatDuration / 2)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // LoopType.Yoyo ile gidip gelme efekti sa�lan�r
    }

    public void StopFloating()
    {
        // Animasyonu durdur
        DOTween.Kill(transform);

        // 3 saniye sonra objeyi aktifle�tirir
        StartCoroutine(MenuActive(1.5f));

        // 3 saniye sonra objeyi pasifle�tir
        //StartCoroutine(DeactivateAndDestroyAfterDelay(3f));


    }
    private IEnumerator DeactivateAndDestroyAfterDelay(float delay)  
    {
        yield return new WaitForSeconds(delay); // Belirtilen s�re kadar bekle

        // Objeyi pasifle�tir
        gameObject.SetActive(false);

        // Objeyi 3 saniye sonra tamamen yok et
        Destroy(gameObject, 3f);
    }

    private IEnumerator MenuActive(float del)
    {
        yield return new WaitForSeconds(del); // Belirtilen s�re kadar bekle

        Menu.SetActive(true); //menu aktif

    }

}
