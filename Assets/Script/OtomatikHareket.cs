using UnityEngine;

public class OtomatikHareket : MonoBehaviour
{
    public float ilerlemeHizi = 5.0f; // Nesnenin ilerleme hýzý

    void Update()
    {
        // Nesneyi -y (aþaðý) yönde hareket ettirin.
        transform.Translate(Vector3.down * ilerlemeHizi * Time.deltaTime);
    }
}
