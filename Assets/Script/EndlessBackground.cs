using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndlessBackground : MonoBehaviour
{
    public float moveDistance = 10.0f; // Hareket mesafesi
    public float moveSpeed = 1.0f;     // Hareket hýzý

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;

        MoveRight();
    }

    private void MoveRight()
    {
        transform.DOMoveX(startPosition.x + moveDistance, moveSpeed)
            .SetEase(Ease.Linear)
            .OnComplete(MoveLeft);
    }

    private void MoveLeft()
    {
        transform.DOMoveX(startPosition.x, moveSpeed)
            .SetEase(Ease.Linear)
            .OnComplete(MoveRight);
    }
}
