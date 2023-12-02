using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    

    private void Start()
    {
        transform.DOMoveY(-10f, 3f).SetEase(Ease.Linear).OnComplete(DestroyEnemy); // Y ekseninde hareket ettir, 3 saniyede, do�rusal hareket, hareket tamamland���nda DestroyEnemy metodunu �a��r
    }

    private void Update()
    {
        // D��man�n hareket etmesi gerekmiyor, DOTween taraf�ndan y�netiliyor
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject); // D��man objesini yok et
    }
}
