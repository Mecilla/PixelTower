using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoveUIButtons : MonoBehaviour
{
    public Button[] buttonsToMove; // Hareket ettirilecek buttonlarý buraya sürükleyin
    public float moveDistance = 100f; // Hareket mesafesi
    public float moveDuration = 2f; // Hareket süresi
    public float shakeDuration = 0.5f; // Titreme süresi
    public float shakeStrength = 20f; // Titreme þiddeti

    public Text[] TextName; // Hareket ettirilecek Text buraya sürükleyin
    public float moveDistanceY = 100f; // Hareket mesafesi
    public float moveDurationY = 2f; // Hareket süresi

    private void Start()
    {
        MoveButtonsSequentially();
        MoveTextSequentially();
    }

    private void MoveButtonsSequentially()
    {
        for (int i = 0; i < buttonsToMove.Length; i++)
        {
            Button button = buttonsToMove[i];
            RectTransform buttonRectTransform = button.GetComponent<RectTransform>();

            // Hedef pozisyonu belirle: Saða veya sola doðru kaydýr
            Vector3 targetPosition = buttonRectTransform.anchoredPosition + new Vector2(moveDistance * (i % 2 == 0 ? -1 : 1), 0f);

            // Buttonlarý hareket ettirme animasyonunu baþlat
            buttonRectTransform.DOAnchorPos(targetPosition, moveDuration)
                .SetEase(Ease.Linear)
                .OnComplete(() => ShakeAndStop(buttonRectTransform));
        }
    }

    private void MoveTextSequentially()
    {
        for (int i = 0; i < TextName.Length; i++)
        {
            Text text = TextName[i];
            RectTransform textRectTransform = text.GetComponent<RectTransform>();

            // Hedef pozisyonu belirle: Yukarý veya aþaðý doðru kaydýr
            Vector3 targetPosition = textRectTransform.anchoredPosition + new Vector2(0f, moveDistanceY * (i % 2 == 0 ? -1 : 1));

            // Metin nesnelerini hareket ettirme animasyonunu baþlat
            textRectTransform.DOAnchorPos(targetPosition, moveDurationY)
                .SetEase(Ease.Linear);
        }
    }



    private void ShakeAndStop(RectTransform buttonRectTransform)
    {
        // Buttonu titretme iþlemini baþlat
        StartCoroutine(ShakeButton(buttonRectTransform));
    }

    private IEnumerator ShakeButton(RectTransform buttonRectTransform)
    {
        Vector2 originalPosition = buttonRectTransform.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // Rastgele bir titreme ofseti hesapla ve button pozisyonunu güncelle
            Vector2 randomOffset = Random.insideUnitCircle * shakeStrength;
            buttonRectTransform.anchoredPosition = originalPosition + randomOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Titreme tamamlandýðýnda button pozisyonunu eski haline getir
        buttonRectTransform.anchoredPosition = originalPosition;
    }
}
