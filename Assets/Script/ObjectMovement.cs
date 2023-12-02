using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoveUIButtons : MonoBehaviour
{
    public Button[] buttonsToMove; // Hareket ettirilecek buttonlar� buraya s�r�kleyin
    public float moveDistance = 100f; // Hareket mesafesi
    public float moveDuration = 2f; // Hareket s�resi
    public float shakeDuration = 0.5f; // Titreme s�resi
    public float shakeStrength = 20f; // Titreme �iddeti

    public Text[] TextName; // Hareket ettirilecek Text buraya s�r�kleyin
    public float moveDistanceY = 100f; // Hareket mesafesi
    public float moveDurationY = 2f; // Hareket s�resi

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

            // Hedef pozisyonu belirle: Sa�a veya sola do�ru kayd�r
            Vector3 targetPosition = buttonRectTransform.anchoredPosition + new Vector2(moveDistance * (i % 2 == 0 ? -1 : 1), 0f);

            // Buttonlar� hareket ettirme animasyonunu ba�lat
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

            // Hedef pozisyonu belirle: Yukar� veya a�a�� do�ru kayd�r
            Vector3 targetPosition = textRectTransform.anchoredPosition + new Vector2(0f, moveDistanceY * (i % 2 == 0 ? -1 : 1));

            // Metin nesnelerini hareket ettirme animasyonunu ba�lat
            textRectTransform.DOAnchorPos(targetPosition, moveDurationY)
                .SetEase(Ease.Linear);
        }
    }



    private void ShakeAndStop(RectTransform buttonRectTransform)
    {
        // Buttonu titretme i�lemini ba�lat
        StartCoroutine(ShakeButton(buttonRectTransform));
    }

    private IEnumerator ShakeButton(RectTransform buttonRectTransform)
    {
        Vector2 originalPosition = buttonRectTransform.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // Rastgele bir titreme ofseti hesapla ve button pozisyonunu g�ncelle
            Vector2 randomOffset = Random.insideUnitCircle * shakeStrength;
            buttonRectTransform.anchoredPosition = originalPosition + randomOffset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Titreme tamamland���nda button pozisyonunu eski haline getir
        buttonRectTransform.anchoredPosition = originalPosition;
    }
}
