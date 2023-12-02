using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    [Range(-10f, 10f)]
    public float scrollSpeed = 5f; // Arka plan kayma hýzý, -1 (ters yönde) ile 1 (ileri yönde) arasýnda bir deðer alýr.

    private float offset; // Arka planýn kayma miktarýný tutan deðiþken.
    private Material mat; // GameObject'in malzemesini tutan deðiþken.

    private void Start()
    {
        // Baþlangýçta malzemeyi al.
        mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        // Her güncelleme adýmýnda kayma miktarýný güncelle.
        offset += (Time.deltaTime * scrollSpeed) / 10f;

        // Malzeme üzerindeki "_MainTex" özelliðini güncelle, bu da arka planýn kaymasýný saðlar.
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
