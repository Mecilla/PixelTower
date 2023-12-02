using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    

    private void Start()
    {
        transform.DOMoveY(-10f, 3f).SetEase(Ease.Linear).OnComplete(DestroyEnemy); // Y ekseninde hareket ettir, 3 saniyede, doðrusal hareket, hareket tamamlandýðýnda DestroyEnemy metodunu çaðýr
    }

    private void Update()
    {
        // Düþmanýn hareket etmesi gerekmiyor, DOTween tarafýndan yönetiliyor
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject); // Düþman objesini yok et
    }
}
