using UnityEngine;

public class OtomatikHareket : MonoBehaviour
{
    public float ilerlemeHizi = 5.0f; // Nesnenin ilerleme h�z�

    void Update()
    {
        // Nesneyi -y (a�a��) y�nde hareket ettirin.
        transform.Translate(Vector3.down * ilerlemeHizi * Time.deltaTime);
    }
}
