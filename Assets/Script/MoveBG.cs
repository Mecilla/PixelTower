using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    [Range(-10f, 10f)]
    public float scrollSpeed = 5f; // Arka plan kayma h�z�, -1 (ters y�nde) ile 1 (ileri y�nde) aras�nda bir de�er al�r.

    private float offset; // Arka plan�n kayma miktar�n� tutan de�i�ken.
    private Material mat; // GameObject'in malzemesini tutan de�i�ken.

    private void Start()
    {
        // Ba�lang��ta malzemeyi al.
        mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        // Her g�ncelleme ad�m�nda kayma miktar�n� g�ncelle.
        offset += (Time.deltaTime * scrollSpeed) / 10f;

        // Malzeme �zerindeki "_MainTex" �zelli�ini g�ncelle, bu da arka plan�n kaymas�n� sa�lar.
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
